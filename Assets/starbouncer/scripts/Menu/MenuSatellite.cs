using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSatellite : MonoBehaviour
{

    public GameObject target;
    public float rotateSpeed;

    private void Awake()
    {
        rotateSpeed = target.GetComponent<MenuPlanet>().rotateSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.RotateAround(target.transform.position, Vector3.back, rotateSpeed * Time.deltaTime);
    }
}
