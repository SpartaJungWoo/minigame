using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

public class DonutPangGameManager : MonoBehaviour
{
    public GameObject GameOverLine;
    public static DonutPangGameManager I;
    public int totalScore;
    public int totalfinalScore;
    public Text scoreText;
    public GameObject GameOverText;
    public Text finalscoreText;
    public GameObject ResumeBtn;
    public Text highScore;
    public Text finalhighScore;
    public GameObject Canvas;
    public bool isPause = false;
    public GameObject Adbtn;
    public int round = 0;
    public GameObject Retrybtn;
    public GameObject Exitbtn;
    public bool adplayed = false;
    public bool adplayed2 = false;


    private void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        initGame();
        totalScore = PlayerPrefs.GetInt("Adscoretotal", 0);
        totalfinalScore = PlayerPrefs.GetInt("Adscoretotalfinal", 0);
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        finalhighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        scoreText.text = PlayerPrefs.GetInt("Adscoretotal", 0).ToString();
        finalscoreText.text = PlayerPrefs.GetInt("Adscoretotalfinal", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(totalScore > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", totalScore);
            highScore.text = totalScore.ToString();
            finalhighScore.text = totalScore.ToString();
        }

        if(Application.platform == RuntimePlatform.Android)
        {
            if(SceneManager.GetActiveScene().name == "Start")
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    Application.Quit();
                }
            }
            else if(SceneManager.GetActiveScene().name == "GamePlay")
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    pause();
                }
            }
        }
        if (round == 0)
        {
            if (totalScore > 500 & totalScore < 2000)
            {
                if (adplayed == false)
                {
                    adplayed = true;
                }

            }

            if (totalScore > 2000)
            {
                if (adplayed2 == false)
                {
                    adplayed2 = true;
                }
            }
        }
            

        
    }

    public void addScore(int score)
    {

        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    public void addfinalScore(int score)
    {
        totalfinalScore += score;
        finalscoreText.text = totalfinalScore.ToString();

        //CloudOnceServices.instance.SubmitScoreToLedaerboard(totalfinalScore);
        
    }

    public void gameOver()
    {
        if(round == 0)
        {
            GameOverText.SetActive(true);
            Time.timeScale = 0.0f;
            Canvas.SetActive(false);

        }
        else
        {
            Destroy(Adbtn);
            GameOverText.SetActive(true);
            Time.timeScale = 0.0f;
            Canvas.SetActive(false);
            Retrybtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(-137, -262);
            Exitbtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(137, -262);
        }

    }

    public void retry()
    {
        //if (donutSFXManager.sfxInstance.musicToggle == true)
        //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
        Addressables.LoadSceneAsync(gameObject.scene.name);
        PlayerPrefs.DeleteKey("Adscoretotal");
        PlayerPrefs.DeleteKey("Adscoretotalfinal");
        PlayerPrefs.DeleteKey("round");
    }

    void initGame()
    {
        Time.timeScale = 1.0f;
        totalScore = PlayerPrefs.GetInt("Adscoretotal", 0);
        totalfinalScore = PlayerPrefs.GetInt("Adscoretotalfinal", 0);
        round = PlayerPrefs.GetInt("round", 0);
        adplayed = false;
    }

    public void resume()
    {
        //if (donutSFXManager.sfxInstance.musicToggle == true)
        //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
        ResumeBtn.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;

    }

    public void pause()
    {
        //if (donutSFXManager.sfxInstance.musicToggle == true)
        //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
        ResumeBtn.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void exit()
    {
        //if (donutSFXManager.sfxInstance.musicToggle == true)
        //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.Click);
        PlayerPrefs.DeleteKey("Adscoretotal");
        PlayerPrefs.DeleteKey("Adscoretotalfinal");
        PlayerPrefs.DeleteKey("round");
        SceneManager.LoadScene("LobbyScene");
    }

    public void resetdata()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

    public void reGame()
    {
        round = round + 1;
        PlayerPrefs.SetInt("round", round);
        PlayerPrefs.SetInt("Adscoretotal", totalScore);
        PlayerPrefs.SetInt("Adscoretotalfinal", totalfinalScore);
        Addressables.LoadSceneAsync(gameObject.scene.name);
    }
}
