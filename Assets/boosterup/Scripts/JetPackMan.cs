using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class JetPackMan : MonoBehaviour
{

    public GameObject GameOver;

    public GameObject me;
    public Camera camera1;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public static float topScore = 0.0f;
    public static float topHighScore = 0.0f;
    public static float heightScore = 0.0f;
    public Rigidbody player;

    public TMP_Text pointText;
    public TMP_Text pointTextTotal;
    public TMP_Text gameoverscoreText;
    public TMP_Text gameoverhighschoreText;
    public static float pointValueTotal = 0.0f;

    public bool isdead = false;
    public GameObject gameOverWall;

    public bool istransporting = false;
    public GameObject leftFire;
    public GameObject rightFire;

    public static int fevermodecount = 0;
    public bool isfever = false;



    //PlayBtn playbtn;
    //public GameObject playBtn;

    void Awake()
    {
        //playbtn = playBtn.GetComponent<PlayBtn>();
    }

    void Start()
    {
        pointValueTotal = PlayerPrefs.GetFloat("pointvaluetotal", 0);
        topHighScore = PlayerPrefs.GetFloat("topHighScore", 0);
        highscoreText.text = "Highscore: " + Mathf.Round(topHighScore).ToString();
        gameoverhighschoreText.text = Mathf.Round(topHighScore).ToString();
        heightScore = 0.0f;
        pointValueTotal = 0.0f;
        fevermodecount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(me.transform.position.y < camera1.transform.position.y - 10 && isdead == false)
        {
            GameOver.SetActive(true);
            player.velocity = Vector3.zero;
            isdead = true;
            player.GetComponent<CapsuleCollider>().isTrigger = false;
            gameOverBG();
        }

        topScore = heightScore * 10 + pointValueTotal;
        Debug.Log(fevermodecount);
        Debug.Log(isfever);
        
        if(player.velocity.y > 0 && transform.position.y > heightScore)
        {
            heightScore = transform.position.y;
        }

        if(topHighScore < topScore)
        {
            PlayerPrefs.SetFloat("topHighScore", Mathf.Round(topScore));
            highscoreText.text = "Highscore: " + Mathf.Round(topScore).ToString();
            gameoverhighschoreText.text = Mathf.Round(topScore).ToString();
        }
    
        scoreText.text = Mathf.Round(topScore).ToString();

        // pointText.text = "Point: " + pointValueTotal;

        // pointTextTotal.text = pointValueTotal.ToString();

        gameoverscoreText.text = Mathf.Round(topScore).ToString();

        PlayerPrefs.SetFloat("pointvaluetotal", pointValueTotal);

        if(istransporting == true)
        {
            StartCoroutine(TurnOffFire());
        }

        if(fevermodecount == 5)
        {
            isfever = true;
            StartCoroutine(FeverModeEnd());
        }
    }

    IEnumerator FeverModeEnd()
     {
         yield return new WaitForSeconds(4);

         fevermodecount = 0;

     }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LeftWall" && isdead == false)
        {
            // GameOver.SetActive(true);
            // player.velocity = Vector3.zero;
            // isdead = true;
            // player.GetComponent<CapsuleCollider>().isTrigger = false;

            Vector3 pos = player.transform.position;
            gameObject.transform.position = new Vector3(pos.x - 9.42f, pos.y, 0);
            istransporting = true;
            
        }

        else if(other.gameObject.tag == "RightWall" && isdead == false)
        {
            Vector3 pos = player.transform.position;
            gameObject.transform.position = new Vector3(pos.x + 9.56f, pos.y, 0);
            istransporting = true;
            
        }

        else if(other.gameObject.tag == "Enemy" && isdead == false)
        {
            GameOver.SetActive(true);
            player.velocity = Vector3.zero;
            isdead = true;
            player.GetComponent<CapsuleCollider>().isTrigger = false;
            gameOverBG();
        }

        else if(other.gameObject.tag == "Wall" && isdead == false)
        {
            GameOver.SetActive(true);
            player.velocity = Vector3.zero;
            isdead = true;
            player.GetComponent<CapsuleCollider>().isTrigger = false;
            gameOverBG();
        }

        else if (other.tag == "Fire")
         return;  
    }

    public void gameOverBG()
    {
        if(player.transform.position.y <= 17)
        {
            Instantiate(gameOverWall, new Vector3(0, player.transform.position.y, 0), Quaternion.identity);
        }
        

        else if(player.transform.position.y > 17)
        {
            Instantiate(gameOverWall, new Vector3(0, player.transform.position.y -10f, 0.9f), Quaternion.identity);
        }
    }


    IEnumerator TurnOffFire()
     {
        leftFire.SetActive(false);
        rightFire.SetActive(false);
        player.GetComponent<CapsuleCollider>().enabled = false;
         yield return new WaitForSeconds(0.2f);

         istransporting = false;
         player.GetComponent<CapsuleCollider>().enabled = true;
     }

}
