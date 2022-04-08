using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleFromAudio : MonoBehaviour
{

    public AudioSource source;
    public Vector3 minimalScale;
    public Vector3 maximalScale;
    public AudioLoudnessDetection detector;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;

    void Update()
    {
        float loudness = detector.LoudnessAudio(source.timeSamples, source.clip) * loudnessSensibility;

        if (loudness < threshold)
        {
            loudness = 0;
        }

        transform.localScale = Vector3.Lerp(minimalScale, maximalScale, loudness);
    }
}
