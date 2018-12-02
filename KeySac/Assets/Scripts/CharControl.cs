using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    Animator animator;
    StateMachine gameManager;
    float moveSpeed = 4f; //Movement speed
    //float maxSpeed = 4f; //Maximum speed of player
    float turnSpeed = 50f; //Turning/rotation speed; adjustable

    //float acceleration = 2f;
    //float deceleration = 2f;
    public int health;
    public int damage;
    public Rigidbody rb;

    private GameObject stateMachine;
    public GameObject bulletPrefab;

    public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<StateMachine> ();
		animator = GetComponent<Animator> ();
        rb = GetComponent<Rigidbody>();
		setStats ();
		//here for testing
		//gameManager.trade("q");
    }
	
	void Update () {
		if (health <= 0) {
			gameManager.OnDeath ();
			//Destroy (this.gameObject);

        if (Input.anyKey) //Only execute if a key is being pressed
        {
            Move();
        }
    }

    void Move()
    {
        bool[] Keys = gameManager.getKeys();
        if (Input.GetKey(KeyCode.W) && Keys[1])
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
            //rb.velocity  = transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && Keys[4])
        {
            transform.position += -transform.forward * Time.deltaTime * moveSpeed;
            //rb.AddRelativeForce(-transform.forward * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) && Keys[3])
        {
            transform.position += -transform.right * Time.deltaTime * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D) && Keys[5])
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.Q) && Keys[0])
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E) && Keys[2])
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Keys[6])
        {
            StartCoroutine("Fire");
        }
    }

    IEnumerator Fire()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) 
        {
            //Start firing animation
            animator.SetTrigger("Fire");

            //Wait for point in animation to fire bullet
            yield return new WaitForSeconds(0.9f);

            //Create bullet
            var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            //Add velocity to bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 60;
            //Bullet trail add
            bullet.AddComponent<TrailRenderer>();
        }

    }
    
	//Sets bullet damage
	void SetDamage(){
		BulletScript.SetDamage (damage);
	}

	//Updates stats from StateMachine
	public void setStats(){
		health = gameManager.getHealth ();
		damage = gameManager.getDamage ();
		SetDamage ();
		moveSpeed = gameManager.getSpeed ();

	}

	private void OnTriggerEnter(Collider other){
		//Controls collision with enemy
		if (other.tag == "Enemy") {
			health -= 1;
			Destroy(other.gameObject);
		}
		if (other.tag == "Finish") {
			gameManager.onLevelFinish ();
		}
	}
}
