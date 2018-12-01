using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public float smoothSpeed = 5f;
    Vector3 offset;

    // Use this for initialization
    void Start () {

        offset = transform.position - target.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 smoothMove = Vector3.Lerp(target.transform.position, target.transform.position + offset, smoothSpeed);

        transform.LookAt(target.transform);
        //transform.position = target.transform.position + offset;
        transform.position = smoothMove;
    }
}
