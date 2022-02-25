using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public float speed, min, max;
    Rigidbody rb;

    public Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        move = new Vector3(0,speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move * Time.deltaTime);

        if (transform.position.x < -25)
        {
            Destroy(transform.parent.gameObject);
        }

        if(gameObject.name == "bldg1")
        {
            transform.parent.position= new Vector3(transform.parent.position.x, 0, transform.parent.position.z);
        }
    }
}
