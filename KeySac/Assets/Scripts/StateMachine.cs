using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StateMachine : MonoBehaviour {
	public static StateMachine instance = null;
	string currentState;
	public static bool[] Keys;
	private int level;

	private int Health;
	private int Damage;
	private float speed;
	void Awake(){
		Health = 1;
		Damage = 1;
		speed = 4f;
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (this);
		currentState = "startscreen";
		level = 1;
		//Keys = new bool[] {true,true,true,true,true,true,true};
		 //Q //W //E //A //S //D//Space

	}
	//change player state
	public void setHealth(int HP){
		Health = HP;
	}
	public void setDamage(int dam){
		Damage = dam;
	}
	public void setSpeed(float spe){
		speed = spe;
	}
	//Change the player stats
	public int getHealth(){return Health;}
	public int getDamage(){return Damage;}
	public float getSpeed(){return speed;}

	public void OnRestart(){
		currentState = "level1";
		SceneManager.LoadScene ("SampleScene");
		Keys = new bool[] {true,true,true,true,true,true,true};
	}
	public void OnDeath(){
		currentState = "GameOver";
		SceneManager.LoadScene ("Game Over");
	}
	public void onStart(){
		currentState = "level1";
		SceneManager.LoadScene ("SampleScene");
		Keys = new bool[] {true,true,true,true,true,true,true};
	}
	public void onLevelFinish(){
		currentState = "trader";
		level += 1;
		SceneManager.LoadScene ("Trading");
	}
	public void onTradeFinish(){
		currentState = "level" + level;
		SceneManager.LoadScene ("level" + level);
	}
	public void trade(string key){
		switch (key) {
		case "q":
			Keys [0] = false;
			break;
		case "w":
			Keys [1] = false;
			break;
		case "e":
			Keys [2] = false;
			break;
		case "a":
			Keys [3] = false;
			break;
		case "s":
			Keys [4] = false;
			break;
		case "d":
			Keys [5] = false;
			break;
		case "space":
			Keys [6] = false;
			break;
		}
	}
	public bool[] getKeys(){
		return Keys;
	}
}
