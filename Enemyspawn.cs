using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawn : MonoBehaviour
{
    public GameObject enemy;
    public float spawntime;
    public float spawninterval;

    void Update()
    {
        spawntime += Time.deltaTime;
        if (spawntime >= spawninterval)
        {
            spawntime = 0;
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
