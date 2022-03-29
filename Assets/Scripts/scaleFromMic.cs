using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleFromMic : MonoBehaviour
{
    public AudioSource source;
    public AudioLoudnessDetection detector;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;

    void Update()
    {
        float loudness = detector.getLoudnessFromMic() * loudnessSensibility;

        if (loudness < threshold)
        {
            loudness = 0;
        }

        if(loudness >= threshold)
        {
            GetComponent<SecondPlayerScript>().Jump();
        }
    }
}
