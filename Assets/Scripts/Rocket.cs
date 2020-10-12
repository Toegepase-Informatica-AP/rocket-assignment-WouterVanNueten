using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Rocket : MonoBehaviour
{

    [SerializeField] float tiltingForce = 10f;

    private float thrustSpeed = 0f;
    private float maxVSpeed = 10f;
    private float maxFallSpeed = -50f;
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Thrust(InputAction.CallbackContext context)
    {
        if (!(thrustSpeed >= maxVSpeed))
        {
            thrustSpeed = thrustSpeed + 0.4f;
        }

        Debug.Log(thrustSpeed);
    }

    public void TiltLeft(InputAction.CallbackContext context)
    {

        float left = -30f;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3((left * tiltingForce * Time.deltaTime), 0f, 0f));
    }

    public void TiltRight(InputAction.CallbackContext context)
    {

        float right = 30f;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3((right * tiltingForce * Time.deltaTime), 0f, 0f));
    }

    private void FixedUpdate()
    {
        Debug.Log(thrustSpeed);

        if (transform.position.y > 0 && thrustSpeed <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - thrustSpeed * Time.deltaTime, transform.position.z);
        }
        else
        {
            rb.velocity = transform.up * thrustSpeed;
        }

        if (thrustSpeed > maxFallSpeed && rb.velocity.y > 0)
        {
            thrustSpeed = thrustSpeed - 0.1f;
        }

        if (rb.velocity.y == 0) {
            thrustSpeed = 0;
        }
    }
}
