using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDonut : MonoBehaviour
{

    int type;
    float size;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-2.27f, 2.27f);
        float y = Random.Range(3.0f, 5.0f);

        transform.position = new Vector3(x, y, 0);

        type = Random.Range(1, 4);
        if (type == 1)
        {
            size = 0.1f;
        }
        else if (type == 2)
        {
            size = 0.2f;
        }
        else
        {
            size = 0.25f;
        }
        transform.localScale = new Vector3(size, size, 0);
    }
}
