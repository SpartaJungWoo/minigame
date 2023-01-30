using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialImage : MonoBehaviour
{
    public Sprite Page1Ko;
    public Sprite Page2Ko;
    public Sprite Page3Ko;
    public Sprite Page4Ko;

    public Sprite Page1En;
    public Sprite Page2En;
    public Sprite Page3En;
    public Sprite Page4En;

    public Button SkipButton;

    private int CurrentIndex;

    private void Start()
    {
        var trigger = GetComponent<EventTrigger>();
        var entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener(data => { OnPointerDownDelegate( /*(PointerEventData)data*/); });
        trigger.triggers.Add(entry);

        OnPointerDownDelegate();
    }

    public void OnPointerDownDelegate( /*PointerEventData data*/)
    {
        CurrentIndex++;
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            if (CurrentIndex == 1) gameObject.GetComponent<Image>().sprite = Page1Ko;

            if (CurrentIndex == 2)
            {
                SkipButton.gameObject.SetActive(false);
                gameObject.GetComponent<Image>().sprite = Page2Ko;
            }

            if (CurrentIndex == 3) gameObject.GetComponent<Image>().sprite = Page3Ko;

            if (CurrentIndex == 4) gameObject.GetComponent<Image>().sprite = Page4Ko;

            if (CurrentIndex == 5) SceneManager.LoadScene("GameScene");
        }
        else
        {
            if (CurrentIndex == 1) gameObject.GetComponent<Image>().sprite = Page1En;

            if (CurrentIndex == 2)
            {
                SkipButton.gameObject.SetActive(false);
                gameObject.GetComponent<Image>().sprite = Page2En;
            }

            if (CurrentIndex == 3) gameObject.GetComponent<Image>().sprite = Page3En;

            if (CurrentIndex == 4) gameObject.GetComponent<Image>().sprite = Page4En;

            if (CurrentIndex == 5) SceneManager.LoadScene("GameScene");
        }
    }
}