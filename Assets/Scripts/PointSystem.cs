using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public GameObject Points1;
    public static int scoreValue = 0;
    public Text scoreText;
    //public float SpawnTimer = 15f;

    [SerializeField]
    private int minSpawnTime;
    [SerializeField]
    private int maxSpawnTime;

    private float _nextSpawnTime = 0;
    private float _timer = 0;
    private void Start()
    {
        Spawn();
    }


    public void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _nextSpawnTime)
        {
            Spawn();
        }
        scoreText.text = scoreValue.ToString();
    }

    void Spawn()
    {
        float SpawnPointX = Random.Range(-30f, 5f);
        float SpawnPointY = Random.Range(20f, 20f);
        Vector2 SpawnPosition = new Vector2(SpawnPointX, SpawnPointY);
        Instantiate(Points1, SpawnPosition, Quaternion.identity);

        _nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        _timer = 0;
    }
}
