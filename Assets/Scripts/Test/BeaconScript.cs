using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;

public class BeaconScript : MonoBehaviour {

    public bool isFacing;
    public bool isMoving;
	public bool debug;
	private GazeAware _gazeAwareComponent;

        // Use this for initialization
	void Start () {
        isFacing = false;
        isMoving = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
		

    public bool getIsFacing() 
    {
        return isFacing;
    }

    public bool getIsMoving()
    {
        return isMoving;
    }

    public void setisFacingToTrue()
    {
        isFacing = true;
    }

    public void setisFacingToFalse()
    {
        isFacing = false;
    }

    public void setisMovingTrue()
    {
        isMoving = true;
    }

    public void setisMovingToFalse()
    {
        isMoving = false;
    }


}
