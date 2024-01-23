using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // You need to add this for SceneManager
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private TMP_Text scoreText;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public bool isGameOver;
    private int score;

    // Agrega una referencia al Animator del jugador
    [SerializeField] private Animator playerAnimator;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGameOver)
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        // Activa el texto de Game Over
        isGameOver = true;
        gameOverText.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

    }
}
