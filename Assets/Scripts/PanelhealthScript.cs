using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelhealthScript : MonoBehaviour
{
    public Text healthtext;
    int hp100 = 100;
    int hp95 = 95;
    void Awake()
    {
        StartCoroutine(ChangeHealth());
        
    }
    IEnumerator ChangeHealth()
    {
        while (true)
        {
            Debug.Log("here");
            healthtext.text = "" + hp95;
            yield return new WaitForSeconds(1f);
            healthtext.text = "" + hp100;
            yield return new WaitForSeconds(1.5f);

        }
    }

}
