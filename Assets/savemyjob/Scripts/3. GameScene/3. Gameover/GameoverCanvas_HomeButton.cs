using UnityEngine;

public class GameoverCanvas_HomeButton : MonoBehaviour
{
    public void OnPressed()
    {
        CoinGameManager.I.DoGotoOpeningScene();
    }
}