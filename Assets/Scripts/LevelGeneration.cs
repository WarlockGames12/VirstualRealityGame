using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject Spikes;
    public Transform Spawner;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier = 0.1f;

    private void Awake()
    {
        currentSpeed = MinSpeed;
        generateSpike();
    }

    public void GenerateNextSpikeWithGap()
    {
        float randomWait = Random.Range(1.5f, 3.6f);
        Invoke("generateSpike", randomWait);
    }


    public void generateSpike()
    {
        GameObject Spike1 = Instantiate(Spikes, Spawner.transform.position, Quaternion.identity);

        Spike1.GetComponent<SpikeScript>().spikeGenerator = this;
    }

    private void Update()
    {
        if(currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
    }
}
