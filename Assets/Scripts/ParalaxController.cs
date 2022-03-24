using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    public float spd, vspd, timer, t; //speed of each object

    public Vector3 startpos, endpos;
    //startpos - the starting position of each GameObject
    //endpos - the ending position of each GameObject

    public bool isLoop, isFinish; //bool to check if the object will loop
    public GameObject store;
    public PauseScript pause;
    public TitleScreenScript title;

    // Start is called before the first frame update
    void Start()
    {
        store = GameObject.Find("Main Camera");
        pause = store.GetComponent<PauseScript>();
        title = store.GetComponent<TitleScreenScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //  timer += Time.deltaTime;
      
        //transform.position += new Vector3(spd, 0, 0);
if (!isFinish && !pause.isPaused)
        {
            timer += Time.deltaTime;
            t = spd * timer;
            if (gameObject.name == "pg_city" && title.mode != 0)
            {
                transform.Translate(-spd, 0, 0);
             }
            else if (gameObject.name == "pg_sun" && title.mode != 0)
                {
                transform.Translate(-spd, vspd, 0); 
            }
            else if (gameObject.name != "pg_city" && gameObject.tag != "bridge")
            {
                transform.Translate(-spd, 0, 0);
            }
            else if (gameObject.tag == "bridge")
            {
                startpos = new Vector3(startpos.x, transform.position.y, transform.position.z);
                transform.Translate(0, -spd, 0);
            }
            
            if (isLoop && !pause.isPaused)
            {
                LoopingFunction();
            }

        }
    }

    public void LoopingFunction()
    {
        
        if(transform.position.x <= endpos.x)
        {
            transform.position = startpos;
        }
    }
}
