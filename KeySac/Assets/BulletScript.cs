using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Destroy on collision with wall or enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Walls" || other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log(other.name);
        }
    }
}
