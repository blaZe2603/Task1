using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_p : MonoBehaviour
{
    public Transform tp2;
    //public Transform own;
    player player;
    float dist;
    // Start is called before the first frame update
    void Start()
    {
        //dist = own.position.x - tp2.position.x;
        player = GameObject.Find("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.existg)
            tp2  = player.currentPortalg.transform;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            if(player.rightfac)
            player.transform.position = tp2.position + new Vector3(2f, 0f, 0f);
            else
            player.transform.position = tp2.position + new Vector3(-2f, 0f, 0f);
        }
    }
}
