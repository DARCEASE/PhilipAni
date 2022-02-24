using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float speed,min,max;
    Rigidbody rb;

    public Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(min, max);
        rb = GetComponent<Rigidbody>();
        move = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(move * Time.deltaTime);

        if(transform.position.x < -14)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
       /* if (rb.velocity.magnitude > speed * 2)
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);*/

    }
}
