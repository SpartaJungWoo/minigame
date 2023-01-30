using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainballtutorial : MonoBehaviour
{

    public GameObject Ball_rightmotion;
    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
 //       transform.position = new Vector3(xposition, yposition, 0);
        transform.position = transform.position + new Vector3(1, 1, 0) * Time.deltaTime;
    }
}
