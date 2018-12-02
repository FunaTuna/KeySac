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

    //Destroy bullet on collision with enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
			Destroy (other.gameObject);
            Destroy(gameObject);
            Debug.Log(other.name);
        }
		if (other.gameObject.tag == "Walls")
		{
			Destroy(gameObject);
			Debug.Log(other.name);
		}
    }
}
