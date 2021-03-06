﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public GameObject PlayerActiveItem;
    private SpriteRenderer sprite;
    private GameObject GameController;
    private char direction;
    Animator anim;

    void Start () {
        GameController = GameObject.Find("GameController");
        anim = GetComponent<Animator>();
        direction = GameController.GetComponent<GameController>().PlayerDirection;
        sprite = PlayerActiveItem.GetComponent<SpriteRenderer>();

         


    }
	
	// Update is called once per frame
	void Update () {
        userAttack();
    }

    void userAttack(){

        if (Input.GetKeyDown(KeyCode.Space)){
            anim.SetBool("isattacking", true);
        }

        // If Attack is Held
        if (Input.GetKey(KeyCode.Space))
        { 
            direction = GameController.GetComponent<GameController>().PlayerDirection;
            // Sword in front of you when facing down.
            if(direction == 's'){
                sprite.sortingOrder = 3;
            } else if( direction == '-'){
                sprite.sortingOrder = -1;
            } else {
                sprite.sortingOrder = 1;
            }

        // If Attack is Released.    
        } else {
            PlayerActiveItem.SetActive(false);
            anim.SetBool("isattacking", false);
        }
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            other.gameObject.SetActive(false);
        }

        // Retract Attack when with any collission for now.
        anim.SetBool("isattacking", false);
    }
}
