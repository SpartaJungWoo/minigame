using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBtn : MonoBehaviour
{

    public GameObject playBtn;
    public GameObject myPageBtn;
    public GameObject settingsBtn;
    //public GameObject pointBoard;
    public GameObject logo;
    public Rigidbody rigid;
    public bool start = false;
    public bool touchable = false;
    public GameObject QuestionMark;
    
    
    public float startForce = 5000f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        start = true;
        touchable = true;
        gameManager.I.initGame();
        playBtn.SetActive(false);
        myPageBtn.SetActive(false);
        settingsBtn.SetActive(false);
        //pointBoard.SetActive(true);
        logo.SetActive(false);
        rigid.AddForce(0,startForce,0);
        rigid.GetComponent<Animator>().Play("Up");
        QuestionMark.SetActive(false);
    }
}
