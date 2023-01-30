using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalObstacleHolder : MonoBehaviour
{
    public GameObject obst1;
    public GameObject obst2;
    public GameObject obst3;

    public float offsetY = 0.85f;


    void Start()
    {
        GameObject tempObstacle1 = Instantiate(obst1, transform.position, Quaternion.identity);       //Spawns a random obstacle to the spawner's position with the same rotation
        tempObstacle1.transform.parent = this.transform;
        Vector3 obstPos1 = transform.position;
        //obstPos1.y += offsetY;
        tempObstacle1.transform.SetPositionAndRotation(obstPos1, transform.rotation);
        //tempObstacle1.transform.Rotate(Vector3.forward, 90f);
        //tempObstacle1.transform.Rotate(Vector3.up, 180f);
        

        GameObject tempObstacle2 = Instantiate(obst2, transform.position, Quaternion.identity);       //Spawns a random obstacle to the spawner's position with the same rotation
        tempObstacle2.transform.parent = this.transform;
        Vector3 obstPos2 = transform.position;
        obstPos2.x += 3;
        tempObstacle2.transform.SetPositionAndRotation(obstPos2, transform.rotation);
        //tempObstacle2.transform.Rotate(Vector3.forward, 90f);
        //tempObstacle2.transform.Rotate(Vector3.up, 180f);
        

        GameObject tempObstacle3 = Instantiate(obst3, transform.position, Quaternion.identity);       //Spawns a random obstacle to the spawner's position with the same rotation
        tempObstacle3.transform.parent = this.transform;
        Vector3 obstPos3 = transform.position;
        //obstPos3.y += offsetY;
        obstPos3.x -= 3;
        tempObstacle3.transform.SetPositionAndRotation(obstPos3, transform.rotation);
        //tempObstacle3.transform.Rotate(Vector3.forward, 90f);
        //tempObstacle3.transform.Rotate(Vector3.up, 180f);
    }

}
