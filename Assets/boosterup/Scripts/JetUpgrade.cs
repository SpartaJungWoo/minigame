using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetUpgrade : MonoBehaviour
{
    public float YthrustForce = 1100f;
    public float XthrustForce = 400f;
    public float ZthrustForce = 170f;
    public float startForce = 10f;
    public float boostForce = 800f;
    public Rigidbody rigid;
    public GameObject leftFire;
    public GameObject rightFire;
    public GameObject target;
    public GameObject lefttarget;
    public GameObject righttarget;
    public GameObject centertarget;
    public float maxSpeed = 8f;
    public Transform playerTransform;
    public GameObject Stickman;
    public Material Original;
    public Material Sunset;
    
    public GameObject startFire;

    PlayBtn playbtn;
    public GameObject playBtn;

    JetPackMan jetpackman;
    public GameObject JetPackMan;

    void Awake()
    {
        playbtn = playBtn.GetComponent<PlayBtn>();
        jetpackman = JetPackMan.GetComponent<JetPackMan>();
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        // Debug.Log(playerTransform.localEulerAngles.z);


        if(playbtn.touchable == true && jetpackman.isdead == false && jetpackman.isfever == false)
        {   
            float boostTrigger = 0.8f;

            rigid.GetComponent<Rigidbody>().useGravity = true;

            if(Input.touchCount> 0)
            {

                if(Input.GetTouch(0).position.x < Screen.width/2 && Input.touchCount == 1)
                {
                    if(Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved)
                    {

                        // if(playerTransform.localEulerAngles.z >= 0 && playerTransform.localEulerAngles.z <= 180)
                        // {
                        //     rigid.AddForce(new Vector3(-boostTrigger * XthrustForce * Time.deltaTime,boostTrigger * YthrustForce * Time.deltaTime,0));
                        //     rigid.AddRelativeTorque(0,0, boostTrigger * ZthrustForce * Time.deltaTime);
                        //     rigid.angularVelocity = Vector3.zero;
                        //     leftFire.SetActive(true);
                        //     rigid.GetComponent<Animator>().Play("Up");
                        // }

                        // if(playerTransform.localEulerAngles.z > 180 && playerTransform.localEulerAngles.z <=360)
                        // {
                        //     rigid.AddForce(new Vector3(boostTrigger * XthrustForce * Time.deltaTime,boostTrigger * YthrustForce * Time.deltaTime,0));
                        //     rigid.AddRelativeTorque(0,0, boostTrigger * ZthrustForce * Time.deltaTime);
                        //     rigid.angularVelocity = Vector3.zero;
                        //     leftFire.SetActive(true);
                        //     rigid.GetComponent<Animator>().Play("Up");
                        // }

                        Vector3 posCharacter = rigid.position;
                        Vector3 posLeftDirection = lefttarget.transform.position;
                        Vector3 dir = (posLeftDirection - posCharacter).normalized;
                        rigid.AddForce(dir.x * XthrustForce * Time.deltaTime, dir.y * YthrustForce * Time.deltaTime, 0);
                        rigid.AddRelativeTorque(0,0, boostTrigger * ZthrustForce * Time.deltaTime);
                        rigid.angularVelocity = Vector3.zero;
                        leftFire.SetActive(true);
                        rigid.GetComponent<Animator>().Play("Up");

                        
                    }

                    else if(Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        leftFire.SetActive(false);
                        rigid.GetComponent<Animator>().Play("Fall");
                        //rigid.velocity = rigid.velocity * 0.99f * Time.deltaTime;
                    }
                    
                }

                else if(Input.GetTouch(0).position.x > Screen.width/2 && Input.touchCount == 1)
                {
                    if(Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        // if(playerTransform.localEulerAngles.z >= 0 && playerTransform.localEulerAngles.z <= 180)
                        // {   

                        //     rigid.AddForce(new Vector3(-boostTrigger * XthrustForce * Time.deltaTime,boostTrigger * YthrustForce * Time.deltaTime,0));
                        //     rigid.AddRelativeTorque(0,0, -boostTrigger * ZthrustForce * Time.deltaTime);
                        //     rigid.angularVelocity = Vector3.zero;
                        //     rightFire.SetActive(true);
                        //     rigid.GetComponent<Animator>().Play("Up");
                        // }

                        // if(playerTransform.localEulerAngles.z > 180 && playerTransform.localEulerAngles.z <360)
                        // {
                        //     rigid.AddForce(new Vector3(boostTrigger * XthrustForce * Time.deltaTime,boostTrigger * YthrustForce * Time.deltaTime,0));
                        //     rigid.AddRelativeTorque(0,0, -boostTrigger * ZthrustForce * Time.deltaTime);
                        //     rigid.angularVelocity = Vector3.zero;
                        //     rightFire.SetActive(true);
                        //     rigid.GetComponent<Animator>().Play("Up");
                        // }

                        Vector3 posCharacter = rigid.position;
                        Vector3 posRightDirection = righttarget.transform.position;
                        Vector3 dir = (posRightDirection - posCharacter).normalized;
                        rigid.AddForce(dir.x * XthrustForce * Time.deltaTime, dir.y * YthrustForce * Time.deltaTime, 0);
                        rigid.AddRelativeTorque(0,0, -boostTrigger * ZthrustForce * Time.deltaTime);
                        rigid.angularVelocity = Vector3.zero;
                        rightFire.SetActive(true);
                        rigid.GetComponent<Animator>().Play("Up");


                    }

                    else if(Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        rightFire.SetActive(false);
                        rigid.GetComponent<Animator>().Play("Fall");
                        //rigid.velocity = rigid.velocity * 0.99f * Time.deltaTime;
                    }
                
                }

                else if(Input.touchCount == 2)
                {
                    if(Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        rigid.angularVelocity = Vector3.zero;

                        Vector3 posCharacter = rigid.position;
                        Vector3 posDirection = target.transform.position;
                        Vector3 dir = (posDirection - posCharacter).normalized;
                        rigid.AddForce(dir * boostForce * Time.deltaTime);
                        rigid.GetComponent<Animator>().Play("Up");

                        //rigid.AddForce(new Vector3(0,YthrustForce,0));
                        leftFire.SetActive(true);
                        rightFire.SetActive(true);
                    }

                    else if(Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(1).phase == TouchPhase.Ended)
                    {
                        leftFire.SetActive(false);
                        rightFire.SetActive(false);
                        rigid.GetComponent<Animator>().Play("Fall");
                    }
                }

                // else if(playbtn.start == false)
                // {
                // leftFire.SetActive(false);
                // rightFire.SetActive(false);
                // rigid.GetComponent<Animator>().Play("Fall");
                // }
            }
            
            if(rigid.velocity.magnitude > maxSpeed)
            {
                rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, maxSpeed);
            }
        }

        if(jetpackman.isdead == true)
        {
            leftFire.SetActive(false);
            rightFire.SetActive(false);
        }
        

        if(playbtn.start == true)
        {
            StartCoroutine(ActivationRoutine());
        }

        if(jetpackman.isfever == true)
        {
            StartCoroutine(FeverMode());
        }
        
    }
    IEnumerator ActivationRoutine()
     {
        startFire.SetActive(true);
         yield return new WaitForSeconds(1);

         playbtn.start = false;
        
        Destroy(startFire.gameObject);

         
     }

     IEnumerator FeverMode()
     {
        Debug.Log("Fever Mode!");
        Stickman.GetComponent<SkinnedMeshRenderer>().material = Sunset;
        rigid.GetComponent<CapsuleCollider>().enabled = false;
        Vector3 posCharacter = rigid.position;
        Vector3 posCenterDirection = centertarget.transform.position;
        Vector3 dir = (posCenterDirection - posCharacter).normalized;
        rigid.AddForce(dir.x * 270 * Time.deltaTime, dir.y * 250 * Time.deltaTime, 0);
        rigid.GetComponent<Animator>().Play("Up");
        rigid.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 1.0f * Time.deltaTime);


        leftFire.SetActive(true);
        rightFire.SetActive(true);
         yield return new WaitForSeconds(3);
         jetpackman.isfever = false;

         
         yield return new WaitForSeconds(1);
         rigid.GetComponent<CapsuleCollider>().enabled = true;
         Stickman.GetComponent<SkinnedMeshRenderer>().material = Original;

     }

        //Debug.Log(rigid.velocity.magnitude);    

    // void OnTriggerEnter(Collider other)
    //     {
    //         if (other.tag == "Player")
    //         return; 

    //         else if(other.tag == "Enemy")
    //         {
    //             Destroy(other.gameObject);
    //             Debug.Log("Enemy Killed!");
    //         }

    //     }
}
    