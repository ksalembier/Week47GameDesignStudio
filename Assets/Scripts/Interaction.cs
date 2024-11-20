using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    public GameObject[] responses = new GameObject[12];
    private int currentResponse = 0;
    
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    { 
        if (collider.gameObject.tag == "NPC") 
        {
            collider.gameObject.GetComponent<NPC>().SetTextActive();
        }
        else if (collider.gameObject.tag == "Player Dialog")
        {
            responses[currentResponse].SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "NPC") 
        {
            collider.gameObject.GetComponent<NPC>().SetTextInactive();
        }
        else if (collider.gameObject.tag == "Player Dialog")
        {
            responses[currentResponse].SetActive(false);
            currentResponse++;
        }
    }
}
