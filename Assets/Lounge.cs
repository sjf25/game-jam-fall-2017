using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Lounge : Building {

	// Use this for initialization
	void Start () {
		//level0Res = "breakroom 0";
		Debug.Log ("Lounge\n");
		this.Width = 2;
		this.Height = 2;
		//this.Cost = 100;
		this.Cost = 30;
		this.CarryingCap = 10; 
		this.CostMultiply = 1.4;
		this.CostUpgrade = 1.25;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override Sprite getLevel0Sprite() {
		return Resources.Load ("breakroom 0", typeof(Sprite)) as Sprite;
	}

	void OnMouseDown() {
		dialogHelper ();
	}
}
