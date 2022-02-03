using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject thing;
    public LayerMask player;

    public Vector3 offset;
    public int obstacleNum;

    public List<GameObject> obstacles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectedPlayer())
            SpawnObstacle();
    }

    void SpawnObstacle()
    {
        //for now we're just gonna spawn one specific obstacle at a time
        //but in the future i plan on using an array or a list
        //so that each spawner can randomly choose
        //an obstacle from the array or list to spawn.
        /*if (obstacleNum < 1)
        {
            Instantiate(thing, transform.position + offset, Quaternion.identity);
            obstacleNum += 1;
        }*/

        //Planned Code for the future:
        if (obstacleNum < 1)
        {
            int num = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[num].gameObject, transform.position + offset, Quaternion.identity);
            obstacleNum += 1;
        }
    }

    bool DetectedPlayer()
    {
        var ray = new Ray(transform.position, -transform.right);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.right + new Vector3(-30,0,0), Color.red);
        if (Physics.Raycast(ray, 30f, player))
        {
            //Debug.Log("crash");
            return true;
        }

        return false;
    }
}
