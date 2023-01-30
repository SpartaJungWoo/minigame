using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라 흔들기



public class CameraShake1 : MonoBehaviour
{
    public float ShakeAmount;

    //public Canvas canvas;

    public float ShakeTime;
    private Rigidbody rb;

    public Vector3 originPos;
    public float positionX, positionY;
    // Start is called before the first frame update
    private void Start()

    {

        positionX = 0f;
        positionY = transform.localPosition.y;
        originPos = transform.localPosition;

    }

    // Update is called once per frame
    private void Update()

    {

        if (ShakeTime > 0)

        {
            originPos = transform.localPosition;
            transform.position = Random.insideUnitSphere * ShakeAmount + originPos;
            ShakeTime -= Time.deltaTime;

        }

        else

        {

            ShakeTime = 0.0f;

            //transform.position = transform.localPosition;
            //canvas.renderMode = RenderMode.ScreenSpaceCamera;

        }
    }
}
