using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptions : MonoBehaviour
{
    [SerializeField]
    private GameObject uiPanel;
    private void Start()
    {
        uiPanel.SetActive(false);
    }
    public void TogglePanel(bool state)
    {
        uiPanel.SetActive(state);
    }
}

