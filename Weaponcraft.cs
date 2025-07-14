using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponcraft : MonoBehaviour
{
    public Areaweapon weapon;
    private Vector3 size;
    private float timer;
    public List<Enemy> enemylist;
    private float count;
    void Start()
    {
        weapon = GameObject.Find("area weapon").GetComponent<Areaweapon>();
        Destroy(gameObject, weapon.start[weapon.weaponlevel].duration);
        size = Vector3.one * weapon.start[weapon.weaponlevel].ranger;
        transform.localScale = Vector3.zero;
        timer = weapon.start[weapon.weaponlevel].duration;
    }

    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, size, Time.deltaTime * 10);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            size = Vector3.zero;
            if (transform.localScale.x == 0f)
                Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.Takedamage(weapon.start[weapon.weaponlevel].damage);
        }
    }
        /*      count -=Time.deltaTime;
                if(count <= 0)
               {
                   count = 1;
                   for (int i = 0; i < enemylist.Count; i++)
                   {
                       enemylist[i].Takedamage(weapon.start[weapon.weaponlevel].damage);
                   }
               }
           }
               private void OnTriggerEnter2D(Collider2D collision)
               {
                   if (collision.CompareTag("Enemy"))
                   {
                       enemylist.Add(collision.GetComponent<Enemy>());
                   }
               }
               private void OnTriggerExit2D(Collider2D collision)
               {
                   if (collision.CompareTag("Enemy"))
                   {
                       enemylist.Remove(collision.GetComponent<Enemy>());
                   }
               }*/
    }

