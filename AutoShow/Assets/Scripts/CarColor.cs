using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColor : MonoBehaviour
{
    [SerializeField]
    private GameObject fcpGo;
    [SerializeField]
    private Material _mat;
    private FlexibleColorPicker fcp;
    private void Start()
    {
        fcp = fcpGo.GetComponent<FlexibleColorPicker>();
        fcpGo.SetActive(false);
    }
    public void ApplyColor()
    {
        _mat.SetColor("_BaseColor", fcp.color);
    }

    public void ColorPickerToggle(bool toggle)
    {
        fcpGo.SetActive(toggle);
    }
}
