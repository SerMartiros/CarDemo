using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarRotation : MonoBehaviour
{
    [SerializeField]
    private GameObject carPlatform;
    [SerializeField]
    private Vector3 autoDir;
    [SerializeField]
    private float automaticRotSpeed;
    [SerializeField]
    private float manualRotSpeed;
    [SerializeField]
    private bool rotatingAutomatically;
    [SerializeField]
    private bool rotatingManually;
    [SerializeField]
    private List<GameObject> rotButtons;

    private bool choseDir;
    private Vector3 newDir;
    void Update()
    {
        if (rotatingAutomatically)
        {
            AutomaticRotation(rotatingAutomatically);
        }
    }
    private void Start()
    {
        foreach (GameObject item in rotButtons)
        {
            item.SetActive(false);
        }
    }
    public void ToggleRotationButtons(bool toggle)
    {
        foreach (GameObject item in rotButtons)
        {
            item.SetActive(toggle);
        }
    }
    public void AutomaticRotation(bool rotation)
    {
        rotatingAutomatically = rotation;
        if (!rotation)
        {
            choseDir = false;
        }
        if (!choseDir)
        {
            choseDir = true;
            newDir = new Vector3(0, Random.Range(-1,2), 0);
            if (newDir.y == 0)
            {
                while (newDir.y == 0)
                {
                    newDir = new Vector3(0, Random.Range(-1, 2), 0);
                }
            }
        }
        if (rotatingAutomatically && !rotatingManually)
        {
            carPlatform.transform.Rotate(newDir * Time.deltaTime * automaticRotSpeed, Space.Self);
        }
    }

    public void ManualRotation(int count)
    {
        if (!rotatingManually && !rotatingAutomatically)
        {
            StartCoroutine(RotateEnum(count));
        }
    }

    IEnumerator RotateEnum(int count)
    {
        rotatingManually = true;
        int amount = Mathf.Abs(count);
        Vector3 neededDirection = new Vector3(0, Mathf.Sign(count), 0);
        while (amount > 0)
        {
            carPlatform.transform.Rotate(neededDirection * Time.deltaTime * manualRotSpeed, Space.Self);
            amount--;
            yield return null;
        }
        rotatingManually = false;
    }
}