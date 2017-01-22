using UnityEngine;
using System.Collections;

public class LookAtMove : MonoBehaviour {

    public float moveSpeed = 1;
    public GameObject target;
    Vector3 targetPosition;

	// Use this for initialization
	void Start () {
        LookAt();
	}
	
	// Update is called once per frame
	void Update () {
        LookAt();
        Move();
	}

    void Move()
    {
        transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
    }
    
    void LookAt()
    {
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
        this.transform.LookAt(targetPosition);
    }
}
