using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour {

    public static UI_Manager instance;

    // GLOBAL VARIABLES

    // HULL AND FUEL
    public GameObject fuelBar;
    public GameObject HullHealthBar;
    float hullHealthBarLength;
    public int hullHealth = 100;
    float fuelBarLength;
    public int fuelLevel = 100;
    float lastSecond = 0;
    float fuelBarChangeAmmount;
    public float FUEL_UPGRADE_LEVEL = 1;
    public bool atGasStation = false;
    public GameObject gasCanvas;
    private GameObject gasInstance;
    public Text moneyText;

    //REFINERY
    public bool atRefinery = false;
    public GameObject refineryCanvas;
    private GameObject refineryInstance;

    // INVENTORY
    public GameObject inv_panel;
    public Button inv_btn;
    public Button exit_btn;
    private GameObject inv_instance;
    public Transform main_canvas;
    private bool inv_panel_active = false;

    void Awake()
    {
        if (instance == null)  //there is no instance, the instance will be assigned to this instance
        {
            instance = this;
        }
        else if (instance != this) //if there is an instance already, delete this instance
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start() {
        GetFuelBarInfo();
    }

    // Update is called once per frame
    void Update() {
        if (instance == null) { Debug.Log("UI Instance Null"); }
        UpdateFuel();
        moneyText.text = "$" + PlayerManager.instance.GetMoney().ToString();
    }

    
    public void ShowInv()
    {
        PrintArray();
        Debug.Log("showing inventory");
        inv_instance = Instantiate(inv_panel);
        inv_panel_active = true;
    }

    void PrintArray()
    {
        string tempStr;
        for (int i = 0; i < 25; i++)
        {
            tempStr. + i;
        }

    }

    public void HideInv()
    {
        Debug.Log("hiding inventory");
        Destroy(inv_instance);
        inv_panel_active = false;
    }

    public bool Is_inv_active()
    {
        if(inv_panel_active)
        { return true; }
        else
        { return false; }
    }

    // gathers the required info about fuel bar
    void GetFuelBarInfo()
    {
        RectTransform fuelRectTF;
        fuelRectTF = fuelBar.GetComponent<RectTransform>();
        Vector2 fuelTopRight = fuelRectTF.anchorMax;
        Vector2 fuelBottomLeft = fuelRectTF.anchorMin;
        fuelBarLength = fuelBottomLeft.x - fuelTopRight.x;
        hullHealthBarLength = fuelBarLength;
        fuelBarChangeAmmount = fuelBarLength / 200;
        //Debug.Log(fuelBarLength);
        //Debug.Log(fuelBarChangeAmmount);
    }

    //sets the yellow fuel bar to the same proportion as %fuel remaining
    void UpdateFuel()
    {
        // check if enough time has passed to deincriment fuel
        if (lastSecond < Time.time && !atGasStation && !inv_panel_active && !atRefinery) //AND PLAYER ISN'T MOVING
        {
            fuelLevel--;
            lastSecond = Time.time;
            lastSecond += (float)(FUEL_UPGRADE_LEVEL * .3);
        }
        
        if(fuelLevel < 1)
        {
            fuelLevel = 0;
        }

        else if (fuelLevel > 99)
        {
            fuelLevel = 100;
        }

        // update the bar == the fuel level
        RectTransform fuelRectTF = fuelBar.GetComponent<RectTransform>();
        Vector2 tempBarMax = fuelRectTF.anchorMin;
        // minus b/c minus is the right direction
        tempBarMax.x -= fuelBarLength;
        tempBarMax.x += (100 - fuelLevel)*2*fuelBarChangeAmmount;
        
        fuelRectTF.anchorMax = tempBarMax;
    }

    void LowerHullHealth(int damageAmmount)
    {
        RectTransform hullRectTF;
        hullRectTF = HullHealthBar.GetComponent<RectTransform>();
        Vector2 barMaxTemp = hullRectTF.anchorMax;
        hullHealth -= damageAmmount;
        if (hullHealth < 1)
        {
            hullHealth = 0;
            //  KILL THE PLAYER
            Vector2 barMinTemp = hullRectTF.anchorMin;
            barMaxTemp.x = barMinTemp.x;
        }
        else
        {
            barMaxTemp.x += 2*fuelBarChangeAmmount;
            hullRectTF.anchorMax = barMaxTemp;
        }

    }

    public int FillTank(int button)
    {
        //set up test for >99 for 1 & 5 and return extra
        string tempFuelLogStr;
        int extra = 0;
        switch (button)
        {
            case 1:
                if (fuelLevel < 97)
                {
                    fuelLevel += 4;
                    tempFuelLogStr = "Filled tank 1 " + fuelLevel.ToString();
                    PlayerManager.instance.SpendMoney(1);
                }
                else if (fuelLevel < 100)
                {
                    fuelLevel = 100;
                    PlayerManager.instance.SpendMoney(1);
                }
                break;
            case 2:
                if (fuelLevel < 81)
                {
                    fuelLevel += 20;
                    tempFuelLogStr = "Filled tank 5 " + fuelLevel.ToString();
                    PlayerManager.instance.SpendMoney(5);
                }
                else if (fuelLevel < 100)
                {
                    extra = 100 - fuelLevel;
                    PlayerManager.instance.SpendMoney((int)(extra / 4));
                    fuelLevel = 100;
                }
                break;
            case 3:
                if (fuelLevel < 50)
                {
                    extra = 0;
                    PlayerManager.instance.SpendMoney(13);
                    fuelLevel += 50;
                }
                else if (fuelLevel < 100)
                {
                    extra = 100 - fuelLevel;
                    PlayerManager.instance.SpendMoney((int)(extra / 4));
                    fuelLevel = 100;
                }
                break;
            case 4:
                extra = 100 - fuelLevel;
                PlayerManager.instance.SpendMoney((int)((100 - extra) / 4));
                fuelLevel = 100;
                break;
        }
        return extra;
    }

    public void OpenGasStation()
    {
        if (!atGasStation)
        {
            //Debug.Log("showing gas station");
            gasInstance = Instantiate(gasCanvas);
            atGasStation = true;
        }
        else
        {
            //Debug.Log("gas station already open");
        }
    }

    public void CloseGasStation()
    {
        Debug.Log("hiding gas station");
        Destroy(gasInstance);
        atGasStation = false;
    }

    public void OpenRefinery()
    {
        if (!atRefinery)
        {
            //Debug.Log("showing gas station");
            refineryInstance = Instantiate(refineryCanvas);
            atRefinery = true;
        }
        else
        {
            //Debug.Log("gas station already open");
        }
    }

    public void CloseRefinery()
    {
        Debug.Log("hiding refinery");
        Destroy(refineryInstance);
        atRefinery = false;
    }

}