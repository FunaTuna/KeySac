﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
	public int health;
    public float speed;
    Transform player;
    NavMeshAgent nav;

	// Use this for initialization
	void Start () {

        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        speed = 4f;

		if (health <= 0) {
			Destroy (gameObject);
		}
    }

    //Take damage function
	public void damage(int dam){
		health -= dam;
	}

    //Move towards player's last known position if player intercepts field of vision trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            nav.GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
        }
    }

    //TODO: Patrols forwards in straight line (unless player is seen); turn around on collision with a wall
    //(Reuse this script for other enemy type)
    //void Move() {
    //    transform.position += transform.forward * speed * Time.deltaTime;
    //}

    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.collider.gameObject.tag == "Walls")
    //    {
    //        transform.rotation = Quaternion.AngleAxis(180, transform.up) * transform.rotation;
    //    }
    //}

    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.collider.gameObject.tag == "Walls")
    //    {
    //        transform.rotation = Quaternion.AngleAxis(180, transform.up) * transform.rotation;
    //    }
    //}
}
