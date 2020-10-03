using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyBarUI : MonoBehaviour
{
	public Image background;
	public Image mask;
	public int maximum = 100;
	public int current = 0;
    
    public void UpdateFill(int amount){
    	current += amount;
		float fillAmount = (float)current / (float)maximum;
		mask.fillAmount = fillAmount;
	}

    public void Show(){
    	gameObject.SetActive(true);
    }

    public void Hide(){
    	gameObject.SetActive(false);
    }
}
