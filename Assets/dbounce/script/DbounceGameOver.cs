using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


public class DbounceGameOver : MonoBehaviour
{
    public int heartcount;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject Home;
    public GameObject End;
    public GameObject onemore;
    public GameObject cleaner;

    //public GameObject Vibmanager;

    

   // public int vibb;
    // Start is called before the first frame update
    void Start()
    {
     //   vibb = PlayerPrefs.GetInt("vibmuted");
        Debug.Log("vvvvvib");
        Debug.Log(PlayerPrefs.GetInt("vibmuted"));
        heartcount = 4;
        // Advertisement.Initialize(4402129, true);
       




    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void vib()
    {

        if (PlayerPrefs.GetInt("vibmuted")==0)
        {
            Handheld.Vibrate();
            Debug.Log("rvibration");
        }
        
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("collision");
       
        if (collision.transform.tag == "hoop")
        {

            Debug.Log(heartcount);
            heartcount = heartcount - 1;
            Debug.Log(heartcount);
            PlayerPrefs.SetInt("Heart", heartcount);
            if (PlayerPrefs.GetInt("Heart", 0) == 3)
            {
                Debug.Log("heat 1");
                vib();
                heart3.SetActive(false);
            }
            if (PlayerPrefs.GetInt("Heart", 0) == 2)
            {
                Debug.Log("heat 2");
                vib();
                heart2.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Heart", 0) == 1)
            {
                Debug.Log("heat 3");
                vib();
                heart1.SetActive(false);
               
                Time.timeScale = 0;
                //Ads.SetActive(true);
                Home.SetActive(true);
                End.SetActive(true);
                //onemore.SetActive(true);



                Debug.Log("game over!!!");
            }

        }

        

    }

   public void reGame()
    {
        Debug.Log("regame");
  
        heartcount = 4;
        Home.SetActive(false);
        End.SetActive(false);
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);

        del();
        
        Time.timeScale = 1;

        

        
    }

    public void del()
    {
        cleaner.SetActive(true);


        Invoke("onclean", 0.1f);

    }
    public void onclean()
    {
        cleaner.SetActive(false);
    }


}
