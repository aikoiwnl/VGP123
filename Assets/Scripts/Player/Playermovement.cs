using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Playermovement : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;



    public float Speed;
    public float Jumpforce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform GroundCheck;
    public float GroundcheckRadius;



    // Start is called before the first frame update
    void Start()
    {
        
       rb.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

        if (Speed <= 0)
        {
            Speed = 5.0f;
        }
        if (Jumpforce <= 0)
        {
            Jumpforce = 100;
        }
        if (GroundcheckRadius <= 0)
        {
            GroundcheckRadius = 0.01f;
        }    
        if (!GroundCheck)
        {
            Debug.Log("GroundCheck doesn't exist, pleast set a transform value for GroundCheck");
        }
    }

    // Update is called once per frame
    void Update()
    {

        float hvalue = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundcheckRadius, isGroundLayer);

        Debug.Log(hvalue);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * Jumpforce);
        }
        rb.velocity = new Vector2(hvalue * Speed, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(hvalue));
        anim.SetBool("isgrounded", isGrounded);
    }
}
