using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    public GameObject character;
    public GameObject checkpoint;
    GameObject health;
    void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player");
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            character.transform.position = checkpoint.transform.position;
            health.GetComponent<CharactrerControl>().hp-=5;
        }
    }
}
