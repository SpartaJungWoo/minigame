using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowPath : MonoBehaviour
{
    public EndOfPathInstruction endOfPathInstruction;
    public float movementSpeed = 5f;

    private PathCreator path;
    public float distanceTravelled;

    [HideInInspector]
    private Vector3 newPos;

    void Awake()
    {
        path = GameObject.FindGameObjectWithTag("Path").GetComponent<PathCreator>();        //Initializes path
        //distanceTravelled = Random.Range(0f, path.path.length);        //Player starts at a random position
        distanceTravelled = 11000;
        //distanceTravelled = 3800;
        //distanceTravelled = 10;
        Move();     //Makes the player follow the path
    }

    void Update() => Move();     //Makes the player follow the path

    public void Move()
    {
        distanceTravelled += movementSpeed * Time.deltaTime;
        newPos = path.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        transform.position = newPos;
        transform.rotation = path.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        transform.Rotate(Vector3.forward, 90f);

        //if (timeBetweenSpawns - spawnTimeReduce >= minSpawnTime)
        //    timeBetweenSpawns -= spawnTimeReduce;
        //time between spawns reduces until the minimum amount of time between spawns
    
    }
}
