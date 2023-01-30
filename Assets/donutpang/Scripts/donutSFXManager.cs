using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donutSFXManager : MonoBehaviour
{

    public AudioSource Audio;

    public AudioClip Click;

    public AudioClip Start;

    public AudioClip pop1;

    public AudioClip pop2;

    public AudioClip pop3;

    public AudioClip shoot;

    public static donutSFXManager sfxInstance;

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
