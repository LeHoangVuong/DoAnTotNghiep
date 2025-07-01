using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Playercontrol : MonoBehaviour
{
    public static Playercontrol playerA;
    public float movespeed;
    Rigidbody2D rb;
    Vector2 movedir;

    void Start()
    {
        playerA = this;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Inputmanagement();
    }
    void FixedUpdate()
    {
        move();
    }
    void Inputmanagement()
    {
        float moveX = UnityEngine.Input.GetAxis("Horizontal");
        float moveY = UnityEngine.Input.GetAxis("Vertical");
        movedir = new Vector2(moveX, moveY).normalized;
    }
    void move()
    {
        rb.velocity = new Vector2(movedir.x * movespeed, movedir.y * movespeed);
    }

}
