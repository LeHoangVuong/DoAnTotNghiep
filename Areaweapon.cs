using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Areaweapon : Weapon
{
    [SerializeField] private GameObject weapon;
    private float spawncount;
    void Update()
    {
        spawncount -= Time.deltaTime;
        if (spawncount <= 0)
        {
            spawncount = start[weaponlevel].countdown;
            Instantiate(weapon, transform.position, transform.rotation, transform);
        }
    }
}

