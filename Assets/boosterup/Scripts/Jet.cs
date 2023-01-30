using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour
{

    public float thrustForce = 0.5f;
    public Rigidbody rigid;
    public ParticleSystem lefteffect;
    public ParticleSystem righteffect;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("left"))
        {
            //rigid.AddForce(rigid.transform.up * thrustForce, ForceMode.Impulse);
            rigid.AddForce(new Vector3(-1,1,0) * thrustForce, ForceMode.Impulse);
            lefteffect.Play();
        }

        else if(Input.GetButtonDown("right"))
        {
            //rigid.AddForce(rigid.transform.up * thrustForce, ForceMode.Impulse);
            rigid.AddForce(new Vector3(1,1,0) * thrustForce, ForceMode.Impulse);
            righteffect.Play();
        }

        else
        {
            lefteffect.Stop();
            righteffect.Stop();
        }
    }
}
