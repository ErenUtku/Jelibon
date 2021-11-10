using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMovementZero : MonoBehaviour
{
    GameObject Speed;
    void Awake()
    {
        Speed = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        Speed.GetComponent<CharactrerControl>().speed = 0;     
    }

}
