using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public LayerMask groundlayer;
    public Transform groundcheck;
    public Transform portal_distance;
    public Animator animator;
    public Rigidbody2D rb;
    public BoxCollider2D collider2D;
    public float movespeed;
    float horizontal;
    public float jumpspeed;
    public bool rightfac = true;
    public GameObject portal_p;
    public GameObject portal_g;
    public GameObject currentPortalp;
    public GameObject currentPortalg;
    public float dis;
    public bool existp;
    public bool existg;

    public float player_health;
    // Start is called before the first frame update
    void Start()
    {
        collider2D =   gameObject.GetComponent<BoxCollider2D>();   
        player_health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if(player_health <= 0)
        {
            animator.SetBool("dead",true);
            StartCoroutine(dead());
        }
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
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
        existp = true;

        // Destroy existing portal if it exists
        if (currentPortalp != null)
        {
            Destroy(currentPortalp);
        }

        // Spawn new portal at a position in front of the player
        Vector3 spawnPos = portal_distance.position;
                           

        currentPortalp = Instantiate(portal_p, spawnPos, Quaternion.identity);
    }
    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
        existg = true;
        // Destroy existing portal if it exists
        if (currentPortalg != null)
        {
            Destroy(currentPortalg);
        }

        // Spawn new portal at a position in front of the player
        Vector3 spawnPos = portal_distance.position;  
                           

        currentPortalg = Instantiate(portal_g, spawnPos, Quaternion.identity);
        Debug.Log("works");
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

    IEnumerator dead()
    {
            Animator animator = GetComponent<Animator>();

            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

            float deathAnimLength = 0f;

            foreach (AnimationClip clip in clips)
            {
                if (clip.name == "player_death")
                {
                    deathAnimLength = clip.length;
                    break;
                }
            }

            yield return new WaitForSeconds(deathAnimLength+0.1f);

            Destroy(gameObject);
    }
}
