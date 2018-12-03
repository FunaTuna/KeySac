using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LftButton : MonoBehaviour {
	StateMachine gameManager;
	public int SacChoiceState;
	private bool[] internalKeys;
	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<StateMachine> ();
		internalKeys = gameManager.getKeys();
		int count = 0;
		for (int i= (internalKeys.Length-1); i>0;i=i-1){
			if ( internalKeys[i]== true){
				count++;
			}
		} // counts the number of Keys you can use.
		count++;
		int transitionalChoice = (int)Mathf.Floor(Random.Range(0,((float)count)-0.01f));
		//chooses one of those keys
		if (count >0){
			for(int i=0;i<=internalKeys.Length-1;i++){
				if (internalKeys[i] == true){
					count = count-1;
					if (count== transitionalChoice){
						SacChoiceState = i;
						break;
					}
				}
			}//looks up what that choice is and assigns it to a number the rest of the code understands.
	}
		string[] Keys = {"Turn Left","Move forwards","Turn Right","Move Left","Reverse","Move Right","Fire Your primary weapon"};
		string corrispondingKey = Keys[SacChoiceState];
		this.GetComponentInChildren<Text>().text = ("Keep the Capacity to "+ corrispondingKey + "?");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnClick(){
		
		gameManager.onTradeFinish();
	}
}
