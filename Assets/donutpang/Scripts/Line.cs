using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    private SpriteRenderer gameobject;
    public GameObject Blackout;

    // How long the player needs to stay at location
    public float timerCountDown = 1.5f;
    // Is the player currently at location
    bool isDonutColliding = false;
    bool CollidingNow = false;

    void Update()
    {
        // Collision timer
        if (isDonutColliding == true)
        {
            timerCountDown -= Time.deltaTime;
            if (timerCountDown < 0)
            {
                timerCountDown = 0;
            }
        }
    }

    // Start the collision timer when player enters
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("D"))
        {
            Debug.Log("Player Entered");
            isDonutColliding = true;
        }

    }
    // Check if the player is still at location, if they are spawn our secret item
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("D"))
        {
            isDonutColliding = true;
            CollidingNow = true;
            if (timerCountDown <= 0)
            {
                other.gameObject.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("End");
                Blackout.SetActive(true);
                StartCoroutine(TriggerStayRoutine());
                DonutPangGameManager.I.isPause = true;
                
            }

        }
    }
    // If the player is not colliding reset our timer
    void OnTriggerExit2D(Collider2D other)
    {
        CollidingNow = false;

        if (other.gameObject.name.Contains("D") && CollidingNow == false)
        {
            Debug.Log("Player Exited");
            isDonutColliding = false;
            timerCountDown = 1.5f;
        }
    }

    IEnumerator TriggerStayRoutine()
    {
        yield return new WaitForSeconds(2.5f);
        Blackout.SetActive(false);
        DonutPangGameManager.I.gameOver();
    }
}
