using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Persistence : MonoBehaviour
{
    public static int bestScore = 0;

    public static Persistence Instance;
    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    //public void GameOver()
    //{
    //    m_GameOver = true;
    //    GameOverText.SetActive(true);

    //    if (m_Points > highScore)
    //    {
    //        highScore = m_Points;

    //    }

    //    HighScoreText.text = "Best Score: Name:" + highScore;
    //}

    public void StartNewScene()
    {

        SceneManager.LoadScene(1);
    }

}
