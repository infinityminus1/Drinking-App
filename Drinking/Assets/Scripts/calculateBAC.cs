using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class calculateBAC : MonoBehaviour {

	public Text BAC_Text;
	public InputField weight;
	public InputField duration;
	public Slider gender;
	public Text[] drinkText;


	const float FEMALE_ALCOHOL_DISTRO = 0.66f;
	const float MALE_ALCOHOL_DISTRO = 0.73f;
	
	void Awake ()
	{
		BAC_Text = GetComponent<Text> ();
	}
	
	int getWeight ()
	{
		return int.Parse (weight.text);
	}
	
	int getDuration ()
	{
		return int.Parse (duration.text);
	}
	
	float getGenderConst ()
	{
		if (gender.value == 0)
			return MALE_ALCOHOL_DISTRO;
		else
			return FEMALE_ALCOHOL_DISTRO;
	}
	
	float getAlcohol ()
	{
		float numofdrinks = 0;

		foreach (Text drink in drinkText) {
			numofdrinks += drink.GetComponent<increaseDrinkCount> ().drinkCount;
		}


		/*drinks = gameObject.GetComponents<Text> ();
		foreach (Text drink in drinks) {

			numofdrinks = numofdrinks + drink;

		}*/
		Debug.Log ("drinkCount: " + numofdrinks);
		return numofdrinks * 0.6f;
	}
	
	//void public function for the calculate button to call
	public void calculate ()
	{
		//liquid ounces of alcohol
		float A = getAlcohol ();
		//a person’s weight in pounds
		float W = getWeight ();
		//a gender constant of alcohol distribution (.73 for men and .66 for women)
		float r = getGenderConst ();
		//hours elapsed since drinking commenced
		float H = getDuration ();
		
		//% BAC = (A x 5.14 / W x r) – .015 x H
		float BAC = (A * 5.14f / W * r) - (0.015f * H);

		if (BAC < 0) 
			BAC = 0;
		
		BAC_Text.text = "Your blood alcohol content is: " + BAC.ToString () + "%";
		
		
	}
}
