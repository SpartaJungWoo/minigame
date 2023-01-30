using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSkipButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}