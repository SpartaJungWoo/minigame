using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public static gameManager I;
    public GameObject startFire;
    PlayBtn playbtn;
    public GameObject playBtn;
    public bool isTutorial = false;


    // Start is called before the first frame update
    void Awake()
    {
        I = this;
        playbtn = playBtn.GetComponent<PlayBtn>();
    }

    void Start()
    {   
        startFire.SetActive(false);
        Time.timeScale = 1.0f;
        playbtn.touchable = false;
        playbtn.start = false;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    }

    public void initGame()
    {
        Time.timeScale = 1.0f;
    }

    public void retry()
    {
        Addressables.LoadSceneAsync(gameObject.scene.name);
    }

    private void InitCallback ()
    {
    }

    private void OnHideUnity (bool isGameShown)
    {
    }

    

    

}
