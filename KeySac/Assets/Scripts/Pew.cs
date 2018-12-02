using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pew : MonoBehaviour {

    public AudioClip pewClip;
    public AudioSource pewSource;

	// Use this for initialization
	void Start () {
        pewSource.clip = pewClip;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
