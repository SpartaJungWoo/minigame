using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpforce = 40f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void jumpright()
    {
        // if(Input.GetMouseButtonDown(0))
        //{
        rb.AddForce(new Vector2(40f, jumpforce));
        //}
    }
    public void jumpleft()
    {
        // if(Input.GetMouseButtonDown(0))
        //{
        rb.AddForce(new Vector2(-40f, jumpforce));
        //}
    }

}
