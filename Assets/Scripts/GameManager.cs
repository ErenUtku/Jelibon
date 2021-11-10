using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject OptionPanel;
    public GameObject Swipe;
    public GameObject Chapter1;
    bool Chapter1active = false;

    void Start()
    {
        IsActiveChapter();
    }
    public void IsActiveChapter()
    {
        if (Chapter1active == true)
        {
            Chapter1.SetActive(true);
        }
    }

    public void OpenSkinPanel()
    {
        OptionPanel.SetActive(true);
        DontDestroyOnLoad(Chapter1);
    }
    public void CloseSkinPanel()
    {
        OptionPanel.SetActive(false);
    }
    public void OpenSwipePanel()
    {
        Swipe.SetActive(true);
    }
    public void ClosSwipePanel()
    {
        Swipe.SetActive(false);
    }
    public void Chapter1PanelOpen()
    {
        Chapter1.SetActive(true);
        Chapter1active = true;
    }
    public void Chapter1PanelClose()
    {
        Chapter1.SetActive(false);
    }
 
    public void QuitButton()
    {
        Application.Quit();
    }
}
