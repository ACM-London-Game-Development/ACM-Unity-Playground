using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PanObjectAudio : MonoBehaviour
{
    AudioSource audioSource;
    Camera cam;
    Vector3 screenPos;
    float halfScreenWidth;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cam = Camera.main;
        halfScreenWidth = cam.scaledPixelWidth / 2;
    }

    // Update is called once per frame
    void Update()
    {
        screenPos = cam.WorldToScreenPoint(transform.position);
        audioSource.panStereo = -(halfScreenWidth - screenPos.x) / halfScreenWidth;
    }
}
