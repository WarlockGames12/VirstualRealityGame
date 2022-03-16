using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;



public class MicrobitToUnity : MonoBehaviour
{
    //this might need some adjusting to point wherever the arduino is connected to.
    [SerializeField]
    private string _serialPortName = "COM7";
    [SerializeField]
    private int _bautrate = 9600;

    private SerialPort stream;

    public Pair arduinoPedalValues = new Pair(0, 0);

    void Start()
    {
        stream = new SerialPort(_serialPortName, _bautrate);

        SerialPort.GetPortNames();
        stream.ReadTimeout = 50;
        stream.Open();

        StartCoroutine
        (
            AsynchronousReadFromArduino
            (
                (string s) => SetResult(s),     // Callback
                () => Debug.LogError("Arduino script"), // Error callback
                10000f                          // Timeout (milliseconds)
            )
        );
    }
    private void SetResult(string str)
    {
        //Debug.Log(str);
        this.arduinoPedalValues = SplitString(str);
    }

    /*
     * Async listening to the port.
     */
    private IEnumerator AsynchronousReadFromArduino(Action<string> callback, Action fail = null, float timeout = float.PositiveInfinity)
    {
        DateTime initialTime = DateTime.Now;
        DateTime nowTime;
        TimeSpan diff = default(TimeSpan);

        string dataString = null;

        /*
         * While not timed out, pass the string to the callback function.
         */
        do
        {
            try
            {
                dataString = stream.ReadLine();
            }
            catch (TimeoutException)
            {
                dataString = null;
            }
            //
            if (dataString != null)
            {
                callback(dataString);
                yield return new WaitForSeconds(0.05f);
            }
            else
                yield return new WaitForSeconds(0.05f);

            nowTime = DateTime.Now;
            diff = nowTime - initialTime;

        } while (diff.Milliseconds < timeout);

        if (fail != null)
            fail();
        Debug.LogError("Time OUT");
        yield return null;
    }
    private Pair SplitString(string str)
    {
        string[] split = str.Split(';');
        if (!CheckSplitStringValues(split))
        {
            //Debug.LogError("Splitting Error");
            return new Pair(0, 0);
        }
        Debug.Log(str);
        return new Pair(float.Parse(split[0]), float.Parse(split[1]));
    }

    private bool CheckSplitStringValues(string[] stra)
    {
        if (stra.Length < 2)
        {
            return false;
        }
        for (int i = 0; i < stra.Length; i++)
        {
            if (stra[0] == "" || stra[0] == " ")
            {
                return false;
            }
        }
        return true;
    }
}
[Serializable]
public struct Pair
{
    public float a;
    public float b;
    public Pair(float a, float b)
    {
        this.a = a;
        this.b = b;
    }
}
