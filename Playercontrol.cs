using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Windows;

public class Playercontrol : MonoBehaviour
{
    public static Playercontrol playerA;
    public float movespeed;
    [SerializeField] private Rigidbody2D rb;
    public Animator anim;
    public Vector2 movedir;
    public float playerhealth;
    public float playermaxhealth;
    public int experience;
    public int currentlevel;
    public int maxlevel;
    public List<int> playerlevel;
    public Weapon pickweapon;
    void Awake()
    {
        if (playerA != null && playerA != this)
        {
            Destroy(this);
        }
        else
        {
            playerA = this; 
        }
    }
    void Start()
    {
        playerhealth = playermaxhealth;
        rb = GetComponent<Rigidbody2D>();
        UIplayer.ui.Updateexpslider();
    }
    void Update()
    {
        float moveX = UnityEngine.Input.GetAxisRaw("Horizontal");
        float moveY = UnityEngine.Input.GetAxisRaw("Vertical");
        movedir = new Vector2(moveX, moveY).normalized;
        if (moveX > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        anim.SetFloat("move", movedir.magnitude);
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movedir.x * movespeed, movedir.y * movespeed);
    }
    public void takedame(float damage) 
    {
        playerhealth -= damage;
        UIplayer.ui.Updatehealthslider();
        if (playerhealth <= 0)
        {
            gameObject.SetActive(false);
            Gamemanager.game.Gameover();
        }
    }
    public void takeexp(int exp)
    {
        experience += exp;
        UIplayer.ui.Updateexpslider();
        if (experience >= playerlevel[currentlevel - 1])
        {
            levelup();
        }
    }
    public void levelup()
    {
        experience -= playerlevel[currentlevel - 1];
        currentlevel++;
        UIplayer.ui.Updateexpslider();
        UIplayer.ui.levelupbutton[0].choosebutton(pickweapon);
        UIplayer.ui.levelupopen();

    }
}

