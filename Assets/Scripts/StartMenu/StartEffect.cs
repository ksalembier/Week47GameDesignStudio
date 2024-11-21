using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEffect : MonoBehaviour
{
    Text tt;
    private float i = 0;
    public float speed;
    bool isOne = false;

    private void Start()
    {
        tt = GetComponent<Text>();
        speed = 0.7f;
    }
    void Update()
    {
        if (!isOne)
        {
            i += Time.deltaTime * speed;
            tt.color = new Color(tt.color.r, tt.color.g, tt.color.b, i);
            if (i >= 1)
                isOne = true;
        }
        else
        {
            i -= Time.deltaTime * speed;
            tt.color = new Color(tt.color.r, tt.color.g, tt.color.b, i);
            if (i <= 0)
                isOne = false;
        }
    }

}
