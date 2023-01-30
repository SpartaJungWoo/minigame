using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;


public class Spawner : MonoBehaviour
{
    public GameObject obstacle_check;
    public int chidCount_check;
    public int changeAnimal_num;
    public float up = -90f;
    public float forward = 90f;
    public float down = 0f;
    public float back = 0f;

    public bool Colorcharger_exist = false;
    public GameObject[] Animal_obstacles;
    public GameObject[] Change_obstacles;
    //public GameObject Animal_obstacle, Animal_obstacle1, Animal_obstacle2, Animal_obstacle3, Animal_obstacle4, Animal_obstacle5;
    public GameObject fire, colorChanger, tornado;
    public int tokenSpawnFrequency = 8, minFrequency, maxFrequency;
    //public float offsetY = 0.85f;
    public float offsetY = 0.95f;
    public float timeBetweenSpawns, spawnTimeReduce, minSpawnTime;
    public float firstObstacleSpawn = 2f, aheadOfPlayer = 100f;

    public EndOfPathInstruction endOfPathInstruction;
    public float distanceTravelled;
    public float playerSpeed;
    //public float tempdistanceTravelled = 0f;
    public float abs_distance;
    public int obs_continue;
    public float temp_timeBetweenSpawns;
    public float temp_trigger = 0;
    [SerializeField]
    private int frequency = 0;
    [HideInInspector]
    private int spawnType, previousSpawnType;
    private PathCreator path;
    private Renderer playerRend;
    public float x_position;
    public int spawn_fire_frequency = 0;
    [SerializeField]
    private List<string> animalNameList = new List<string> {
                                                              "Husky",
                                                              "Lamb",
                                                              "Mallard"
                                                            };
    public int animal_num;

    public float changesetX = 0;
    public float changesetY = 0;
    public float changesetZ = 3f;
    private ParticleSystemRenderer particleRend;



    void Start()
    {
        path = GameObject.FindGameObjectWithTag("Path").GetComponent<PathCreator>();        //Initializes path
        Invoke("Spawn", firstObstacleSpawn);        //Spawns first obstacle after x seconds
        playerRend = GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>();
    }

    void Update()
    {
        //Sets the spawner ahead of the player by aheadOfPlayer value
        distanceTravelled = FindObjectOfType<FollowPath>().distanceTravelled + aheadOfPlayer;
        transform.position = path.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        transform.rotation = path.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        playerSpeed = FindObjectOfType<FollowPath>().movementSpeed;
        //abs_distance = 3 / playerSpeed;
        abs_distance = 12 / playerSpeed;
    }

    public void SpawnFire()
    {

        if (spawn_fire_frequency <= 0)     //we decrease this variable's value after each spawn
        {

            //Spawns token to a random position
            GameObject tempFire = Instantiate(fire, transform.position, Quaternion.identity);
            Vector3 tokenPos = transform.position;
            tokenPos.x += Random.Range(-2f, 2f);
            tokenPos.y += 4f;
            tempFire.transform.SetPositionAndRotation(tokenPos, transform.rotation);


            //tempFire.transform.Rotate(Vector3.forward, forward);
            //tempFire.transform.Rotate(Vector3.up, up);
            //tempFire.transform.Rotate(Vector3.down, down);
            //tempFire.transform.Rotate(Vector3.back, back);


            tempFire.transform.Rotate(Vector3.up, 90f);
            tempFire.transform.Rotate(Vector3.down, 270f);
            tempFire.transform.Rotate(Vector3.forward, 270f);
            tempFire.transform.Rotate(Vector3.back, back);

            spawn_fire_frequency = Random.Range(2, 4);
        }

        spawn_fire_frequency--;

        //tempFire.transform.Rotate(Vector3.forward, 90f);
        //tempFire.transform.Rotate(Vector3.up, -90f);
        //tempFire.transform.Rotate(Vector3.down, 0f);
        //tempFire.transform.Rotate(Vector3.back, 90f);
        //tempFire.transform.Rotate(Vector3.up, 90f);
        //tempFire.transform.Rotate(Vector3.forward, 90f);
        //tempToken.GetComponent<Transform>().transform.localPosition = tokenPos;
        //tempToken.GetComponent<Transform>().GetChild(0).transform.localPosition = tokenPos;
    }

