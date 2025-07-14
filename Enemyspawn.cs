using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawn : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject enemy;
        public float spawntime;
        public float spawninterval;
        public int enemywave;
        public int enemycountwave;
    }
    public List<Wave> waves;
    public int wavenumber;
    public Transform Aposition;
    public Transform Bposition;

    void Update()
    {
        if (Playercontrol.playerA.gameObject.activeSelf)
        {
            waves[wavenumber].spawntime += Time.deltaTime;
            if (waves[wavenumber].spawntime >= waves[wavenumber].spawninterval)
            {
                waves[wavenumber].spawntime = 0;
                SpawnEnemy();
            }
            if (waves[wavenumber].enemycountwave >= waves[wavenumber].enemywave)
            {
                waves[wavenumber].enemycountwave = 0;
                wavenumber++;
            }
            if (wavenumber >= waves.Count)
            {
                wavenumber = 0;
            }
        }

    }
    private void SpawnEnemy()
    {
        Instantiate(waves[wavenumber].enemy, radomspawn(), transform.rotation);
        waves[wavenumber].enemycountwave++;
    }
    private Vector2 radomspawn()
    {
        Vector2 spawnpoint;

        if (Random.Range(0f, 1f) > 0.5)
        {
            spawnpoint.x = Random.Range(Aposition.position.x, Bposition.position.x);
            if (Random.Range(0f, 1f) > 0.5)
            {
                spawnpoint.y = Aposition.position.y;
            }
            else
            {
                spawnpoint.y = Bposition.position.y;
            }
        }
        else
        {
            spawnpoint.y = Random.Range(Aposition.position.y, Bposition.position.y);
            if (Random.Range(0f, 1f) > 0.5)
            {
                spawnpoint.x = Aposition.position.x;
            }
            else
            {
                spawnpoint.x = Bposition.position.x;
            }
        }
        return spawnpoint;
    }
}
