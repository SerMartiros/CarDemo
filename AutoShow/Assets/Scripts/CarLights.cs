using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour
{
    [SerializeField]
    private GameObject carLights;
    private void Awake()
    {
        if (carLights.activeSelf)
        {
            carLights.SetActive(false);
        }
    }
    public void ToggleLights(bool toggle)
    {
        carLights.SetActive(toggle);
    }
}
