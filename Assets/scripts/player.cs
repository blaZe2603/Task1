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
    public BoxCollider2D col;
    public float movespeed;
    float horizontal;
    public float jumpspeed;
    public bool rightfac = true;
    public GameObject portal_p;
    public GameObject portal_g;
    public GameObject currentPortalp;
    public GameObject currentPortalg;
    public GameObject bow;
    public float dis;
    public bool existp;
    public bool existg;
    public float player_health;

    public bool bow_state = true;
    public bool player_dead = false;
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();   
        player_health = 100f;
    }

    void Update()
    {
        //death animation
        if(player_health <= 0)
        {
            player_dead = true;
            animator.SetBool("dead",true);
            StartCoroutine(dead());
        }
        //bow activate deactivate
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bow_state = !bow_state;
            bool newState = !bow.activeSelf;
            bow.SetActive(newState);
        }
        //animation
        animator.SetFloat("speed", Mathf.Abs(horizontal)) ;
        animator.SetFloat("jump", Mathf.Abs(rb.velocity.y));
        rb.velocity = new Vector2(horizontal * movespeed, rb.velocity.y);
        //direction of player
        if (!rightfac && horizontal > 0)
        {
            Flip();
        }
        else if(rightfac && horizontal < 0)
        {
           Flip();
 
        }
        
        //portal creation
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            existp = true;

            if (currentPortalp != null)
            {
                Destroy(currentPortalp);
            }

            Vector3 spawnPos = portal_distance.position;
                            

            currentPortalp = Instantiate(portal_p, spawnPos, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            existg = true;
            if (currentPortalg != null)
            {
                Destroy(currentPortalg);
            }

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
