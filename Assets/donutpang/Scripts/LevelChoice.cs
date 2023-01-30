using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChoice : MonoBehaviour
{

    public GameObject Popup;
    public GameObject Easymode;
    public GameObject Hardmode;
    public GameObject ExitBtn;
    public GameObject EasyInfo;
    public GameObject HardInfo;
    public GameObject Ready;
    
    public void EasyMode()
    {
        if (donutSFXManager.sfxInstance.musicToggle == true)
            donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Start);
        SceneManager.LoadScene("Loading");

    }

    public void HardMode()
    {
        if (donutSFXManager.sfxInstance.musicToggle == true)
            donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
        Easymode.SetActive(false);
        Hardmode.SetActive(false);
        ExitBtn.SetActive(false);
        EasyInfo.SetActive(false);
        HardInfo.SetActive(false);
        Ready.SetActive(false);
        Popup.SetActive(true);

    }

    public void PopupClose()
    {
        Easymode.SetActive(true);
        Hardmode.SetActive(true);
        ExitBtn.SetActive(true);
        EasyInfo.SetActive(true);
        HardInfo.SetActive(true);
        Ready.SetActive(true);
        Popup.SetActive(false);
        if (donutSFXManager.sfxInstance.musicToggle == true)
            donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
    }

    public void BacktoStart()
    {
        if (donutSFXManager.sfxInstance.musicToggle == true)
            donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
        SceneManager.LoadScene("Start");
    }
}
