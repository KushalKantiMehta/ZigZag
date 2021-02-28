using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;


    public GameObject ZigzagPanel;
    public GameObject GameOverPanel;
    public GameObject TapText;
    public Text Score;
    public Text CurrentScore;
    public Text highScore1;
    public Text highScore2;

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
        highScore1.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void GameStart()
    {
       
        TapText.SetActive(false);
        ZigzagPanel.GetComponent<Animator>().Play("PanelUp");
        TapText.GetComponent<Animator>().Play("BlinkText");

    }

    public void GameOver()
    {
        Score.text =PlayerPrefs.GetInt ("Score").ToString();
        highScore2.text =PlayerPrefs.GetInt ("highScore").ToString();
     
        GameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0); 
    }
    // Update is called once per frame
    void Update()
    {
        CurrentScore.text = PlayerPrefs.GetInt("Score").ToString();
    }
}
