using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	void Start ()
    {
        FindObjectOfType<ColorManager>().ChangeColor(GetComponent<ParticleSystemRenderer>(), GetComponent<Renderer>());     //Sets the color of the particle to the same color as the gameObject
    }
}
