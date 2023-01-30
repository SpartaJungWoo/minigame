using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRecommend : MonoBehaviour
{
    [SerializeField] List<Sprite> _bannerImg = new List<Sprite>();

    [SerializeField] Image _banner;


    private void Start()
    {
        StartCoroutine(ChangeBanner());
    }

    IEnumerator ChangeBanner()
    {

        while (true)
        {
            yield return new WaitForSeconds(1.5f);

            _banner.sprite = _bannerImg[Random.Range(0, _bannerImg.Count)];

        }
    }
}
