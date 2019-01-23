using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerLiveStats : MonoBehaviour {

    public FirstPersonController controller;

    public float HP = 100;
    public float STAMINA = 5.0f;
    public float HUNGER = 100f;
    public float WATER = 100f;


	// Use this for initialization
	void Start ()
    {
	   
	}
	
	// Update is called once per frame
	void Update ()
    {
        STAMINA = controller.Stamina;
	}

    private void FixedUpdate()
    {
        CheckWater();
        CheckHunger();
    }

    void CheckWater()
    {
        if(WATER > 0f)
        {
            WATER -= 0.1f * Time.deltaTime;
            if (STAMINA < 1.5f)
            {
                WATER = WATER - 0.15f;
            }
        }
        else
        {
            MinusHP(1);
            //Player Dead
            Debug.Log("Player is dead!");
        }
    }

    void CheckHunger()
    {
        if(HUNGER > 0f)
        {
            HUNGER -= 0.15f * Time.deltaTime;
            if (STAMINA < 1.5f)
            {
                HUNGER = HUNGER - 0.1f;
            }
        }
        else
        {
            MinusHP(2);
            //Player Dead
            Debug.Log("Player is dead!");
        }
    }

    private void MinusHP(float damage)
    {
        HP -= damage;
    }

    
}
