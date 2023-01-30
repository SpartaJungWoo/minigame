using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] Canvas _canvas;
    [SerializeField] GameObject _background;
    void Start()
    {

        _background = GameObject.Find("Background");
        StartCoroutine(StarMove());
    }

    IEnumerator StarMove()
    {
        while (true)
        {
            transform.parent = _background.transform;
            transform.localScale = Vector3.one;
            transform.localPosition = new Vector3(Random.Range(0, 550), 1470, 0);
            float _lerpTimer = 0f, _lerpDuration = 3f, _alpha = 0f;

            Vector3 _startPos = transform.localPosition;
            Vector3 _endPos = new Vector3(-670, Random.Range(0, -1470), 0);
            while (_alpha < 1)
            {
                _lerpTimer += Time.deltaTime;
                _alpha = _lerpTimer / _lerpDuration;
                yield return null;

                transform.localPosition = Vector3.Lerp(_startPos, _endPos, _alpha);
            }
            Destroy(gameObject);
        }

    }
}
