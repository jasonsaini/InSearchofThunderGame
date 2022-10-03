using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class lightningDashSFX : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip lightningDash;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            audioSource.PlayOneShot(lightningDash, 0.5F);
    }
}