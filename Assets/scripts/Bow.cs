using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float power;
    public Transform shotpoint;
    player player;
    void Start()
    {
        player = FindObjectOfType<player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bow_pos = transform.position;
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouse_pos - bow_pos;
        if(player.rightfac)
            transform.right = direction;
        else
            transform.right = -direction;

        if(Input.GetMouseButtonDown(0))
        {
            shoot(player.rightfac);
        }
    }

    void shoot(bool pos)
    {
        GameObject new_arrow = Instantiate(arrow ,shotpoint.position,shotpoint.rotation);
        if(pos == true)
        {
            new_arrow.GetComponent<Rigidbody2D>().velocity = transform.right *power;
        }
        else 
        {
            new_arrow.GetComponent<Rigidbody2D>().velocity = -transform.right *power;
        }
    }
}
