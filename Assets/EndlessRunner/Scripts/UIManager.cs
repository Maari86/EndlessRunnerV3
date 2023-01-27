using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject pauseScreen;
    //public TextMeshProUGUI scoreText;
   // public int score;



    private void OnEnable()
    {
        Health.OnPlayerDeath += EnableGameOverMenu;
      
    }

    private void OnDisable()
    {
        Health.OnPlayerDeath -= EnableGameOverMenu;
      
    }
    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }

      //  score = (int)Time.time;
      //  scoreText.text = "Score : " + score.ToString() + "s";
    }
    #region Game Over
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    #endregion

    #region Pause
    public void  PauseGame(bool status)
    {
        pauseScreen.SetActive(status);

     //   if (status)
     //       Time.timeScale = 0;
      //  else
      //      Time.timeScale = 1;
    }
    #endregion
}
