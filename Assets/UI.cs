using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UI : MonoBehaviour {
	private Rect winRect = new Rect ((Screen.width - 500) / 2, (Screen.height - 100) / 2, 500, 100);
	public bool result = false;
	public Building b;
	public bool upgradeShow = false;

	void OnGUI() {
		if (upgradeShow) {
			//isAnotherOpen = true;
			GUI.Window (0, winRect, upgradeDialog, "Upgrade");
		}
	}

	// TODO: fix multiple dialogs from being able to open
	public void upgradeDialog(int blah) {
		GUI.Label (new Rect (5, 20, winRect.width, 20), "Do you want to upgrade? It will cost: "+b.Cost); 
		if (GUI.Button (new Rect (5, 50, winRect.width / 2, 20), "Yes")) {
			result = true;
			upgradeShow = false;
		}
		if (GUI.Button (new Rect (5+winRect.width/2, 50, winRect.width/2, 20), "No")) {
			result = false;
			upgradeShow = false;
		}
	}
}
