using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{

    public GameObject Tutorial;
    public GameObject QuestionMark;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openHelp()
    {
        Tutorial.SetActive(true);
        QuestionMark.SetActive(false);
    }

    public void closeHelp()
    {
        Tutorial.SetActive(false);
        QuestionMark.SetActive(true);
    }
}
