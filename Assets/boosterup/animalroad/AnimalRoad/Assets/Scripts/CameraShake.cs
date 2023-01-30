using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakes = 0f;
    public float shakeAmount = 0.05f;
    public float decreaseFactor = 1.0f;
    Vector3 OriginalPos;
    public bool CameraShaking;
    public GameObject playerHolder;

    private void OnEnable()
    {
        CameraShaking = false;
        
    }

    private void Update()
    {
        if (CameraShaking)
        {
            if(shakes > 0f)
            {
                OriginalPos = gameObject.transform.position;

                OriginalPos.y += 6.8f;
                OriginalPos.z -= 15.5f;

                gameObject.transform.position = OriginalPos + Random.insideUnitSphere * shakeAmount;

                shakes -= Time.deltaTime * decreaseFactor;


            }
            else
            {
                shakes = 0f;
                CameraShaking = false;
                //gameObject.transform.position = playerHolder.transform.position;
                OriginalPos = gameObject.transform.position;

                OriginalPos.y += 6.8f;
                OriginalPos.z -= 15.5f;

                gameObject.transform.position= OriginalPos;
            }
        }

      
    }

    public void ShakeCamera(float shaking)
    {
        if (!CameraShaking)
        {
            OriginalPos = gameObject.transform.position;

            OriginalPos.y += 6.8f;
            OriginalPos.z -= 15.5f;

            //OriginalPos = playerHolder.transform.position;
        }

        shakes = shaking;
        CameraShaking = true;
    }

}