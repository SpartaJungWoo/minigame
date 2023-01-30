using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public Color[] colors, chooseColorsFrom;

    private int randomColor, randomColor2, randomColor3;
    public Color playerColor;
    public Color trailColor;

    private Renderer playerRend;
    private Renderer trailRend;

    //Color changing functions
    //These functions are called in other scripts

    void Awake()
    {
        randomColor = Random.Range(0, chooseColorsFrom.Length);
        colors[0] = chooseColorsFrom[randomColor];

        do
        {
            randomColor2 = Random.Range(0, chooseColorsFrom.Length);
        } while (randomColor == randomColor2);

        do
        {
            randomColor3 = Random.Range(0, chooseColorsFrom.Length);
        } while (randomColor == randomColor3 || randomColor2 == randomColor3);

        colors[1] = chooseColorsFrom[randomColor2];
        colors[2] = chooseColorsFrom[randomColor3];
    }

    public void SetRandomColor(Renderer obj)
    {
      
            obj.material.color = colors[Random.Range(0, colors.Length)];
            //obj.material.color = colors[0];
      
    }

    public void ChangeColor(Renderer from, Renderer to)
    {
        from.material.color = to.material.color;
    }

    public bool CompareColor(Renderer obj1, Renderer obj2)
    {
        return obj1.material.color == obj2.material.color;
    }

    //public void TrailChangeColor(Renderer from, Renderer to)
    //{
    //    from.material.color = to.material.color;
    //    //trailRend = GameObject.FindGameObjectWithTag("Trail").GetComponent<Renderer>();
        
    //}
}
