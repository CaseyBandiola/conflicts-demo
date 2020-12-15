using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData : MonoBehaviour
{
	[SerializeField] private UserData userData = new UserData();

}

[System.Serializable]
public class UserData{
	public List<UserDetails> userDetails = new List<UserDetails>();
	public List<UserChoices> userChoices = new List<UserChoices>();
	public List<Quest1> quest1 = new List<Quest1>();
	public List<Quest2> quest2 = new List<Quest2>();
	public List<SatisfactionValues> sValues = new List<SatisfactionValues>();
}

[System.Serializable]
public class UserDetails{
	public string name;
	public int age;
	public string sex;
	public string university;
	public int year;
	public string healthy;
	public string playedvn;
}

[System.Serializable]
public class UserChoices{
	public string[] choices;
}

[System.Serializable]
public class Quest1{
	public int despair;
	public int resent;
	public int hollow;
	public int scared;
	public int angry;
	public int annoyed;
	public int down;
	public int frustrated;
	public int depressed;
	public int furious;
	public int sick;
	public int rightChoice;
	public int rightThing;
	public int needed;
	public int fooled;
	public int tricked;
	public int wrongRewards;
}

[System.Serializable]
public class Quest2{
	public int despair;
	public int resent;
	public int hollow;
	public int scared;
	public int angry;
	public int annoyed;
	public int down;
	public int frustrated;
	public int depressed;
	public int furious;
	public int sick;
	public int rightChoice;
	public int rightThing;
	public int needed;
	public int fooled;
	public int tricked;
	public int wrongRewards;
}

[System.Serializable]
public class SatisfactionValues{
	public int family;
	public int boss;
}

