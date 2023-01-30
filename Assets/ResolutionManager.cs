using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{



    private void Start()
    {
        SetResolution();
    }


    void SetResolution()
    {
        int _setWidth = 1440;
        int _setHeight = 3040;

        int _deviceWidth = Screen.width;
        int _deviceHeight = Screen.height;

        Screen.SetResolution(_setWidth, (int)(((float)_deviceHeight / _deviceWidth) * _setWidth), true);

        if ((float)_setWidth / _setHeight < (float)_deviceWidth / _deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)_setWidth / _setHeight) / ((float)_deviceWidth / _deviceHeight); 
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); 
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)_deviceWidth / _deviceHeight) / ((float)_setWidth / _setHeight); 
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); 
        }
    }
}
