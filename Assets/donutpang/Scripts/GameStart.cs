using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    public GameObject Startbtn;
    public GameObject Helpbtn;
    public GameObject Title;
    public GameObject Creditsbtn;
    public GameObject CreditsBackground;
    public GameObject Loading;
    public GameObject ResetBG;
    public GameObject Rankingbtn;

    public void PlayGame()
    {
        if (donutSFXManager.sfxInstance.musicToggle == true)
            donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Start);
        PlayerPrefs.DeleteKey("round");
        SceneManager.LoadScene("LevelChoice");
    }

    public void Help()
    {
        SceneManager.LoadScene("Help");
        if (donutSFXManager.sfxInstance.musicToggle == true)
            donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
    }

    public void Main()
    {
        SceneManager.LoadScene("Start");
        if (donutSFXManager.sfxInstance.musicToggle == true)
            donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
    }

    public void Credits()
    {
        Startbtn.SetActive(false);
        Helpbtn.SetActive(false);
        Title.SetActive(false);
        Creditsbtn.SetActive(false);
        Rankingbtn.SetActive(false);
        CreditsBackground.SetActive(true);
        if (donutSFXManager.sfxInstance.musicToggle == true)
            donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
    }

    public void CreditsExit()
    {
        Startbtn.SetActive(true);
        Helpbtn.SetActive(true);
        Title.SetActive(true);
        Creditsbtn.SetActive(true);
        Rankingbtn.SetActive(true);
        CreditsBackground.SetActive(false);
        if (donutSFXManager.sfxInstance.musicToggle == true)
            donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
    }

    public void ResetData()
    {
        ResetBG.SetActive(true);
        CreditsBackground.SetActive(false);
        if (donutSFXManager.sfxInstance.musicToggle == true)
            donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
    }

    public void ResetDataYes()
    {
        DonutPangGameManager.I.resetdata();
        ResetBG.SetActive(false);
        CreditsBackground.SetActive(true);
        if (donutSFXManager.sfxInstance.musicToggle == true)
            donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
    }

    public void ResetDataNo()
    {
        ResetBG.SetActive(false);
        CreditsBackground.SetActive(true);
        if (donutSFXManager.sfxInstance.musicToggle == true)
            donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
    }

}
