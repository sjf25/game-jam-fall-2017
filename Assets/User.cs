using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{

    private bool inPlay = true; //is the player playing
    private float money; //money
	public List<Building> ownedProps;
	private float totalGarbage = 0;

    public bool IsPlaying
    { //Cost of the building
        get { return inPlay; }
        set { inPlay = value; }
    }

    public float Money
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
		int dumpCount = 0;
		int loungeCount = 0;
		for (int i = 0; i < grid.Buildings.Count; i++) {
			if (grid.Buildings [i] is Garage)
				garageCount++;
			else if (grid.Buildings [i] is Dump)
				dumpCount++;
			else if (grid.Buildings [i] is Lounge)
				loungeCount++;
		}
		// need one lounge per 3 garages
		dumpCount = Mathf.Min (dumpCount, loungeCount * 3);
		float dumpCapacity = 30*dumpCount;
		float newGarbageCount = garageCount * Time.deltaTime;
		float acceptedGarbage;
		if (newGarbageCount + totalGarbage >= dumpCapacity) {
			acceptedGarbage = dumpCapacity - totalGarbage;
			totalGarbage = dumpCapacity;
		} else {
			acceptedGarbage = newGarbageCount;
			totalGarbage += newGarbageCount;
		}
		money += acceptedGarbage;
		Debug.Log (money);
        // TODO: check end
    }
}
