using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip Boost;

    public AudioClip Click;

    public AudioClip Kill;

    public AudioClip Killed;


    public static SFXManager sfxInstance;

    public bool musicToggle = true;



    private void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
