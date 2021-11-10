using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PanelController : MonoBehaviour
{
    public GameObject FirstPanel1, FirstPanel2, FirstPanel3, JumpPanel, CloudPanel, HighJumpPanel, BouncePanel,HealthPanel,FinishFlagPanel;
    GameObject Speed;
    void Awake()
    {
        Speed = GameObject.FindGameObjectWithTag("Player");
    }  


    public void Start()
    {
        StartCoroutine(GameStartPanel());
    }
    public void CloseFirstPanel1ToFirstPanel2()
    {
        FirstPanel1.SetActive(false);
        FirstPanel2.SetActive(true);

    }
    public void CloseFirstPanel2ToFirstPanel3()
    {
        FirstPanel2.SetActive(false);
        FirstPanel3.SetActive(true);
    }
    public void CloseFirstPanel3()
    {
        FirstPanel3.SetActive(false);
        Time.timeScale = 1;
        Speed.GetComponent<CharactrerControl>().speed = 10f;
    }
    public void CloseFlagPanel()
    {
        FinishFlagPanel.SetActive(false);
        Time.timeScale = 1;
        Speed.GetComponent<CharactrerControl>().speed = 10f;
    }
    public void CloseHealthPanel()
    {
        HealthPanel.SetActive(false);
        Time.timeScale = 1;
        Speed.GetComponent<CharactrerControl>().speed = 10f;
    }
    public void ClosejumpPanel()
    {
        JumpPanel.SetActive(false);
        Time.timeScale = 1;
        Speed.GetComponent<CharactrerControl>().speed = 10f;
    }
    public void CloseBouncePanel()
    {
        BouncePanel.SetActive(false);
        Time.timeScale = 1;
        Speed.GetComponent<CharactrerControl>().speed = 10f;
    }
    public void CloseCloudPanel()
    {
        CloudPanel.SetActive(false);
        Time.timeScale = 1;
        Speed.GetComponent<CharactrerControl>().speed = 10f;
    }
    public void CloseHighJumpPanel()
    {
        HighJumpPanel.SetActive(false);
        Time.timeScale = 1;
        Speed.GetComponent<CharactrerControl>().speed = 10f;
    }


    IEnumerator GameStartPanel()
    {
        
        yield return new WaitForSeconds(2.1f);
        FirstPanel1.SetActive(true);
        
    }
}
