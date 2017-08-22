using UnityEngine;
using System.Collections;

public class SpinningCube : MonoBehaviour 
{
	public float m_Speed = 20f;
    public float increments = 10f;


    private string RotationDirection = "Up";
	private Vector3 m_RotationDirection = Vector3.up;
    private Vector3 stopRotation = Vector3.zero;
    private Vector3 tempRotation;


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
        m_Speed = m_Speed + increments;

        Debug.Log("Rotation Speed: " + m_Speed);
    }

    public void LowerRotationSpeed()
    {
        m_Speed = m_Speed - increments;

        Debug.Log("Rotation Speed: " + m_Speed);
    }

    public void ResetRotationSpeed()
    {
        m_Speed = 20.0f;
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

    void Update() 
	{
		transform.Rotate(m_RotationDirection * Time.deltaTime * m_Speed);
	}


}


