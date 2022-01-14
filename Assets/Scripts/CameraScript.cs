using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerPos;
    public float speed;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        playerPos = GameObject.FindObjectOfType<PlayerScript>().GetComponent<Transform>();

        transform.position = Vector3.Lerp(transform.position, playerPos.position - offset, speed);
    }
}
