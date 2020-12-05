using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCam;

    [SerializeField]
    private float teleportTime;

    private Vector3 initRot;
    private Vector3 initPos;
    public static Teleporter Instance { get; private set; }

    [SerializeField]
    private GameObject teleportBoxes;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        initPos = mainCam.transform.position;
        initRot = mainCam.transform.eulerAngles;
        teleportBoxes.SetActive(false);
    }
    public void ResetView()
    {
        iTween.MoveTo(mainCam, iTween.Hash("position", initPos, "time", teleportTime, "easeType", iTween.EaseType.easeInOutSine));
        iTween.RotateTo(mainCam, iTween.Hash("rotation", initRot, "time", teleportTime, "easeType", iTween.EaseType.easeInOutSine));
    }

    public void Teleport(GameObject toTransform)
    {
        iTween.MoveTo(mainCam, iTween.Hash("position", toTransform.gameObject.transform.position, "time", teleportTime, "easeType", iTween.EaseType.easeInOutSine));
        iTween.RotateTo(mainCam, iTween.Hash("rotation", toTransform.gameObject.transform.eulerAngles, "time", teleportTime, "easeType", iTween.EaseType.easeInOutSine));
    }

    public void TeleportationBoxes(bool toggle)
    {
        teleportBoxes.SetActive(toggle);
    }
}
