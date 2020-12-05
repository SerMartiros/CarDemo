using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Vector3 closeState;
    private Vector3 openState;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private Vector3 rotationAmount;
    private bool isOpened;
    private bool isInMotion;

    private void Start()
    {
        this.closeState = this.transform.localEulerAngles;
        this.openState = new Vector3(closeState.x + rotationAmount.x, closeState.y + rotationAmount.y, closeState.z + rotationAmount.z);
    }
    private void OnMouseDown()
    {
        if (!isOpened && !isInMotion)
        {
            StartCoroutine(Open());
        }
        else if (isOpened && !isInMotion)
        {
            StartCoroutine(Close());
        }
    }

    IEnumerator Open()
    {
        isInMotion = true;
        CarAudio.Instance.OpenDoor();
        float lerpState = 0;
        while (lerpState < rotationSpeed)
        {
            this.transform.localEulerAngles = Vector3.Slerp(closeState, openState, lerpState / rotationSpeed);
            lerpState += Time.deltaTime;
            yield return null;
        }
        this.transform.localEulerAngles = openState;
        isOpened = true;
        isInMotion = false;

    }
    IEnumerator Close()
    {
        isInMotion = true;
        float lerpState = 0;
        while (lerpState < rotationSpeed)
        {
            this.transform.localEulerAngles = Vector3.Slerp(openState, closeState, lerpState / rotationSpeed);
            lerpState += Time.deltaTime;
            yield return null;
        }
        this.transform.localEulerAngles = closeState;
        CarAudio.Instance.CloseDoor();
        isOpened = false;
        isInMotion = false;
    }
}