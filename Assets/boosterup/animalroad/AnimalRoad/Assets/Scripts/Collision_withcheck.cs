using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_withcheck : MonoBehaviour
{
    [SerializeField]
    private List<string> animalNameList = new List<string> {
                                                              "Husky",
                                                              "Lamb",
                                                              "Mallard"
                                                            };

    public string animal_name;
    public string tag_check;
    public int tag_number;

    public float speed_increase = 0.02f;

    private ParticleSystem playerParticle;
    public bool gameIsOver = false;
    GameObject player;
    // Start is called before the first frame update
    public float speed = 1f;

    GameObject cinecamera;
    public Vector3 cineoriginalPos;
    Cinemachine.CinemachineCollisionImpulseSource source;

    void Awake()
    {

        tag_check = gameObject.tag;

        for (int i = 0; i < 3; i++)
        {
            if (animalNameList[i] == tag_check)
                tag_number = i;
            //break;
        }


        animal_name = animalNameList[FindObjectOfType<CharacterChange>().dropdowncheck];

    }
    public void Update()
    {
        cinecamera = GameObject.FindWithTag("MainCamera");
    }

    public void OnTriggerEnter(Collider other)
    {

        animal_name = animalNameList[FindObjectOfType<CharacterChange>().dropdowncheck];

        if (other.CompareTag("Player"))
        {
            //playerParticle = FindObjectOfType<Collision>().playerParticle;
            //FindObjectOfType<ColorManager>().ChangeColor(particleRend, playerRend);
            //playerParticle.Play();
            if (animal_name == tag_check)     //If the obstacle and the player have the same color
            {
                //FindObjectOfType<PlayerMovement>().Jump();

                FindObjectOfType<ScoreManager>().IncrementScore(50);        //Increments score by 100 (if we delete the second '0' parameter, then a text like "Good Job" will display too)
                //cameraAnim.Play();      //Plays the animation attached to the Main Camera
                //Destroy(other.gameObject);      //Destroys obstacle
                //FindObjectOfType<FollowPath>().movementSpeed += speed_increase;
                //FindObjectOfType<PlayerMovement>().
                Destroy(gameObject);


            }
            else      //If they have different color
            {
                //FindObjectOfType<CameraShake>().Shake();

                if (FindObjectOfType<CharacterChange>().dropdownAnimation.value != 12)
                {
                    //cineoriginalPos = cinecamera.transform.localPosition;
                    FindObjectOfType<FollowPath>().movementSpeed = 10;
                    CinemachineShake.Instance.ShakeCamera(5f, 0.2f);
                    FindObjectOfType<CharacterChange>().dropdownAnimation.value = 12;
                    FindObjectOfType<CharacterChange>().ChangeAnimation();
                }
                else
                {
                    //cineoriginalPos = cinecamera.transform.localPosition;
                    FindObjectOfType<FollowPath>().movementSpeed = 10;
                    CinemachineShake.Instance.ShakeCamera(5f, 0.2f);
                    FindObjectOfType<CharacterChange>().dropdownAnimation.value = 3;
                    FindObjectOfType<CharacterChange>().ChangeAnimation();

                    AnimationDeath();

                    FindObjectOfType<FollowPath>().enabled = false;
                    FindObjectOfType<Spawner>().enabled = false;
                    FindObjectOfType<Collision>().gameIsOver = true;      //Game is over
                                                                          //FindObjectOfType<AudioManager>().DeathSound();      //Plays DeathSound
                    FindObjectOfType<animalGameManager>().EndPanelActivation();       //Activates endPanel
                    FindObjectOfType<PlayerMovement>().enabled = false;     //Stops player

                    FindObjectOfType<Collision>().GetComponent<Renderer>().enabled = false;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>().enabled = false;       //Disables collider
                    //GetComponent<Renderer>().enabled = false;       //Makes player invisible
                    FindObjectOfType<ScoreManager>().combo = 0;


                    //Destroy(gameObject);
                }
            }
        }
    }

    public void AnimationDeath()
    {
        GameObject a = gameObject;
        player = GameObject.FindWithTag("Player");

        int count = a.transform.childCount;
        a.transform.GetComponent<Animation>().Play("HorizontalMovementAnim");
        Invoke("ObstacleAnimationStop", 0.3f);

        for (int i = 0; i < count; i++)
        {
            if (a.GetComponent<Animator>() != null)
            {
                a.GetComponent<Animator>().Play("Death");
            }
            else if (a.transform.GetChild(i).GetComponent<Animator>() != null)
            {
                a.transform.GetChild(i).GetComponent<Animator>().Play("Death");
            }
        }

        a.transform.position = Vector3.MoveTowards(transform.position, transform.forward, speed * Time.deltaTime);
    }

    public void ObstacleAnimationStop()
    {
        GameObject a = gameObject;
        a.transform.GetComponent<Animation>().Stop("HorizontalMovementAnim");

    }

}
