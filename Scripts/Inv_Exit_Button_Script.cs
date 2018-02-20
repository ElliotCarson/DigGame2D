using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inv_Exit_Button_Script : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        UI_Manager.instance.HideInv();
        Debug.Log("You have clicked the exit inv button!");
    }
}