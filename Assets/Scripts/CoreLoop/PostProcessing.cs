using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    public PostProcessVolume ppv;
    private ColorGrading colorGrading;

    public GameObject endPoint;
    private float playerY;
    private float endY;
    private float startDistance;
    private float changeUnit;
    private int currentSaturationChange;

    void Start()
    {
        ppv.profile.TryGetSettings(out colorGrading);
        playerY = transform.position.y;
        endY = endPoint.transform.position.y;
        startDistance = endY - playerY;
        changeUnit = startDistance/100;
        currentSaturationChange = 0;
    }

    void Update()
    {
        playerY = transform.position.y;
        float currentDistance = endY - playerY;
        float distanceChange = startDistance - currentDistance;
        int intChange = (int)(distanceChange/changeUnit);
        if (intChange > currentSaturationChange)
        {
            EditColorGrading(-1);
            currentSaturationChange++;
        }
    }

    public void EditColorGrading(float change)
    {
        if (colorGrading.saturation.value + change >= -100)
        {
            colorGrading.saturation.value = colorGrading.saturation.value + change;
        }
        else
        {
            colorGrading.saturation.value = -100;
        }
    }
}