    public void SpawnTornado()
    {
        //Spawns token to a random position
        GameObject tempTornado = Instantiate(tornado, transform.position, Quaternion.identity);
        Vector3 tornadoPos = transform.position;
        tornadoPos.x += Random.Range(-FindObjectOfType<PlayerMovement>().mapWidth, FindObjectOfType<PlayerMovement>().mapWidth);
        //tornadoPos.y += 6f;
        tempTornado.transform.SetPositionAndRotation(tornadoPos, transform.rotation);
        tempTornado.transform.Rotate(Vector3.up, up);
        tempTornado.transform.Rotate(Vector3.forward, forward);

        Invoke("SpawnFire", abs_distance * 2);
        //tempToken.GetComponent<Transform>().transform.localPosition = tokenPos;
        //tempToken.GetComponent<Transform>().GetChild(0).transform.localPosition = tokenPos;
    }


    //public void Spawn()
    //{

    //    //if(timeBetweenSpawns ==0.15 && obs_continue <= 0)
    //    //    timeBetweenSpawns = temp_timeBetweenSpawns;

    //    if ( frequency <= 0)     //we decrease this variable's value after each spawn
    //    {
    //        do
    //        { 
    //            spawnType = Random.Range(0, 5);     //there are 4 types of spawn
    //        } while (spawnType == previousSpawnType);       //there can't be two same type of spawns after each other
    //        previousSpawnType = spawnType;
    //        frequency = Random.Range(minFrequency, maxFrequency);       //random frequency of one spawn type
    //    }

    //    GameObject tempObstacle = Instantiate(Animal_obstacles[Random.Range(0,6)], transform.position, Quaternion.identity);       //Spawns a random obstacle to the spawner's position with the same rotation
    //    Vector3 obstPos = transform.position;
    //    obstPos.y += offsetY-0.85f;

    //    tempObstacle.transform.SetPositionAndRotation(obstPos, transform.rotation);
    //    tempObstacle.transform.Rotate(Vector3.forward, 90f);
    //    tempObstacle.transform.Rotate(Vector3.up, 180f);

    //    //GameObject tempAnimal_obstacle = Instantiate(animal_obstacle, transform.position, Quaternion.identity);       //Spawns a random obstacle to the spawner's position with the same rotation
    //    //obstPos.y += offsetY;
    //    //tempAnimal_obstacle.transform.SetPositionAndRotation(obstPos, transform.rotation);
    //    //tempAnimal_obstacle.transform.Rotate(Vector3.forward, 90f);
    //    //tempAnimal_obstacle.transform.Rotate(Vector3.up, 180f);


    //    if (!FindObjectOfType<Collision>().gameIsOver)        //Invokes the next spawn only if the game is not over
    //        //temp_trigger = 0;
    //        if (temp_trigger == 0 && Colorcharger_exist == true)
    //        {
    //            temp_trigger = 1;
    //            Invoke("Spawn", 5*abs_distance);
    //        }
    //               //Next spawn after 'timeBetweenSpawns' secs
    //        else {
    //            temp_trigger = 0;
    //            Invoke("Spawn", timeBetweenSpawns);
    //        }
    //    //GameObject tempObstacle2 = tempObstacle;       //Spawns a random obstacle to the spawner's position with the same rotation
    //    //Vector3 obstPos2 = transform.position;

    //    //obstPos2.z += offsetZ;
    //    //tempObstacle.transform.SetPositionAndRotation(obstPos2, transform.rotation);
    //    //tempObstacle.transform.Rotate(Vector3.forward, 90f);


    //    //if (Random.Range(0, tokenSpawnFrequency) == 0)      
    //    //    Invoke("SpawnTornado", timeBetweenSpawns / 2f);

