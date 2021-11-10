using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScubaHelmet : MonoBehaviour
{
    public GameObject helmet;
    public GameObject groundhelmet;
    public GameObject gamebreakercollision;
    public GameObject noreturncollider;
    void Start()
    {
        helmet.SetActive(false);
        noreturncollider.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "helmet")
        {
            helmet.SetActive(true);
            Destroy(groundhelmet);
            Destroy(gamebreakercollision);
            noreturncollider.SetActive(true);
        }
    }
    void Update()
    {
        
    }
}
