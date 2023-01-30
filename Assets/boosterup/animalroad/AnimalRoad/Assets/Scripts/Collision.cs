using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public ParticleSystem tokenParticle;
    public ParticleSystem cloudParticle;
    public float speed_increase = 2;

    public int random_animal;
    //public Transform animal_parent;
    //private GameObject[] animal;

    [HideInInspector]
    public bool gameIsOver = false;

    private Renderer playerRend;
    public ParticleSystem playerParticle;
    private ParticleSystemRenderer particleRend;
    private Animation cameraAnim;

    private Renderer trailRend;

    public int[] select_animal = new int[3];


    void Start()
    {

        //int count = animal_parent.childCount;
        //animal = new GameObject[count];
        //Initizalization
        playerParticle = GetComponent<ParticleSystem>();
        particleRend = GetComponent<ParticleSystemRenderer>();
        cameraAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animation>();
        playerRend = GetComponent<Renderer>();

        select_animal = FindObjectOfType<CharacterChange>().select_animal;

        //FindObjectOfType<ColorManager>().SetRandomColor(playerRend);
        //FindObjectOfType<ColorManager>().ChangeColor(particleRend, playerRend);
        //trailRend = GameObject.FindGameObjectWithTag("Trail").GetComponent<TrailRenderer>();
        //FindObjectOfType<ColorManager>().ChangeColor(trailRend, playerRend);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ColorChanger"))      //If Player collided with a ColorChanger
        {
            //FindObjectOfType<ColorManager>().ChangeColor(playerRend, other.GetComponent<Renderer>());       //Changes the color of the player to the same color as the ColorChangers

            ////Sets back the transparency
            //Color color = playerRend.material.color;
            //color.a = 1f;
            //playerRend.material.color = color;
            FindObjectOfType<Spawner>().Colorcharger_exist = false;


            random_animal = select_animal[FindObjectOfType<Spawner>().changeAnimal_num];
            FindObjectOfType<CharacterChange>().HopeAnimal(random_animal);
            Destroy(Instantiate(cloudParticle, other.gameObject.transform.position, transform.rotation), 1.5f);
            Destroy(other.gameObject);
            //FindObjectOfType<CharacterChange>().HopeAnimal_exp(count_animal);

            //FindObjectOfType<AudioManager>().SkinSwitchSound();     //Plays SkinSwitchSound
        }
        //else if (other.CompareTag("Obstacle"))         //If Player collided with an obstacle
        //{
        //    FindObjectOfType<ColorManager>().ChangeColor(particleRend, playerRend);
        //    playerParticle.Play();
        //    if (FindObjectOfType<ColorManager>().CompareColor(playerRend, other.GetComponent<Renderer>()))     //If the obstacle and the player have the same color
        //    {
        //        FindObjectOfType<ScoreManager>().IncrementScore(1, 0);
        //        FindObjectOfType<ScoreManager>().IncrementScore(150);        //Increments score by 100 (if we delete the second '0' parameter, then a text like "Good Job" will display too)
        //        cameraAnim.Play();      //Plays the animation attached to the Main Camera
        //        Destroy(other.gameObject);      //Destroys obstacle
        //        FindObjectOfType<FollowPath>().movementSpeed += speed_increase;
        //        //FindObjectOfType<PlayerMovement>().


        //    }
        //    else      //If they have different color
        //    {
        //        gameIsOver = true;      //Game is over
        //        //FindObjectOfType<AudioManager>().DeathSound();      //Plays DeathSound
        //        FindObjectOfType<GameManager>().EndPanelActivation();       //Activates endPanel
        //        FindObjectOfType<PlayerMovement>().enabled = false;     //Stops player
        //        FindObjectOfType<FollowPath>().enabled = false;     //Stops player
        //        GetComponent<Collider>().enabled = false;       //Disables collider
        //        GetComponent<Renderer>().enabled = false;       //Makes player invisible
        //        FindObjectOfType<ScoreManager>().combo = 0;
        //    }
        //}
        //else if (other.CompareTag("Alpaca"))         //If Player collided with an obstacle
        //{
        //    FindObjectOfType<ColorManager>().ChangeColor(particleRend, playerRend);
        //    playerParticle.Play();

        //        FindObjectOfType<ScoreManager>().IncrementScore(1, 0);
        //        FindObjectOfType<ScoreManager>().IncrementScore(150);        //Increments score by 100 (if we delete the second '0' parameter, then a text like "Good Job" will display too)
        //        cameraAnim.Play();      //Plays the animation attached to the Main Camera
        //        Destroy(other.gameObject);      //Destroys obstacle
        //        FindObjectOfType<FollowPath>().movementSpeed += speed_increase;

        //else      //If they have different color
        //{
        //    gameIsOver = true;      //Game is over
        //    //FindObjectOfType<AudioManager>().DeathSound();      //Plays DeathSound
        //    FindObjectOfType<GameManager>().EndPanelActivation();       //Activates endPanel
        //    FindObjectOfType<PlayerMovement>().enabled = false;     //Stops player
        //    FindObjectOfType<FollowPath>().enabled = false;     //Stops player
        //    GetComponent<Collider>().enabled = false;       //Disables collider
        //    GetComponent<Renderer>().enabled = false;       //Makes player invisible
        //    FindObjectOfType<ScoreManager>().combo = 0;
        //}
        //}
        else if (other.CompareTag("Fire"))     //If player collides with a token
        {
            //Destroy(other.gameObject);      //Destroys token
            Destroy(Instantiate(tokenParticle, transform.position, transform.rotation), 1.5f);      //Instantiates tokenParticle, then destroys it after x seconds
            //FindObjectOfType<ScoreManager>().IncrementToken();      //Increments tokenCounter
        }
        else if (other.CompareTag("Token"))     //If player collides with a token
        {
            Destroy(other.gameObject);      //Destroys token
            Destroy(Instantiate(tokenParticle, transform.position, transform.rotation), 1.5f);      //Instantiates tokenParticle, then destroys it after x seconds
            FindObjectOfType<ScoreManager>().IncrementToken();      //Increments tokenCounter
        }

        else if (other.CompareTag("Tornado"))     //If player collides with a token
        {
            Destroy(other.gameObject);
            FindObjectOfType<PlayerMovement>().Jump();

        }
        else if (other.CompareTag("Jump"))     //If player collides with a token
        {
            if (FindObjectOfType<PlayerMovement>().playerStatus == 4)
                FindObjectOfType<ScoreManager>().IncrementScore(1, 0);
            Destroy(other.gameObject);
            FindObjectOfType<PlayerMovement>().Jump();

        }
        else if (other.CompareTag("Husky"))
        {
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("Lamb"))
        {
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("Mallard"))
        {
            Destroy(other.gameObject);

        }
    }

    public void Revive()
    {
        gameIsOver = false;

        FindObjectOfType<CharacterChange>().dropdownAnimation.value = 13;
        FindObjectOfType<CharacterChange>().ChangeAnimation();

        FindObjectOfType<PlayerMovement>().enabled = true;      //Makes the player move
        FindObjectOfType<Spawner>().enabled = true;
        FindObjectOfType<FollowPath>().enabled = true;      //Makes the player move
        //GetComponent<Renderer>().enabled = true;       //Makes player visible
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Invoke("EnableCollider", 2f);       //Enables the collider of the player after x seconds
        FindObjectOfType<Spawner>().Invoke("Spawn", 2f);        //Spawns again
        //FindObjectOfType<ScoreManager>().IncrementScore();      //Scores again
        CinemachineShake.Instance.ShakeCamera(0f, 0f);
    }

    public void EnableCollider()
    {

        GetComponent<Collider>().enabled = true;       //Enables collider
    }
}
