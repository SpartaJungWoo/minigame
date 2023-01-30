using UnityEngine;

public class PauseCanvas_HomeButton : MonoBehaviour
{
    public void OnPressed()
    {
        CoinGameManager.I.DoGotoOpeningScene();
    }
}