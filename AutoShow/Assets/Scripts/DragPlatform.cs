using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DragPlatform : MonoBehaviour
{
    [SerializeField]
    private Toggle checker;
    public void OnMouseDrag()
    {
        if (checker.isOn)
        {
            float mouseX = Input.GetAxis("Mouse X") * 5f;
            this.gameObject.transform.Rotate(Vector3.down, mouseX);
        }
    }
}
