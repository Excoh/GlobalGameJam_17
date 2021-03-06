using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour {

    public float Speed;
    public float rotationSpeed;
    public int numOfWaypoints;
    public int curWaypoint;
    public Vector3 target;
    public Vector3 moveDirection;
    public Vector3 Velocity;
    public BeaconScript checker;
    public GameObject[] Beacons;

    // Use this for initialization
    void Start()
    {
        curWaypoint = 0;
        checker = FindObjectOfType<BeaconScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (checker.getIsMoving() == true && curWaypoint < numOfWaypoints) 
        {
            target = Beacons[curWaypoint].transform.position;
            
            moveDirection = target - transform.position;
             if (moveDirection.magnitude < 1)
                {
                    checker.setisMovingToFalse();
                    curWaypoint++;
                    Velocity = Vector3.zero;
                }
                else 
                {
                    Velocity = GetComponent<Rigidbody>().velocity;
                    Velocity = moveDirection.normalized * Speed;
                }
			GetComponent<Rigidbody> ().velocity = Velocity;
        }
			   
    }   

}