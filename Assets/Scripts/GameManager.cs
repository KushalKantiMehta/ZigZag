using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        gameOver = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void StartGame()
    {
        UiManager.instance.GameStart();
        ScoreManager.instance.startScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpwaning();

    }
    public void GameOver()
    {
        UiManager.instance.GameOver();
        ScoreManager.instance.stopScore();
        gameOver = true;
    }
}
