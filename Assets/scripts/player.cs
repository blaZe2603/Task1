using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public LayerMask groundlayer;
    public Transform groundcheck;
    public Animator animator;
    public Rigidbody2D rb;
    public BoxCollider2D collider2D;
    public float movespeed;
    float horizontal;
    public float jumpspeed;
    public bool rightfac = true;
    // Start is called before the first frame update
    void Start()
    {
        collider2D =   gameObject.GetComponent<BoxCollider2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal)) ;
        animator.SetFloat("jump", Mathf.Abs(rb.velocity.y));
        rb.velocity = new Vector2(horizontal * movespeed, rb.velocity.y);
        if (!rightfac && horizontal > 0)
        {
            Flip();
        }
        else if(rightfac && horizontal < 0)
        {
           Flip();
 
        }
        
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && is_grounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);

        }

    }
    private bool is_grounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
    }

    private void Flip()
    { 
        rightfac = !rightfac;
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale; 
    }

    public void move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
