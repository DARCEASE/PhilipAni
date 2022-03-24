using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float timer, spd, colorTime, t, spdtimer;
    public Vector4 startColor, endColor;
    public TextMeshProUGUI timerText, carCount;

    public GameObject endScreen, blackScreen;
    public TitleScreenScript title;
    public PlayerScript p;

    public int mode;
    // Start is called before the first frame update
    void Start()
    {
        title = GetComponent<TitleScreenScript>();
        p = GameObject.Find("vespa").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mode);
       if(title.mode == 2)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                timerText.text = "Time: " + Mathf.RoundToInt(timer);
            }
            else if (timer <= 0 && mode == 0)
            {
                timerText.text = null;
                mode = 1;
                Debug.Log("game end");
            }

            if (mode == 1)
            {
                spdtimer += Time.deltaTime;
                t = spdtimer * spd;
                blackScreen.GetComponent<Image>().color = Vector4.Lerp(startColor, endColor, t);
                if (blackScreen.GetComponent<Image>().color.a >= 1)
                {
                    mode = 2;
                }
            }
            if (mode == 2)
            {
                spdtimer = 0;
                colorTime += Time.deltaTime;
                if (colorTime >= 1)
                {
                    endScreen.gameObject.SetActive(true);
                    mode = 3;
                }
            }
            if (mode == 3)
            {
                SceneManager.LoadScene(1);
            }

        }
    }
    public void RestartFunction()
    {
        timer = 30;
    }
}
