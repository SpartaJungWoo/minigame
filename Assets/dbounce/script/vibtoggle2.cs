using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vibtoggle2 : MonoBehaviour
{
    public GameObject Ball;


    [SerializeField] Image vibonIcon;
    [SerializeField] Image viboffIcon;

    private bool vibmuted;
    // Start is called before the first frame update

    void Start()
    {

        if (PlayerPrefs.GetInt("vibmuted") == 1)
        {
           
            Debug.Log("s2_true");
        }

        if (PlayerPrefs.GetInt("vibmuted") == 0)
        {
            
            Debug.Log("s2_false");
        }
        UpdateButtonIcon();
    }


    public void OnbuttonPress()
    {

        if (PlayerPrefs.GetInt("vibmuted") == 0)
        {
            //make off vib
            vibmuted = true;
            PlayerPrefs.GetInt("vibmuted", 1);
            Debug.Log("vibmuted1");


        }
        else
        {
            //make on vib
            vibmuted = false;
            PlayerPrefs.GetInt("vibmuted", 0);
            Debug.Log("vibon0");
            // AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
        // vib();

    }




    private void UpdateButtonIcon()
    {
        if (PlayerPrefs.GetInt("vibmuted") == 0)
        {
            vibonIcon.enabled = true;
            viboffIcon.enabled = false;
        }
        else
        {
            vibonIcon.enabled = false;
            viboffIcon.enabled = true;

        }

    }





    // Update is called once per frame



    
    private void Save()
    {
        PlayerPrefs.SetInt("vibmuted", vibmuted ? 1 : 0);

    }




}
