using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuHero;
    [SerializeField] private Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", 0);
        }
        highScoreText.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetFloat("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        menuHero.GetComponent<Transform>().rotation *= Quaternion.Euler(new Vector3(0, 0, 0.5f));
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
