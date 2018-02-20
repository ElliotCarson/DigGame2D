using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvManager : MonoBehaviour {

    public static InvManager instance;

    public Text count_coal_text;
    public Text count_copper_text;
    public Text count_iron_text;
    public Text count_gold_text;
    public Text count_diamond_text;
    public Text count_platnium_text;
    public Text count_uranium_text;

    //public GameObject inv_panel;
    //public Button inv_btn;
    public Button exit_btn;
    private GameObject inv_instance;
    //public Transform main_canvas;
    private bool inv_panel_active = false;

    void Awake()
    {
        if (instance == null)  //there is no instance, the instance will be assigned to this instance
        {                     //if there is an instance, another one will not be created (there will only be one instance)
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        UpdateNums();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateNums()
    {
        count_coal_text.text = PlayerManager.instance.GetOreCount(0).ToString();
        count_copper_text.text = PlayerManager.instance.GetOreCount(1).ToString();
        count_iron_text.text = PlayerManager.instance.GetOreCount(2).ToString();
        count_gold_text.text = PlayerManager.instance.GetOreCount(3).ToString();
        count_diamond_text.text = PlayerManager.instance.GetOreCount(4).ToString();
        count_platnium_text.text = PlayerManager.instance.GetOreCount(5).ToString();
        count_uranium_text.text = PlayerManager.instance.GetOreCount(6).ToString();
    }
    
}
