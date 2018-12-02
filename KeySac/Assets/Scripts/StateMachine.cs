using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateMachine : MonoBehaviour {
	public static StateMachine instance = null;
	string currentState;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (this);
		currentState = "level1";
	}
	public void OnRestart(){
		currentState = "level1";
		SceneManager.LoadScene ("SampleScene");
	}
	public void OnDeath(){
		currentState = "GameOver";
		SceneManager.LoadScene ("Game Over");
	}
}
