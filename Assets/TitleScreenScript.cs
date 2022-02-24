using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenScript : MonoBehaviour
{
    public int mode;
    //0 - Title Screen
    //1 - Play Button is pressed and the transition begins
    //2 - Transition has ended
    public Vector3 cloudstart, cloudend, citystart, cityend;
    public Vector2 menustart, menuend;
    public GameObject clouds, city, menu, pstore;
    public PauseScript pause;
    public float spd, time, t;

    public float speed;
    public Vector3 offset;

    public GameObject spawner, player;
    // Start is called before the first frame update
    void Start()
    {
        pause = GetComponent<PauseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mode == 1 && pause.isPaused == false)
        {
            time += Time.deltaTime;
            t = time / spd;
            t = t * t * (3 - 2 * t);
            clouds.transform.position = Vector3.Lerp(cloudstart, cloudend, t);
            city.transform.position = Vector3.Lerp(citystart, cityend, t);
            menu.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(menustart, menuend, t);
            if(clouds.transform.position.y  >= cloudend.y - .05f)
            {
                mode = 2;
            }
        }

        if(mode == 2)
        {
            player.SetActive(true);
            spawner.SetActive(true);
        }
        else
        {
            player.SetActive(false);
            spawner.SetActive(false);
        }

   
    }

    public void StartButton()
    {
        mode = 1;
    }
    public void QuitButton()
    {

    }
}
