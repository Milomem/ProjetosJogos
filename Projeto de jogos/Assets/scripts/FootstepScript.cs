using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public AudioClip footstepClip;
    public float stepInterval = 0.5f; // Intervalo entre passos
    private float stepTimer;

    // Start is called before the first frame update
    void Start()
    {
        stepTimer = stepInterval;
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d");

        if (isWalking)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            StopFootsteps();
            stepTimer = stepInterval; // Reseta o timer quando para de andar
        }
    }

    void PlayFootstep()
    {
        if (!footstepAudioSource.isPlaying)
        {
            footstepAudioSource.PlayOneShot(footstepClip);
        }
    }

    void StopFootsteps()
    {
        if (footstepAudioSource.isPlaying)
        {
            footstepAudioSource.Stop();
        }
    }
}
