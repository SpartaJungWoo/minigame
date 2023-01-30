using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicContinue : MonoBehaviour
{
    public static MusicContinue BGInstance;
    public AudioSource Audio;
    public bool musicToggle = true;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        if(BGInstance !=null && BGInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        BGInstance = this;
        DontDestroyOnLoad(this);
    }

    
}
