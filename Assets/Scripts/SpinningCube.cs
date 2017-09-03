﻿using UnityEngine;
using System.Collections;

public class SpinningCube : MonoBehaviour 
{

  //Playerdata -- Needs saved
  public float currentSpeed = 20f;
  public float currentIncrement = 10f;


  private string RotationDirection = "Up";
  private Vector3 m_RotationDirection = Vector3.up;
  private Vector3 rotationOrigin;
  private Vector3 stopRotation = Vector3.zero;
  private Vector3 tempRotation;
  private float angle2 = 0;
  private float angledif, angle1;
  private float angleSum = 0;

  [SerializeField]
  private int rotations;

  public void OnDestroy()
  {
    GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Save();
  }

  public void ToggleRotationDirection()
  {

    if (m_RotationDirection == Vector3.up) 
    {
	    m_RotationDirection = Vector3.down;
      RotationDirection = "Down";
    }
    else 
    {
	    m_RotationDirection = Vector3.up;
      RotationDirection = "Up";
    }
    Debug.Log("Toggled rotation direction: " + RotationDirection);

  }

  public void ToggleRotation()
  {
    Debug.Log("Stopping Rotation. Last known rotation direction: " + RotationDirection);
    stopRotation = Vector3.zero;
        
    if (m_RotationDirection == stopRotation)
    {
      m_RotationDirection = tempRotation; 
    }
    else {
      tempRotation = m_RotationDirection;
      m_RotationDirection = stopRotation;
    }
  }

  public void RaiseRotationSpeed()
  {
    currentSpeed = currentSpeed + currentIncrement;
    Debug.Log("Rotation Speed: " + currentSpeed);
  }

  public void LowerRotationSpeed()
  {
    currentSpeed = currentSpeed - currentIncrement;
    Debug.Log("Rotation Speed: " + currentSpeed);
  }

  public void ResetRotationSpeed()
  {
    currentSpeed = 20.0f;
    Debug.Log("Rotation Speed Reset");
  }

  public void ChangeColorWhite()
  {
    GameObject.FindGameObjectsWithTag("Player");
    gameObject.GetComponent<Renderer>().material.color = Color.white;
  }

  public void ChangeColorBlue()
  {
    gameObject.GetComponent<Renderer>().material.color = Color.blue;
  }

  public void ChangeColorBlack()
  {
    gameObject.GetComponent<Renderer>().material.color = Color.black;
  }

  public void ChangeColorGreen()
  {
    gameObject.GetComponent<Renderer>().material.color = Color.green;
  }

  public void ChangeColorRed()
  {
    gameObject.GetComponent<Renderer>().material.color = Color.red;
  }

  public void ChangeColorMagenta()
  {
    gameObject.GetComponent<Renderer>().material.color = Color.magenta;
  }

  public void ChangeColorYellow()
  {
    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
  }

  public void ChangeColorCyan()
  {
    gameObject.GetComponent<Renderer>().material.color = Color.cyan;
  }

  void FixedUpdate()
  {
    //Set angle1 = eulerAngle of axis being rotated prior to applying rotation
    angle1 = this.gameObject.transform.rotation.eulerAngles.y;
    transform.Rotate(m_RotationDirection * Time.deltaTime * currentSpeed);
    //angle2 = eulerAngle of axis after rotation applied
    angle2 = this.gameObject.transform.rotation.eulerAngles.y;
    //Difference between angle2 and angle1, how much the object rotated between frames
    angledif = angle2 - angle1;

    //rotations += (int)(m_Speed / 360);

    //if object is rotating, and angle difference is less than 0
    //If object has rotated 20 degrees (currentSpeed = 20), when angle1 = 350, && angle2 = 10
    //angle2(10)-angle1(350) = -340
    //Object has rotated past 360
    if ((currentSpeed > 0) && (angledif < 0))
    {
      ++rotations;
      GameObject.FindGameObjectWithTag("ExpGained").GetComponent<ExperienceBar>().ExpMore();
    }
  }
}


