using UnityEngine;

public class BtnRight : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
    }

    public void OnMouseDown()
    {
        if (CoinGameManager.I.IsMatched("SilverCoin") || CoinGameManager.I.IsMatched("SilverCoinFull"))
            CoinGameManager.I.RemoveCoin();
        else
            CoinGameManager.I.Wrong();
    }
}