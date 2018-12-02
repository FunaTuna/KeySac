using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	private static int BulletDamage;
	// Use this for initialization
	void Start () {
		BulletDamage = 1;
	}
	
	// Update is called once per frame
	void Update () {
	}
	public static void SetDamage(int amount){
		BulletDamage = amount;
	}

    //Destroy bullet on collision with enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
			EnemyMovement enemy = other.GetComponent<EnemyMovement> ();
			enemy.damage (BulletDamage);
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
