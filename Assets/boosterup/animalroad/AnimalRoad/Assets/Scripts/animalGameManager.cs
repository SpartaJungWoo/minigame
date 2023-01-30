using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;


public class animalGameManager : MonoBehaviour
{
    public GameObject startPanel, endPanel, muteImage, reviveButton;
    public TextMeshProUGUI scoreText, highScoreText, endScoreText, endHighScoreText, comboText;


    //private int animalIndex;
    //private List<string> animationList = new List<string> {
    //                                                          "Attack",
    //                                                          "Bounce",
    //                                                          "Clicked",
    //                                                          "Death",
    //                                                          "Eat",
    //                                                          "Fear",
    //                                                          "Fly",
    //                                                          "Hit",
    //                                                          "Idle_A", "Idle_B", "Idle_C",
    //                                                          "Jump",
    //                                                          "Roll",
    //                                                          "Run",
    //                                                          "Sit",
    //                                                          "Spin/Splash",
    //                                                          "Swim",
    //                                                          "Walk"
    //                                                        };
    //private List<string> facialExpList = new List<string> {
    //                                                          "Eyes_Annoyed",
    //                                                          "Eyes_Blink",
    //                                                          "Eyes_Cry",
    //                                                          "Eyes_Dead",
    //                                                          "Eyes_Excited",
    //                                                          "Eyes_Happy",
    //                                                          "Eyes_LookDown",
    //                                                          "Eyes_LookIn",
    //                                                          "Eyes_LookOut",
    //                                                          "Eyes_LookUp",
    //                                                          "Eyes_Rabid",
    //                                                          "Eyes_Sad",
    //                                                          "Eyes_Shrink",
    //                                                          "Eyes_Sleep",
    //                                                          "Eyes_Spin",
    //                                                          "Eyes_Squint",
    //                                                          "Eyes_Trauma",
    //                                                          "Sweat_L",
    //                                                          "Sweat_R",
    //                                                          "Teardrop_L",
    //                                                          "Teardrop_R"
    //                                                        };

    //public Transform animal_parent;

    [SerializeField]
    //private GameObject[] animal;


    [HideInInspector]
    public bool gameIsOver = false;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void InitCallback()
    {

    }

    private void OnHideUnity(bool isGameShown)
    {
    }

    void Start()
    {
        //UNCOMMENT THE FOLLOWING LINES IF YOU ENABLED UNITY ADS AT UNITY SERVICES AND REOPENED THE PROJECT!
        //if (FindObjectOfType<AdManager>().unityAds)
        //    CallUnityAds();     //Calls Unity Ads
        //else
        //CallAdmobAds();     //Calls Admob Ads

        StartPanelActivation();
        Initialize();


        //CharacterInitialize();
        //HighScoreCheck();
        //AudioCheck();

    }

    //UNCOMMENT THE FOLLOWING LINES IF YOU ENABLED UNITY ADS AT UNITY SERVICES AND REOPENED THE PROJECT!
    //public void CallUnityAds()
    //{
    //    if (Time.time != Time.timeSinceLevelLoad)
    //        FindObjectOfType<AdManager>().ShowUnityVideoAd();      //Shows Interstitial Ad when game starts (except for the first time)
    //    FindObjectOfType<AdManager>().HideAdmobBanner();
    //}



    public void Initialize()
    {
        //comboText.enabled = false;
        CinemachineShake.Instance.ShakeCamera(0f, 0f);
        scoreText.enabled = false;
        FindObjectOfType<FollowPath>().enabled = false;
        FindObjectOfType<Spawner>().enabled = false;
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().enabled = false;
        //FindObjectOfType<CharacterChange>().enabled = false;
        //int count = animal_parent.childCount;
        //animal = new GameObject[count];
        //player.GetComponent<m_Parameters.colorGradient> = GameObject.FindGameObjectWithTag("Player").GetComponent<Color>;
    }

    //public void CharacterInitialize()
    //{
    //    int count = animal_parent.childCount;
    //    animal = new GameObject[count];
    //    List<string> animalList = new List<string>();

