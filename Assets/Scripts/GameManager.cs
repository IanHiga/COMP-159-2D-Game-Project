using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float score;
    private float timer;
    [SerializeField] private Text display;
    [SerializeField] private Text loseText;
    [SerializeField] private Text totalPoints;
    [SerializeField] private Button restartButton;
    [SerializeField] private Text restartButtonText;
    [SerializeField] private Button menuButton;
    [SerializeField] private Text menuButtonText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text newHS;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 0;
        highScoreText.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetFloat("HighScore");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            score += 1;
            timer = 0;
        }
        display.text = score + " Pts";
    }

    public void PassedSpike()
    {
        score += 10;
        display.text = score + " Pts";
    }

    public void CollectCoin()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
        score += 100;
        display.text = score + " Pts";
    }

    public void EndGame()
    {
        loseText.enabled = true;
        totalPoints.enabled = true;
        totalPoints.text = score + " Pts";
        display.enabled = false;
        menuButton.GetComponent<Image>().enabled = true;
        menuButton.GetComponent<Button>().enabled = true;
        menuButtonText.GetComponent<Text>().enabled = true;
        restartButton.GetComponent<Button>().enabled = true;
        restartButton.GetComponent<Image>().enabled = true;
        restartButtonText.GetComponent<Text>().enabled = true;
        Time.timeScale = 0;
        if (score > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            newHS.GetComponent<Text>().enabled = true;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public float GetScore()
    {
        return score;
    }
}
