using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameUIController : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject deathPanel;
    private KeyCode pauseKey = KeyCode.Escape;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            OpenPausePanel();
        }
    }

    private void OpenPausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenDeathPanel()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
