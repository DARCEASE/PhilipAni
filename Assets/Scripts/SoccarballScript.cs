using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccarballScript : MonoBehaviour
{
    public Vector3 move, jump;
    public LayerMask ground;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move * Time.deltaTime);

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }

    public void FlyAway()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            rb.AddForce(jump, ForceMode.Impulse);
        }
    }
}
