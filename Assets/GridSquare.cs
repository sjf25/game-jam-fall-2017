using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquare : MonoBehaviour {
	private bool occupied = false;
	public Vector2 gridLoc;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public bool Occupied {
		get { return occupied; }
		set { occupied = value; }
	}
}
