using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    GameObject levels,level1,level2,level3;
    GameObject locks,lock1,lock2,lock3;
    void Start()
    {
        level1 = GameObject.Find("Level1Buton");
        level2 = GameObject.Find("Level2Buton");
        level3 = GameObject.Find("Level3Buton");

        lock1 = GameObject.Find("Level1Lock");
        lock2 = GameObject.Find("Level2Lock");
        lock3 = GameObject.Find("Level3Lock");
     

        levels = GameObject.Find("Levels");
        locks = GameObject.Find("Locks");

          for (int i = 0; i < PlayerPrefs.GetInt("WhichLevel"); i++)
          {
              levels.transform.GetChild(i).GetComponent<Button>().interactable = true;
          }
        for (int i = 0; i < PlayerPrefs.GetInt("WhichLevel"); i++)
        {
            var LockOverlay = locks.transform.GetChild(i).gameObject;
            LockOverlay.SetActive(false);
            
        }
    }
  
    void Update()
    {
         
    }
}
