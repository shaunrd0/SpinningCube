using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ExperienceBar : MonoBehaviour {
  // Eventually.. public RectTransform gainedExp
  //Array used as expRequired[leveldesired]

  [SerializeField]
  private int level = 1;
  [SerializeField]
  private float expObtained = 0;
  [SerializeField]
  private float expRequired = 100;
  [SerializeField]
  private float fillAmount;
  [SerializeField]
  private GameObject levelText;
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

  private struct levelReqA
  {
    int levelA;
    float expRequiredA;
    float clicksRequiredA;
  }

  private struct levelReqB
  {
    public int levelB;
    public float expRequiredB;
    public float clicksRequiredB;
  }

  // Use this for initialization
  void Start () {
    fillAmount = 0;
  }

  // Update is called once per frame
  void Update () {

    if (fillAmount != expBarSprite.fillAmount)
    {
    expBarSprite.fillAmount = Mathf.Lerp(expBarSprite.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
    }
    
    //Check if Exp bar is full
    if (expBarSprite.fillAmount >= 1.0f)
    {
      LevelUp();
      clicksNeeded = (expRequired - expObtained) / Increment;
      fillAmount = 0;
    }
  }

  public void ExpMore()
  {
    ++clicks;
    expObtained = expObtained + Increment;
    fillAmount = (expObtained / expRequired);
    Debug.Log("fillAmount = " + fillAmount);
  }

  public void LevelUp()
  {
    ++level;
    levelText.GetComponent<Text>().text = level.ToString();
    previousExpRequired = expRequired;
    expObtained = 0;
    expRequired = Mathf.Pow(expRequired, 1.05f);
  }

  public void ResetExp()
  {
    level = 1;
    levelText.GetComponent<Text>().text = level.ToString();
    fillAmount = 0;
    expObtained = 0;
    expRequired = 100;
    clicksNeeded = 10;
    clicks = 0;
  }

  public void ExpLess()
  {
    --clicks;
    expObtained = expObtained - Increment;
    fillAmount = (expObtained / expRequired);
    Debug.Log("fillAmount = " + fillAmount);
  }

  private levelReqB LevelRequirement(int level, levelReqB levelB)
  {
    ++level;
    levelText.GetComponent<Text>().text = level.ToString();
    levelB.expRequiredB = Mathf.Pow(100, 1.05f);
    expObtained = 0;

    

    expRequired = Mathf.Pow(expRequired, 1.05f);
    
  }

}
