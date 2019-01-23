using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour {

    private PlayerLiveStats stats;
    public Text HPtext;
    public Text WATERtext;
    public Text HUNGERtext;
    public Text STAMINAtext;
    // Use this for initialization
    void Start () {
        stats = gameObject.GetComponent<PlayerLiveStats>();
	}
	
	// Update is called once per frame
	void Update () {
        HPtext.text = "HP: " + stats.HP.ToString();
        WATERtext.text = "WATER: " + stats.WATER.ToString();
        HUNGERtext.text = "HUNGER: " + stats.HUNGER.ToString();
        STAMINAtext.text = "STAMINA: " + stats.STAMINA.ToString();
	}
}
