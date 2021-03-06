﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private hole hole1;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private float speed = 3f;
    private float spd;
    public float distance;
    private float inputVertical;
    private float inputHorizontal;
    
    private bool isclimbing;
    public GameObject destroyedItem;
    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityScore;
    public GameObject thingbeingdestroyed;
    public bool inbox;

    public int curHealth;
    public int maxHealth = 5;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityScore = rb.gravityScale;
        curHealth = maxHealth;
    }
    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
      
        Move();

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0)
        {
            Die();
        }



    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag.Equals("Enemy"))
        {
            SoundManagerScript.PlaySound("deathSound");
            Destroy(gameObject);
            Damage(1);



        }
               
    }

    void Die()
    {
        //Application.LoadLevel(Application.loadedLevel);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        

    }






    void Move()
    {
       
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (inputHorizontal < 0)
        {
            sr.flipX = false;
        }
        if (inputHorizontal > 0)
        {
            sr.flipX = true;
        }
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
        if (onLadder)
        {
            rb.gravityScale = 0f;
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, climbVelocity);
        }
        if (!onLadder)
        {
            rb.gravityScale = gravityScore;
        }
    }
}
