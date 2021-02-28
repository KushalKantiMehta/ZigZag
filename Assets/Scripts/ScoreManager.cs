using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int Score;
    public int HighScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        PlayerPrefs.SetInt("Score", Score);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Score", Score);
    }

    void incrementScore()
    {
        Score += 1;
    }
    public void startScore()
    {
        InvokeRepeating("incrementScore", 0.1f, 0.5f);
    }
   public void stopScore()
    {
        CancelInvoke("incrementScore");
        PlayerPrefs.SetInt("Score", Score);

        if (PlayerPrefs.HasKey("highScore")) 
        {
            if (Score>PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", Score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", Score);
        }
    }



}
