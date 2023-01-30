using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text toggleMusictxt;
    public Text toggleFXtxt;

    private void Start()
    {
        if (MusicContinue.BGInstance.Audio.isPlaying)
        {
            toggleMusictxt.text = "ON";
        }
        else
        {
            toggleMusictxt.text = "OFF";
        }

        if (donutSFXManager.sfxInstance.musicToggle == true)
        {
            toggleFXtxt.text = "ON";
        }
        else
        {
            toggleFXtxt.text = "OFF";
        }
    }

    public void SfxToggle()
    {
        if (donutSFXManager.sfxInstance.musicToggle == true)
        {
            donutSFXManager.sfxInstance.musicToggle = false;
            toggleFXtxt.text = "OFF";
        }
        else
        {
            donutSFXManager.sfxInstance.musicToggle = true;
            toggleFXtxt.text = "ON";
        }
    }

    public void MusicToggle()
    {
        if(MusicContinue.BGInstance.Audio.isPlaying)
        {
            MusicContinue.BGInstance.Audio.Pause();
            toggleMusictxt.text = "OFF";
        }
        else
        {
            MusicContinue.BGInstance.Audio.Play();
            toggleMusictxt.text = "ON";
        }
    }

    public void resetdata()
    {
        DonutPangGameManager.I.resetdata();

    }
}
