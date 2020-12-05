using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip openDoor;
    [SerializeField]
    private AudioClip closeDoor;
    public static CarAudio Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void OpenDoor()
    {
        audioSource.PlayOneShot(openDoor);
    }
    public void CloseDoor()
    {
        audioSource.PlayOneShot(closeDoor);
    }
}
