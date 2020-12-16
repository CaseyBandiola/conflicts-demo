using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;


public class InitialSurvey : MonoBehaviour
{
	public TextMeshProUGUI textDisplay;
	public string[] sentences;
	private int index;
	public float typingSpeed;

	public GameObject continueButton;
	public GameObject finishButton;

	public string nextScene;

	public GameObject Name;
	public GameObject Age;
	public GameObject Sex;
	public GameObject University;
	public GameObject YearLevel;
	public GameObject HealthyAdult;
	public GameObject PlayedVN;

	public InputField user_name;
	public InputField user_age;
	public InputField user_sex;
	public InputField user_uni;
	public InputField user_yl;
	public Toggle user_ha_yes;
	public Toggle user_ha_no;
	public Toggle user_vn_yes;
	public Toggle user_vn_no;

	new public static string name;
	public static string age;
	public static string sex;
	public static string univ;
	public static string year;
	public static string ha;
	public static string vn;

	void Start(){
		finishButton.SetActive(false);
		textDisplay.enabled = true;
		StartCoroutine(Type());
		user_name.interactable = true;
		user_age.interactable = true;
		user_sex.interactable = true;
		user_uni.interactable = true;
		user_yl.interactable = true;
	}

	void Update(){
		if(textDisplay.text == sentences[index]){
			continueButton.SetActive(true);
		}
		if(index == sentences.Length){
			continueButton.SetActive(false);
			textDisplay.enabled = false;
		}

		if((string.IsNullOrEmpty(user_name.text) || string.IsNullOrEmpty(user_age.text) || string.IsNullOrEmpty(user_sex.text) || string.IsNullOrEmpty(user_uni.text) || string.IsNullOrEmpty(user_yl.text))){
			finishButton.SetActive(false);
		}
		else{
			finishButton.SetActive(true);
		}
	}

    IEnumerator Type(){
		foreach(char letter in sentences[index].ToCharArray()){
			textDisplay.text += letter;
			yield return new WaitForSeconds(typingSpeed);
		}
	}

	public void NextSentence(){

		continueButton.SetActive(false);

		if(index < sentences.Length - 1){
			index++;
			textDisplay.text = "";
			StartCoroutine(Type());
		}
		else{
			textDisplay.text = "";

			Name.SetActive(true);
			Age.SetActive(true);
			Sex.SetActive(true);
			University.SetActive(true);
			YearLevel.SetActive(true);
			HealthyAdult.SetActive(true);
			PlayedVN.SetActive(true);
		}

		continueButton.SetActive(false);
	}

	public void Finish(){
		//finishButton.SetActive(true);

		name = user_name.text;
		age = user_age.text;
		sex = user_sex.text;
		univ = user_uni.text;
		year = user_yl.text;
		
		if(user_ha_yes.isOn){
			ha = "Yes";
		}
		else if(user_ha_no.isOn){
			ha = "No";
		}

		if(user_vn_yes.isOn){
			vn = "Yes";
		}
		else if(user_vn_no.isOn){
			vn = "No";
		}
	
		SceneManager.LoadScene(nextScene);
	}

	public string getName(){
		return name;
	}

	public string getAge(){
		return age;
	}

	public string getSex(){
		return sex;
	}

	public string getUniv(){
		return univ;
	}

	public string getYear(){
		return year;
	}

	public string getHA(){
		return ha;
	}

	public string getVN(){
		return vn;
	}
}
