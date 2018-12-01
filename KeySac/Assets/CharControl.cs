using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour {

    float moveSpeed = 4f; //Movement speed; can adjust in editor
    float turnSpeed = 50f; //Turning/rotation speed; adjustable
    Vector3 forward, right; //Vectors for relative fwd and right movement

	// Use this for initialization
	void Start () {
        forward = Camera.main.transform.forward; //forward = Camera's fwd vector
        forward.y = 0; //Set y to 0 as no need for y movement
        forward = Vector3.Normalize(forward); //set length of vector =< 1.0
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward; // set r-facing vector to face r relative to camera's fwd vector
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey) //Only execute if a key is being pressed
        {
            Move();
        }
    }

    void Move() {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey")); //Direction vector based on keyboard input

        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement); //New vector for where facing

        transform.forward = heading; //Set forward direction to direction currently moving in
        transform.position += rightMovement; //Move transform's position right/left
        transform.position += upMovement; //Move transform's position up/down

        //TODO: Rotation controls (mapped to Q & E; currently broke)
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }
}
