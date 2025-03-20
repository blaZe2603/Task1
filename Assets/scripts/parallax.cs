using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    [SerializeField] float movespeed;
    [SerializeField] bool scrollleft;

    float singletexture;
    float scale = 21;

    void Start()
    {
       setuptexture();
        if(scrollleft)  movespeed = -movespeed  ;
    }

    void setuptexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singletexture = sprite.texture.width /sprite.pixelsPerUnit;
    }

    void scroll()
    {
        float delta = movespeed*Time.deltaTime;
        transform.position += new Vector3(delta, 0f, 0f);
    }

    void check()
    {
        if((Mathf.Abs(transform.position.x) - singletexture*scale > 0)){
            transform.position = new Vector3(0f, transform.position.y, transform.position.z); 
        }
    }
    void Update()
    {
        scroll();
        check();
    }
}
 