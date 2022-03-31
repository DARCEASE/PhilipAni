using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAway : MonoBehaviour
{
    public Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        transform.Translate(move * Time.deltaTime);
    }

}
