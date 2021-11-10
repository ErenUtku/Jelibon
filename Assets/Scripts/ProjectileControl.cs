using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControl : MonoBehaviour
{
    MaceScript mace;
    Rigidbody2D physic;

    [SerializeField] AudioClip HitSound;
    [SerializeField] [Range(0, 1)] float HitSoundVolume = 0.3f;

    void Start()
    {
        mace = GameObject.FindGameObjectWithTag("Enemy").GetComponent<MaceScript>();
        physic = GetComponent<Rigidbody2D>();
        physic.AddForce(mace.getDirection()*1000);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            AudioSource.PlayClipAtPoint(HitSound, transform.position, HitSoundVolume);
            Destroy(gameObject);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
