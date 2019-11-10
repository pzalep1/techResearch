using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Text textScore;
    public bool gameOver = false;
    public GameObject gameOverText;

    public float scrollingSpeed = -5f;
    private int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScore()
    {
        if(gameOver == true)
        {
            return;
        }
        score++;
        textScore.text = "Score: " + score.ToString();
    }

    public void BirdDied()
    {
        gameOver = true;
        gameOverText.SetActive(true);
    }
}
