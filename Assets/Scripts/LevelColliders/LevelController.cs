using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    public float WaitToLoad = 4f;
    public int Coins = 3;
    public GameObject WinLabel;
    

    GameObject Speed;
    void Awake()
    {
        Speed = GameObject.FindGameObjectWithTag("Player");
    }

    private int nextSceneIndex;


    private void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        WinLabel.SetActive(false);
        
    }
    public void CoinsPicked()
    {
        Coins--;
        if (Coins <= 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    public void LevelCompleted()
    {
        StartCoroutine(HandleWinCondition());
    }
    IEnumerator HandleWinCondition()
    {
        Speed.GetComponent<CharactrerControl>().speed = 0;
        WinLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(WaitToLoad);
        SceneManager.LoadScene(nextSceneIndex);
       

    }
}
