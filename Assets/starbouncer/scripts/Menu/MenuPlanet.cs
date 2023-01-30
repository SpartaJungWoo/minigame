using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlanet : MonoBehaviour
{

    public float rotateSpeed;
    public GameObject star;

    public GameObject camTartget;

   
 





    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        {


            camera campoint = GameObject.Find("Main Camera").GetComponent<camera>();
            campoint.target = camTartget; //Ä«¸Þ¶ó Å¸°Ù


        }

    }

    void LateUpdate()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("star"))
        {



            star.GetComponent<MenuCircle>().rigid.velocity = Vector2.zero;


            star.GetComponent<MenuCircle>().rotateSpeed = rotateSpeed;



            Vector3 v3 = this.transform.position - star.transform.position;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("star"))
        {
            
                GameObject point = transform.GetChild(0).gameObject;
                star.transform.position = Vector2.MoveTowards(star.transform.position, point.transform.position, rotateSpeed * Time.deltaTime);
                star.transform.rotation = point.transform.rotation;

            

        }
    }

}
