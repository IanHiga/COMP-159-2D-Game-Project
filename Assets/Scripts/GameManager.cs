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

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 0;
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
        score += 100;
        display.text = score + " Pts";
    }

    public void EndGame()
    {
        loseText.enabled = true;
        totalPoints.enabled = true;
        totalPoints.text = score + " Pts";
        display.enabled = false;
        restartButton.GetComponent<Button>().enabled = true;
        restartButton.GetComponent<Image>().enabled = true;
        restartButtonText.GetComponent<Text>().enabled = true;
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float GetScore()
    {
        return score;
    }
}
