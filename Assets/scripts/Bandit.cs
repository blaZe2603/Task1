using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class Bandit : MonoBehaviour
{
    public GameObject dialgoue_box;
    public TextMeshProUGUI dialogue_text;
    public string[] dialogue;
    public GameObject next_button;
    public GameObject prev_button;

    private int index;

    public float wordspeed;
    public bool player_near;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && player_near)
        {
            if(dialgoue_box.activeInHierarchy)
            {
                text_reset();
             
            }
            else
            {
                dialgoue_box.SetActive(true);
                StartCoroutine(Typing());
            }

        }

        if(dialogue_text.text == dialogue[index])
        {
            
            next_button.SetActive(true);
            
            prev_button.SetActive(true);
        }
    }

    public void text_reset()
    {
        dialogue_text.text = "";
        index = 0;
        dialgoue_box.SetActive(false);
    }    


    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogue_text.text += letter;
            yield return new WaitForSeconds(wordspeed);
        }
    }

    public void next()
    {
        next_button.SetActive(false);
        prev_button.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogue_text.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            text_reset();
        }
    }

    public void prev()
    {
        prev_button.SetActive(false);
        next_button.SetActive(false);
        if (index > 0)
        {
            index--;
            dialogue_text.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            text_reset();
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player_near = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player_near = false;
            text_reset();
        }
    }
}
