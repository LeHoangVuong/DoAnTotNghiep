using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firegun : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    [SerializeField] float damage = 3f;
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if( enemy != null)
        {
            Destroy(gameObject);
            enemy.Takedamage(damage);
        }
    }
}
