using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    //Setup
    public string Name;
    public bool isWater;
    public bool isFood;
    public float WaterAmount;
    public float FoodAmount;
    public bool PlayFoodSound;
    public bool PlayWaterSound;
    public Texture itemTexture;
    public bool craftMaterial;
    private GameObject Player;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Use"))
        {
            if (isWater) //Check is it Water
            {
                Drink(WaterAmount, this.gameObject.GetComponent<PlayerLiveStats>());
                if (PlayWaterSound == true) // Check if it includes water sound
                {
                    PlayerAudio audio = Player.gameObject.GetComponent<PlayerAudio>();
                    audio.PlaySound(audio.waterSound);
                }
            }
            if (isFood) //Check is it Water
            {
                Eat(FoodAmount, Player.gameObject.GetComponent<PlayerLiveStats>());
                if (PlayFoodSound == true) // Check if it includes food sound
                {
                    PlayerAudio audio = Player.gameObject.GetComponent<PlayerAudio>();
                    audio.PlaySound(audio.foodSound);
                }
            }
            this.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F) && !craftMaterial)
        {
            this.gameObject.SetActive(false);
        }
	}

    //When player is in item trigger
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player") //Check is it Player
        {
           
        }
    }

    void Drink(float amount, PlayerLiveStats stats)
    {
        if(stats.WATER < 100f) // Check is Water full
        {
            if(stats.WATER > 100f - amount) // Check is needed water bigger then water amount of item
            {
                stats.WATER = 100f;
            }
            if(stats.WATER < 100f - amount) // Check is needed water less then water amount of item
            {
                stats.WATER += amount;
            }       
        }
    }

    void Eat(float amount, PlayerLiveStats stats)
    {
        if (stats.HUNGER < 100f) // Check is Hunger full
        {
            if (stats.HUNGER > 100f - amount) // Check is needed hunger bigger then food amount of item
            {
                stats.HUNGER = 100f;
            }
            if (stats.HUNGER < 100f - amount) // Check is needed hunger less then food amount of item
            {
                stats.HUNGER += amount;
            }
        }
    }
}
