using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollision : MonoBehaviour
{
    public ParticleSystem sparkle;

    private void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cloud")
        {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
            sparkle.Play();
        }

    }
   
}
