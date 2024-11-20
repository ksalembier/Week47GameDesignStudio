using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject text;

    public void SetTextActive()
    { text.SetActive(true); }

    public void SetTextInactive()
    { text.SetActive(false); }
}
