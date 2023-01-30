using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudOnceServices : MonoBehaviour
{
    public static CloudOnceServices instance;

    private void Awake()
    {
        TestSingleton();
    }

    private void TestSingleton()
    {
        if(instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SubmitScoreToLedaerboard(int score)
    {
    }
}
