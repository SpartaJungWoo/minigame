using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public GameObject fullShot;
    public GameObject cam;
    public float width;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        cam.GetComponent<camera>().target = fullShot; //카메라 타겟
        cam.GetComponent<camera>().camwidth = width; //카메라 확대 넓이
        cam.GetComponent<camera>().speed = 1.0f; //카메라 타겟으로 이동 속도
        cam.GetComponent<camera>().zoom(); //카메라의 줌인(줌아웃임) 가져오기

    }



}
