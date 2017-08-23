using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ExperienceBar : MonoBehaviour {

  public float expObtained = 0;
  public int level = 0;
  public float Increment = 10;
  public GameObject levelText;
  public float barWidth;
  public float barHeight;
    
  GameObject expBar;
  // Eventually.. public RectTransform gainedExp
  //Array used as expRequired[leveldesired]
  public float expRequired = 100;
  public float clicksNeeded = 10;
  float barMovement;
  float barPosition;
    
  // Use this for initialization
  void Start () {
    expBar = this.gameObject;
    barPosition = 0;
    this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector3(barPosition, barHeight);
  }

  // Update is called once per frame
  void Update () {
    //Check if Exp bar is full

    if(this.gameObject.GetComponent<RectTransform>().sizeDelta.x == barWidth || expBar.GetComponent<RectTransform>().sizeDelta.x > barWidth)
    {
      LevelUp();
      clicksNeeded = (expRequired - expObtained) / Increment;
      barPosition = 0;
      this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector3(barPosition, barHeight);
    }
  }

  public void ExpMore()
  {
    expObtained = expObtained + Increment;
    //Since increment is 10 && Level 1 = 100
    //10 clicks per level DIVDED BY clicks required for exp gain
    //int clicks = 0;
    //clicks++;
    barMovement = (barWidth / clicksNeeded) / 10.0f ; 
    barPosition = barMovement + barPosition;
    Debug.Log("barPosition = " + barPosition);
    //use time.deltatime to smooth this out to make it look better?
    this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector3(barPosition * 10, barHeight); 
  }

  public void LevelUp()
  {
    level++;
    levelText.GetComponent<Text>().text = level.ToString();
    expRequired = Mathf.Pow(expRequired, 1.05f) + expRequired ;
  }

  public void ResetExp()
  {
    barPosition = 0;
    this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector3(barPosition, barHeight);
    expObtained = 0;
    level = 1;
    levelText.GetComponent<Text>().text = level.ToString();
    expRequired = 100;
    clicksNeeded = 10;
  }

  public void ExpLess()
  {
    expObtained = expObtained - Increment;
    //Since increment is 10 && Level 1 = 100
    //10 clicks per level DIVDED BY clicks required for exp gain
    //int clicks = 0;
    //clicks++;
    barMovement = (barWidth / clicksNeeded) / 10.0f;
    barPosition = barPosition - barMovement;
    Debug.Log("barPosition = " + barPosition);
    //use time.deltatime to smooth this out to make it look better?
    this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector3(barPosition * 10, barHeight);
  }

}
