using UnityEngine;

public class BtnPause : MonoBehaviour
{
    public void OnPressed()
    {
        CoinGameManager.I.TogglePause();
    }
}