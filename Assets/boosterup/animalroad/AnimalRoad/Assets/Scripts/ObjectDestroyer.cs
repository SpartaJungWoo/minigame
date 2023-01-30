//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ObjectDestroyer : MonoBehaviour {

//    public void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Obstacle") || other.CompareTag("ColorChanger") || other.CompareTag("Token") || (other.CompareTag("Alpaca")))       //If gameObject collides with an obstacle or with a colorChanger, or with a token
//        {
//            Destroy(other.gameObject);      //Then destroys it
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;


public class ObjectDestroyer : MonoBehaviour
{

    //public GameObject obstacle, token, colorChanger, animal_obstacle;
    //public int tokenSpawnFrequency = 8, minFrequency, maxFrequency;
    //public float offsetY = 0.85f;
    //public float timeBetweenSpawns, spawnTimeReduce, minSpawnTime;
    public float aheadOfPlayer = -50f;

    //public float offsetZ = 5f;

    public EndOfPathInstruction endOfPathInstruction;
    public float distanceTravelled;
    //public float playerSpeed;
    ////public float tempdistanceTravelled = 0f;
    //public float abs_distance;
    //public int obs_continue;
    //public float temp_timeBetweenSpawns;
    //public float temp_trigger;
    //[SerializeField]
    //private int frequency = 0;
    [HideInInspector]
    //private int spawnType, previousSpawnType;
    private PathCreator path;
    //private Renderer playerRend;



    void Start()
    {
        path = GameObject.FindGameObjectWithTag("Path").GetComponent<PathCreator>();        //Initializes path
        //Invoke("Spawn_animal", firstObstacleSpawn);        //Spawns first obstacle after x seconds
        //playerRend = GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>();
    }

    void Update()
    {
        //Sets the spawner ahead of the player by aheadOfPlayer value
        distanceTravelled = FindObjectOfType<FollowPath>().distanceTravelled + aheadOfPlayer;
        transform.position = path.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        transform.rotation = path.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        transform.Rotate(Vector3.forward, 90f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("TokenParticle") || other.CompareTag("Fire") || other.CompareTag("Tornado") || other.CompareTag("Animal_obstacle") || other.CompareTag("Token") || (other.CompareTag("Alpaca") || other.CompareTag("Goose") || other.CompareTag("Lamb") || other.CompareTag("Mallard")))       //If gameObject collides with an obstacle or with a colorChanger, or with a token
        {
            Destroy(other.gameObject);      //Then destroys it
        }
        else if(other.CompareTag("ColorChanger"))
        {
            FindObjectOfType<Spawner>().Colorcharger_exist = false;
            Destroy(other.gameObject);
        }
    }
}
