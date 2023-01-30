using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

public class nextStage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        //���� �� ������ ������ �´�
        Scene scene = SceneManager.GetActiveScene();

        //���� ���� ���� ������ ������ �´�
        int curScene = scene.buildIndex;

        //���� �� �ٷ� ���� ���� �������� ���� +1�� ���ش�.
        int nextScene = curScene + 1;

        //���� ���� �ҷ��´�
        SceneManager.LoadScene("starbuncer");
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();

    }

    public void retry()
    {
        Addressables.LoadSceneAsync(gameObject.scene.name);
        SceneManager.LoadScene("starbuncer");
    }

    public void exit()
    {
        SceneManager.LoadScene("LobbyScene");
    }

}
