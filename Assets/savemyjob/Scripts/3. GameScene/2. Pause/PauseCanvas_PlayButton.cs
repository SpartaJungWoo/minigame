using UnityEngine;

public class PauseCanvas_PlayButton : MonoBehaviour
{
    public void OnPressed()
    {
        CoinGameManager.I.TogglePause();
    }
}