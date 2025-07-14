using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] Transform muzzleposition;
    [SerializeField] GameObject shoot;
    [Header("Config")]
    [SerializeField] float firedistance = 10;
    [SerializeField] float firerate = 0.5f;
    Transform player;
    Vector2 offset;
    private float timelastshot = 0f;
    Transform closeenemy;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        timelastshot = firerate;
        player = GameObject.Find("Player").transform;

    }
    private void Update()
    {
        transform.position = (Vector2)player.position + offset;
        findenemy();
        aimenemy();
        shotting();
    }
    void findenemy()
    {
        closeenemy = null;
        float closedistance = Mathf.Infinity;
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closedistance && distance < firedistance)
            {
                closedistance = distance;
                closeenemy = enemy.transform;
            }
        }
    }
    void aimenemy()
    {
        if(closeenemy != null)
        {
            Vector3 direction = closeenemy.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x)* Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            transform.position = (Vector2)player.position + offset;
        }
    }
    void shotting()
    {
        if (closeenemy == null) return;
        timelastshot += Time.deltaTime;
        if(timelastshot >= firerate)
        {
            Shoot();
            timelastshot = 0;
        }           
    }
    void Shoot()
    {
        var fire = Instantiate(shoot, muzzleposition.position, transform.rotation);
        Destroy(fire, 3);
    }
    public void SetOffset(Vector2 o)
    {
        offset = o;
    }
}

