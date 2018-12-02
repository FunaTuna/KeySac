using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StateMachine : MonoBehaviour {
	public static StateMachine instance = null;
	string currentState;
	public static bool[] Keys = new bool[] {true,true,true,true,true,true,true};
	//Q //W //E //A //S //D//Space
	public static bool[] Boons = new bool[] {false,false,false};
	private static int level = 1;

	private static int Health;
	private static int Damage;
	private static float speed;
	void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (this);
		currentState = "startscreen";

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
		Health = 1;
		Damage = 1;
		speed = 4f;
		Keys = new bool[] {true,true,true,true,true,true,true};
		Boons = new bool[] {false,false,false};
	}
	public void OnDeath(){
		currentState = "GameOver";
		SceneManager.LoadScene ("Game Over");
	}
	public void onStart(){
		currentState = "level1";
		Health = 1;
		Damage = 1;
		speed = 4f;
		Keys = new bool[] {true,true,true,true,true,true,true};
		Boons = new bool[] {false,false,false};
		SceneManager.LoadScene ("SampleScene");
	}
	public void onLevelFinish(){
		currentState = "trader";
		level += 1;
		SceneManager.LoadScene ("Trading");
	}
	public void onTradeFinish(){
		currentState = "level" + level;
		print (currentState);
		SceneManager.LoadScene ("level" + level);
	}
	public void boonAquire(string boon){
		switch(boon){
		case "damage":
			Boons[0]= true;
			setDamage(4);
			break
		case "hp":
			Boons[1] = true;
			setHealth(3);
			break;
		case "speed":
			Boons[2] = true;
			setSpeed(6f);
			break;
	}}
	public void sacrifice(string key){
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
