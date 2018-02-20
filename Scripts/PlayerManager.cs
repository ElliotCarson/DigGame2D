using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    public GameObject player;
    Vector2 player_pos;
    Dictionary<string, int> inv;
    private int money = 50;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        InvDictInit();
        player_pos.x = 3;
        player_pos.y = (float)5.5;
        //Initial spawn for player
        Instantiate(player, player_pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InvDictInit()
    {
        inv = new Dictionary<string, int>();
        inv.Add("coal", 0);
        inv.Add("copper", 0);
        inv.Add("iron", 0);
        inv.Add("gold", 0);
        inv.Add("diamond", 0);
        inv.Add("platnium", 0);
        inv.Add("uranium", 0);
    }

    public int GetMoney()
    {
        return money;
    }

    public bool HasOre(int oreType)
    {
        switch (oreType)
        {
            case 0:
                if (inv["coal"] == 0)
                {
                    return false;
                }
                break;
            case 1:
                if (inv["copper"] == 0)
                {
                    return false;
                }
                break;
            case 2:
                if (inv["iron"] == 0)
                {
                    return false;
                }
                break;
            case 3:
                if (inv["gold"] == 0)
                {
                    return false;
                }
                break;
            case 4:
                if (inv["diamond"] == 0)
                {
                    return false;
                }
                break;
            case 5:
                if (inv["platnium"] == 0)
                {
                    return false;
                }
                break;
            case 6:
                if (inv["uranium"] == 0)
                {
                    return false;
                }
                break;
        }
        return true;
    }

    public void SellOre(int oreType)
    {
        /* Ore          Value
         * ----------------------
         * Coal         $1
         * Copper       $3
         * Iron         $5
         * Gold         $10
         * Diamond      $20
         * Platnium     $40
         * Uranium      $50
        */
        switch (oreType)
        {
            case 0:
                inv["coal"]--;
                money++;
                break;
            case 1:
                inv["copper"]--;
                money += 3;
                break;
            case 2:
                inv["iron"]--;
                money += 5;
                break;
            case 3:
                inv["gold"]--;
                money += 10;
                break;
            case 4:
                inv["diamond"]--;
                money += 20;
                break;
            case 5:
                inv["platnium"]--;
                money += 40;
                break;
            case 6:
                inv["uranium"]--;
                money += 50;
                break;
        }
    }

    public void IncrementOre(int oreType)
    {
        switch (oreType)
        {
            case 0:
                inv["coal"]++;
                Debug.Log(("PlayerManager: Incrementing Coal. Current Coal = " + inv["coal"].ToString()));
                break;
            case 1:
                inv["copper"]++;
                Debug.Log(("PlayerManager: Incrementing Copper. Current Copper = " + inv["copper"].ToString()));
                break;
            case 2:
                inv["iron"]++;
                Debug.Log(("PlayerManager: Incrementing Iron. Current Iron = " + inv["iron"].ToString()));
                break;
            case 3:
                inv["gold"]++;
                break;
            case 4:
                inv["diamond"]++;
                break;
            case 5:
                inv["platnium"]++;
                break;
            case 6:
                inv["uranium"]++;
                break;
        }
    }

    public int GetOreCount(int oreType)
    {
        switch (oreType)
        {
            case 0:
                return inv["coal"];
            case 1:
                return inv["copper"];
            case 2:
                return inv["iron"];
            case 3:
                return inv["gold"];
            case 4:
                return inv["diamond"];
            case 5:
                return inv["platnium"];
            case 6:
                return inv["uranium"];
            default:
                return -1;
        }
    }

    public void SpendMoney(int ammount)
    {
        money -= ammount;
    }

}
