using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    
    public float rotateSpeed;
    public GameObject star;

    //bool meet;
    public GameObject camTartget;
    public GameObject fullCount;
    public Animator anim;


    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            star.GetComponent<CircleMove>().circleMove = true;
        }

        if (fullCount.GetComponent<keySystem>().count == fullCount.GetComponent<keySystem>().touchCount)
        {
            anim.SetBool("finish", true);
        }


    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("star"))
        {
            // star.transform.localEulerAngles = new Vector3(0, 0, -90);
            //star.transform.rotation = Quaternion.Euler(0, 0, 270);

            // meet = true;

            star.GetComponent<CircleMove>().rigid.velocity = Vector2.zero;
            star.GetComponent<CircleMove>().circleMove = false;

            Vector3 v3 = this.transform.position - star.transform.position;




            camera campoint = GameObject.Find("Main Camera").GetComponent<camera>();
            campoint.target = camTartget;

        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("star"))
        {
            if (star.GetComponent<CircleMove>().circleMove != true)
            //star.transform.RotateAround(gameObject.transform.position, Vector3.back, rotateSpeed * Time.deltaTime);
            {
                GameObject point = transform.GetChild(0).gameObject;
                star.transform.position = Vector2.MoveTowards(star.transform.position, point.transform.position, rotateSpeed * Time.deltaTime);
                star.transform.rotation = point.transform.rotation;
            }


        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //meet = false;
    }
}