    //    //Deciding which spawn type to spawn

    //    chidCount_check = tempObstacle.transform.childCount;


    //    switch (spawnType)
    //    {
    //        case 1:
    //            //timeBetweenSpawns = 1.5f;
    //            Destroy(tempObstacle.transform.GetChild(Random.Range(0, tempObstacle.transform.childCount)).gameObject);
    //            break;
    //        case 2:
    //            //timeBetweenSpawns = 1.5f;
    //            Destroy(tempObstacle.transform.GetChild(2).gameObject);
    //            Destroy(tempObstacle.transform.GetChild(1).gameObject);
    //            tempObstacle.transform.GetChild(0).GetComponent<Animation>().Play("HorizontalMovementAnim");        //Makes the obstacle move horizontally
    //            break;
    //        case 3:
    //            //timeBetweenSpawns = 1.5f;
    //            Destroy(tempObstacle.gameObject);
    //            ChangeCharacter();
    //            break;
    //        case 4:
    //            Destroy(tempObstacle.gameObject);
    //            SpawnFire();
    //            break;
    //    }



    //    frequency--;
    //    if (timeBetweenSpawns - spawnTimeReduce >= minSpawnTime)
    //        timeBetweenSpawns -= spawnTimeReduce;
    //    //time between spawns reduces until the minimum amount of time between spawns

    //}

    public void SpawnColorChanger()
    {
        Vector3 obstPos = transform.position;
        obstPos.y += offsetY;
        GameObject tempColorChanger = Instantiate(colorChanger, obstPos, transform.rotation);       //Spawns ColorChanger
        tempColorChanger.transform.Rotate(Vector3.forward, 90f);


        Renderer colorChangerRend = tempColorChanger.GetComponent<Renderer>();


        do
        {
            FindObjectOfType<ColorManager>().SetRandomColor(colorChangerRend);      //Selects a random color for ColorChanger
        } while (FindObjectOfType<ColorManager>().CompareColor(colorChangerRend, playerRend));      //ColorChanger can't have the same color as the Player

        //Changes the transparency of the ColorChanger
        Color color = colorChangerRend.material.color;
        color.a = 0.7f;
        colorChangerRend.material.color = color;

        frequency = 0;      //If we spawn a colorchanger, then we won't spawn more of them
    }

    public void ChangeCharacter()
    {
        if (Colorcharger_exist != true)
        {
            Colorcharger_exist = true;

            if (FindObjectOfType<Collision_withcheck>().animal_name == "Husky")
            {
                animal_num = 0;
            }
            if (FindObjectOfType<Collision_withcheck>().animal_name == "Lamb")
            {
                animal_num = 1;
            }
            if (FindObjectOfType<Collision_withcheck>().animal_name == "Mallard")
            {
                animal_num = 2;
            }

            do
            {
                changeAnimal_num = Random.Range(0, 3);
            } while (changeAnimal_num == animal_num);

            Vector3 changeobstPos = transform.position;
            //changeobstPos.x += changesetX;
            //changeobstPos.y += changesetY;
            //changeobstPos.z += changesetZ;

            GameObject changeCharacter = Instantiate(Change_obstacles[changeAnimal_num], changeobstPos, transform.rotation);       //Spawns a random obstacle to the spawner's position with the same rotation
            changeCharacter.transform.Rotate(Vector3.forward, 90f);
            changeCharacter.transform.Rotate(Vector3.up, 180f);


            AnimationJump(changeCharacter);
            frequency = 0;

            Invoke("SpawnColorChanger", abs_distance);
        }
    }

    public void AnimationJump(GameObject changeCharacter)
    {
        int count = changeCharacter.transform.childCount;


        for (int i = 0; i < count; i++)
        {
            if (changeCharacter.GetComponent<Animator>() != null)
            {
                changeCharacter.GetComponent<Animator>().Play("Jump");
            }
            else if (changeCharacter.transform.GetChild(i).GetComponent<Animator>() != null)
            {
                changeCharacter.transform.GetChild(i).GetComponent<Animator>().Play("Jump");
            }
        }
    }



