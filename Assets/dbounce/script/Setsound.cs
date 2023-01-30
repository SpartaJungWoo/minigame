using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setsound : MonoBehaviour
{


    [SerializeField] Image soundonIcon;
    [SerializeField] Image soundoffIcon;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Scene1");
        Debug.Log(PlayerPrefs.HasKey("muted"));
        Debug.Log(PlayerPrefs.GetInt("muted"));

        //haskey : 키값 존재 유무만 확인.
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Debug.Log("muted_OFF");
            Load();
        }
        else
        {
            //키값 있으면 들어와서 로드.
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }


    public void OnbuttonPress()
    {
        if (muted == false)
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




    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            Debug.Log("update_On");
            soundonIcon.enabled = true;
            soundoffIcon.enabled = false;
        }
        else
        {
            Debug.Log("update_OFF");
            soundonIcon.enabled = false;
            soundoffIcon.enabled = true;

        }

    }

   

   

    // Update is called once per frame
    


    private void Load()
    {

        muted = PlayerPrefs.GetInt("muted") == 1;
        Debug.Log("muted=1");
        
    }

    
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
        
    }




    
}
