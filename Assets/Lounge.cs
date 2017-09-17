using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Lounge : Building {
	

	// Use this for initialization
	void Start () {
		this.Width = 2;
		this.Height = 2;
		this.Cost = 100;
		this.CarryingCap = 10; 
		this.CostMultiply = 1.4;
		this.CostUpgrade = 1.25;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		if (level != sprites.Count - 1) {
			Debug.Log ("CLICKED\n");
			GameObject temp = new GameObject ();
			temp.AddComponent<UI> ();
			temp.GetComponent<UI> ().b = this;
			temp.GetComponent<UI> ().upgradeShow = true;
			//new UI().upgradeMessageBox (this);
		}
		//Debug.Log ("CLICKED\n");
	}
}
