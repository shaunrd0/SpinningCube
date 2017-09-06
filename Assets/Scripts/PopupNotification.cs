using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopupNotification : MonoBehaviour {

  public bool move = false;
  public bool active = false;
  public Vector3 origin;
  public float timer = 0.0f;
  public float maxTimer = 3.0f;
  public float speed = 50.0f;
  public string localNotify;
  public int notificationType;
  public float localValue;


	// Use this for initialization
	void OnEnable ()
  {
    active = true;

    //Get & set random rotation
    double randomRotation = GetRandomNumber(-4.0, 4.0);
    transform.Rotate(0.0f, 0.0f, (float)randomRotation);
    //Debug.Log("Rotation set to :" + randomRotation);

    //
    notificationType = GameObject.Find("EventSystem").GetComponent<GameManager>().notificationType;
    //localNotify = GameObject.Find("EventSystem").GetComponent<GameManager>().notify;
    localValue = GameObject.Find("EventSystem").GetComponent<GameManager>().noteValue;

    CheckNotificationType();
  }

  // Update is called once per frame
  void FixedUpdate()
  {

    timer += 0.02f;


    if (timer >= maxTimer)
    {
      active = false;
      timer = 0.0f;

      Destroy(this.gameObject);
    }

    if(move == true)
    {
      this.gameObject.transform.Translate(new Vector3(-5.0f, speed * Time.deltaTime, 0));
      this.gameObject.GetComponentInChildren<Text>().text = localNotify;
    }
    else
    {
      this.gameObject.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
      this.gameObject.GetComponentInChildren<Text>().text = localNotify;
    }
  }

  void OnCollisionEnter (Collision col)
  {
    if(col.gameObject.GetComponent<PopupNotification>().notificationType == 1 && notificationType == 1)
    {
      //if both colliding popus are EXP related


      if ((maxTimer - timer) > (col.gameObject.GetComponent<PopupNotification>().maxTimer - col.gameObject.GetComponent<PopupNotification>().timer))
      {
        //If this Popup has more time left than colliding popup
        localValue += col.gameObject.GetComponent<PopupNotification>().localValue;
        maxTimer += 0.5f;
        CheckNotificationType();
        Destroy(col.gameObject);
      }//else do nothing, let other popup handle it
    }
    else if (col.gameObject.GetComponent<PopupNotification>().notificationType == 2 && notificationType == 2)
    {
      //if both colliding popus are level related


      if (localValue > col.gameObject.GetComponent<PopupNotification>().localValue)
      {
        //If this popup is of higher level
        Destroy(col.gameObject);
      }//Destroy collider, show most recent level
      maxTimer += 1.0f;
      CheckNotificationType();

    }
    else if (col.gameObject.GetComponent<PopupNotification>().notificationType != notificationType)
    {
      //if both colliding popus are not related


      if (notificationType == 2)
      {
        move = true;
      }//else do nothing, let other popup handle it
    }



  }

  public double GetRandomNumber(double min, double max)
  {
    System.Random random = new System.Random();
    return random.NextDouble() * (max - min) + min;
  }

  public void CheckNotificationType()
  {
    //If notification is of type EXP
    if (notificationType == 1)
    {

      if (localValue == 0)
      {
        Debug.Log("Null EXP value, popup discarded :" + localValue);
        Destroy(this.gameObject);
      }

      if (localValue > 0)
      {
        //If adding EXP
        localNotify = "+" + localValue + "EXP";

      }
      else if (localValue < 0)
      {
        //If subtracting EXP
        localNotify = localValue + "EXP";
      }

    }
    else if (notificationType == 2)
    {
      //If notification is of type Level Gained
      localNotify = "Level " + localValue + "!";
    }

    this.gameObject.GetComponentInChildren<Text>().text = localNotify;
  }

}

