using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningCanvas_Startbutton : MonoBehaviour
{
    public void OnClick()
    {
        if (PlayerPrefs.GetString("LastTutorialDate", "") != DateTime.Now.ToString("yyyyMMdd"))
        {
            PlayerPrefs.SetString("LastTutorialDate", DateTime.Now.ToString("yyyyMMdd"));
            SceneManager.LoadScene("TutorialScene");
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}