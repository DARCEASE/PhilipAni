using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public float timer, spd, t;
    public Color startC, endC;
    public Image blackScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        t = spd * timer;
        blackScreen.color = Vector4.Lerp(startC, endC, t);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
