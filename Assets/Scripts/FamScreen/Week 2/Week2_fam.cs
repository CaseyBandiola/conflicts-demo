﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Week2_fam : MonoBehaviour {
    // Week objects
    private int weekNum;
    public Text week;

    // Mom objects
    public Text momDialogue;
    public Text momRequest;
    public GameObject momBuyButton;
    public Image momRqImg;
    public MomController mom;

    // Sis objects
    public Text sisDialogue;
    public Text sisRequest;
    public GameObject sisBuyButton;
    public Image sisRqImg;
    public SisController sis;

    // Bro objects
    public Text broDialogue;
    public Text broRequest;
    public GameObject broBuyButton;
    public Image broRqImg;
    public BroController bro;

    // Request prices
    private int momRqPrice;
    private int sisRqPrice;
    private int broRqPrice;   

    // money handler
    public MoneyHandler2 money;
    void Start() {
        weekNum = 2;
        week.text = "Week " + weekNum;
        // money.AddMoney(2500);
        UpdateDialogue();
        UpdateRequest();
    }

    // Update is called once per frame
    public void UpdateRequest() {
        // Mom requests
        KeyValuePair<string, int> mrq = mom.GetRequest2();
        string mrqText = mrq.Key.Equals("None") ? "Request: " + mrq.Key : "Request: " + mrq.Key + " - ₱ " + mrq.Value.ToString();
        momRequest.text = mrqText;
        momRqPrice = mrq.Value;
        // Hide button if no request avaialable for purchase
        if (mrq.Key.Equals("None")){
            momBuyButton.SetActive(false);
        } else {
            momBuyButton.SetActive(true);
        }

        // Sis requests
        KeyValuePair<string, int> srq = sis.GetRequest2();
        string srqText = srq.Key.Equals("None") ? "Request: " + srq.Key : "Request: " + srq.Key + " - ₱ " + srq.Value.ToString();
        sisRequest.text = srqText;
        sisRqPrice = srq.Value;
        // Hide button if no request avaialable for purchase
        if (srq.Key.Equals("None")) {
            sisBuyButton.SetActive(false);
        } else {
            sisBuyButton.SetActive(true);
        }

        // Bro requests
        KeyValuePair<string, int> brq = bro.GetRequest();
        string brqText = brq.Key.Equals("None") ? "Request: " + brq.Key : "Request: " + brq.Key + " - ₱ " + brq.Value.ToString();
        broRequest.text = brqText;
        broRqPrice = brq.Value;
        // Hide button if no request avaialable for purchase
        if (brq.Key.Equals("None")) {
            broBuyButton.SetActive(false);
        } else {
            broBuyButton.SetActive(true);
        }
    }

    public void UpdateDialogue(){
        momDialogue.text = mom.GetDialogue2();
        sisDialogue.text = sis.GetDialogue2();
        broDialogue.text = bro.GetDialogue2();
    }

    public int GetMomRqPrice() {
        return momRqPrice;
    }

    public int GetSisRqPrice() {
        return sisRqPrice;
    }

    public int GetBroRqPrice() {
        return broRqPrice;
    }

    public void EndWeekPressed(){
        // UpdateDialogue();
        // UpdateRequest();
        // UpdateWeek();
        // ResetButtons();
    }
}
