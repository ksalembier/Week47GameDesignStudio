using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    public GameObject[] responses = new GameObject[12]; // this becomes array of strings
    private int currentResponse = 0;
    
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // manages collision with obstacles; triggers post-processing and audio
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {

        }
    }

    // manages collision with obstacles; triggers post-processing and audio
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            
        }
    }

    // manages collision with npc colliders and player response colliders
    void OnTriggerEnter2D(Collider2D collider)
    { 
        if (collider.gameObject.tag == "NPC") 
        {
            collider.gameObject.GetComponent<NPC>().SetTextActive();
        }
        else if (collider.gameObject.tag == "Player Dialog")
        {
            responses[currentResponse].SetActive(true); // this becomes changing the text of the UI and then setting it active
        }
    }

    // manages collision with npc colliders and player response colliders
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "NPC") 
        {
            collider.gameObject.GetComponent<NPC>().SetTextInactive();
        }
        else if (collider.gameObject.tag == "Player Dialog")
        {
            responses[currentResponse].SetActive(false); // set UI inactive 
            currentResponse++;
        }
    }
}
