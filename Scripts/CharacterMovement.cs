using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float horizontal;
    private float speed=8f;

    public Animator animator;

    private float jumpingPower=16f;

    private bool isFacingRight=true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;



    // Update is called once per frame
    void Update()
    {
        horizontal=Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed",Mathf.Abs(horizontal));

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity=new Vector2(rb.velocity.x,jumpingPower);
        }
        if(Input.GetButtonDown("Jump") && rb.velocity.y >0f )
        {
            rb.velocity=new Vector2(rb.velocity.x,rb.velocity.y *0.5f);
        }
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity=new Vector2(horizontal*speed,rb.velocity.y);
        animator.SetFloat("Speed",Mathf.Abs(horizontal));
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal <0f || !isFacingRight && horizontal>0f)
        {
            isFacingRight =!isFacingRight;
            Vector3 localScale=transform.localScale;
            localScale.x *=-1f;
            transform.localScale=localScale;
        }
    }
}
