using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallposition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wall_left;
    public GameObject wall_right;
    public GameObject wall_top;
    public GameObject wall_bottom;
    public GameObject wall_top_ball;



    private void Start()
    {
        setupBD();
    }

    void setupBD()
    {
        Vector3 point = new Vector3();

        //top
        point = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, Camera.main.nearClipPlane));
        wall_top.transform.position = point;

        //bottom
        point = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, Camera.main.nearClipPlane));
        wall_bottom.transform.position = point;


        //left

        point = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, Camera.main.nearClipPlane));
        wall_left.transform.position = point;

        //right
        point = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, Camera.main.nearClipPlane));
        wall_right.transform.position = point;

        //gameover
        point = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, Camera.main.nearClipPlane));
        wall_top_ball.transform.position = point;
    }







}
