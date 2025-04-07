    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_sword : MonoBehaviour
{
    private float time_btw_attack;
    public float totat_time_attack;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time_btw_attack <=0)
        {
            time_btw_attack = totat_time_attack;
        }    
        else
        {
            time_btw_attack -= Time.deltaTime;
        }
    }
}
