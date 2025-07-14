using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float movespeed;
    [SerializeField] private float damage;
    [SerializeField] private float health;
    [SerializeField] private int dropexp;
    private Vector3 direction;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (Playercontrol.playerA.gameObject.activeSelf)
        {
            if (Playercontrol.playerA.transform.position.x > transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else
            { 
                spriteRenderer.flipX = false;
            }
            direction = (Playercontrol.playerA.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * movespeed, direction.y * movespeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Playercontrol.playerA.takedame(damage);
            Destroy(gameObject);
        }
    }
    public void Takedamage(float damage)
    {
        health -= damage;
        Damagecanvas.dame.number(damage, transform.position);
        if (health < 0)
        {
            Destroy(gameObject);
            Playercontrol.playerA.takeexp(dropexp);
        }

    }
}
