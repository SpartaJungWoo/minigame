using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinGameManager : MonoBehaviour
{
    public static CoinGameManager I;

    private static readonly int TOTAL_COIN_COUNT = 12;

    private static readonly LinkedList<GameObject> CoinList = new LinkedList<GameObject>();

    public GameObject goldCoin;
    public GameObject silverCoin;
    public GameObject goldCoinFull;
    public GameObject silverCoinFull;
    public HpBar healthBar;
    public Text scoreText;
    public List<GameObject> personList;
    public Canvas pauseCanvas;
    public AudioSource gameAudioSource;

    public Canvas gameOverCanvas;
    public Text gameOverTotalAmountLabel;
    public Text gameOverTotalAmountValue;
    public Text gameOverHighScoreLabel;
    public Text gameOverHighScoreValue;


    public AudioSource effectAudioSource;
    public AudioClip effectBtnClick;
    public AudioClip effectBtnStart;
    public AudioClip effectCoinGold;
    public AudioClip effectCoinSilver;
    public AudioClip effectGameOver;

    private float _currentHealth = 100.0f;

    private int _currentScore;

    private int _highScore;
    private bool _isRunning = true;

    private void Awake()
    {
        I = this;

        if (Application.systemLanguage == SystemLanguage.Korean)
        {
        }
        else
        {
             gameOverTotalAmountLabel.text = "SCORE";
            gameOverHighScoreLabel.text = "HIGH";
        }
    }

    private void Start()
    {
        healthBar.SetMaxHealth((int) _currentHealth);
        SetCoin();
    }

    private void Update()
    {
        healthBar.SetHealth((int) _currentHealth);
        if (!_isRunning || _currentScore <= 0) return;

        int damagePerSeconds;
        if (_currentScore <= 5000) damagePerSeconds = 20;
        else if (_currentScore <= 20000) damagePerSeconds = 30;
        else if (_currentScore <= 20000) damagePerSeconds = 35;
        else if (_currentScore <= 30000) damagePerSeconds = 40;
        else if (_currentScore <= 40000) damagePerSeconds = 42;
        else if (_currentScore <= 50000) damagePerSeconds = 45;
        else if (_currentScore <= 60000) damagePerSeconds = 48;
        else if (_currentScore <= 70000) damagePerSeconds = 53;
        else if (_currentScore <= 80000) damagePerSeconds = 56;
        else if (_currentScore <= 90000) damagePerSeconds = 60;
        else damagePerSeconds = 65;
        _currentHealth -= damagePerSeconds * Time.deltaTime;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            DoGameOver();
        }
    }

    private void PlayMusic(string action)
    {
        switch (action)
        {
            case "BTN_CLICK":
                effectAudioSource.clip = effectBtnClick;
                break;
            case "BTN_START":
                effectAudioSource.clip = effectBtnStart;
                break;
            case "COIN_GOLD":
                effectAudioSource.clip = effectCoinGold;
                break;
            case "COIN_SILVER":
                effectAudioSource.clip = effectCoinSilver;
                break;
            case "GAME_OVER":
                effectAudioSource.clip = effectGameOver;
                break;
        }

        effectAudioSource.Play();
    }

    private void SetCoin()
    {
        var remainCoinCount = TOTAL_COIN_COUNT - CoinList.Count;
        for (var i = 0; i < remainCoinCount; i++)
        {
            GameObject coin;
            double prob = Random.Range(0.0f, 100.0f);
            if (prob < 0.25)
                coin = Instantiate(goldCoinFull);
            else if (prob < 0.5)
                coin = Instantiate(silverCoinFull);
            else if (prob < 41)
                coin = Instantiate(goldCoin);
            else
                coin = Instantiate(silverCoin);

            CoinList.AddFirst(coin);
        }

        var yPos = -1.14f;
        var sortingOrder = 100;
        var scale = 0.40f - 0.01f * TOTAL_COIN_COUNT;
        foreach (var coin in CoinList)
        {
            var targetPos = new Vector3(-0.06f, yPos, 0);
            if (coin.GetComponent<Transform>().position == new Vector3(0.0f, 0.0f, 0.0f))
            {
                coin.GetComponent<Transform>().position = targetPos;
                coin.GetComponent<Transform>().localScale = new Vector3(scale, scale, 1);
            }
            else
            {
                coin.GetComponent<Coin>().SetTarget(targetPos, new Vector3(scale, scale, 1));
            }

            coin.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
            yPos -= 0.27f;
            sortingOrder++;
            scale += 0.02f;
        }
    }

    public bool IsMatched(string coinName)
    {
        return CoinList.Last.Value.gameObject.CompareTag(coinName);
    }

    public void RemoveCoin()
    {
        _isRunning = true;
        Time.timeScale = 1.0f;
        var moveTarget = Vector3.zero;
        if (CoinList.Last.Value.gameObject.CompareTag("GoldCoin"))
        {
            PlayMusic("COIN_GOLD");
            _currentScore += 500;
            moveTarget = new Vector3(-3.6f, -4.11f, 0);
        }
        else if (CoinList.Last.Value.gameObject.CompareTag("SilverCoin"))
        {
            PlayMusic("COIN_SILVER");
            _currentScore += 100;
            moveTarget = new Vector3(3.54f, -4.11f, 0);
        }
        else if (CoinList.Last.Value.gameObject.CompareTag("GoldCoinFull"))
        {
            PlayMusic("COIN_GOLD");
            _currentScore += 500;
            moveTarget = new Vector3(-3.6f, -4.11f, 0);
            _currentHealth = 100;
        }
        else if (CoinList.Last.Value.gameObject.CompareTag("SilverCoinFull"))
        {
            PlayMusic("COIN_SILVER");
            _currentScore += 100;
            moveTarget = new Vector3(3.54f, -4.11f, 0);
            _currentHealth = 100;
        }

        scoreText.text = _currentScore.ToString();

        CoinList.Last.Value.GetComponent<Coin>().SetTarget(moveTarget, new Vector3(0.5f, 0.5f, 1));
        CoinList.Last.Value.GetComponent<Coin>().speed = 1.0f;
        CoinList.Last.Value.GetComponent<Coin>().destoryAfterMove = true;
        CoinList.Last.Value.GetComponent<SpriteRenderer>().sortingOrder = 1000;
        CoinList.RemoveLast();

        SetCoin();
        int addHealth;
        if (_currentScore <= 10000) addHealth = 30;
        else if (_currentScore <= 20000) addHealth = 27;
        else if (_currentScore <= 30000) addHealth = 25;
        else if (_currentScore <= 40000) addHealth = 23;
        else if (_currentScore <= 50000) addHealth = 21;
        else if (_currentScore <= 60000) addHealth = 18;
        else if (_currentScore <= 70000) addHealth = 16;
        else if (_currentScore <= 80000) addHealth = 14;
        else if (_currentScore <= 90000) addHealth = 12;
        else addHealth = 10;
        _currentHealth = Mathf.Min(100.0f, _currentHealth + addHealth);

        if (_currentScore >= 10000 && personList[0].gameObject.activeSelf == false)
            personList[0].gameObject.SetActive(true);
        if (_currentScore >= 20000 && personList[1].gameObject.activeSelf == false)
            personList[1].gameObject.SetActive(true);
        if (_currentScore >= 30000 && personList[2].gameObject.activeSelf == false)
            personList[2].gameObject.SetActive(true);
        if (_currentScore >= 40000 && personList[3].gameObject.activeSelf == false)
            personList[3].gameObject.SetActive(true);
        if (_currentScore >= 50000 && personList[4].gameObject.activeSelf == false)
            personList[4].gameObject.SetActive(true);
        if (_currentScore >= 60000 && personList[5].gameObject.activeSelf == false)
            personList[5].gameObject.SetActive(true);
        if (_currentScore >= 70000 && personList[6].gameObject.activeSelf == false)
            personList[6].gameObject.SetActive(true);
    }

    public void TogglePause()
    {
        PlayMusic("BTN_CLICK");

        if (!pauseCanvas.gameObject.activeSelf)
        {
            pauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
            gameAudioSource.Pause();
            _isRunning = false;
        }
        else
        {
            pauseCanvas.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
            // SceneManager.LoadScene("GameScene");
            gameAudioSource.UnPause();
            _isRunning = true;
        }
    }

    public void Wrong()
    {
        Vibration.Vibrate(1000);
        _currentHealth = (int) Mathf.Max(0, _currentHealth - 40);

        if (_currentHealth == 0) DoGameOver();
    }

    public void DoGameOver()
    {
        PlayMusic("GAME_OVER");
        gameAudioSource.Stop();
        gameOverCanvas.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        _isRunning = false;
        gameOverTotalAmountValue.text = string.Format("{0:n0}", _currentScore);
        Vibration.Vibrate(1000);

        _highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (_currentScore > _highScore)
        {
            _highScore = _currentScore;
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
        else
        {
        }

        gameOverHighScoreValue.text = string.Format("{0:n0}", _highScore);
    }

    public void DoResetGame()
    {
        Time.timeScale = 1.0f;
        foreach (var coin in CoinList) Destroy(coin);

        CoinList.Clear();
        Addressables.LoadSceneAsync(gameObject.scene.name);
    }

    public void DoGotoOpeningScene()
    {
        Time.timeScale = 1.0f;
        foreach (var coin in CoinList) Destroy(coin);

        CoinList.Clear();
        SceneManager.LoadScene("LobbyScene");
    }

    public void ReGame()
    {
        PlayMusic("BTN_START");
        gameAudioSource.Play();
        gameOverCanvas.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        Time.timeScale = 1.0f;
        _currentHealth = 100.0f;
        _isRunning = false;
    }
}