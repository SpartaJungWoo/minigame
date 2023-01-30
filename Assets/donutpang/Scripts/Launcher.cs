using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Launcher : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endDragPosition;
    private LaunchPreview launchPreview;
    public bool didfunction = false;
    public bool abletoshoot = true;
    [SerializeField] private Animator myAnimationController;

    public int totalBallCount = 0;

    public GameObject[] doughnuts;

    int randomInt;


    private void Start()
    {
        didfunction = true;
    }
    private void Awake()
    {
        launchPreview = GetComponent<LaunchPreview>();
    }

    private void Update()
    {
        if(didfunction)
        {
            Destroy(GameObject.Find("sample"));
            randomInt = UnityEngine.Random.Range(0, doughnuts.Length);
            var sample = Instantiate(doughnuts[randomInt], new Vector3(0, (float)-3.3, 0), Quaternion.identity);
            sample.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            sample.name = ("sample");
            didfunction = false;
        }

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * -10;

        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(worldPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrag(worldPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    public void EndDrag()
    {
        if(abletoshoot == true)
        {
            if (DonutPangGameManager.I.isPause == false)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    myAnimationController.SetBool("Shoot", true);
                    //if (donutSFXManager.sfxInstance.musicToggle == true)
                    //    donutSFXManager.sfxInstance.Audio.PlayOneShot(donutSFXManager.sfxInstance.shoot);

                    Vector3 direction = endDragPosition - startPosition;
                    direction.Normalize();


                    var ball = Instantiate(doughnuts[randomInt], transform.position, Quaternion.identity);
                    ball.GetComponent<Donut>().ballNo = totalBallCount;
                    ball.GetComponent<Rigidbody2D>().AddForce(-direction * 300);

                    totalBallCount += 1;
                    didfunction = true;
                    abletoshoot = false;
                    StartCoroutine(TriggerStayRoutine());

                }
            }
        }
        


    }


    private void ContinueDrag(Vector3 worldPosition)
    {

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            endDragPosition = worldPosition;

            Vector3 direction = endDragPosition - startPosition;

            launchPreview.SetEndPoint(transform.position - direction);
        }
    }

    private void StartDrag(Vector3 worldPosition)
    {

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            startPosition = worldPosition;
            launchPreview.SetStartPoint(transform.position);
            myAnimationController.SetBool("Shoot", false);

        }
    }

    IEnumerator TriggerStayRoutine()
    {
        yield return new WaitForSeconds(0.75f);
        abletoshoot = true;
    }
}
