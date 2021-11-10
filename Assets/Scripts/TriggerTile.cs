using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTile : MonoBehaviour
{
    public BoxCollider2D Safe;
    
    void Start()
    {
        Safe.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Safe.enabled = true;
            StartCoroutine(WaitAndPop());
        }
    }
    IEnumerator WaitAndPop()
    {
        yield return new WaitForSeconds(.1f);
        Safe.enabled = true;
    }
    void Update()
    {
        
    }
}
