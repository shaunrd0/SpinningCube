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
  public GameObject Square;
  public GameObject Sphere;
  public GameObject Cylinder;
  public GameObject Capsule;
  public GameObject Temp;
  public GameObject mySpawn;

  private string Spawn = "Spawn";
  private string Active = "Cube";

  //Use with lighting menu
  //private GameObject lighting = GameObject.FindGameObjectWithTag("Lighting");

  public float lightRotX, lightRotY, lightRotZ;


  // Use this for initialization
  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    InitializeButtonArrays();

    Temp = Square;
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

  public void ChangeShapeSquare()
  {
    Instantiate(Square, mySpawn.transform.position, mySpawn.transform.rotation);
    Debug.Log("Destroy " + Active);
    Destroy(GameObject.Find(Active));
    Active = "Cube(Clone)";
    Debug.Log(Active);
  }

  public void ChangeShapeSphere()
  {
    Instantiate(Sphere, mySpawn.transform.position, mySpawn.transform.rotation);
    Debug.Log("Destroy " + Active);
    Destroy(GameObject.Find(Active));
    Active = "Sphere(Clone)";
    Debug.Log(Active);
  }

  public void ChangeShapeCapsule()
  {
    Instantiate(Capsule, mySpawn.transform.position, mySpawn.transform.rotation);
    Debug.Log("Destroy " + Active);
    Destroy(GameObject.Find(Active));
    Active = "Capsule(Clone)";
    Debug.Log(Active);
  }

  public void ChangeShapeCylinder()
  {
    Instantiate(Cylinder, mySpawn.transform.position, mySpawn.transform.rotation);
    Debug.Log("Destroy " + Active);
    Destroy(GameObject.Find(Active));
    Active = "Cylinder(Clone)";
    Debug.Log(Active);
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

    rotationButtons[0].onClick.AddListener(() => { player.GetComponent<SpinningCube>().RaiseRotationSpeed(); });
    rotationButtons[1].onClick.AddListener(() => { player.GetComponent<SpinningCube>().LowerRotationSpeed(); });
    rotationButtons[2].onClick.AddListener(() => { player.GetComponent<SpinningCube>().ToggleRotation(); });
    rotationButtons[3].onClick.AddListener(() => { player.GetComponent<SpinningCube>().ToggleRotationDirection(); });
    rotationButtons[4].onClick.AddListener(() => { player.GetComponent<SpinningCube>().ResetRotationSpeed(); });

    colorButtons[0].onClick.AddListener(() => { player.GetComponent<SpinningCube>().ChangeColorBlack(); });
    colorButtons[1].onClick.AddListener(() => { player.GetComponent<SpinningCube>().ChangeColorWhite(); });
    colorButtons[2].onClick.AddListener(() => { player.GetComponent<SpinningCube>().ChangeColorRed(); });
    colorButtons[3].onClick.AddListener(() => { player.GetComponent<SpinningCube>().ChangeColorGreen(); });
    colorButtons[4].onClick.AddListener(() => { player.GetComponent<SpinningCube>().ChangeColorBlue(); });
    colorButtons[5].onClick.AddListener(() => { player.GetComponent<SpinningCube>().ChangeColorYellow(); });
    colorButtons[6].onClick.AddListener(() => { player.GetComponent<SpinningCube>().ChangeColorCyan(); });
    colorButtons[7].onClick.AddListener(() => { player.GetComponent<SpinningCube>().ChangeColorMagenta(); });

    shapesButtons[0].onClick.AddListener(() => { ChangeShapeCylinder(); });
    shapesButtons[1].onClick.AddListener(() => { ChangeShapeCapsule(); });
    shapesButtons[2].onClick.AddListener(() => { ChangeShapeSquare(); });
    shapesButtons[3].onClick.AddListener(() => { ChangeShapeSphere(); });

    //Temporary save/load hidden in lighting for debug
    lightingButtons[0].onClick.AddListener(() => { GameObject.Find("EventSystem").GetComponent<GameManager>().Save(); });
    lightingButtons[1].onClick.AddListener(() => { GameObject.Find("EventSystem").GetComponent<GameManager>().Load(); });
    //lightingButtons[2].onClick.AddListener(() => { function(); });

    expButtons[0].onClick.AddListener(() => { GameObject.Find("Gained Image").GetComponent<ExperienceBar>().ExpMore(); });
    expButtons[1].onClick.AddListener(() => { GameObject.Find("Gained Image").GetComponent<ExperienceBar>().ExpLess(); });
    expButtons[2].onClick.AddListener(() => { GameObject.Find("Gained Image").GetComponent<ExperienceBar>().ResetExp(); });

  }
}
