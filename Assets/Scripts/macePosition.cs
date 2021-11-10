using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macePosition : MonoBehaviour
{
    public GameObject macelocation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = macelocation.transform.position;
    }
}
