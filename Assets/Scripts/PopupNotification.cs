using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopupNotification : MonoBehaviour {

  public bool active = false;
  public Vector3 origin;
  public float timer = 0.0f;
  public string localNotify;

	// Use this for initialization
	void OnEnable ()
  {
    active = true;
    double randomRotation = GetRandomNumber(-4.0, 4.0);
    transform.Rotate(0.0f, 0.0f, (float)randomRotation);
    Debug.Log("Rotation set to :" + randomRotation);
    origin = this.transform.localPosition;
    localNotify = GameObject.Find("EventSystem").GetComponent<GameManager>().GetNotify();
  }

  // Update is called once per frame
  void FixedUpdate()
  {

    timer += 0.02f;

    this.gameObject.transform.Translate(new Vector3(0, 50f * Time.deltaTime, 0));
    this.gameObject.GetComponentInChildren<Text>().text = localNotify;

    if (timer >= 3)
    {
      active = false;
      timer = 0.0f;
      Destroy(this.gameObject);
    }
  }

  public double GetRandomNumber(double min, double max)
  {
    System.Random random = new System.Random();
    return random.NextDouble() * (max - min) + min;
  }

}

