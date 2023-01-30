using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setsound2 : MonoBehaviour
{


    [SerializeField] Image soundonIcon;
    [SerializeField] Image soundoffIcon;
    private bool muted ;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Scene2");
        Debug.Log(PlayerPrefs.HasKey("muted"));
        Debug.Log(PlayerPrefs.GetInt("muted"));

        //haskey : 키값 존재 유무만 확인.

        if(PlayerPrefs.GetInt("muted") == 0)
        { 
            AudioListener.pause = false;
            Debug.Log("s2_true");
        }

        if(PlayerPrefs.GetInt("muted") == 1)
        { 
            AudioListener.pause = true;
            Debug.Log("s2_false");
        }
        UpdateButtonIcon();

    }

   
    private void UpdateButtonIcon()
    {
        if (PlayerPrefs.GetInt("muted") == 0)
        {
            Debug.Log("2update_On");
            soundonIcon.enabled = true;
            soundoffIcon.enabled = false;
        }
        else
        {
            Debug.Log("2update_OFF");
            soundonIcon.enabled = false;
            soundoffIcon.enabled = true;

        }

    }

    // Update is called once per frame



    private void Load()
    {

        muted = PlayerPrefs.GetInt("muted") == 1;

    }


    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);

    }





    public void OnbuttonPress()
    {
        if (PlayerPrefs.GetInt("muted") == 0)
        {
            muted = true;
            AudioListener.pause = true;
            Debug.Log("s_OFF");

        }
        else
        {
            muted = false;
            AudioListener.pause = false;
            Debug.Log("s_ON");
        }

        Save();
        UpdateButtonIcon();
    }




}
