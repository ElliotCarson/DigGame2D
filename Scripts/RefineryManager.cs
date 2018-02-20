using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefineryManager : MonoBehaviour {

    public RefineryManager instance;

    public Text countCoalText;
    public Text countCopperText;
    public Text countIronText;
    public Text countGoldText;
    public Text countDiamondText;
    public Text countPlatniumText;
    public Text countUraniumText;
    public Text moneyText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        UpdateTextNums();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

    void UpdateTextNums()
    {
        countCoalText.text = PlayerManager.instance.GetOreCount(0).ToString();
        countCopperText.text = PlayerManager.instance.GetOreCount(1).ToString();
        countIronText.text = PlayerManager.instance.GetOreCount(2).ToString();
        countGoldText.text = PlayerManager.instance.GetOreCount(3).ToString();
        countDiamondText.text = PlayerManager.instance.GetOreCount(4).ToString();
        countPlatniumText.text = PlayerManager.instance.GetOreCount(5).ToString();
        countUraniumText.text = PlayerManager.instance.GetOreCount(6).ToString();
        moneyText.text = "$" + PlayerManager.instance.GetMoney().ToString();
    }

    public void SellButtonClicked(int btnNum)
    {
        switch (btnNum)
        {
            case 0://Coal
                //if coal != 0
                if (PlayerManager.instance.HasOre(btnNum))
                {
                    PlayerManager.instance.SellOre(btnNum);
                    UpdateTextNums();

                }
                //PlayerManager.instance.SellOre(0) [this deincrements the ore and adds the appropriate ammount of money
                break;
            case 1://Copper
                if (PlayerManager.instance.HasOre(btnNum))
                {
                    PlayerManager.instance.SellOre(btnNum);
                    UpdateTextNums();
                }
                break;
            case 2://Iron
                if (PlayerManager.instance.HasOre(btnNum))
                {
                    PlayerManager.instance.SellOre(btnNum);
                    UpdateTextNums();
                }
                break;
            case 3://Gold
                if (PlayerManager.instance.HasOre(btnNum))
                {
                    PlayerManager.instance.SellOre(btnNum);
                    UpdateTextNums();
                }
                break;
            case 4://Diamond
                if (PlayerManager.instance.HasOre(btnNum))
                {
                    PlayerManager.instance.SellOre(btnNum);
                    UpdateTextNums();
                }
                break;
            case 5://Platnium
                if (PlayerManager.instance.HasOre(btnNum))
                {
                    PlayerManager.instance.SellOre(btnNum);
                    UpdateTextNums();
                }
                break;
            case 6://Uranium
                if (PlayerManager.instance.HasOre(btnNum))
                {
                    PlayerManager.instance.SellOre(btnNum);
                    UpdateTextNums();
                }
                break;
        }


    }

    public void Exit()
    {
        UI_Manager.instance.CloseRefinery();
    }

}
