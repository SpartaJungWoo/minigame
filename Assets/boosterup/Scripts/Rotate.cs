using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] private Vector3 rotation;
    [SerializeField] private float rotatespeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(rotation * rotatespeed * Time.deltaTime);
    }
}
