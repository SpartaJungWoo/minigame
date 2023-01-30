using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarSpawn : MonoBehaviour
{
    [SerializeField] GameObject _star;
    float _reSpawnTime;

    private void Start()
    {
        StartCoroutine(StarSpawner());
    }

    IEnumerator StarSpawner()
    {

        while (true)
        {
            Instantiate(_star);

            _reSpawnTime = Random.Range(1f, 3f);

            yield return new WaitForSeconds(_reSpawnTime);
        }

    }
}
