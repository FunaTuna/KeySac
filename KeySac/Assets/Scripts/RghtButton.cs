using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RghtButton : MonoBehaviour {
	StateMachine gameManager;
	public int BoonChoiceState;
	private bool[] internalBoons;
	public GameObject LeftButton;
	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<StateMachine> ();
		internalBoons = gameManager.getBoons();
		int count = 0;
		for (int i= internalBoons.Length; i>0;i=i-1){
			if (internalBoons[i]== false){
				count++;
			}
		} // counts the number of internalBoons you can use.
		int transitionalChoice = (int)Mathf.Floor(Random.Range(0,count-1));
		//chooses one of those internalBoons
		if (count >0){
			for(int i=0;i<=internalBoons.Length;i=i-1){
				if (internalBoons[i] == false){
					count = count-1;
					if (count== 0){
						BoonChoiceState = i;
						break;
					}
				}
			}
		}
		string[] textualBoons = {"More damage","More HP","Faster Movement"};
		string corrispondingBoon = textualBoons[BoonChoiceState];
		this.GetComponentInChildren<Text>().text = ("Or be Granted "+ corrispondingBoon + "?");
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void onClick(){
		print ("Right Clicked");
		string[] keyToString = {"q","w","e","a","s","d","space"};
		string[] boonToString ={"damage","hp","speed"};
		gameManager.boonAquire(boonToString[BoonChoiceState]);
		gameManager.sacrifice(keyToString[LeftButton.GetComponent<LftButton>.SacChoiceState]);
		gameManager.onTradeFinish();

		}
	}
