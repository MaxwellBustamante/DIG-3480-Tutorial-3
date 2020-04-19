using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text DifficultyText;

    private bool gameOver;
    private bool restart;
    private int score;

    public AudioClip backgroundMusic;
    public AudioClip victoryMusic;
    public AudioClip defeatMusic;
    public AudioSource musicSourcebg;

    public bool playerInvincible;
    private float invincDuration = 3.0f;
    private float remainingInvincibleTime;

    void Start()
    {
        playerInvincible = true;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (playerInvincible)
        {
            remainingInvincibleTime -= Time.deltaTime;
            if (remainingInvincibleTime <= 0.0f)
            {
                SetPlayerInvincible(false);
            }
        }
    }

    public void SetPlayerInvincible(bool value)
    {
        playerInvincible = value;
        if (playerInvincible)
        {
            remainingInvincibleTime = invincDuration;
        }
        else if (!playerInvincible)
        {
            remainingInvincibleTime = 0.0f;
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'G' to Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100 && score <= 101)
        {
            musicSourcebg.Stop();
            musicSourcebg.clip = victoryMusic;
            musicSourcebg.Play();
            musicSourcebg.loop = false;
        }
        if (score >= 100)
        {
            DifficultyText.text = "";
            winText.text = "You win! Game Created by Maxwell Bustamante";
            BGScroller.test = true;
            StarScroller.nyoom = true;
            gameOver = true;
            restart = true;
        }
    }
    public void GameOver()
    {
        if (score >= 100)
        {
        }
        else
        {
            DifficultyText.text = "";
            gameOverText.text = "Game Over! Game Created by Maxwell Bustamante";
            musicSourcebg.Stop();
            musicSourcebg.clip = defeatMusic;
            musicSourcebg.Play();
            musicSourcebg.loop = false;
            gameOver = true;
        }
    }

}