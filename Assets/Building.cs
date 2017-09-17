using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
	private double c; //cost
	private int h; //height
	private int w; //width
	private double cap; //carrying capacity
	private double cM; //ratio by which the upgrade cost increases
	private double capU; //ratio by which the capacity increases with an upgrade
	private double cU; //upgrade cost

	//private int maxLevel = 2;
	//private int level = 0;


	//public Sprite spriteBuilding;
	public int level = 0;
	public List<Sprite> sprites;

	public double Cost //Cost of the building
	{
		get { return c; }
		set { c = value; }
	}

	public int Height  // height of the building
	{
		get { return h; }
		set { h = value; }
	}

	public int Width   // Width of the building
	{
		get { return w; }
		set { w = value; }
	}

	public double CarryingCap
	{
		get { return cap; }
		set { cap = value; }
	}

	public double CostMultiply {
		get { return cM; }
		set { cM = value; }
	}

	public double CostUpgrade
	{
		get { return cU; }
		set { cU = value; }
	}

	public void changeCost(){
		cU *= CostMultiply;
	}

	// call this to level up the building
	public void upgrade() {
		// TODO check player money
		cap *= capU;
		if (level < sprites.Count - 1)
			level++;
		GetComponent<SpriteRenderer> ().sprite = sprites [level];
	}



	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
