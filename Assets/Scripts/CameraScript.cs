using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerPos;
    public float speed;
    public Vector3 offset;

    public TitleScreenScript title;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        title = GameObject.FindObjectOfType<TitleScreenScript>();
    }

    private void LateUpdate()
    {
        if (title.mode == 2)
        {
            playerPos = GameObject.FindObjectOfType<PlayerScript>().GetComponent<Transform>();

            transform.position = Vector3.Lerp(transform.position, playerPos.position - offset, speed);
        }
    }
}
