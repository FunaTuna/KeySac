using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
	public int health;
    Transform player;
    NavMeshAgent nav;

	// Use this for initialization
	void Start () {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        //nav.SetDestination(player.position);
		if (health <= 0) {
			Destroy (gameObject);
		}
    }
	public void damage(int dam){
		health -= dam;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            nav.GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
        }
    }
}
