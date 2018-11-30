﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    

    [Header("Set In Inspector")]
    public Text ammoCount;
    public Text ammoInClip;

    public Text currentHealth;
    public Text currentArmor;


    [Header("Dynamically Set")]
    public Blaster currentBlaster;
    public PlayerDefenseManager playerDefenseManager;

    void Start()
    {
        playerDefenseManager = GetComponent<PlayerDefenseManager>();
    }


	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            currentBlaster.Fire();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentBlaster.Reload();
        }

        UpdateUI();
	}

    public void UpdateUI()
    {
        ammoInClip.text     = currentBlaster.ammoInClip.ToString();
        ammoCount.text      = currentBlaster.currentAmmo.ToString();

        currentHealth.text  = playerDefenseManager.health.ToString();
        currentArmor.text   = playerDefenseManager.armor.ToString();
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "item")
        {
            collision.gameObject.GetComponent<Item>().Pickup(gameObject);
        } 
    }

}
