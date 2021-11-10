using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMechanic : MonoBehaviour
{
    Animator m_Animator;
    //AudioSource audioData;
    [SerializeField] GameObject obstacle;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.enabled = false;
        obstacle.SetActive(true);
       
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            m_Animator.enabled = true;
            StartCoroutine(removeobstacle());           
        }
        

    }
    IEnumerator removeobstacle()
    {
        yield return new WaitForSeconds(0.3f);
        obstacle.SetActive(false);
    }

    void Update()
    {

    }
}
