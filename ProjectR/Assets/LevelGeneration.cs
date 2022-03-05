using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

    [SerializeField] private Transform levelStart;
    [SerializeField] private List<Transform> levelPartList;

    [Header("Player Itself")]
    public GameObject Player;

    private Vector3 LastEndPosition;
    

    private void Awake()
    {
        LastEndPosition = levelStart.Find("EndPosition").position;

        int startingSpawnLevelParts = 5;
        for(int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if(Vector3.Distance(Player.transform.position, LastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            //Spawn another level part
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[(Random.Range(0, levelPartList.Count))];
        Transform lastLevelPartTransform = SpawnLevelParting(chosenLevelPart,LastEndPosition);
        LastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelParting(Transform levelPart, Vector3 SpawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, SpawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
