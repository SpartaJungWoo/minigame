using UnityEngine;

public class GameoverCanvas_PlayButton : MonoBehaviour
{
    public void OnPressed()
    {
        var gameOverCount = PlayerPrefs.GetInt("GameOverCount", 0);
        gameOverCount++;

        PlayerPrefs.SetInt("GameOverCount", gameOverCount);

        CoinGameManager.I.DoResetGame();
    }
}