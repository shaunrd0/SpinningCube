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
	void OnEnable () {
    active = true;
    origin = this.transform.localPosition;
    localNotify = GameObject.Find("EventSystem").GetComponent<GameManager>().GetNotify();
  }
	
	// Update is called once per frame
	void FixedUpdate () {

    timer += 0.02f;

    this.gameObject.transform.Translate(new Vector3(0, 10f * Time.deltaTime, 0));
    this.gameObject.GetComponentInChildren<Text>().text = localNotify;
    
    if(timer >= 3)
    {
      this.gameObject.SetActive(false);
      active = false;
      timer = 0.0f;
      this.gameObject.transform.localPosition = origin;
    }

  }
}
