using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public Text restartText;
    public Text gameOverText;
    public Text scoreText;

    public string level;
    public string nextLevel;

    public List<Image> UIImages = new List<Image>();
    public float speed;

    public int score;
    public int finish;
    private bool gameOver;
    private bool restart;

    // all code here is executed at the start
    private void Start()
    {
        // sets gameover and restart to false
        gameOver = false;
        restart = false;
        // sets the restart and gameover text to say nothing
        restartText.text = "";
        gameOverText.text = "";
        // sets the score to 0 and instantiates updatescore and calls upon the coroutine spawnwaves
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        
    }

    private void Update()
    {
        // continuasly checks the game for an object with the tag player
        GameObject.FindGameObjectWithTag("Player");

        // if the restart bool is true-
        if (restart == true)
        {
            // and the R key is pressed
            if (Input.GetKeyDown(KeyCode.R))
            {
                // then it restarts the current level
                SceneManager.LoadScene(level);
            }
        }

        // if the score has reached a preset number (finish)
        if (score >= finish)
        {
            // then it activates both coroutines
            StartCoroutine(CutSceneActivation());
            StartCoroutine(CutSceneDelay());
        }
    }

    // makes an image fade in by incrimenting the alpha value from 0 to 255 before the cutscene activates
    IEnumerator CutSceneActivation()
    {
        float alpha = UIImages[0].color.a;
        while (alpha < 1)
        {
            alpha += Time.deltaTime * speed;
            for (int i = 0; i < UIImages.Count; i++)
            {
                UIImages[i].color = new Color(UIImages[i].color.r, UIImages[i].color.g, UIImages[i].color.b, alpha);
            }
            yield return null;
        }
    }

    // sets off a 1 second timer that upon finishing loads the next level
    IEnumerator CutSceneDelay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevel);
    }

    IEnumerator SpawnWaves()
    {
        // counts down from an editable float
        yield return new WaitForSeconds(startWait);
        // if the float has reached 0
        while (true)
        {
            // makes the hazardCount go up by 1
            for (int i = 0; i < hazardCount; i++)
            {
                // sets hazard to hazards and generates a random number between 0 and an editable float
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                // sets a new Vector3 with a random x value between -09 and 09
                Vector3 spawnPosition = new Vector3(Random.Range(-09.0f, 09.0f), spawnValues.y, spawnValues.z);
                // sets spawn rotation to a random rotation using Quaternions
                Quaternion spawnRotation = new Quaternion();
                // creates a new hazard
                Instantiate(hazard, spawnPosition, spawnRotation);
                // waits for a certain number of seconds to pass before spawning the next hazard
                yield return new WaitForSeconds(spawnWait);
                // if it doesn't find an object with the player tag
                if (GameObject.FindGameObjectWithTag("Player") == null)
                {
                    // calls on the gameover function and breaks out of the loop
                    GameOver();
                    break;
                }
            }
            // waits for a period of time before spawning a new wave
            yield return new WaitForSeconds(waveWait);

            // checks if the gameover bool is true
            if (gameOver == true)
            {
                // activates the instructions to restart the level and sets the restart bool to true
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        // adds the score value of an object to the current score
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        // sets the score text to display score and the current number
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // activates the gameover text and sets the gameover bool to true
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
