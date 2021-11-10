using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLevel : MonoBehaviour
{

    public GameObject last;

    GameObject Speed;
    void Awake()
    {
        Speed = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        last.SetActive(false);
    }

    public void lastlevel()
    {
        Speed.GetComponent<CharactrerControl>().speed = 0;
        last.SetActive(true);
        GetComponent<AudioSource>().Play();

    }
}