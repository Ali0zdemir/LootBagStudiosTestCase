using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public Transform[] spawnPoints;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private System.Collections.IEnumerator SpawnEnemies(){
        while(true){
            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Count);
            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefabs[randomEnemyIndex], spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);
            yield return new WaitForSeconds(5f); // Adjust the spawn rate as needed
        }
    }

}
