using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public AudioSource jumpSound;
    public AudioSource vespaSounds;
    public AudioSource hitSound;
    //music 

    public float speed, jumpSpeed;
    public Vector3 move;
    public Rigidbody rb;
    public Animator animator;

    public LayerMask ground, car;
    public Vector3 collision;

    public int collidedCarAmount;

    public float gravityScale;

    public AnimationClip jump;
    public bool playable;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playable)
        {
            vespaSounds.Play();
            //resets the scene
           // if (Input.GetKey(KeyCode.LeftShift))
           // {
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           // }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (CheckIfGrounded())
                {
                    animator.SetTrigger("jump");
                }
            }
            else
            {
                jumpSpeed = 0;
            }

           // if (Input.GetKey(KeyCode.LeftShift))
          //  {
             //   if (CheckIfGrounded())
             //   {
              //      animator.SetBool("slide", true);
             //   }
           // }
          //  else
          //  {
          //      animator.SetBool("slide", false);
          //  }
            //constantly changes the speed
            move = new Vector3(0, jumpSpeed);
            rb.AddForce(move);
        }
    }

    private void FixedUpdate()
    {
        //Uses raycasts to check for ground and car collision
        //each function returns true if the ground or a car is detected
        CheckIfGrounded();
        CheckforCar();

        animator.SetBool("grounded", CheckIfGrounded());

        //prevents the vespa from constantly increasing speed
        //if (rb.velocity.magnitude > speed * 2)
          //  rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);


        //Unity's built in gravity sucks, makes it too floaty when falling
        //so this is my own gravity code
        Vector3 gravity = gravityScale * Vector3.down;
        rb.AddForce(gravity, ForceMode.Acceleration);


     
        if(CheckforCar())
        {
           // collidedCarAmount += 1;
           // rb.AddForce(-move * 4, ForceMode.Impulse);
           // Debug.Log("crash");
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
            //Debug.Log("crash");
            return true;
        }

        return false;
    }

    //called by the animation event, so that it jumps
    //when the correct frame plays
    public void JumpOff()
    {
        //Debug.Log("!!!");
        jumpSound.Play();
        jumpSpeed = 1700;
        move = new Vector3(0, jumpSpeed);
        rb.AddForce(move);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            hitSound.Play();
            collidedCarAmount += 1;
        }
    }

    public void StartFunction()
    {
        playable = true;
    }
}
