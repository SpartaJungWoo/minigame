using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panel_sc3 : MonoBehaviour
{

    public Text HStext;
    public Text HCtext;
    public Text SCtext;

    // Start is called before the first frame update
    void Start()

    {//initialize point, coin
       //  PlayerPrefs.SetInt("HighScore", 0);
        // PlayerPrefs.SetInt("HighCoin", 0);
        // PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        HStext.text = "BEST " + PlayerPrefs.GetInt("HighScore");
        HCtext.text = "" + PlayerPrefs.GetInt("HighCoin");
        SCtext.text = "" + PlayerPrefs.GetInt("Score");
    }

    public void retry()
    {

        GameManager.I.retry();

    }

}
