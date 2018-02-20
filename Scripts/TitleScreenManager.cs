using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour {

    public void PlayScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void OptionsScene()
    {
        SceneManager.LoadScene("OptionsScene");
    }

}
