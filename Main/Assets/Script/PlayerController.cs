using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float x_moveInput;
    private float y_moveInput;
    public float xPower;
    public float yPower;
    public float x_decForce;
    public float y_decForce;
    public Joystick joystick;
    public static int health = 10; //health number

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //for computer
        /*
        x_moveInput = Input.GetAxis("Horizontal");
        y_moveInput = Input.GetAxis("Vertical");
        */

        //for mobile
        x_moveInput = joystick.Horizontal;
        y_moveInput = joystick.Vertical;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
         //x-axis movement
        if(x_moveInput > 0.1f) //movement right x-axis
        {
            rb.velocity = new Vector2(xPower*x_moveInput, rb.velocity.y);
        }
        else if(x_moveInput < -0.1f) //movement left x-axis
        {
            rb.velocity = new Vector2(xPower*x_moveInput, rb.velocity.y);
        }
        else //movement stop x-axis
        {
            rb.velocity = new Vector2((xPower -x_decForce) * x_moveInput, rb.velocity.y);
        }
        /* ********************************************************************************** */
        //y-axis movement

        if(y_moveInput > 0.1f) //movement up
        {
            rb.velocity = new Vector2(rb.velocity.x, yPower * y_moveInput);
        }
        else if(y_moveInput < -0.1f) //movement down
        {
            rb.velocity = new Vector2(rb.velocity.x, yPower * y_moveInput);
        }
        else //movement stop yAxis
        {
            rb.velocity = new Vector2(rb.velocity.x, (yPower - y_decForce) * y_moveInput);
        }
    }
    private void Animation()
    {
        if(x_moveInput == 0 && y_moveInput ==0)
        {
            anim.Play("anim_Idle");
        }
    }
}
