using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    public bool finish = true;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadGame", 4);
    }

    public void LoadGame()
    {
        finish = false;
        SceneManager.LoadScene("GamePlay");
    }
}
