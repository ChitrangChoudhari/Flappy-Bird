using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TMP_Text scoreText;
    public TMP_Text highScore;
    public GameObject gameOverScreen;
    public AudioManagerScript audio;

    private void Awake()
    {
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
        highScore.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }

    public void addScore(int scoreToAdd)
    {
        playerScore+=scoreToAdd;
        scoreText.text=playerScore.ToString();
    }

    public void Update()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (playerScore > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", playerScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", playerScore);
        }
        highScore.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }

    public void restartGame()
    {
        audio.PlaySFX(audio.button);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void mainmenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
