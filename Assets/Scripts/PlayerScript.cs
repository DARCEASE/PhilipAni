using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed, jumpForce, gravityScale;
    public Rigidbody rb;
    public Animator animator;
    public LayerMask ground, car;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //resets the scene
        if(Input.GetKey(KeyCode.LeftShift))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckIfGrounded())
            {
                animator.SetTrigger("pressedJump");
            }
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("sliding", true);
        }
        else
        {
            animator.SetBool("sliding", false);
        }

        animator.SetBool("grounded", CheckIfGrounded());

    }

    private void FixedUpdate()
    {
        //Uses raycasts to check for ground and car collision
        //each function returns true if the ground or a car is detected
        CheckIfGrounded();
        CheckforCar();

        //moves the vespa right at a rate of speed
        rb.AddForce(Vector3.right * speed);

        //prevents the vespa from constantly increasing speed
        if (rb.velocity.magnitude > speed * 2)
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);


        //Unity's built in gravity sucks, makes it too floaty when falling
        //so this is my own gravity code
        //Vector3 gravity = gravityScale * Vector3.down;
        //rb.AddForce(gravity, ForceMode.Acceleration);


        if(CheckforCar())
        {
            //bounces the player back with a force 4 times as strong as their velocity on impact
            rb.AddForce(Vector3.left * rb.velocity.x * 4, ForceMode.Impulse);
            Debug.Log("crash");
        }
    }

    //checks if it detects the ground below the player
    bool CheckIfGrounded()
    {
        Vector3 offset = new Vector3(0,2,0);

        var ray = new Ray(transform.position + offset, -this.transform.up);
        RaycastHit hit;

        Debug.DrawRay(transform.position, -this.transform.up, Color.red);

        if (Physics.Raycast(ray, 6f, ground))
        {
            //Debug.Log("found ground");
            return true;
        }
        return false;
    }

    //checks if it detects a car in front of the player
    bool CheckforCar()
    {
        Vector3 offset = new Vector3(1.5f, 1, 0);
        var ray = new Ray(transform.position + offset, this.transform.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position + offset, transform.forward, Color.red);
        if (Physics.Raycast(ray, 1.5f, car))
        {
            return true;
        }

        return false;
    }

    //called by the jumpOff animation event, so that it jumps
    //when the correct frame plays
    public void JumpOff()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }
}
