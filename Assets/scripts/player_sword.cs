using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_sword : MonoBehaviour
{
    private float time_btw_attack;
    public float totat_time_attack;
    player player;

    public LayerMask enemies; 
    public Transform attack_pos;
    public float attack_range;
    public int damage;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time_btw_attack <=0)
        {
        if(Input.GetMouseButtonDown(0) && player.bow_state)
        {
            player.animator.Play("sword");
            time_btw_attack = totat_time_attack;
            Collider2D[] enemeis_in_range = Physics2D.OverlapCircleAll(attack_pos.position,attack_range,enemies);
            for(int i = 0; i < enemeis_in_range.Length;i++)
            {

            }
        }
        }    
        else
        {
            time_btw_attack -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attack_pos.position,attack_range);
    }
}
