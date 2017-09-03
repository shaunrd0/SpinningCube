using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
  }

	// Update is called once per frame
	void Update () {
		
	}


	// Use this for initialization
	void Start () {
    Load();
	}

  void OnEnable()
  {    
    Load();
  }

  void OnApplicationPause()
  {
    Save();
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
    float currentSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentSpeed;
    float currentIncrement = GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentIncrement;

    PlayerData data = new PlayerData();
    data.level = currentLevel;
    data.experience = currentExp;
    data.requirement = currentRequirement;
    data.speed = currentSpeed;
    data.increment = currentIncrement;

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

      GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentSpeed = data.speed;
      GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentIncrement = data.increment;
      GameObject.FindGameObjectWithTag("ExpGained").GetComponent<ExperienceBar>().currentLevel = data.level;
      GameObject.FindGameObjectWithTag("ExpGained").GetComponent<ExperienceBar>().currentExp = data.experience;
      GameObject.FindGameObjectWithTag("ExpGained").GetComponent<ExperienceBar>().currentRequirement = data.requirement;
      Debug.Log("Loaded");
    }
  }
}
