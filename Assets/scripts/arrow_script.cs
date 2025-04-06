using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class arrow_script : MonoBehaviour
{
    bool hit;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y,rb.velocity.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
