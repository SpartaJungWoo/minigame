using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ani_21R : MonoBehaviour
{

    [SerializeField] List<Sprite> _21R_new = new List<Sprite>();

    [SerializeField] Image _myImage;

    private void Start()
    {
        _myImage = GetComponent<Image>();
        StartCoroutine(Ani_21R());
    }


    IEnumerator Ani_21R()
    {

        int _alpha = 0;

        while (_alpha/ _21R_new.Count < 1f)
        {
            yield return new WaitForSeconds(0.1f);
            _myImage.sprite = _21R_new[_alpha];

            _alpha += 1;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Ani_21R());
    }
}
