using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LftButton : MonoBehaviour {
	public int SacChoiceState;
	// Use this for initialization
	void Start () {
		SacChoiceState = (int)Mathf.Floor(Random.Range(0,6));
		string[] Keys = {"Turn Left","Move forwards","Turn Right","Move Left","Reverse","Move Right","Fire Your primary weapon"};
		string corrispondingKey = Keys[SacChoiceState];
		this.GetComponentInChildren<Text>().text = ("Keep the Capacity to "+ corrispondingKey + "?");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
