using System;
using UnityEngine;
using UnityEngine.UI;

public class MainmenuController : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	public GameObject playText;

	public GameObject settingsText;

	public GameObject creditsText;

	public GameObject exitText;

	public GameObject save1Label;

	public GameObject save2Label;

	public GameObject triviaText;

	public GameObject backText;

	public GameObject correct1Number;

	public GameObject incorrect1Number;

	public GameObject correct2Number;

	public GameObject incorrect2Number;

	public GameObject transition;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		transition.GetComponent<Animator>().SetBool("visibleOver", true);
		transition.GetComponent<Animator>().SetTrigger("out");
		generalController.Initialize();
		ChangeLang();
		ShowSavesData();
		generalController.progressSaved = false;
		GC.Collect();
	}

	public void ChangeLang()
	{
		if (generalController.lang == "en")
		{
			playText.GetComponent<Text>().text = "Play";
			settingsText.GetComponent<Text>().text = "Settings";
			creditsText.GetComponent<Text>().text = "Credits";
			exitText.GetComponent<Text>().text = "Exit";
			save1Label.GetComponent<Text>().text = "Save";
			save2Label.GetComponent<Text>().text = "Save";
			triviaText.GetComponent<Text>().text = "Just trivia";
			backText.GetComponent<Text>().text = "Back";
		}
		else
		{
			playText.GetComponent<Text>().text = "Jugar";
			settingsText.GetComponent<Text>().text = "Ajustes";
			creditsText.GetComponent<Text>().text = "Créditos";
			exitText.GetComponent<Text>().text = "Salir";
			save1Label.GetComponent<Text>().text = "Guardado";
			save2Label.GetComponent<Text>().text = "Guardado";
			triviaText.GetComponent<Text>().text = "Solo trivia";
			backText.GetComponent<Text>().text = "Volver";
		}
		if (generalController.mobile)
		{
			exitText.GetComponent<Text>().text = string.Empty;
		}
	}

	public void ShowSavesData()
	{
		generalController.saveFile = 1;
		generalController.Load();
		correct1Number.GetComponent<Text>().text = string.Empty + generalController.wins;
		incorrect1Number.GetComponent<Text>().text = string.Empty + generalController.fails;
		if (generalController.youCredits)
		{
			PlayerPrefs.SetInt("YouCredits", 1);
		}
		generalController.saveFile = 2;
		generalController.Load();
		correct2Number.GetComponent<Text>().text = string.Empty + generalController.wins;
		incorrect2Number.GetComponent<Text>().text = string.Empty + generalController.fails;
		if (generalController.youCredits)
		{
			PlayerPrefs.SetInt("YouCredits", 1);
		}
	}
}
