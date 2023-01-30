using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 2f;

    private void Update()
    {
        transform.Translate(new Vector3(bulletSpeed* Time.deltaTime,bulletSpeed* Time.deltaTime,0f));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RightWall" || other.gameObject.tag == "LeftWall")
        {
            Destroy(this.gameObject);
        }
    }

}
