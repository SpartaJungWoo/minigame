using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class planet : MonoBehaviour
{

    public float rotateSpeed;
    public GameObject star;
    public GameObject key;
    
    public Animator anim;
    public GameObject camTartget;
    bool touchStar = false;
    public bool meet;
    public float center;

    //private bool clockWise = true;
    public float camSpeed;
    public float zoomSpeed;
    
    AudioSource audioSoure;

    // Start is called before the first frame update
    void Start()
    {
        audioSoure = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (meet == true)
        {

            //star.transform.localRotation = Quaternion.Euler(0f, rotateSpeed * Time.deltaTime, 0f);
            //star.GetComponent<CircleMove>().rigid.velocity = Vector2.zero;
            //star.transform.RotateAround(gameObject.transform.position, Vector3.back, rotateSpeed * Time.deltaTime);
            //star.GetComponent<CircleMove>().rotateSpeed = rotateSpeed;
            //star.GetComponent<Rigidbody2D>().isKinematic = false;

            camera campoint = GameObject.Find("Main Camera").GetComponent<camera>();
            campoint.target = camTartget; //카메라 타겟
            campoint.camwidth = center; // 카메라 커지는 넓이
            campoint.speed = camSpeed; // 카메라 타겟 속도
            campoint.zoomSpeed = zoomSpeed; // 카메라 확대 속도 
            //campoint.GetComponent<camera>().zoomOut();
            //campoint.GetComponent<camera>().zoom();


            //CircleMove move = GameObject.Find("Circle").GetComponent<CircleMove>();
            //move.speed = go;


            if (Input.GetMouseButtonDown(0))
            {
                //star.GetComponent<CircleMove>().bc();
                meet = false;
                //star.GetComponent<CircleMove>().rigid.isKinematic = true;
                //CircleMove move = GameObject.Find("Circle").GetComponent<CircleMove>();  
                //move.bc();

            }
        }

    }

    void LateUpdate()
    {
        if (key.GetComponent<keySystem>().count == key.GetComponent<keySystem>().touchCount)
        {
            anim.SetBool("finish", true);

            //transform.GetChild(3).gameObject.SetActive(true); 
          
            


        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("star"))
        {

             //star.transform.eulerAngles = new Vector3(0, 0, 180);
            //star.transform.rotation = Quaternion.Euler(0, 0, 90);
            

            meet = true;
            anim.SetBool("touched", true);
            //CircleMove move = GameObject.Find("Circle").GetComponent<CircleMove>();
            //move.rigid.velocity = Vector2.zero;
            //star.transform.localEulerAngles = new Vector3(0, 0, 180);

            

            //<수정
            star.GetComponent<CircleMove>().rigid.velocity = Vector2.zero;
            star.GetComponent<CircleMove>().circleMove = false;

            star.GetComponent<CircleMove>().rotateSpeed = rotateSpeed;

            //GameObject point = transform.GetChild(0).gameObject;
            //point.transform.position = star.transform.position;
            //star.transform.rotation = point.transform.rotation;


            Vector3 v3 = this.transform.position - star.transform.position;
            

            //if (v3.x > 0.0f) clockWise = true;
            //else if (v3.x < 0.0f) clockWise = false;

            //>

           



            if (touchStar == false)
            {
                audioSoure.Play();
                key.GetComponent<keySystem>().count += 1;
                touchStar = true;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        meet = false;
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("star"))
        {
            if (star.GetComponent<CircleMove>().circleMove != true)
            {
                GameObject point = transform.GetChild(0).gameObject;
                star.transform.position = Vector2.MoveTowards(star.transform.position, point.transform.position, rotateSpeed * Time.deltaTime);
                star.transform.rotation = point.transform.rotation;

                //star.transform.LookAt(gameObject.transform);
                //Vector3 v3 = this.transform.position - star.transform.position;//방향
                //star.transform.eulerAngles = v3;

                //if (clockWise == true)
                // star.transform.RotateAround(gameObject.transform.position, Vector3.back, rotateSpeed * Time.deltaTime);
                //else if (clockWise == false)
                // star.transform.RotateAround(gameObject.transform.position, Vector3.back, rotateSpeed * Time.deltaTime);
            }

        }
    }

    void zoomIn()
    {
        camera campoint = GameObject.Find("Main Camera").GetComponent<camera>();
        campoint.target = camTartget; //카메라 타겟
        campoint.camwidth = center; // 카메라 커지는 넓이
        campoint.speed = camSpeed; // 카메라 타겟 속도
        campoint.zoomSpeed = zoomSpeed; // 카메라 확대 속도 
        


    }

}