using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{

    private float speed = 0.025f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 25) {
            speed = -0.025f;
        }
        else if(transform.position.y <= 12)
        {
            speed = 0.025f;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
    }
}
