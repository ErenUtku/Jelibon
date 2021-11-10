using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerScript : MonoBehaviour
{
    Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();       
    }
    public void OnTriggerEnter2D(Collider2D othercollidder)
    {
        
        m_Animator.SetBool("IsBouncing", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        m_Animator.SetBool("IsBouncing", false);
    }


    void Update()
    {
        
    }
}
