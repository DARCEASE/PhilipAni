using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    public float spd, vspd, timer; //speed of each object

    public Vector3 startpos, endpos;
    //startpos - the starting position of each GameObject
    //endpos - the ending position of each GameObject

    public bool isLoop; //bool to check if the object will loop

    // Start is called before the first frame update
    void Start()
    {
        //set values in inspector for each GameObject
    }

    // Update is called once per frame
    void Update()
    {
        //  timer += Time.deltaTime;

        //transform.position += new Vector3(spd, 0, 0);
        if (isLoop)
        {
            transform.position += new Vector3(spd, vspd, 0);
            LoopingFunction();
        }
        else if (!isLoop && transform.position.x > endpos.x && transform.position.y <= endpos.y)
        {
            transform.position += new Vector3(spd, vspd, 0);
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
