using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ToggleMenus : MonoBehaviour
{
  //Menus
  public GameObject rotMenu;
  public GameObject colorMenu;
  public GameObject shapesMenu;
  public GameObject lightingMenu;
  public GameObject expMenu;

  private bool ActiveMenu = false;

  //Shapes - Prefabs
  public GameObject player;
  public GameObject Cube;
  public GameObject Sphere;
  public GameObject Cylinder;
  public GameObject Capsule;
  public GameObject Temp;
  public GameObject mySpawn;

  //Use with lighting menu
  //private GameObject lighting = GameObject.FindGameObjectWithTag("Lighting");

  public float lightRotX, lightRotY, lightRotZ;

  private string Spawn = "Spawn";
  private string Active = "Cube";



  // Use this for initialization
  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    mySpawn = GameObject.Find("PlayerSpawn");
    InitializeButtonArrays();

    Temp = Cube;
    lightRotX = 0;
    lightRotY = 0;
    lightRotZ = 0;
    //EditLightingRotation();
    //EditLightingLocation();


  }

  public void Update()
  {
    GameObject.FindGameObjectWithTag("Lighting").transform.Rotate(lightRotX, lightRotY, lightRotZ);
  }

  public void ToggleRotationMenu()
  {
    if (rotMenu.gameObject.activeSelf)
    {
      rotMenu.gameObject.SetActive(false);
      ActiveMenu = !ActiveMenu;
    }
    else if (!rotMenu.gameObject.activeSelf && ActiveMenu)
    {
      CloseAll();
      rotMenu.gameObject.SetActive(true);
    }
    else
    {
      rotMenu.gameObject.SetActive(true);
      ActiveMenu = !ActiveMenu;
    }
  }

  public void ToggleColorMenu()
  {
    if (colorMenu.activeSelf)
    {
      colorMenu.gameObject.SetActive(false);
      ActiveMenu = !ActiveMenu;
    }
    else if (!colorMenu.activeSelf && ActiveMenu)
    {
      CloseAll();
      colorMenu.SetActive(true);
    }
    else
    {
      colorMenu.SetActive(true);
      ActiveMenu = !ActiveMenu;
    }
  }

  public void ToggleShapesMenu()
  {
    if (shapesMenu.gameObject.activeSelf)
    {
      shapesMenu.gameObject.SetActive(false);
      ActiveMenu = !ActiveMenu;
    }
    else if (!shapesMenu.gameObject.activeSelf && ActiveMenu)
    {
      CloseAll();
      shapesMenu.gameObject.SetActive(true);
    }
    else
    {
      shapesMenu.gameObject.SetActive(true);
      ActiveMenu = !ActiveMenu;
    }

  }

  public void ToggleLightingMenu()
  {
    if (lightingMenu.gameObject.activeSelf)
    {
      lightingMenu.gameObject.SetActive(false);
      ActiveMenu = !ActiveMenu;
    }
    else if (!lightingMenu.gameObject.activeSelf && ActiveMenu)
    {
      CloseAll();
      lightingMenu.gameObject.SetActive(true);
    }
    else
    {
      lightingMenu.gameObject.SetActive(true);
      ActiveMenu = !ActiveMenu;
    }
  }

  public void ToggleExpMenu()
  {
    if (expMenu.gameObject.activeSelf)
    {
      expMenu.gameObject.SetActive(false);
      //check if another menu is open to avoid overlapping
      ActiveMenu = !ActiveMenu;
    }
    else if (!expMenu.gameObject.activeSelf && ActiveMenu)
    {
      CloseAll();
      expMenu.gameObject.SetActive(true);
    }
    else
    {
      expMenu.gameObject.SetActive(true);
      ActiveMenu = !ActiveMenu;
    }
  }

  public void CloseAll()
  {
    shapesMenu.gameObject.SetActive(false);
    rotMenu.gameObject.SetActive(false);
    colorMenu.gameObject.SetActive(false);
    lightingMenu.gameObject.SetActive(false);
    expMenu.gameObject.SetActive(false);
  }

  public void ChangeShape(string shape)
  {
    switch (shape)
    {
      case "Cube":
        Instantiate(Cube, mySpawn.transform.position, mySpawn.transform.rotation);
        Debug.Log("Destroy " + Active);
        Destroy(GameObject.Find(Active));
        Active = "Cube(Clone)";
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(Active);

        break;

      case "Sphere":
        Instantiate(Sphere, mySpawn.transform.position, mySpawn.transform.rotation);
        Debug.Log("Destroy " + Active);
        Destroy(GameObject.Find(Active));
        Active = "Sphere(Clone)";
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(Active);

        break;

      case "Capsule":
        Instantiate(Capsule, mySpawn.transform.position, mySpawn.transform.rotation);
        Debug.Log("Destroy " + Active);
        Destroy(GameObject.Find(Active));
        Active = "Capsule(Clone)";
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(Active);

        break;

      case "Cylinder":
        Instantiate(Cylinder, mySpawn.transform.position, mySpawn.transform.rotation);
        Debug.Log("Destroy " + Active);
        Destroy(GameObject.Find(Active));
        Active = "Cylinder(Clone)";
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(Active);

        break;

      default:
        Debug.Log("Error - Not a valid shape : " + shape);
        break;
    }
  }

  /*
  public void EditLightingRotation()
  {
    buttons = GameObject.FindGameObjectsWithTag("RotationMenuButtons");
    foreach (Object button in buttons)
    {
      gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    /*
    GameObject.Find("X Button").GetComponent<Button>().onClick.AddListener(() => { EditLightingRotationX(); });
    GameObject.Find("Y Button").GetComponent<Button>().onClick.AddListener(() => { EditLightingRotationY(); });
    GameObject.Find("Z Button").GetComponent<Button>().onClick.AddListener(() => { EditLightingRotationZ(); });
    
  }

  public void EditLightingLocation()
  {
    buttons = GameObject.FindGameObjectsWithTag("RotationMenuButtons");
    foreach (Object button in buttons)
    {
      gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
    }
    //
    //CHANGE THESE TO LOCATION NOT ROTATION
    //
    GameObject.Find("X Button").GetComponent<Button>().onClick.AddListener(() => { EditLightingRotationX(); });
    GameObject.Find("Y Button").GetComponent<Button>().onClick.AddListener(() => { EditLightingRotationY(); });
    GameObject.Find("Z Button").GetComponent<Button>().onClick.AddListener(() => { EditLightingRotationZ(); });
  }

  public void EditLightingLocationX()
  {
    //lightRotX = 20 * Time.deltaTime; 
  }

  public void EditLightingRotationX()
  {
    lightRotX = 20 * Time.deltaTime;
  }

  public void EditLightingRotationY()
  {
    lightRotY = 20 * Time.deltaTime;
  }

  public void EditLightingRotationZ()
  {
    lightRotZ = 20 * Time.deltaTime;
  }
  */
  public void InitializeButtonArrays()
  {
    List<Button> mainButtons = new List<Button>();
    List<Button> rotationButtons = new List<Button>();
    List<Button> colorButtons = new List<Button>();
    List<Button> shapesButtons = new List<Button>();
    List<Button> lightingButtons = new List<Button>();
    List<Button> expButtons = new List<Button>();

    //Component spinningCube = player.GetComponent<SpinningCube>();

    Button[] allButtons = GameObject.Find("UI Canvas").GetComponentsInChildren<Button>(true);
    foreach(Button b in allButtons)
    {

      if (b.gameObject.transform.parent.name.Contains("Main"))
      {
        mainButtons.Add(b.gameObject.GetComponent<Button>());
      }

      if (b.gameObject.transform.parent.name.Contains("Rotation"))
      {
        rotationButtons.Add(b.gameObject.GetComponent<Button>());
      }

      if (b.gameObject.transform.parent.name.Contains("Color"))
      {
        colorButtons.Add(b.gameObject.GetComponent<Button>());
      }

      if (b.gameObject.transform.parent.name.Contains("Shapes"))
      {
        shapesButtons.Add(b.gameObject.GetComponent<Button>());
      }

      if (b.gameObject.transform.parent.name.Contains("Lighting"))
      {
        lightingButtons.Add(b.gameObject.GetComponent<Button>());
      }

      if (b.gameObject.transform.parent.name.Contains("Exp"))
      {
        expButtons.Add(b.gameObject.GetComponent<Button>());
      }
    }

    //5 (0-4)
    Debug.Log("mainButtons: " + mainButtons.Count);
    //5 (0-4)
    Debug.Log("rotationButtons: " + rotationButtons.Count);
    //8 (0-7)
    Debug.Log("colorButtons: " + colorButtons.Count);
    //4 (0-3)
    Debug.Log("shapesButtons: " + shapesButtons.Count);
    //3 (0-2)
    Debug.Log("lightingButtons: " + lightingButtons.Count);
    //3 (0-2)
    Debug.Log("expButtons: " + expButtons.Count);

    mainButtons[0].onClick.AddListener(() => { ToggleRotationMenu(); });
    mainButtons[1].onClick.AddListener(() => { ToggleColorMenu(); });
    mainButtons[2].onClick.AddListener(() => { ToggleShapesMenu(); });
    mainButtons[3].onClick.AddListener(() => { ToggleLightingMenu(); });
    mainButtons[4].onClick.AddListener(() => { ToggleExpMenu(); });

    rotationButtons[0].onClick.AddListener(() => { RaiseRotationSpeed(); });
    rotationButtons[1].onClick.AddListener(() => { LowerRotationSpeed(); });
    rotationButtons[2].onClick.AddListener(() => { ToggleRotation(); });
    rotationButtons[3].onClick.AddListener(() => { ToggleRotationDirection(); });
    rotationButtons[4].onClick.AddListener(() => { ResetRotationSpeed(); });

    colorButtons[0].onClick.AddListener(() => { ChangeColor("Black"); });
    colorButtons[1].onClick.AddListener(() => { ChangeColor("White"); });
    colorButtons[2].onClick.AddListener(() => { ChangeColor("Red"); });
    colorButtons[3].onClick.AddListener(() => { ChangeColor("Green"); });
    colorButtons[4].onClick.AddListener(() => { ChangeColor("Blue"); });
    colorButtons[5].onClick.AddListener(() => { ChangeColor("Yellow"); });
    colorButtons[6].onClick.AddListener(() => { ChangeColor("Cyan"); });
    colorButtons[7].onClick.AddListener(() => { ChangeColor("Magenta"); });

    shapesButtons[0].onClick.AddListener(() => { ChangeShape("Cylinder"); });
    shapesButtons[1].onClick.AddListener(() => { ChangeShape("Capsule"); });
    shapesButtons[2].onClick.AddListener(() => { ChangeShape("Cube"); });
    shapesButtons[3].onClick.AddListener(() => { ChangeShape("Sphere"); });

    //Temporary save/load hidden in lighting for debug
    lightingButtons[0].onClick.AddListener(() => { GameObject.Find("EventSystem").GetComponent<GameManager>().Save(); });
    lightingButtons[1].onClick.AddListener(() => { GameObject.Find("EventSystem").GetComponent<GameManager>().Load(); });
    //lightingButtons[2].onClick.AddListener(() => { function(); });

    expButtons[0].onClick.AddListener(() => { GameObject.Find("Gained Image").GetComponent<ExperienceBar>().ExpMore(); });
    expButtons[1].onClick.AddListener(() => { GameObject.Find("Gained Image").GetComponent<ExperienceBar>().ExpLess(); });
    expButtons[2].onClick.AddListener(() => { GameObject.Find("Gained Image").GetComponent<ExperienceBar>().ResetExp(); });

  }

  public void ToggleRotationDirection()
  {

    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().m_RotationDirection == Vector3.up)
    {
      GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().m_RotationDirection = Vector3.down;
      GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().RotationDirection = "Down";
    }
    else
    {
      GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().m_RotationDirection = Vector3.up;
      GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().RotationDirection = "Up";
    }
    Debug.Log("Toggled rotation direction: " + GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().RotationDirection);

  }

  public void ToggleRotation()
  {
    Debug.Log("Stopping Rotation. Last known rotation direction: " + GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().RotationDirection);
    GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().stopRotation = Vector3.zero;

    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().m_RotationDirection == GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().stopRotation)
    {
      GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().m_RotationDirection = GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().tempRotation;
    }
    else
    {
      GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().tempRotation = GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().m_RotationDirection;
      GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().m_RotationDirection = GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().stopRotation;
    }
  }

  public void RaiseRotationSpeed()
  {
    GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentSpeed + GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentIncrement;
    Debug.Log("Rotation Speed: " + GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentSpeed);
  }

  public void LowerRotationSpeed()
  {
    GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentSpeed - GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentIncrement;
    Debug.Log("Rotation Speed: " + GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentSpeed);
  }

  public void ResetRotationSpeed()
  {
    GameObject.FindGameObjectWithTag("Player").GetComponent<SpinningCube>().currentSpeed = 20.0f;
    Debug.Log("Rotation Speed Reset");
  }

  public void ChangeColor(string color)
  {
    switch (color)
    {

      case "White":
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.white;
        break;

      case "Blue":
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.blue;
        break;

      case "Black":
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.black;
        break;

      case "Green":
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.green;
        break;

      case "Red":
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.red;
        break;

      case "Magenta":
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.magenta;
        break;

      case "Yellow":
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.yellow;
        break;

      case "Cyan":
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.cyan;
        break;


      default:
        Debug.Log("Error - no color named :" + color);
        break;
        

    }
  }
}
