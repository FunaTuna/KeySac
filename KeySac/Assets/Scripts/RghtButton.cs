using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RghtButton : MonoBehaviour {
	StateMachine gameManager;
	public int BoonChoiceState;
	public static int[] BoonPrior; 
	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<StateMachine> ();
		BoonChoiceState = (int)Mathf.Floor(Random.Range(0,2));
		string[] Boons = {"More damage","More HP","Faster Movement"};
		string corrispondingBoon = Boons[BoonChoiceState];
		this.GetComponentInChildren<Text>().text = ("Or be Granted "+ corrispondingBoon + "?");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void onClick(){
		print ("Right Clicked");
		string[] keyToString = {"q","w","e","a","s","d","space"};
		string[] boonToString ={"damage","hp","speed"}:
		gameManager.boonAquire(boonToString[BoonChoiceState]);
		gameManager.sacrifice(keyToString[this.SacChoiceState]);
		gameManager.onTradeFinish();
	}
}
