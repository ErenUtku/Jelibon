using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    Animator m_Animator;
    AudioSource audioData;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.enabled = false;

        audioData = GetComponent<AudioSource>();
        audioData.Pause();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioData.Play();
        m_Animator.enabled = true;
        
    }
    
    void Update()
    {
        
    }
}
