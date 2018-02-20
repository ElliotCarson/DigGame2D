using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inv_Button_Script : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (!UI_Manager.instance.Is_inv_active())
        {
            UI_Manager.instance.ShowInv();
        }
        //Debug.Log("You have clicked the inv button!");
    }
}