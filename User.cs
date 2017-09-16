using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {

	private bool iP; //is the player playing
	private int m; //money

	public bool IsPlaying { //Cost of the building
		get { return iP;}
		set { iP = value;}
	}

	public int money {
		get{ return m;}
		set{ m = value;}
	}

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
