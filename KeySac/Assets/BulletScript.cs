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
    void DestroyOnCollision (Collision other) {
        if (other.gameObject.CompareTag("Walls") || other.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
    }
}
