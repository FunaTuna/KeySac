using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RghtButton : MonoBehaviour {
	StateMachine gameManager;
	public int BoonChoiceState;
	private bool[] internalBoons;
	public GameObject LeftButton;
	private LftButton lfscript;
	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<StateMachine> ();
		internalBoons = gameManager.getBoons();
		lfscript=LeftButton.GetComponent<LftButton> ();
		int count = 0;
		for (int i= internalBoons.Length-1; i>-1;i=i-1){
			if (internalBoons[i]== false){
				count++;
			}
		} // counts the number of internalBoons you can use.
		int transitionalChoice = (int)Mathf.Floor(Random.Range(0,((float)count)-0.01f));
		//chooses one of those internalBoons
		if (count >0){
			for(int i=0;i<=internalBoons.Length-1;i++){
				if (internalBoons[i] == false){
					count = count-1;
					if (count== transitionalChoice){
						BoonChoiceState = i;
						break;
					}
				}
			}
		}
		string[] textualBoons = {"More damage","More HP","Faster Movement","Faster TurnSpeed"};
		string corrispondingBoon = textualBoons[BoonChoiceState];
		this.GetComponentInChildren<Text>().text = ("Or be Granted "+ corrispondingBoon + "?");
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void onClick(){
		print ("Right Clicked");
		string[] keyToString = {"q","w","e","a","s","d","space"};
		string[] boonToString ={"damage","hp","speed","turn"};
		gameManager.boonAquire(boonToString[BoonChoiceState]);
		gameManager.sacrifice(keyToString[lfscript.SacChoiceState]);
		gameManager.onTradeFinish();

		}
	}
