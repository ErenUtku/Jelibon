using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelControllerLevel2 : MonoBehaviour
{
    public GameObject MidJumpPanel;
    GameObject Speed;
    void Awake()
    {
        Speed = GameObject.FindGameObjectWithTag("Player");
    }

    public void CloseMidJumpPanel()
    {
        MidJumpPanel.SetActive(false);
        Time.timeScale = 1;
        Speed.GetComponent<CharactrerControl>().speed = 10f;
    }

}
