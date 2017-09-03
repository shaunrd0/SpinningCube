using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ExperienceBar : MonoBehaviour {
  // Eventually.. public RectTransform gainedExp
  //Array used as expRequired[leveldesired]


  //playerdata - needs saved
  public int currentLevel = 1;
  public float currentExp = 0;
  public float currentRequirement = 100;
  public GameObject currentLevelText;

  [SerializeField]
  private float fillAmount;
  [SerializeField]
  private Image expBarSprite;
  [SerializeField]
  private float lerpSpeed;
  [SerializeField]
  private int clicks;
    
  private float clicksNeeded = 10;
  private float previousExpRequired;
  private float barMovement;
  private float barPosition;
  private float Increment = 10;
  
  // Use this for initialization
  void Start () {
    fillAmount = currentExp / currentRequirement;
  }

  // Update is called once per frame
  void Update () {
    fillAmount = currentExp / currentRequirement;


    if (currentLevelText.GetComponent<Text>().text != currentLevel.ToString()){
      currentLevelText.GetComponent<Text>().text = currentLevel.ToString();
    }

    if (fillAmount != expBarSprite.fillAmount)
    {
    expBarSprite.fillAmount = Mathf.Lerp(expBarSprite.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
    }
    
    //Check if Exp bar is full
    if (expBarSprite.fillAmount >= 1.0f)
    {
      LevelUp();
      clicksNeeded = (currentRequirement - currentExp) / Increment;
      fillAmount = 0;
    }
  }

  public void ExpMore()
  {
    ++clicks;
    currentExp = currentExp + Increment;
    fillAmount = currentExp / currentRequirement;
    Debug.Log("fillAmount = " + fillAmount);
  }

  public void LevelUp()
  {
    ++currentLevel;
    currentLevelText.GetComponent<Text>().text = currentLevel.ToString();
    previousExpRequired = currentRequirement;
    currentExp = 0;
    currentRequirement = Mathf.Pow(currentRequirement, 1.05f);
    GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().RaiseRotationSpeed();
  }

  public void ResetExp()
  {
    currentLevel = 1;
    currentLevelText.GetComponent<Text>().text = currentLevel.ToString();
    fillAmount = 0;
    currentExp = 0;
    currentRequirement = 100;
    clicksNeeded = 10;
    clicks = 0;
  }

  public void ExpLess()
  {
    --clicks;
    currentExp = currentExp - Increment;
    fillAmount = (currentExp / currentRequirement);
    Debug.Log("fillAmount = " + fillAmount);
  }

  public float GetExperience()
  {
    float currentExp;
    currentExp = this.currentExp;
    return currentExp;
  }


}
