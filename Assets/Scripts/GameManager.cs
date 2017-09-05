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

  public float idleExp;

  public GameObject popup;
  public GameObject popupSpawn;
  public string notify;

  void OnApplicationFocus(bool pauseStatus)
  {
    Debug.Log("OnApplicationFocused");
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
        MakePopup(notification);
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

  public void MakePopup(string content)
  {
    notify = content;
    Instantiate(popup, popupSpawn.transform.position, popupSpawn.transform.rotation, GameObject.Find("Notification Panel").gameObject.transform );
    Debug.Log("Popup Created");
  }

  public string GetNotify()
  {
    return notify;
  }

}