    public void Spawn()
    {

        //if(timeBetweenSpawns ==0.15 && obs_continue <= 0)
        //    timeBetweenSpawns = temp_timeBetweenSpawns;

        if (frequency <= 0)     //we decrease this variable's value after each spawn
        {
            do
            {
                spawnType = Random.Range(0, 5);     //there are 4 types of spawn
            } while (spawnType == previousSpawnType);       //there can't be two same type of spawns after each other
            previousSpawnType = spawnType;
            frequency = Random.Range(minFrequency, maxFrequency);       //random frequency of one spawn type
        }

        GameObject tempObstacle = Instantiate(Animal_obstacles[Random.Range(0, 6)], transform.position, Quaternion.identity);       //Spawns a random obstacle to the spawner's position with the same rotation
        Vector3 obstPos = transform.position;
        obstPos.y += offsetY - 0.85f;

        tempObstacle.transform.SetPositionAndRotation(obstPos, transform.rotation);
        tempObstacle.transform.Rotate(Vector3.forward, 90f);
        tempObstacle.transform.Rotate(Vector3.up, 180f);

        //GameObject tempAnimal_obstacle = Instantiate(animal_obstacle, transform.position, Quaternion.identity);       //Spawns a random obstacle to the spawner's position with the same rotation
        //obstPos.y += offsetY;
        //tempAnimal_obstacle.transform.SetPositionAndRotation(obstPos, transform.rotation);
        //tempAnimal_obstacle.transform.Rotate(Vector3.forward, 90f);
        //tempAnimal_obstacle.transform.Rotate(Vector3.up, 180f);


        if (!FindObjectOfType<Collision>().gameIsOver)        //Invokes the next spawn only if the game is not over
            //temp_trigger = 0;
            if (temp_trigger == 0 && Colorcharger_exist == true)
            {
                temp_trigger = 1;
                Invoke("Spawn", 5 * abs_distance);
            }
            //Next spawn after 'timeBetweenSpawns' secs
            else
            {
                temp_trigger = 0;
                Invoke("Spawn", timeBetweenSpawns);
            }
        //Invoke("Spawn", timeBetweenSpawns);


        //GameObject tempObstacle2 = tempObstacle;       //Spawns a random obstacle to the spawner's position with the same rotation
        //Vector3 obstPos2 = transform.position;

        //obstPos2.z += offsetZ;
        //tempObstacle.transform.SetPositionAndRotation(obstPos2, transform.rotation);
        //tempObstacle.transform.Rotate(Vector3.forward, 90f);


        //if (Random.Range(0, tokenSpawnFrequency) == 0)      
        //    Invoke("SpawnTornado", timeBetweenSpawns / 2f);

        //Deciding which spawn type to spawn

        chidCount_check = tempObstacle.transform.childCount;


        switch (spawnType)
        {
            case 1:
                //timeBetweenSpawns = 1.5f;
                Destroy(tempObstacle.transform.GetChild(Random.Range(0, tempObstacle.transform.childCount)).gameObject);
                break;
            case 2:
                //timeBetweenSpawns = 1.5f;
                Destroy(tempObstacle.transform.GetChild(2).gameObject);
                Destroy(tempObstacle.transform.GetChild(1).gameObject);
                tempObstacle.transform.GetChild(0).GetComponent<Animation>().Play("HorizontalMovementAnim");        //Makes the obstacle move horizontally
                break;
            case 3:
                //timeBetweenSpawns = 1.5f;
                Destroy(tempObstacle.gameObject);
                ChangeCharacter();
                break;
            case 4:
                Destroy(tempObstacle.gameObject);
                SpawnFire();
                break;
        }



        frequency--;
        if (timeBetweenSpawns - spawnTimeReduce >= minSpawnTime)
            timeBetweenSpawns -= spawnTimeReduce;
        //time between spawns reduces until the minimum amount of time between spawns

    }

}
