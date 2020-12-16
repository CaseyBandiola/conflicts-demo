using System.Collections;
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
    void Start() {
        weekNum = 2;
        week.text = "Week " + weekNum;

        // UpdateDialogue();
        // UpdateRequest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndWeekPressed(){
        // UpdateDialogue();
        // UpdateRequest();
        // UpdateWeek();
        // ResetButtons();
    }
}
