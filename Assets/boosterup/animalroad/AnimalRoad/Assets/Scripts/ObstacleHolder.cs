using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHolder : MonoBehaviour
{
    public Renderer[] obstRenderers;

    void Start()
    { 
        FindObjectOfType<ColorManager>().SetRandomColor(obstRenderers[0]);      //Selects a random color for the first obstacle


        do
        {
            FindObjectOfType<ColorManager>().SetRandomColor(obstRenderers[1]);      //Selects a random color for the second obstacle
        } while (obstRenderers[0].material.color == obstRenderers[1].material.color);

        do
        {
            FindObjectOfType<ColorManager>().SetRandomColor(obstRenderers[2]);      //Selects a random color for the third obstacle
        } while (obstRenderers[0].material.color == obstRenderers[2].material.color || obstRenderers[1].material.color == obstRenderers[2].material.color);
    }
}
