﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoneyHandler2 : MonoBehaviour {
    public Text moneyUI;
    public Week2_fam endWeek;
    
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

    public MoneyHandler mh;

    public static int money = 0; //= mh.GetMoney();

    void Start() {
        money += mh.GetMoney();
        AddMoney(2500);
        if( Week2Controller.didPass ){
            AddMoney(1000);
        }
        moneyUI.text = "₱ " + money.ToString();
        momRqButton = momRq.GetComponent<Button>();
        sisRqButton = sisRq.GetComponent<Button>();
        broRqButton = broRq.GetComponent<Button>();
    }

    void Update() {
        // code for mouse over check of UI Button
        // if ( EventSystem.current.IsPointerOverGameObject() ) {
        //     Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        // }
        //DetectObject();
        //Debug.Log(EventSystem.current.IsPointerOverGameObject());
        moneyUI.text = "₱ " + money.ToString();
    }

    // code for sister's requests
    public void BuySisRequest() {
        // buy the request if there's enough money
        int price = endWeek.GetSisRqPrice();
        if( money >= price ){
            money -= price;
            moneyUI.text = "₱ " + money.ToString();

            // remove request from Sis
            SisController.RemoveUniformRequest();

            // once bought, disable the button
            sisRqButton.interactable = false;
            sisRq.GetComponentInChildren<Text>().text = "BOUGHT";
            sisBtnStar.enabled = false;
        }
        // else do nothing
        
    }

    // code for mom's requests
    public void BuyMomRequest(){
        // buy the request if there's enough money
        int price = endWeek.GetMomRqPrice();
        if( money >= price ){
            money -= price;
            moneyUI.text = "₱ " + money.ToString();

            MomController.RemoveGroceryRequest();

            // once bought, disable the button
            momRqButton.interactable = false;
            momRq.GetComponentInChildren<Text>().text = "BOUGHT";
            momBtnStar.enabled = false;
        }
        
    }

    // code for brother's requests
    public void BuyBroRequest(){
        // buy the request if there's enough money
        int price = endWeek.GetBroRqPrice();
        if( money >= price ){
            money -= price;
            moneyUI.text = "₱ " + money.ToString();

            // once bought, disable the button
            broRqButton.interactable = false;
            broRq.GetComponentInChildren<Text>().text = "BOUGHT";
            broBtnStar.enabled = false;
        }
        
    }

    public void AddMoney(int amt){
        money += amt;
        moneyUI.text = "₱ " + money.ToString();
    }

    public int GetMoney(){
        return money;
    }
}
