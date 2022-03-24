using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingspawnscript : MonoBehaviour
{

    public List<GameObject> buildings;

    public Vector3 offset;

    public float timer;
    public int min, max;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4)
            SpawnObstacle();

       
    }

    void SpawnObstacle()
    {
      
        int num = Random.Range(0, 4);
        Instantiate(buildings[num].gameObject, transform.position, Quaternion.identity);
        timer = 0;
    }

}
