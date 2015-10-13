using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class increaseDrinkCount : MonoBehaviour {

	public Text drinkText;
	public string drinkName;

	private int drinkCount;
	

	void Awake ()
	{
		drinkText = GetComponent<Text> ();
		setCountText ();
		drinkCount = 0;
	}
 
	public void drinkUp () 
	{
		drinkCount++;
		setCountText();
	}

	void setCountText ()
	{
		drinkText.text = "You've drank " + drinkCount.ToString () + " " + drinkName;
	}
}
