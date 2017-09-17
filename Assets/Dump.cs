using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dump : Building {

	// Use this for initialization
	void Start () {
		this.Width = 3;
		this.Height = 3;
		this.Cost = 50;
		this.CarryingCap = 10;
		this.CostMultiply = 1.25;
		this.CostUpgrade = 1.25;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		dialogHelper ();
	}

	public override Sprite getLevel0Sprite() {
		return Resources.Load ("garbagedump", typeof(Sprite)) as Sprite;
	}
}
