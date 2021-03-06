﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyHandler : MonoBehaviour {
    public Text moneyUI;
    public EndWeek endWeek;
    
    // Mom objects
    public GameObject momRq;
    public Image momBtnStar;
    private Button momRqButton;
    
    // Sis objects
    public GameObject sisRq;
    public Image sisBtnStar;
    private Button sisRqButton;
    
    // Bro objects
    public GameObject broRq;
    public Image broBtnStar;
    private Button broRqButton;

    private int money;

    void Start() {
        money = 10000;
        moneyUI.text = "₱ " + money.ToString();
        
        momRqButton = momRq.GetComponent<Button>();
        sisRqButton = sisRq.GetComponent<Button>();
        broRqButton = broRq.GetComponent<Button>();
    }

    // code for sister's requests
    public void BuySisRequest() {
        // buy the request
        int price = endWeek.GetSisRqPrice();
        money -= price;
        moneyUI.text = "₱ " + money.ToString();

        // once bought, disable the button
        sisRqButton.interactable = false;
        sisRq.GetComponentInChildren<Text>().text = "BOUGHT";
        sisBtnStar.enabled = false;
    }

    // code for mom's requests
    public void BuyMomRequest(){
        // buy the request
        int price = endWeek.GetMomRqPrice();
        money -= price;
        moneyUI.text = "₱ " + money.ToString();

        // once bought, disable the button
        momRqButton.interactable = false;
        momRq.GetComponentInChildren<Text>().text = "BOUGHT";
        momBtnStar.enabled = false;
    }

    // code for brother's requests
    public void BuyBroRequest(){
        // buy the request
        int price = endWeek.GetBroRqPrice();
        money -= price;
        moneyUI.text = "₱ " + money.ToString();

        // once bought, disable the button
        broRqButton.interactable = false;
        broRq.GetComponentInChildren<Text>().text = "BOUGHT";
        broBtnStar.enabled = false;
    }
}
