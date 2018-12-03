using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartolScript : MonoBehaviour {
	private float speed;
	private int health;
	private int direction;
	public int distance;
	private float startpos;
	// Use this for initialization
	void Start () {
		speed = 4f;
		health = 3;
		direction = 1;
		startpos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if ((transform.position.x > (startpos + distance)) || (transform.position.x < (startpos - distance))) {
			direction = direction * -1;
		}

		Move();

		if (health <= 0) {
			Destroy (gameObject);
		}
	}
	//Movement - patrols forwardsin straight line (unless player is seen)
	void Move() {
		Vector3 V = new Vector3(1,0,0);
		transform.position += direction * V *speed * Time.deltaTime;
	}
	public void damage (int dam){
		health -= dam;
	}
}
