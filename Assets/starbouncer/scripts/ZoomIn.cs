using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public GameObject fullShot;
    public GameObject cam;
    public float width;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        cam.GetComponent<camera>().target = fullShot; //ī�޶� Ÿ��
        cam.GetComponent<camera>().camwidth = width; //ī�޶� Ȯ�� ����
        cam.GetComponent<camera>().speed = 1.0f; //ī�޶� Ÿ������ �̵� �ӵ�
        cam.GetComponent<camera>().zoom(); //ī�޶��� ����(�ܾƿ���) ��������

    }



}
