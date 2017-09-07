using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ExperienceBar : MonoBehaviour {

  //Playerdata -- Needs saved
  public int currentLevel = 1;
  public float currentExp = 0;
  public float currentRequirement = 100;

  [SerializeField]
  private GameObject currentLevelText;
  [SerializeField]
  private float fillAmount;
  [SerializeField]
  private Image expBarSprite;
  [SerializeField]
  private float lerpSpeed;
  [SerializeField]
  private int clicks;

  [SerializeField]
  private GameObject eventSystem;

    
  private float clicksNeeded = 10;
  private float previousExpRequired;
  private float barMovement;
  private float barPosition;
  [SerializeField]
  public float expIncrement = 10.0f;
  private string notify;
  
  // Use this for initialization
  void Start () {
    eventSystem = GameObject.Find("EventSystem");
    fillAmount = currentExp / currentRequirement;
  }

  // Update is called once per frame
  void Update () {
    fillAmount = currentExp / currentRequirement;
    this.gameObject.GetComponentInChildren<Text>().text = (int)currentExp + " / " + (int)currentRequirement;

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
      clicksNeeded = (currentRequirement - currentExp) / expIncrement;
      fillAmount = 0;
    }
  }

  public void ExpMore()
  {
    ++clicks;
    currentExp = currentExp + expIncrement;
    fillAmount = currentExp / currentRequirement;
    notify = "+" + expIncrement + "EXP";
    eventSystem.GetComponent<GameManager>().RewardPopup(expIncrement, 1);

    //Debug.Log("fillAmount = " + fillAmount);
  }

  public void LevelUp()
  {
    ++currentLevel;
    expIncrement += 10;
    currentLevelText.GetComponent<Text>().text = currentLevel.ToString();
    previousExpRequired = currentRequirement;
    currentExp -= previousExpRequired;
    currentRequirement = Mathf.Pow(currentRequirement, 1.05f);
    GameObject.Find("Main Panel").GetComponent<ToggleMenus>().RaiseRotationSpeed();
    notify = "Level " + currentLevel + "!";
    eventSystem.GetComponent<GameManager>().RewardPopup(currentLevel, 2);

  }

  public void ResetExp()
  {
    currentLevel = 1;
    currentLevelText.GetComponent<Text>().text = currentLevel.ToString();
    currentExp = 0;
    fillAmount = 0;
    expIncrement = 10.0f;
    currentRequirement = 100;
    clicksNeeded = 10;
    clicks = 0;
    notify = "EXP Reset";
    eventSystem.GetComponent<GameManager>().MakeStringPopup(notify, 1);

  }

  public void ExpLess()
  {
    --clicks;
    currentExp = currentExp - expIncrement;
    fillAmount = (currentExp / currentRequirement);
    Debug.Log("fillAmount = " + fillAmount);
    notify = "-" + expIncrement + "EXP";
    eventSystem.GetComponent<GameManager>().RewardPopup(-expIncrement, 1);

  }

  public float GetExperience()
  {
    float currentExp;
    currentExp = this.currentExp;
    return currentExp;
  }


}
