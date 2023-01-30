using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingEnemy : MonoBehaviour
{
    public GameObject pointChange;

    private Shoot currentGun;
    private float fireRate;
    private float fireRateDelta;
    public GameObject Explode;

    // Start is called before the first frame update
    void Start()
    {
        currentGun = GetComponentInChildren<Shoot>();
        fireRate = currentGun.GetRateOfFire();

    }

    // Update is called once per frame
    void Update()
    {
        fireRateDelta -= Time.deltaTime;
        if(fireRateDelta<=0)
        {
            currentGun.Fire();
            fireRateDelta = fireRate;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        JetPackMan.pointValueTotal += 1000f;
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
