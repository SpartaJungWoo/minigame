
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCamera : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.3f;

    JetPackMan jetpackman;
    public GameObject JetPackMan;

    void Awake()
    {
        jetpackman = JetPackMan.GetComponent<JetPackMan>();
    }


    void LateUpdate()
    {
        if(target.position.y > transform.position.y && jetpackman.isdead == false)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPos;
        }

        else if(target.position.y +10 < transform.position.y && jetpackman.isdead == true)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y + 10, transform.position.z);
            transform.position = newPos;
        }
    }
}
