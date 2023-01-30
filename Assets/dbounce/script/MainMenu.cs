using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Retry()
    {
        SceneManager.LoadScene("Game");

    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    //option 매뉴 이동은 코드없이 이동이 가능하다. 
}
