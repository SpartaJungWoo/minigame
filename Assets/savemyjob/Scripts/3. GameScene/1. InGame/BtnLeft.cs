using UnityEngine;

public class BtnLeft : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
    }

    public void OnMouseDown()
    {
        if (CoinGameManager.I.IsMatched("GoldCoin") || CoinGameManager.I.IsMatched("GoldCoinFull"))
            CoinGameManager.I.RemoveCoin();
        else
            CoinGameManager.I.Wrong();
    }
}