using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour {

    public int Exp = 0;
    public string level = "1";
    public int nextLevel = 1;
    public int Increment = 10;
    public GameObject levelText;
    public float barWidth;
    public float barHeight;

    GameObject expBar;
    // Eventually.. public RectTransform gainedExp
    //Array used as expRequired[leveldesired]
    public int[] expRequired = {0,0,100,250,450,700,1000,1350,1700,2150,2650 };
    public float clicksNeeded = 10;
    float barMovement;
    float barPosition;

    // Use this for initialization
    void Start () {
        expBar = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        checkExpGain();
        //Check if Exp bar is full

        if(this.gameObject.GetComponent<RectTransform>().sizeDelta.x == barWidth || expBar.GetComponent<RectTransform>().sizeDelta.x > barWidth)
        {
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector3(0, barHeight);
            barPosition = 0;
            levelText.GetComponent<Text>().text = level;
        }
    }

    public void ExpGain()
    {
        Exp = Exp + Increment;
        //10 clicks per level DIVDED BY clicks required for exp gain
        barMovement = 10 / clicksNeeded;
        barPosition = barMovement + barPosition;
        Debug.Log("barPosition = " + barPosition);
        //use time.deltatime to smooth this out to make it look better?
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector3(barPosition * 10, barHeight); 
    }


    public void checkExpGain()
    {
        switch(Exp)
        {
            case (100):
                level = "2";
                nextLevel = 3;
                clicksNeeded = (expRequired[nextLevel] - Exp)/10;
                break;


            case (250):
                level = "3";
                nextLevel = 4;
                clicksNeeded = (expRequired[nextLevel] - Exp) / 10;

                break;

            case (450):
                level = "4";
                nextLevel = 5;
                clicksNeeded = (expRequired[nextLevel] - Exp) / 10;

                break;

            case (700):
                level = "5";
                nextLevel = 6;
                clicksNeeded = (expRequired[nextLevel] - Exp) / 10;
                break;

            case (1000):
                level = "6";
                nextLevel = 7;
                clicksNeeded = (expRequired[nextLevel] - Exp) / 10;
                break;

            case (1350):
                level = "7";
                nextLevel = 8;
                clicksNeeded = (expRequired[nextLevel] - Exp) / 10;
                break;

            case (1700):
                level = "8";
                nextLevel = 9;
                clicksNeeded = (expRequired[nextLevel] - Exp) / 10;
                break;

            case (2150):
                level = "9";
                nextLevel = 10;
                clicksNeeded = (expRequired[nextLevel] - Exp) / 10;
                break;

            case (2650):
                level = "10";
               // nextLevel = 10;
                clicksNeeded = (expRequired[nextLevel] - Exp) / 10;
                break;


        }
    }
}
