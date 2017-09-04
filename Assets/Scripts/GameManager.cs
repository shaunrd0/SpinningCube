using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class GameManager : MonoBehaviour {

  //Used to save playerdata
  //Serializable tells unity it can save to a file
  [Serializable]
  private class PlayerData
  {
    public int level;
    public float experience;
    public float requirement;
    public float speed;
    public float increment;
    public float rotationsPerSec;
    public DateTime currentTime;

  }

  public string notify;
  public bool wait;
  public bool activeOne;
  public bool activeTwo;
  public bool activeThree;
  public bool activeFour;
  public float idleExp;
  public GameObject popupOne;
  public GameObject popupTwo;
  public GameObject popupThree;
  public GameObject popupFour;
  public float timer;

  // Update is called once per frame
  void Update () {
		
	}



  void OnEnable()
  {    
    Load();
  }

  void OnApplicationPause()
  {
    Save();
  }

  void OnApplicationFocus(bool pauseStatus)
  {
    if (pauseStatus)
    {
      //your app is NO LONGER in the background
      Load();
    }
    else
    {
      //your app is now in the background
      Save();
    }
  }

  void OnApplicationQuit()
  {
    Save();
  }
	
  public void Start()
  {
    popupOne.SetActive(false);
    popupTwo.SetActive(false);
    popupThree.SetActive(false);
    popupFour.SetActive(false);


  }

  void FixedUpdate()
  {
    UpdatePopups();
    timer += 0.02f;
    if(timer > 9999.0f)
    {
      timer = 0.0f;
    }


  }

  public void Save()
  {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

    int currentLevel = GameObject.FindGameObjectWithTag("ExpGained").GetComponent<ExperienceBar>().currentLevel;
    float currentExp = GameObject.FindGameObjectWithTag("ExpGained").GetComponent<ExperienceBar>().currentExp;
    float currentRequirement = GameObject.FindGameObjectWithTag("ExpGained").GetComponent<ExperienceBar>().currentRequirement;
    float rotationPerSec = GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().rotationPerSec;
    float currentSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentSpeed;
    float currentIncrement = GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentIncrement;

    PlayerData data = new PlayerData();
    data.level = currentLevel;
    data.experience = currentExp;
    data.requirement = currentRequirement;
    data.speed = currentSpeed;
    data.increment = currentIncrement;
    data.rotationsPerSec = rotationPerSec;
    data.currentTime = System.DateTime.Now;

    bf.Serialize(file, data);
    file.Close();
    Debug.Log("Saved");
  }

  public void Load()
  {
    if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
    {
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
      PlayerData data = (PlayerData)bf.Deserialize(file);
      file.Close();

      GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().rotationPerSec = data.rotationsPerSec;
      GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentSpeed = data.speed;
      GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentIncrement = data.increment;
      GameObject.FindGameObjectWithTag("ExpGained").GetComponent<ExperienceBar>().currentLevel = data.level;
      GameObject.FindGameObjectWithTag("ExpGained").GetComponent<ExperienceBar>().currentExp = data.experience;
      GameObject.FindGameObjectWithTag("ExpGained").GetComponent<ExperienceBar>().currentRequirement = data.requirement;

      DateTime loadTime = System.DateTime.Now;
      int secondsPassed = GetIdleTime(data.currentTime, loadTime);
      idleExp = (data.rotationsPerSec * secondsPassed) * data.increment;
      GameObject.FindGameObjectWithTag("ExpGained").GetComponent<ExperienceBar>().currentExp += idleExp;

      if (idleExp >= 0.0f)
      {
        string notification = ("+" + idleExp + "EXP");
        SendNotification(notification);
      }

      Debug.Log("Loaded");
      Debug.Log("idleExp: " + idleExp);
    }
  }

  public int GetIdleTime(DateTime saveTime, DateTime loadTime)
  {
    int daysPassed = 0;
    int hoursPassed = 0;
    int minutesPassed = 0;
    int secondsPassed = 0;

    for (int monthSaved = saveTime.Month; monthSaved < loadTime.Month; ++monthSaved)
    {
      daysPassed += 30;
    }
    daysPassed += loadTime.Day - saveTime.Day;

    hoursPassed = daysPassed * 24;
    hoursPassed += loadTime.Hour - saveTime.Hour;

    minutesPassed = hoursPassed * 60;
    minutesPassed += loadTime.Minute - saveTime.Minute;

    secondsPassed = minutesPassed * 60;
    secondsPassed += loadTime.Second - saveTime.Second;

    Debug.Log("Seconds Passed: " + secondsPassed);
    return secondsPassed;
  }

  public void UpdatePopups()
  {

    if (GameObject.Find("Pop-up Panel 1") == null)
    {
      activeOne = false;
    }
    else
    {
        activeOne = true;
    }

    if (GameObject.Find("Pop-up Panel 2") == null)
    {
      activeTwo = false;
    }
    else
    {
      activeTwo = true;
    }

    if (GameObject.Find("Pop-up Panel 3") == null)
    {
      activeThree = false;
    }
    else
    {
      activeThree = true;
    }

    if (GameObject.Find("Pop-up Panel 4") == null)
    {
      activeFour = false;
    }else
    {
      activeFour = true;
    }

  }

  public void SendNotification(string notification)
  {

    /*
    List<GameObject> popups = new List<GameObject>();
    GameObject[] allPopups = GameObject.Find("Notification Panel").GetComponentsInChildren<GameObject>(true);
    foreach (GameObject obj in allPopups)
    {
      popups.Add(obj.GetComponent<GameObject>());
    }
    */



    //Debug.Log("Number of Popups: " + popups.Count);


    for (;;)
    {
      Debug.Log("For1");
      if (wait == true)
      {
        Debug.Log("For1.1");
        continue;
      }else
      {
        Debug.Log("For1.1");
        notify = notification;
        break;
      }
    }


    for (;;)
    {
      Debug.Log("For2");
      if (activeOne == false)
      {
        popupOne.SetActive(true);
        wait = false;
        break;
      } else if (activeTwo == false)
      {
        popupTwo.SetActive(true);
        wait = false;
        break;
      } else if (activeThree == false)
      {
        popupThree.SetActive(true);
        wait = false;
        break;
      } else if (activeFour == false)
      {
        popupFour.SetActive(true);
        wait = false;
        break;
      } else
      {
        wait = true;
        continue;
      }
    }

  }

  public string GetNotify()
  {
    return notify;
  }

}
