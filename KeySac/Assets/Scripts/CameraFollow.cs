using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public float smoothSpeed = 5f;
    Vector3 offset;

    // Use this for initialization
    void Start () {

        offset = transform.position - target.transform.position; //Distance between camera and player/target
    }
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 offsetPosition = target.transform.position + offset;
        Vector3 smoothMove = Vector3.Lerp(target.transform.position, offsetPosition, smoothSpeed); //Smoothed vector movement between camera and target/player

        transform.LookAt(target.transform); //Look at the player/target object

        transform.position = smoothMove; //Position camera to smoothMove vector
    }
}
