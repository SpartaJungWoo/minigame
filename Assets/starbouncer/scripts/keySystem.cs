using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class keySystem : MonoBehaviour
{
    public GameObject starLine;
    public int count;
    public int touchCount;
    public GameObject star;
    public GameObject fullShot;
    public GameObject cam;
    public GameObject camBound;
    public GameObject success;
    public GameObject image;
    public GameObject finishUi;
    public GameObject countUi;
    public GameObject firstPlanet;


    public float full;
    public float zoomSpeed;
    public Text CountText;
    public Text TouchCountText;

    

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == touchCount)
        {

            //star.SetActive(false);
            //star.GetComponent<CircleMove>().panel.SetActive(false);
            wait();
            //Invoke("wait", 1);
            cam.GetComponent<camera>().target = fullShot;
            Invoke("Name", 2);
            Invoke("starImage", 4);
            Invoke("finishUI", 9);


            //campoint.target = fullShot;

        }

        CountText.text = count.ToString();
        TouchCountText.text = touchCount.ToString();

    }

    void LateUpdate()
    {
        if (count == touchCount)
        {
            star.SetActive(false);
            star.GetComponent<CircleMove>().panel.SetActive(false);
            zoom();
            countUi.SetActive(false);

            
            

            GameObject yellow = firstPlanet.transform.GetChild(1).gameObject;
            yellow.SetActive(false);
            GameObject white = firstPlanet.transform.GetChild(2).gameObject;
            white.SetActive(true);


        }
        
    }




    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("star"))
        {

            ///Invoke("wait", 1);
            //camera campoint = GameObject.Find("Main Camera").GetComponent<camera>();
            
            //GameObject.Find("Circle").SetActive(false);


        }
    }

    void wait()
    {
        starLine.SetActive(true);
        //starLine.GetComponent<AnimLine>().enabled = true;
    }

    void zoom()
    {
        cam.GetComponent<camera>().speed = 1.5f; //카메라 타겟으로 이동 속도 
        cam.GetComponent<camera>().zoomSpeed = zoomSpeed; //카메라 확대 속도 
        cam.GetComponent<camera>().camwidth = full; // 카메라 확대 넓이
        //cam.GetComponent<camera>().zoom();
        //cam.GetComponent<Camera>().fieldOfView = viewSize;
        camBound.SetActive(false);
        


    }

   


    void Name()
    {
        success.SetActive(true);
    }

    void starImage()
    {
        image.SetActive(true);
    }

    void finishUI()
    {
        finishUi.SetActive(true);
    }

    

}
