using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.WSA;

public class timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI time_text;
    [SerializeField]float total_time;

    // Update is called once per frame
    void Update()
    {
        if(total_time > 0)
            total_time -= Time.deltaTime;
        else
        {
            StartCoroutine(red());
            StartCoroutine(white());
            total_time = 0;

        }    
        int minutes = Mathf.FloorToInt(total_time/60);   
        int seconds = Mathf.FloorToInt(total_time%60);   
        time_text.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
    IEnumerator red()
    {
        time_text.color = Color.red;
        yield return new WaitForSeconds(0.5f);
    }    
    IEnumerator white()
    {
        time_text.color = Color.white;
        yield return new WaitForSeconds(0.5f);
    }
}

