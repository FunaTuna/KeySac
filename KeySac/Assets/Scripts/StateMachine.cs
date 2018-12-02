using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StateMachine : MonoBehaviour {
	public static StateMachine instance = null;
	string currentState;
	public static bool[] Keys;
	void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (this);
		currentState = "startscreen";
		//Keys = new bool[] {true,true,true,true,true,true,true};
		 //Q //W //E //A //S //D//Space

	}
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
