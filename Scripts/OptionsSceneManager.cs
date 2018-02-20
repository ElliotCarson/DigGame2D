using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsSceneManager : MonoBehaviour {
    
    public void TitleScene()
    {
        Debug.Log("TitleScene Loading");
        SceneManager.LoadScene("TitleScene");
    }
}
