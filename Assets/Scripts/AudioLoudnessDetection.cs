using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDetection : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip microphoneClip; 

    void Start()
    {
        microphoneToAudio();
    }

    void Update()
    {

    }


    public void microphoneToAudio()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float getLoudnessFromMic()
    {
        return LoudnessAudio(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    public float LoudnessAudio(int clipPos, AudioClip clip)
    {
        int startPosition = clipPos - sampleWindow;

        if (startPosition < 0)
            return 0;

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / sampleWindow;
    }
}
