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
		int count = 0;
		for (int i= gameManager.Boons.Length; i>0;i=i-1){
			if (gameManager.Boons[i]== false){
				count++;
			}
		} // counts the number of Boons you can use.
		transitionalChoice = (int)Mathf.Floor(Random.Range(0,count-1));
		//chooses one of those Boons
		if (count >0){
			for(int i=0;i<=gameManager.Boons.Length;i=i-1){
				if (gameManger.Boons[i] == false){
					count = count-1;
					if (count== 0){
						BoonChoiceState = i;
						break;
					}
				}
			}
		}
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
		string[] boonToString ={"damage","hp","speed"};
		gameManager.boonAquire(boonToString[BoonChoiceState]);
		gameManager.sacrifice(keyToString[this.SacChoiceState]);
		gameManager.onTradeFinish();

		}
	}
