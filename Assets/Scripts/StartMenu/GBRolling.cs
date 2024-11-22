using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBRolling : MonoBehaviour
{
    public int speed = 4;
    public Vector3 p1, p2;
    public GameObject bg1;
    public GameObject bg2;
    public GameObject swap;

    void Start()
    {
        p1 = bg1.transform.position;
        p2 = bg2.transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        if (bg2.transform.position.y < p1.y)
        {
            bg1.transform.position = p2;
            swap = bg1;
            bg1 = bg2;
            bg2 = swap;
        }
    }

}
