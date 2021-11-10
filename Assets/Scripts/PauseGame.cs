using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PausePanel;
  
    public void OpenPausePanel()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;      
    }
    public void ClosePausePanel()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitLevel()
    {       
        SceneManager.LoadScene(1);
    }
}
