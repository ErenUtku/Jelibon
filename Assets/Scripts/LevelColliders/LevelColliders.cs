using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelColliders : MonoBehaviour
{
    public GameObject JumpPanel; 
    private void Start()
    {
        JumpPanel.SetActive(false);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        JumpPanel.SetActive(true);
        Destroy(gameObject);
    }
}
