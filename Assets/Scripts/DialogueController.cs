using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System;
using System.Text;

public class DialogueController : MonoBehaviour
{
	public Text textDisplay;

	public Dialogue dialogue;

	public string nextScene;

	private int index;

	public GameObject continueButton;
    public GameObject button1;
    public GameObject button2;

    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    public static List<string> choicesMade = new List<string>();

    public Image background;

    public GameObject familyBar;
    private FamilyBarUI familyBarUI;

    public GameObject bossBar;
    private BossBarUI bossBarUI;
	
	//hotdog

    void Start()
    {
    	speakerUILeft  = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();
        familyBarUI = familyBar.GetComponent<FamilyBarUI>();
        bossBarUI = bossBar.GetComponent<BossBarUI>();
        Initialize();
        index++;
        if(dialogue.dialogues[index] == ""){
        	index++;
        }
        StartCoroutine(Type());

        /*SaveObject saveObject = new SaveObject{
        	choices = choicesMade,
        	familyBarSave = familyBarUI.showCurrent(),
        	bossBarSave = bossBarUI.showCurrent(),
        };
        string json = JsonUtility.ToJson(saveObject);
        Debug.Log(json);*/
    }

    private void Initialize() {
        index = -1;

        speakerUILeft.Speaker = dialogue.speakerLeft;
        speakerUIRight.Speaker = dialogue.speakerRight;

        background = this.GetComponent<Image>();
        background.sprite = dialogue.background;

        familyBarUI.Show();
        bossBarUI.Show();
        familyBarUI.UpdateFill(dialogue.familyEffect);
        bossBarUI.UpdateFill(dialogue.bossEffect); 

        SaveObject saveObject = new SaveObject{
        	choices = choicesMade,
        	familyBarSave = familyBarUI.showCurrent(),
        	bossBarSave = bossBarUI.showCurrent(),
        };
        string json = JsonUtility.ToJson(saveObject);
        Debug.Log(json);

    }

    void Update()
    {
    	if(index%2 == 0){
    		speakerUILeft.Show();
    		speakerUIRight.Hide();
    	}
    	else{
    		speakerUILeft.Hide();
    		speakerUIRight.Show();
    	}
        if(textDisplay.text == dialogue.dialogues[index]){
        	if(dialogue.dialogues[index] == ""){
        		continueButton.SetActive(false);
        	}
        	else{
        		continueButton.SetActive(true);
        	}
        }
    }

    IEnumerator Type(){
		foreach(char letter in dialogue.dialogues[index].ToCharArray()){
			textDisplay.text += letter;
			yield return new WaitForSeconds(0.001f);
		}
	}

	public void NextSentence(){

		continueButton.SetActive(false);

		if(index < dialogue.dialogues.Length-1){
			index++;
			textDisplay.text = "";
			StartCoroutine(Type());
		}
		else{
			continueButton.SetActive(false);
			textDisplay.text = "";
			if(dialogue.continueDialogue != null){
				ContinueDialogue();
				if(dialogue.dialogues[index] == ""){
					index++;
					continueButton.SetActive(false);
					StartCoroutine(Type());
				}
			}
			else if(dialogue.responseOptions.Length != 0){
				index = 0;
				button1.SetActive(true);
				button1.GetComponent<Text>().text = dialogue.responseOptions[0].text;
				button2.SetActive(true);
				button2.GetComponent<Text>().text = dialogue.responseOptions[1].text;
			}
			else{
				// at the end of this scene, load the maze scene next
				// textDisplay.text = "end";
				SendGoogle();
				SceneManager.LoadScene(nextScene);
			}
		}
	}

	public void ContinueDialogue(){
		dialogue = dialogue.continueDialogue;
		Initialize();
		NextSentence();
	}

	public void ChooseOption1(){
		choicesMade.Add(dialogue.responseOptions[0].text);
		dialogue = dialogue.responseOptions[0].nextDialogue;
		button1.SetActive(false);
		button2.SetActive(false);
		Initialize();
		NextSentence();
	}
	public void ChooseOption2(){
		choicesMade.Add(dialogue.responseOptions[1].text);
		dialogue = dialogue.responseOptions[1].nextDialogue;
		button1.SetActive(false);
		button2.SetActive(false);
		Initialize();
		NextSentence();
	}

	private class SaveObject {
		public List<string> choices;
		public int familyBarSave;
		public int bossBarSave;
	}

	[SerializeField]
	private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeBCMRmRBrgMyQ_tJNqy0VnkSwvmRXloPT6KedTQM6VlP0d7Q/formResponse";
	IEnumerator Post(List<string> choices, int familySatisfaction, int bossSatisfaction){
		string allChoices = String.Join(", ", choices.ToArray());
		WWWForm form = new WWWForm();
		form.AddField("entry.655487196", allChoices);
		form.AddField("entry.1411661847", familySatisfaction);
		form.AddField("entry.747959956", bossSatisfaction);
		byte[] rawData = form.data;
		WWW www = new WWW(BASE_URL, rawData);
		yield return www;
	}

	public void SendGoogle(){
		StartCoroutine(Post(choicesMade, familyBarUI.showCurrent(), bossBarUI.showCurrent()));
	}
}
