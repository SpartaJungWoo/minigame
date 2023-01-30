using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void NewGame()
    {
        SceneManager.LoadScene("AriesScene");
    }

    public void LoadGame()
    {
        
        
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }


}
