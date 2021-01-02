using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndWeek : MonoBehaviour {
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
    void Start() {
        // Initial Week UI
        weekNum = 1;
        week.text = "Week " + weekNum;

        // Initial Dialogue UI
        UpdateDialogue();
        // Initial Request UI
        UpdateRequest();
    }

    public void EndWeekPressed(){
        UpdateDialogue();
        UpdateRequest();
        UpdateWeek();
        ResetButtons();

        // load minigame
        Loader.Load(Loader.Scene.Week2Minigame);
        
    }

    // Update UI Dialogue weekly
    public void UpdateDialogue(){
        momDialogue.text = mom.GetDialogue();
        sisDialogue.text = sis.GetDialogue();
        broDialogue.text = bro.GetDialogue();
    }

    // Update UI Requests weekly
    public void UpdateRequest(){
        // Mom requests
        KeyValuePair<string, int> mrq = mom.GetRequest();
        string mrqText = mrq.Key.Equals("None") ? "Request: " + mrq.Key : "Request: " + mrq.Key + " - ₱ " + mrq.Value.ToString();
        momRequest.text = mrqText;
        momRqPrice = mrq.Value;
        // Hide button if no request avaialable for purchase
        if( mrq.Key.Equals("None") ){
            momBuyButton.SetActive(false);
        } else {
            momBuyButton.SetActive(true);
        }

        // Sis requests
        KeyValuePair<string, int> srq = sis.GetRequest();
        string srqText = srq.Key.Equals("None") ? "Request: " + srq.Key : "Request: " + srq.Key + " - ₱ " + srq.Value.ToString();
        sisRequest.text = srqText;
        sisRqPrice = srq.Value;
        // Hide button if no request avaialable for purchase
        if ( srq.Key.Equals("None") ){
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
        if ( brq.Key.Equals("None") ) {
            broBuyButton.SetActive(false);
        } else {
            broBuyButton.SetActive(true);
        }
    }

    public void UpdateWeek(){
        weekNum++;
        week.text = "Week " + weekNum;
    }

    public int GetMomRqPrice(){
        return momRqPrice;
    }

    public int GetSisRqPrice() {
        return sisRqPrice;
    }

    public int GetBroRqPrice(){
        return broRqPrice;
    }

    private void ResetButtons(){
        // reset mom buy button
        momBuyButton.GetComponent<Button>().interactable = true;
        momBuyButton.GetComponentInChildren<Text>().text = "Buy";
        momRqImg.enabled = true;

        // reset sis buy button
        sisBuyButton.GetComponent<Button>().interactable = true;
        sisBuyButton.GetComponentInChildren<Text>().text = "Buy";
        sisRqImg.enabled = true;

        // reset bro buy button
        broBuyButton.GetComponent<Button>().interactable = true;
        broBuyButton.GetComponentInChildren<Text>().text = "Buy";
        broRqImg.enabled = true;
    }
}
