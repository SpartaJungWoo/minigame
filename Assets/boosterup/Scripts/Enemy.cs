using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject pointChange;

    public GameObject Explode;

    void OnParticleCollision(GameObject other)
    {
        JetPackMan.pointValueTotal += 200f;
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
