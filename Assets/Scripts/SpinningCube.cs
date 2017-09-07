using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpinningCube : MonoBehaviour 
{

  //Playerdata -- Needs saved
  public float currentSpeed = 20f;
  public float currentIncrement = 20f;
  public float rotationPerSec = 0.0f;


  public string RotationDirection = "Up";
  public Vector3 m_RotationDirection = Vector3.up;
  public Vector3 rotationOrigin;
  public Vector3 stopRotation = Vector3.zero;
  public Vector3 tempRotation;
  public float angle2 = 0;
  public float angledif, angle1;
  public float angleSum = 0;

  [SerializeField]
  public float secPerRotation = 0.0f;

  [SerializeField]
  public float lastRPS = 0.0f;


  [SerializeField]
  public float secondsPassed = 0.0f;

  [SerializeField]
  public int rotations;

  public void Start()
  {

    /*
    if(GameObject.Find("Rotation Panel").activeSelf)
    {
      GameObject.Find("Rotation Direction Button").GetComponent<Button>().onClick.AddListener(() => { ToggleRotationDirection(); });

    }
    */
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
    secondsPassed += 0.02f;
    //rotations += (int)(m_Speed / 360);

    //if object is rotating, and angle difference is less than 0
    //If object has rotated 20 degrees (currentSpeed = 20), when angle1 = 350, && angle2 = 10
    //angle2(10)-angle1(350) = -340
    //Object has rotated past 360
    if ((currentSpeed > 0) && (angledif < 0))
    {
      ++rotations;
      GameObject.FindGameObjectWithTag("ExpGained").GetComponent<ExperienceBar>().ExpMore();

      lastRPS = 1 / secondsPassed;
      if(rotationPerSec != lastRPS)
      {
        rotationPerSec = lastRPS;
        secPerRotation = secondsPassed;
        Debug.Log("Rotations Per Second: " + rotationPerSec);
      }
      secondsPassed = 0.0f;
    }
  }
}


