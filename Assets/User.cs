using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{

    private static bool inPlay = true; //is the player playing
    private static float money; //money
	public static List<Building> ownedProps;
	private totalGarbage = 0;

    public static bool IsPlaying
    { //Cost of the building
        get { return inPlay; }
        set { inPlay = value; }
    }

    public static float Money
    {
        get { return money; }
        set { money = value; }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame

    
    void Update()
    {
		GameObject gridObj = GameObject.FindGameObjectWithTag ("grid");
		Grid grid = gridObj.GetComponent<Grid> ();
		int garageCount = 0;
		int dumpCount;
		for (int i = 0; i < grid.Builings.Count; i++) {
			if (grid.Builings [i] is Garage)
				garageCount++;
		}
		money += garageCount * Time.deltaTime;
		Debug.Log (money);
        // TODO: check end
    }
}
