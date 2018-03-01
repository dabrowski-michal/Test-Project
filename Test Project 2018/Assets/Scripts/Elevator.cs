using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour{

    [SerializeField] private GameObject movingPlatform;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCanvas;

    [SerializeField] private UIController uiController;
    [SerializeField] private AudioSource elevatorMusic;
    [SerializeField] private AudioSource elevatorBell;
    [SerializeField] private float platformSpeed;
    [SerializeField] private Transform[] floors;

    private bool moving = false;
    private bool playerOnThePlatform = false;
    private Transform destination;
    private int currentFloor = 0;


    private void Start()
    {
        destination = floors[currentFloor];
        uiController = mainCanvas.GetComponent<UIController>();
    }

    //moves the elevator ecery frame using Time.deltaTime
    private void Update()
    {
        float step = platformSpeed * Time.deltaTime;
        movingPlatform.transform.position = Vector3.MoveTowards(movingPlatform.transform.position, destination.position, step);

        if ((!moving) && (playerOnThePlatform))
        {
            ChooseDirection();
        }
    }

    //allows player decide which direction elevator should go
    private void ChooseDirection()
    {
        if (Input.GetMouseButtonDown(0) && (currentFloor>0))
        {
            currentFloor--;
            StartCoroutine(MoveElevator());
        }
        else if (Input.GetMouseButtonDown(1) && (currentFloor < floors.Length-1))
        {
            currentFloor++;
            StartCoroutine(MoveElevator());
        }
    }

    //displays instructions and changes player parent 
    private void OnTriggerEnter()
    {
        uiController.DisplayElevatorPanel();

        player.transform.parent = movingPlatform.transform;
        playerOnThePlatform = true;
    }

    //closes instructions and changes player parent
    private void OnTriggerExit()
    {
        player.transform.parent = null;
        playerOnThePlatform = false;
        uiController.CloseElevatorPanel();
    }

    //teleports the elevator to the player floor
    public void CallTheElevator(int playerFloor)
    {
        //should not teleport elevator while it moves with player inside
        if (!moving) 
        {
            currentFloor = playerFloor;
            destination = floors[currentFloor];
            movingPlatform.transform.position = destination.position;
        }
    }

    //elevator music and chill effects during ride
    private IEnumerator MoveElevator()
    {
        destination = floors[currentFloor];
        elevatorMusic.Play();
        uiController.CloseElevatorPanel();
        moving = true;
        yield return new WaitForSeconds(4);
        elevatorMusic.Stop();
        elevatorBell.Play();
        uiController.DisplayElevatorPanel();
        moving = false;
    }


}
