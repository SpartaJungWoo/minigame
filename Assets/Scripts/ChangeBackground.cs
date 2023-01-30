using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackground : MonoBehaviour
{
    [SerializeField] List<Sprite> _backgournds = new List<Sprite>();
    [SerializeField] Image _backgorund;



    private void Start()
    {
        StartCoroutine(ChangeBackgorund());
    }
    


    IEnumerator ChangeBackgorund()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _backgorund.sprite = _backgournds[Random.Range(0, _backgournds.Count)];
        }
    }
}
