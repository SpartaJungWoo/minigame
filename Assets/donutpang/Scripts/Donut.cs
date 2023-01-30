using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{

    public int ballNo;
    int score;

    public GameObject D1;
    public GameObject D2;
    public GameObject D3;
    public GameObject D4;
    public GameObject D5;
    public GameObject D6;
    public GameObject D7;
    public GameObject D8;
    public GameObject D9;
    public GameObject D010;
    public GameObject Explosion;
    public int point;
    public GameObject NextObject;
    public bool nod1 = false;



    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (gameObject.name.Contains("D1"))
        {
            if (coll.gameObject.tag == "D1")
            {
                if (coll.gameObject.GetComponent<Donut>().ballNo > ballNo)
                {
                    //if (donutSFXManager.sfxInstance.musicToggle == true)
                    //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.pop1);
                    PlayExplosion();
                    Destroy(coll.gameObject);
                    Debug.Log("D1");
                    CollideAction();
                }

            }
        }

        else if (gameObject.name.Contains("D2"))
        {
            if (coll.gameObject.tag == "D2")
            {
                if (coll.gameObject.GetComponent<Donut>().ballNo > ballNo)
                {
                    //if (donutSFXManager.sfxInstance.musicToggle == true)
                    //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.pop2);
                    PlayExplosion();
                    Destroy(coll.gameObject);
                    Debug.Log("D2");
                    CollideAction();
                }

            }
        }

        else if (gameObject.name.Contains("D3"))
        {
            if (coll.gameObject.tag == "D3")
            {
                if (coll.gameObject.GetComponent<Donut>().ballNo > ballNo)
                {
                    //if (donutSFXManager.sfxInstance.musicToggle == true)
                    //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.pop3);
                    PlayExplosion();
                    Destroy(coll.gameObject);
                    Debug.Log("D3");
                    CollideAction();
                }

            }
        }

        else if (gameObject.name.Contains("D4"))
        {
            if (coll.gameObject.tag == "D4")
            {
                if (coll.gameObject.GetComponent<Donut>().ballNo > ballNo)
                {
                    //if (donutSFXManager.sfxInstance.musicToggle == true)
                    //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.pop1);
                    PlayExplosion();
                    Destroy(coll.gameObject);
                    Debug.Log("D4");
                    CollideAction();
                }

            }
        }

        else if (gameObject.name.Contains("D5"))
        {
            if (coll.gameObject.tag == "D5")
            {
                if (coll.gameObject.GetComponent<Donut>().ballNo > ballNo)
                {
                    //if (donutSFXManager.sfxInstance.musicToggle == true)
                    //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.pop2);
                    PlayExplosion();
                    Destroy(coll.gameObject);
                    Debug.Log("D5");
                    CollideAction();
                }

            }
        }

        else if (gameObject.name.Contains("D6"))
        {
            if (coll.gameObject.tag == "D6")
            {
                if (coll.gameObject.GetComponent<Donut>().ballNo > ballNo)
                {
                    //if (donutSFXManager.sfxInstance.musicToggle == true)
                    //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.pop3);
                    PlayExplosion();
                    Destroy(coll.gameObject);
                    Debug.Log("D6");
                    CollideAction();
                }

            }
        }

        else if (gameObject.name.Contains("D7"))
        {
            if (coll.gameObject.tag == "D7")
            {
                if (coll.gameObject.GetComponent<Donut>().ballNo > ballNo)
                {
                    //if (donutSFXManager.sfxInstance.musicToggle == true)
                    //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.pop1);
                    PlayExplosion();
                    Destroy(coll.gameObject);
                    Debug.Log("D7");
                    CollideAction();
                }

            }
        }

        else if (gameObject.name.Contains("D8"))
        {
            if (coll.gameObject.tag == "D8")
            {
                if (coll.gameObject.GetComponent<Donut>().ballNo > ballNo)
                {
                    //if (donutSFXManager.sfxInstance.musicToggle == true)
                    //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.pop2);
                    PlayExplosion();
                    Destroy(coll.gameObject);
                    Debug.Log("D8");
                    CollideAction();
                }

            }
        }

        else if (gameObject.name.Contains("D9"))
        {
            if (coll.gameObject.tag == "D9")
            {
                if (coll.gameObject.GetComponent<Donut>().ballNo > ballNo)
                {
                    //if (donutSFXManager.sfxInstance.musicToggle == true)
                    //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.pop3);
                    PlayExplosion();
                    Destroy(coll.gameObject);
                    Debug.Log("D9");
                    CollideAction();
                }

            }
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }

    void CollideAction()
    {
        Destroy(gameObject);
        Debug.Log("DestroyGameobject");
        var ball = Instantiate(NextObject, this.transform.position, Quaternion.identity);
        Debug.Log("Instantiate");
        ball.GetComponent<Donut>().ballNo = ballNo;
        DonutPangGameManager.I.addScore(point);
        DonutPangGameManager.I.addfinalScore(point);
    }

}