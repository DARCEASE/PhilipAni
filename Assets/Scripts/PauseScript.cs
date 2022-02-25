using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseScript : MonoBehaviour
{
    public bool isPaused;
    public GameObject pausedPanel, pauseButton;
    public TitleScreenScript title;

    public GameObject player;
    public GameObject[] obstacles;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerScript>().gameObject;
        title = gameObject.GetComponent<TitleScreenScript>();
    }

    // Update is called once per frame
    void Update()
    {
       if(title.mode == 1)
        {
            if (isPaused)
            {
                PauseFunction();
            }
            else
            {
                ResumeFunction();
            }
        }
    }

    public void PauseFunction()
    {
        isPaused = true;
        pausedPanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void ResumeFunction()
    {
        isPaused = false;
        pausedPanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void RestartFunction()
    {
        isPaused = false;
        pausedPanel.SetActive(false);
        pauseButton.SetActive(true);
        title.gameTimer = 0;
        Time.timeScale = 1;
        RemoveCars();
    }
    public void TitleFunction()
    {
        SceneManager.LoadScene(0);
    }

    void RemoveCars()
    {
        obstacles = GameObject.FindGameObjectsWithTag("car");
        foreach(GameObject obj in obstacles)
        {
            Destroy(obj);
        }
    }
}
