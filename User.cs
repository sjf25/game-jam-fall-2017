using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{

    private bool iP; //is the player playing
    private int m; //money
    private int tR; // rate that trash is collected

    public bool IsPlaying
    { //Cost of the building
        get { return iP; }
        set { iP = value; }
    }

    public int money
    {
        get { return m; }
        set { m = value; }
    }

    public int trashRate
    {
        get { return m; }
        set { tR = value; }
    }

    public void buyLounge()
    {
        m -= buyLounge.Cost;
    }

    int checkLoss = 0;

    public void checkEnd()
    {
         if(m < 0)
        {
            checkLoss++;
            if (checkLoss >= 180)
            {
                //Figure out way to end game
            }
        }

        else
        {
            checkLoss = 0;
        }
    }

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame

    
    void Update()
    {
        checkEnd();
          
       


    }
}
