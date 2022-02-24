using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public bool isPaused;
    public GameObject pausedPanel, pauseButton;
    public TitleScreenScript title;

    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log("restarts the game weee");
    }
public void TitleFunction()
    {
        Debug.Log("goes back to title");
    }
}
