using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class increaseDrinkCount : MonoBehaviour {

	public Text drinkText;
	public string drinkName;
	public float ABV; //ounces of alcohol per drink

	public int drinkCount;

	private float ouncesOfAlcohol;
	

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
		drinkText.text = drinkName + ": "+ drinkCount.ToString () ;
	}

	public float getDrinkCount()
	{
		return drinkCount;
	}
}
