using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingEnemy : MonoBehaviour
{
    public GameObject pointChange;

    public float speed = 0.8f;
    public float range = 3;

    float startingY;
    int dir = 1;

    public GameObject Explode;

    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime * dir);
        if(transform.position.y < startingY || transform.position.y > startingY+range)
            dir *= -1;
    }


    void OnParticleCollision(GameObject other)
    {
        JetPackMan.pointValueTotal += 500f;
        JetPackMan.fevermodecount += 1;
        // JetPackMan.topScore *= 2;
        Destroy(this.gameObject);
        Instantiate(Explode, this.transform.position, Quaternion.identity);
        Instantiate(pointChange, new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z), Quaternion.identity);
        Handheld.Vibrate();

        if (SFXManager.sfxInstance.musicToggle == true)
            SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Kill);
    }
}
