using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    
    public float speed;
    public float turnSpeed;


    float turnSmoothTime = 0.1f;
    float turnVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Move();
        }  
    }

    void Move()
    {

        rb.AddForce(transform.up * speed * Time.deltaTime);

        float Targetangle = Mathf.Atan2(-Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, Targetangle, ref turnVelocity, turnSmoothTime);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
