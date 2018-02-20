using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GasStationManager : MonoBehaviour
{
    public static GasStationManager instance;
    //RectTransform fuelRectTF;
    public GameObject fuelBar;
    float fuelBarFullHeight, fuelBarChangeAmmount;
    int fuelLevel;
    Vector2 newSizeDelta;
    public Text moneyText;

    void Awake()
    {
        if (instance == null)  //there is no instance, the instance will be assigned to this instance
        {                     //if there is an instance, another one will not be created (there will only be one instance)
            instance = this;
        }
    }

    void Start()
    {
        GetFuelRectInfo();
        UpdateFuelBar();
        moneyText.text = "$" + PlayerManager.instance.GetMoney().ToString();
    }

    private void Update()
    {
    }

    public void FuelButtonClicked(int btnNum)
    {
        int extra = 0;
        switch (btnNum)
        {
            case 0:
                extra = UI_Manager.instance.FillTank(1);
                UpdateFuelBar();
                moneyText.text = "$" + PlayerManager.instance.GetMoney().ToString();
                break;
            case 1:
                extra = UI_Manager.instance.FillTank(2);
                UpdateFuelBar();
                moneyText.text = "$" + PlayerManager.instance.GetMoney().ToString();
                break;
            case 2:
                extra = UI_Manager.instance.FillTank(3);
                UpdateFuelBar();
                moneyText.text = "$" + PlayerManager.instance.GetMoney().ToString();
                break;
            case 3:
                extra = UI_Manager.instance.FillTank(4);
                UpdateFuelBar();
                moneyText.text = "$" + PlayerManager.instance.GetMoney().ToString();
                break;
        }     
    }

    public void Exit()
    {
        UI_Manager.instance.CloseGasStation();
    }

    void GetFuelRectInfo()
    {
        newSizeDelta = fuelBar.GetComponent<RectTransform>().sizeDelta;
        fuelBarFullHeight =  newSizeDelta.y;
        fuelBarChangeAmmount = fuelBarFullHeight / 100;
    }

    void UpdateFuelBar()
    {
        fuelLevel = UI_Manager.instance.fuelLevel;
        newSizeDelta.y = Math.Abs(fuelBarFullHeight - (fuelBarChangeAmmount * (100-fuelLevel)));
        fuelBar.GetComponent<RectTransform>().sizeDelta = newSizeDelta;
    }
    


}