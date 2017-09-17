using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garage : Building {
	


	// Use this for initialization
	void Start () {
		this.Width = 3;
		this.Height = 2; 
		this.Cost = 40;
		this.CarryingCap = 10;
		this.CostMultiply = 1.3;
		this.CostUpgrade = 1.25;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override Sprite getLevel0Sprite() {
		return Resources.Load ("Garage 1", typeof(Sprite)) as Sprite;
	}

	void OnMouseDown() {
		dialogHelper ();
	}
}
