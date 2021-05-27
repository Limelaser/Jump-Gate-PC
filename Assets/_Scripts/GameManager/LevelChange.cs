using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public string levelName;

    private void Start()
    {
    
    }
    // constantly checks to see if certain parameters have been met
    void Update()
    {
        // checks if the current scene name is Cutscene, Cutscene 1 or Cutscene 2
        if (SceneManager.GetActiveScene().name == "Cutscene"  ||
            SceneManager.GetActiveScene().name == "Cutscene 1" ||
            SceneManager.GetActiveScene().name == "Cutscene 2")
        {
            // if it is it starts a countdown
            StartCoroutine(TimeCoroutine());
        }

        // checks to see if the escape key has been pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // if pressed quit the application
            Application.Quit();
        }

        // checks if the current scene name is either Intro or End
        if (SceneManager.GetActiveScene().name == "Intro" ||
            SceneManager.GetActiveScene().name == "End")
        {
            // if it is it starts a countdown
            StartCoroutine(GameIntroCoroutine());
        }
    }

    IEnumerator GameIntroCoroutine()
    {
        // starts a 9 scecond countdown for the voice over
        yield return new WaitForSeconds(9);
        SceneManager.LoadScene(levelName);
    }

    IEnumerator TimeCoroutine()
    {
        // starts a 10 second countdown for the cutscene
        yield return new WaitForSeconds(10);
        // loads next scene when the countdown hits 0
        SceneManager.LoadScene(levelName);
    }
    
    // next level script for buttons
    public void nextLevel()
    {
        // loads next level
        SceneManager.LoadScene(levelName);
    }
    
    // closes/quits the game
    public void Quit()
    {
        // closes/quits the game
        Application.Quit();
    }
}

/* create a customizable string called levelName
 * 
 * keeps checking if the name of the scene is "Cutscene" "Cutscene 1" or "Cutscene 2"
 * if it is then starts a count down coroutine that loads the level currently specified in levelName upon compleation
 * 
 * keeps checking if the name of the scene is either "Intro" or "End"
 * if true it starts another countdown that loads the level currently specified in levelName upon compleation
 * 
 * keep checking to see if the escape key has been pressed
 * if it has then quit the application
 * 
 * if the count down is started, wait ten seconds before changing to the level specified in the levelName string
 * 
 * if the nextLevel function is called on change to the level specified in the levelName string
 * 
 * if the Quit function is called then quit the application
 */
