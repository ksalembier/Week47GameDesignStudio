using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collision : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    public GameObject dialogCanvas;
    public TextMeshProUGUI text;
    private string[] responses = new string[] 
            {"Oh, nothing much.", "We're just going for a walk.", "I'm fine, thank you.",
             "Yeah, we're enjoying the fresh air.", "It's nothing, really.", "I think we'll keep going for a while.",
             "I'm fine.", "Just walking.", "No, thank you"}; 
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
            Debug.Log("obstacle");
        }
    }

    // manages collision with obstacles; triggers post-processing and audio
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("obstacle");
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
            text.text = responses[currentResponse];
            dialogCanvas.SetActive(true);
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
            dialogCanvas.SetActive(false);
            currentResponse++;
        }
    }
}
