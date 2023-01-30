using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Setting _setting;

    bool _onVibration = true;

    [SerializeField] Button _vibration; 
    [SerializeField] List<Sprite> _vibrations = new List<Sprite>(); 


    public void SetClick()
    {
        _setting.gameObject.SetActive(true);
    }

    public void SetSaveSlick()
    {
        _setting.gameObject.SetActive(false);
    }

    public void SetVibrationClick()
    {
        _onVibration = !_onVibration;

        if (_onVibration)
        {
            _vibration.GetComponent<Image>().sprite = _vibrations[0];
        }
        else
        {
            _vibration.GetComponent<Image>().sprite = _vibrations[1];
        }
    }
}
