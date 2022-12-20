using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreRecord : MonoBehaviour
{
    public static ScoreRecord instance;

    public Text score, highScore;
    public int scoreCounter, highScoreCounter;
    //public GameObject player;
    public AudioClip moneySound;
    AudioSource audio;


    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            highScoreCounter = PlayerPrefs.GetInt("SaveScore");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "money")
            audio.PlayOneShot(moneySound);
        {
            scoreCounter++;
            HighScore();

            Destroy(other.gameObject);

        }
    }


    void Update()
    {
        score.text = "Score: " + scoreCounter;
        highScore.text = "Highscore: " + highScoreCounter;


    }


    public void AddScore()
    {
        
        HighScore();
    }
    public void HighScore()
    {
        if (scoreCounter > highScoreCounter)
        {
            highScoreCounter = scoreCounter;

            PlayerPrefs.SetInt("SaveScore", highScoreCounter);
        }
    }
    public void ResetScore()
    {
        scoreCounter = 0;
    }
}
