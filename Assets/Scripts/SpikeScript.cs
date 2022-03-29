using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    public LevelGeneration spikeGenerator;

    private void Start()
    {
        spikeGenerator = FindObjectOfType<LevelGeneration>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * spikeGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NextLine")){
            spikeGenerator.GenerateNextSpikeWithGap();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroyed();
        }
    }

    public void Destroyed()
    {
        Destroy(this.gameObject,1f);
    }
}
