﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            
            ScoreScript1.scoreValue += 10;
            Destroy(gameObject);
            SoundManagerScript.PlaySound("candySound");

        }
    }
   
    
}
