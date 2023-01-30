using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }
    // Start is called before the first frame update
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;

    public float rx = 0f;
    public float ry = 0f;
    public float rz = 0f;

    public float up = 0f;
    public float forward = 15f;
    public float down = 0f;
    public float back = 0f;

    public float po_x = 0f;
    public float po_y = 10f;
    public float po_z = -20f;

    public Vector3 originalPos;

    private void Awake()
    {
        //originalPos = gameObject.transform.position;

        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
        
    }

    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                     cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                FindObjectOfType<FollowPath>().movementSpeed = 40;
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;

                GameObject.FindWithTag("MainCamera").transform.localPosition = new Vector3(po_x, po_y, po_z);

                Vector3 originalPos = GameObject.FindWithTag("Player").transform.position - GameObject.FindWithTag("MainCamera").transform.position;
                //originalPos = GameObject.FindWithTag("MainCamera").transform.localPosition;
                GameObject.FindWithTag("MainCamera").transform.rotation = Quaternion.LookRotation(originalPos);
                GameObject.FindWithTag("MainCamera").transform.rotation = GameObject.FindWithTag("PlayerHolder").transform.rotation;
                GameObject.FindWithTag("MainCamera").transform.localRotation = Quaternion.Euler(15f, 0f, 0f);
                //GameObject.FindWithTag("MainCamera").transform.Rotate(Vector3.up, up);
                //GameObject.FindWithTag("MainCamera").transform.Rotate(Vector3.down, down);
                //GameObject.FindWithTag("MainCamera").transform.Rotate(Vector3.forward, forward);
                //GameObject.FindWithTag("MainCamera").transform.Rotate(Vector3.back, back);
                //changeCharacter.transform.Rotate(Vector3.forward, 90f);
                //changeCharacter.transform.Rotate(Vector3.up, 180f);
                //GameObject.FindWithTag("MainCamera").transform.SetPositionAndRotation(originalPos, transform.rotation);

                //gameObject.transform.localPosition = FindObjectOfType<Collision_withcheck>().cineoriginalPos;
                //originalPos.x += Random.Range(-FindObjectOfType<PlayerMovement>().mapWidth, FindObjectOfType<PlayerMovement>().mapWidth);
                //originalPos.x = 0f;
                //originalPos.y = 10f;
                //originalPos.z = -20f;

            }
        }
    }
}