    //    for (int i = 0; i < count; i++)
    //    {
    //        animal[i] = animal_parent.GetChild(i).gameObject;
    //        string n = animal_parent.GetChild(i).name;
    //        animalList.Add(n);
    //        // animalList.Add(n.Substring(0, n.IndexOf("_")));

    //        if (i == 0) animal[i].SetActive(true);
    //        else animal[i].SetActive(false);
    //    }
    //    //dropdownAnimal.AddOptions(animalList);
    //    //dropdownAnimation.AddOptions(animationList);
    //    //dropdownFacialExp.AddOptions(facialExpList);
    //    //dropdownFacialExp.value = 1;
    //    FindObjectOfType<CharacterChange>().ChangeExpression();

    //    //Bounds b = animal[0].transform.GetChild(0).GetChild(0).GetComponent<Renderer>().bounds;
    //}


    public void StartPanelActivation()
    {
        startPanel.SetActive(true);
        endPanel.SetActive(false);
    }

    public void EndPanelActivation()
    {
        gameIsOver = true;
        //FindObjectOfType<AudioManager>().DeathSound();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ParticleSystem>().Play();
        startPanel.SetActive(false);
        endPanel.SetActive(true);
        comboText.enabled = false;
        scoreText.enabled = false;
        endScoreText.text = scoreText.text;
        //HighScoreCheck();
    }

    //public void HighScoreCheck()
    //{
    //    if (FindObjectOfType<ScoreManager>().score > PlayerPrefs.GetInt("HighScore", 0))
    //    {
    //        PlayerPrefs.SetInt("HighScore", FindObjectOfType<ScoreManager>().score);
    //    }
    //    //highScoreText.text = "BEST " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    //    //endHighScoreText.text = "BEST " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    //}

    //public void AudioCheck()
    //{
    //    if (PlayerPrefs.GetInt("Audio", 0) == 0)
    //    {
    //        muteImage.SetActive(false);
    //        //FindObjectOfType<AudioManager>().soundIsOn = true;
    //        //FindObjectOfType<AudioManager>().PlayBackgroundMusic();
    //    }
    //    else
    //    {
    //        muteImage.SetActive(true);
    //        //FindObjectOfType<AudioManager>().soundIsOn = false;
    //        //FindObjectOfType<AudioManager>().StopBackgroundMusic();
    //    }
    //}

    public void StartButton()
    {
        //comboText.enabled = true;
        FindObjectOfType<CharacterChange>().dropdownAnimation.value = 13;
        FindObjectOfType<CharacterChange>().ChangeAnimation();

        scoreText.enabled = true;
        startPanel.SetActive(false);
        //FindObjectOfType<AudioManager>().ButtonClickSound();
        FindObjectOfType<FollowPath>().enabled = true;
        FindObjectOfType<Spawner>().enabled = true;
        //FindObjectOfType<CharacterChange>().enabled = true;
    }

    public void RestartButton()
    {
        //FindObjectOfType<AudioManager>().ButtonClickSound();
        Addressables.LoadSceneAsync(gameObject.scene.name);
    }



    //public void AudioButton()
    //{
    //    //FindObjectOfType<AudioManager>().ButtonClickSound();
    //    if (PlayerPrefs.GetInt("Audio", 0) == 0)
    //        PlayerPrefs.SetInt("Audio", 1);
    //    else
    //        PlayerPrefs.SetInt("Audio", 0);
    //    //AudioCheck();

    public void Home()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void Revive()
    {
        //UNCOMMENT THE FOLLOWING LINES IF YOU ENABLED UNITY ADS AT UNITY SERVICES AND REOPENED THE PROJECT!
        //if (FindObjectOfType<AdManager>().unityAds)
        //    FindObjectOfType<AdManager>().ShowUnityRewardVideoAd();       //Shows Unity Reward Video ad
        //else
        //FindObjectOfType<AdManager>().ShowAdmobRewardVideo();       //Shows Admob Reward Video ad

        endPanel.SetActive(false);
        reviveButton.SetActive(false);
        //comboText.enabled = true;
        scoreText.enabled = true;

        gameIsOver = false;
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().enabled = false;

        FindObjectOfType<Collision>().Revive();
    }

    //public void FixedUpdate()
    //{
    //    CinemachineShake.Instance.ShakeCamera(0f, 0f);
    //}
}
