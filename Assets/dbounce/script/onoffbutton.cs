using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onoffbutton : MonoBehaviour
{
    //public GameObject Ball;


    [SerializeField] Image onIcon;
    [SerializeField] Image offIcon;

    private bool status = true;
    
    // Start is called before the first frame update
    // status = false --> play, on

    void Start()
    {
        
       // if (!PlayerPrefs.HasKey("vibmuted"))
        //{
        //   PlayerPrefs.SetInt("vibmuted", 0);
         //   Load();
       // }
       // else
       // {
       //     Load();
       // }
        UpdateButtonIcon();

        //GameObject.Find("Ball").GetComponent<Ball>().vib = muted;
        // AudioListener.pause = muted;
    }


    public void OnbuttonPress()
    {
        Debug.Log("pause pressed");
        if (status == false)
        {
            status = true;
            Time.timeScale = 1;


            // AudioListener.pause = true;


        }
        else
        {
            status = false;
            Time.timeScale = 0;
            // AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }




    private void UpdateButtonIcon()
    {
        if (status == false)
        {
            onIcon.enabled = true;
            offIcon.enabled = false;
        }
        else
        {
            onIcon.enabled = false;
            offIcon.enabled = true;

        }

    }





    // Update is called once per frame



    private void Load()
    {

        status = PlayerPrefs.GetInt("vibmuted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("vibmuted", status ? 1 : 0);

    }





}
