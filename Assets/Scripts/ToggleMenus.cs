using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleMenus : MonoBehaviour
{
  //Menus
  public GameObject RotMenu;
  public GameObject ColorMenu;
  public GameObject ShapesMenu;
  public GameObject LightingMenu;
  public GameObject ExpMenu;

  private bool ActiveMenu = false;

  //Shapes - Prefabs
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
  public GameObject[] buttons;


  // Use this for initialization
  void Start()
  {
    Temp = Square;
    lightRotX = 0;
    lightRotY = 0;
    lightRotZ = 0;
    EditLightingRotation();
    //EditLightingLocation();
  }

  public void Update()
  {
    GameObject.FindGameObjectWithTag("Lighting").transform.Rotate(lightRotX, lightRotY, lightRotZ);
  }

  public void ToggleRotationMenu()
  {
    if (RotMenu.gameObject.active)
    {
      RotMenu.gameObject.SetActive(false);
      ActiveMenu = !ActiveMenu;
    }
    else if (!RotMenu.gameObject.active && ActiveMenu)
    {
      CloseAll();
      RotMenu.gameObject.SetActive(true);
    }
    else
    {
      RotMenu.gameObject.SetActive(true);
      ActiveMenu = !ActiveMenu;
    }
  }

  public void ToggleColorMenu()
  {
    if (ColorMenu.gameObject.active)
    {
      ColorMenu.gameObject.SetActive(false);
      ActiveMenu = !ActiveMenu;
    }
    else if (!ColorMenu.gameObject.active && ActiveMenu)
    {
      CloseAll();
      ColorMenu.gameObject.SetActive(true);
    }
    else
    {
      ColorMenu.gameObject.SetActive(true);
      ActiveMenu = !ActiveMenu;
    }
  }

  public void ToggleShapesMenu()
  {
    if (ShapesMenu.gameObject.active)
    {
      ShapesMenu.gameObject.SetActive(false);
      ActiveMenu = !ActiveMenu;
    }
    else if (!ShapesMenu.gameObject.active && ActiveMenu)
    {
      CloseAll();
      ShapesMenu.gameObject.SetActive(true);
    }
    else
    {
      ShapesMenu.gameObject.SetActive(true);
      ActiveMenu = !ActiveMenu;
    }

  }

  public void ToggleLightingMenu()
  {
    if (LightingMenu.gameObject.active)
    {
      LightingMenu.gameObject.SetActive(false);
      ActiveMenu = !ActiveMenu;
    }
    else if (!LightingMenu.gameObject.active && ActiveMenu)
    {
      CloseAll();
      LightingMenu.gameObject.SetActive(true);
    }
    else
    {
      LightingMenu.gameObject.SetActive(true);
      ActiveMenu = !ActiveMenu;
    }
  }

  public void ToggleExpMenu()
  {
    if (ExpMenu.gameObject.active)
    {
      ExpMenu.gameObject.SetActive(false);
      //check if another menu is open to avoid overlapping
      ActiveMenu = !ActiveMenu;
    }
    else if (!ExpMenu.gameObject.active && ActiveMenu)
    {
      CloseAll();
      ExpMenu.gameObject.SetActive(true);
    }
    else
    {
      ExpMenu.gameObject.SetActive(true);
      ActiveMenu = !ActiveMenu;
    }
  }

  public void CloseAll()
  {
    ShapesMenu.gameObject.SetActive(false);
    RotMenu.gameObject.SetActive(false);
    ColorMenu.gameObject.SetActive(false);
    LightingMenu.gameObject.SetActive(false);
    ExpMenu.gameObject.SetActive(false);
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

  public void EditLightingRotation()
  {
    buttons = GameObject.FindGameObjectsWithTag("RotationMenuButtons");
    foreach (Object button in buttons)
    {
      gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
    }

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
}
