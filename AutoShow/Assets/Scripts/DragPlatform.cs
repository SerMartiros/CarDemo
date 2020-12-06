using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DragPlatform : MonoBehaviour
{
    [SerializeField]
    private Toggle checker;
    [SerializeField]
    private float dragAmount;
    public void OnMouseDrag()
    {
        if (checker.isOn)
        {
            float mouseX = Input.GetAxis("Mouse X") * dragAmount;
            this.gameObject.transform.Rotate(Vector3.down, mouseX);
        }
    }
}
