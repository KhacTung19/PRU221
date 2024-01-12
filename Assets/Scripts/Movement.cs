using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    public float speed = 6;
    private bool Axis = true;
    private bool Grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(HorizontalInput * speed, body.velocity.y);
        if (HorizontalInput > 0.01f && Axis == true)
        {
            transform.localScale = Vector3.one;
            Axis = false;
        }
        else if (HorizontalInput < -0.01f && Axis != true)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            Axis = true;
        }
        if (Input.GetKey(KeyCode.UpArrow) && Grounded)
        {
            Jump();
        }

        anim.SetBool("run", HorizontalInput != 0);
        anim.SetBool("grounded", Grounded);
    }

    void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        Grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {

            Grounded = true;
        }
    }
}
