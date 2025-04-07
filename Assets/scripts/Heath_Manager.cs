using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heath_Manager : MonoBehaviour
{
    player player_script;
    public Image health_bar;
    public float max_health = 100f;
    public float health;
    public GameObject player;
    private float targetFillAmount;
    public float smoothSpeed = 5f; 
    
    // Start is called before the first frame update
    void Start()
    {
        player_script = GameObject.Find("Player").GetComponent<player>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) )
        {
            damage(20);
        }
        if(Input.GetKeyDown(KeyCode.H) && !player_script.player_dead)
        {
            player_script.animator.Play("special_ability");
            heal(5);
        }
    }

    public void damage(float damage)
    {
    player_script.player_health-= damage;
    StopAllCoroutines();
    StartCoroutine(SmoothFill(player_script.player_health / 100f));
    }
    public void heal(float heal)
    {
        player_script.player_health += heal;
        player_script.player_health = Mathf.Clamp(player_script.player_health,0,max_health);
        StopAllCoroutines();
        StartCoroutine(SmoothFill(player_script.player_health / 100f));
    }
    IEnumerator SmoothFill(float target)
    {
        while (Mathf.Abs(health_bar.fillAmount - target) > 0.001f)
        {
            health_bar.fillAmount = Mathf.Lerp(health_bar.fillAmount, target, Time.deltaTime * 5f);
            yield return null;
        }
        health_bar.fillAmount = target; // Final snap to exact value
    }
}
