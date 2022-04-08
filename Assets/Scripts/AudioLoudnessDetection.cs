using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class AudioLoudnessDetection : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip microphoneClip;
    public Text UIText;
    public Text UITextNumber;

    void Start()
    {
        microphoneToAudio();

        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            // The user authorized use of the microphone.
        }
        else
        {
            // We do not have permission to use the microphone.
            // Ask for permission or proceed without the functionality enabled.
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    void Update()
    {

    }


    public void microphoneToAudio()
    {
        string microphoneName = Microphone.devices[0];
        string microphoneNameDesktop = Microphone.devices[0];
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
            UIText.text = microphoneName.ToString();
        }
        //microphoneClip = Microphone.Start(microphoneName, true, 20, 44100);
        microphoneClip = Microphone.Start(microphoneName, true, 20, 44100);
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
