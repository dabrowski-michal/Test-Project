using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour {

    [SerializeField] private int playerFloor;

    [SerializeField] private GameObject elevator;
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;

    [SerializeField] private Transform leftDoorClosed;
    [SerializeField] private Transform rightDoorClosed;
    [SerializeField] private Transform leftDoorOpen;
    [SerializeField] private Transform rightDoorOpen;

    [SerializeField] private float doorSpeed;
    private Transform leftDestination;
    private Transform rightDestination;

    private Elevator elevatorScript;

    //doors should be closed by default
    void Start()
    {
        elevatorScript = elevator.GetComponent<Elevator>();
        leftDestination = leftDoorClosed;
        rightDestination = rightDoorClosed;
    }

    //interpolates door position every frame using Time.deltaTime
    void Update()
    {
        leftDoor.transform.position = Vector3.Lerp(leftDoor.transform.position, leftDestination.position, Time.deltaTime * doorSpeed);
        rightDoor.transform.position = Vector3.Lerp(rightDoor.transform.position, rightDestination.position, Time.deltaTime * doorSpeed);
    }

    //opens the door and teleports the elevator to the player
    void OnTriggerEnter()
    {
        elevatorScript.CallTheElevator(playerFloor);
        leftDestination = leftDoorOpen;
        rightDestination = rightDoorOpen;
    }

    //closes the door
    void OnTriggerExit()
    {
        leftDestination = leftDoorClosed;
        rightDestination = rightDoorClosed;
    }
}
