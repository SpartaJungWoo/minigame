using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class satellite : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = target.GetComponent<planet>().rotateSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.back, rotateSpeed * Time.deltaTime);
    }

}

   
  
 


