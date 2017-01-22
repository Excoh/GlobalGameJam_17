using UnityEngine;
using System.Collections;

public class SinMovement : MonoBehaviour {

    public float CurveSpeed = 5;
    public float MoveSpeed = 1;
    public float Amplitude = 1;

    float fTime = 0;
    Vector3 vLastPos = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        vLastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        vLastPos = transform.position;

        fTime += Time.deltaTime * CurveSpeed;

        Vector3 vSin = new Vector3(0, Mathf.Sin(fTime) * Amplitude, 0);
        Vector3 vLin = new Vector3(MoveSpeed, 0, 0);

        transform.position += vSin * Time.deltaTime;

        Debug.DrawLine(vLastPos, transform.position, Color.green, 100);
    }
}
