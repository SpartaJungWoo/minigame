using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private allRight line;


    // Start is called before the first frame update

  

    void Start()
    {
        line.SetupLine(points);
        //line.GetComponent<AnimLine>().enabled = true;
        //Invoke("clear", 1);

    }

    // Update is called once per frame
    void Update()
    {
        line.GetComponent<AnimLine>().enabled = true;
    }

    public void clear()
    {
        line.GetComponent<AnimLine>().enabled = true;
    }
}
