using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public TextMeshProUGUI scoreText, tokenText, bonusScoreText, bonusScoreText2, comboText;
    public string[] bonusTexts = new string[] { "Amazing", "Nice shot", "Rampage", "Great one", "Fantastic", "Unbelievable", "Great", "Nice", "Impressive", "Good job!", "Well done!", "Unstoppable", "Phenomenal" };      //You can add new texts here

    private Animation scoreTextAnim, tokenTextAnim, bonusScoreTextAnim, bonusScoreTextAnim2, comboTextAnim;

    [HideInInspector]
    public int score = 0;
    public int combo = 0;

    void Awake()
    {
        tokenText.text = PlayerPrefs.GetInt("Token", 0).ToString();     //Writes out the number of tokens to the screen        
    }

    void Start()
    {
        //Initializations
        scoreTextAnim = scoreText.GetComponent<Animation>();
        comboTextAnim = comboText.GetComponent<Animation>();
        tokenTextAnim = tokenText.GetComponent<Animation>();
        bonusScoreTextAnim = bonusScoreText.GetComponent<Animation>();
        bonusScoreTextAnim2 = bonusScoreText2.GetComponent<Animation>();
        Invoke("IncrementScore", 0.1f);     //Starts to increase the score
    }

    public void IncrementScore(int value)       //Increments score by a given value and there is a congratulation text (Collision script calls this function)
    {
        if (!FindObjectOfType<Collision>().gameIsOver)
        {
            score += (value + combo*10);
            scoreText.text = score.ToString();
            //tokenTextAnim.Play();
            scoreTextAnim.Play();
            bonusScoreText.text = bonusTexts[Random.Range(0, bonusTexts.Length)].ToString() + "\n+ " + (value + combo * 10).ToString();
            bonusScoreTextAnim.Play();
            //FindObjectOfType<AudioManager>().ScoreSound();
        }
    }

    public void IncrementScore(int value, int text)       //Increments score by a given value and there can be a congratulation text (Collision script calls this function)
    {
        if (!FindObjectOfType<Collision>().gameIsOver)
        {
            combo += value;
            comboText.text = "combo bonus:" +(combo*10).ToString() ;
            comboTextAnim.Play();
            bonusScoreText.text = bonusTexts[Random.Range(0, bonusTexts.Length)].ToString() + "\n+ " + combo.ToString() + "combo";
            bonusScoreTextAnim.Play();

            //bonusScoreText2.text = value.ToString();
            //bonusScoreTextAnim2.Play();
            //FindObjectOfType<AudioManager>().ScoreSound();
        }
    }

    public void IncrementScore()        //Increments score by one after every x seconds automatically
    {
        if (!FindObjectOfType<Collision>().gameIsOver)
        {
            //score++;
            scoreText.text = score.ToString();
            
            Invoke("IncrementScore", 0.1f);
        }
    }

    public void IncrementToken()
    {
        if (FindObjectOfType<animalGameManager>().gameIsOver == false)       //If the game is not over
        {
            PlayerPrefs.SetInt("Token", PlayerPrefs.GetInt("Token", 0) + 1);        //Increases the number of tokens
            tokenText.text = PlayerPrefs.GetInt("Token", 0).ToString();     //Writes out the number of tokens to the screen
            tokenTextAnim.Play();       //Plays tokenTextAnim
            //FindObjectOfType<AudioManager>().TokenSound();      //Plays tokenSound
        }
    }

    public void IncrementToken(int countOfToken)
    {
        if (FindObjectOfType<animalGameManager>().gameIsOver == false)       //If the game is not over
        {
            PlayerPrefs.SetInt("Token", PlayerPrefs.GetInt("Token", 0) + countOfToken);        //Increases the number of tokens
            tokenText.text = PlayerPrefs.GetInt("Token", 0).ToString();     //Writes out the number of tokens to the screen
            tokenTextAnim.Play();       //Plays tokenTextAnim
            //FindObjectOfType<AudioManager>().TokenSound();      //Plays tokenSound
        }
    }

    public void DecrementToken(int decreaseValue)
    {
        PlayerPrefs.SetInt("Token", PlayerPrefs.GetInt("Token", 0) - decreaseValue);        //Decreases the number of tokens by decreaseValue
        tokenText.text = PlayerPrefs.GetInt("Token", 0).ToString();     //Writes out the number of tokens to the screen
    }
}
