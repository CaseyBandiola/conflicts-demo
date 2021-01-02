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

    public AudioSource audioSource;
	
	//private GameObject user;
	//private InitialSurvey user;
	//hotdog

	new public static string name;
	public static string age;
	public static string sex;
	public static string univ;
	public static string year;
	public static string ha;
	public static string vn;

    void Start()
    {
    	//user = userDetails.GetComponent<InitialSurvey>();
    	name = InitialSurvey.name;
    	age = InitialSurvey.age;
		sex = InitialSurvey.sex;
		univ = InitialSurvey.univ;
		year = InitialSurvey.year;
		ha = InitialSurvey.ha;
		vn = InitialSurvey.vn;
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

        /*SaveObject saveObject = new SaveObject{
        	choices = choicesMade,
        	familyBarSave = familyBarUI.showCurrent(),
        	bossBarSave = bossBarUI.showCurrent(),
        };
        string json = JsonUtility.ToJson(saveObject);
        Debug.Log(json);*/

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

				// WHERE EQUALS IS THE LAST SCENE OF THE GAME AND WHERE IT SENDS
				// TO G SHEETS
				if(nextScene.Equals("TutorialMazeScene")){
					SendGoogle();
				}
				// WHERE TO LOAD MINIGAME AND/OR FAMILY SCREEN
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
		if(dialogue.audioClip != null){
			audioSource.PlayOneShot(dialogue.audioClip, 0.15F);
		}
		button1.SetActive(false);
		button2.SetActive(false);
		Initialize();
		NextSentence();
	}
	public void ChooseOption2(){
		choicesMade.Add(dialogue.responseOptions[1].text);
		dialogue = dialogue.responseOptions[1].nextDialogue;
		if(dialogue.audioClip != null){
			audioSource.PlayOneShot(dialogue.audioClip, 0.15F);
		}
		button1.SetActive(false);
		button2.SetActive(false);
		Initialize();
		NextSentence();
	}

	/*private class SaveObject {
		public List<string> choices;
		public int familyBarSave;
		public int bossBarSave;
	}*/

	[SerializeField]
	private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeQnA1UwxibKveACIgILgp53tt7fylLHmty6ZGHzBm_ibJEFg/formResponse";
	IEnumerator Post(string name, string age, string sex, string univ, string year, string ha, string vn, List<string> choices, int familySatisfaction, int bossSatisfaction){
		string allChoices = String.Join(", ", choices.ToArray());
		WWWForm form = new WWWForm();
		form.AddField("entry.1067888008", name);
		form.AddField("entry.41188139", age);
		form.AddField("entry.489504437", sex);
		form.AddField("entry.1479408121", univ);
		form.AddField("entry.1157722575", year);
		form.AddField("entry.728165496", ha);
		form.AddField("entry.1405489059", vn);
		form.AddField("entry.2108200016", allChoices);
		form.AddField("entry.1902930186", familySatisfaction);
		form.AddField("entry.641995644", bossSatisfaction);
		byte[] rawData = form.data;
		WWW www = new WWW(BASE_URL, rawData);
		yield return www;
	}

	public void SendGoogle(){
		StartCoroutine(Post(
			name,
			age,
			sex,
			univ,
			year,
			ha,
			vn,
			choicesMade, 
			familyBarUI.showCurrent(), 
			bossBarUI.showCurrent()
			)
		);
	}
}
