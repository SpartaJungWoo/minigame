using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityChanger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Material material;
    [SerializeField] private Renderer myModel;

    private void Start()
    {
        Color color = myModel.material.color;
        color.a = 0;
        myModel.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
