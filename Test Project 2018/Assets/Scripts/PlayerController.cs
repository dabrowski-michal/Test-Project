using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private Camera mainCamera;

    private Rigidbody playerRigidbody;
    private Collider playerCollider;
    private Vector3 moveDirection;

    [SerializeField] private float speed = 1;
    [SerializeField] private float jumpForce = 1;
    [SerializeField] private bool usingPowerUp;

    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private UIController uiController;

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    public bool UsingPowerUp
    {
        get
        {
            return usingPowerUp;
        }
        set
        {
            usingPowerUp = value;
        }
    }

    public float JumpForce
    {
        get
        {
            return jumpForce;
        }
        set
        {
            jumpForce = value;
        }
    }

    private void Start () {
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        uiController = mainCanvas.GetComponent<UIController>();
    }

    //moving player rigidbody in FixedUpdate
    private void FixedUpdate () {

        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        //freeze transform on the Y axis
        forward.y = 0f;
        right.y = 0f;

        //normalize vectors
        forward.Normalize();
        right.Normalize();

        //move the rigidbody
        moveDirection = forward * verticalAxis + right * horizontalAxis;
        playerRigidbody.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
    }

    //check if player is grounded
    public bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, playerCollider.bounds.extents.y + 0.1f);
    }

    //change ui based on player movement in Update
    private void Update()
    {
        if (!Grounded())
        {
            uiController.ChangeMainText(UIController.States.Jumping);
        }
        else if (moveDirection != Vector3.zero)
        {
            uiController.ChangeMainText(UIController.States.Walking);
        }
        else
        {
            uiController.ChangeMainText(UIController.States.Standing);
        }
    }
}
