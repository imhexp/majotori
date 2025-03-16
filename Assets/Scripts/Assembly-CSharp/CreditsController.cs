using UnityEngine;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour
{
	public GameObject createdLabel;

	public GameObject createdCredits;

	public GameObject helpedLabel;

	public GameObject musicLabel;

	public GameObject fontLabel;

	public GameObject soundsLabel;

	public GameObject unityLabel;

	public GameObject thanksLabel;

	public GameObject thanksCredits;

	public GameObject disclaimer;

	private GameObject globalScripter;

	private GeneralController generalController;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
	}

	public void TranslateCredits()
	{
		if (generalController.lang == "en")
		{
			createdLabel.GetComponent<Text>().text = "Created by";
			createdCredits.GetComponent<Text>().text = "Lariat the Witch\nAlva Majo";
			helpedLabel.GetComponent<Text>().text = "With help from";
			musicLabel.GetComponent<Text>().text = "Music by";
			fontLabel.GetComponent<Text>().text = "Using Banksia\n(text font) by";
			soundsLabel.GetComponent<Text>().text = "Using Whoosh Sound Pack\n(sounds) by";
			unityLabel.GetComponent<Text>().text = "Using Unity\n(game engine) by";
			thanksLabel.GetComponent<Text>().text = "Special thanks to";
			thanksCredits.GetComponent<Text>().text = "Alva's brother\nAlva's mother\nDavid Gómez";
			if (PlayerPrefs.GetInt("YouCredits") == 1)
			{
				thanksCredits.GetComponent<Text>().text = "Alva's brother\nAlva's mother\nDavid Gómez\nand you";
			}
			disclaimer.GetComponent<Text>().text = "Majotori is a work of fiction.\nNo identification with actual entities is intended.\nThis is a decompilation of the original source code.";
		}
		else
		{
			createdLabel.GetComponent<Text>().text = "Creado por";
			createdCredits.GetComponent<Text>().text = "Lariat la Bruja\nAlva Majo";
			helpedLabel.GetComponent<Text>().text = "Con la ayuda de";
			musicLabel.GetComponent<Text>().text = "Música por";
			fontLabel.GetComponent<Text>().text = "Usando Banksia\n(fuente de texto) por";
			soundsLabel.GetComponent<Text>().text = "Usando Whoosh Sound Pack\n(sonidos) por";
			unityLabel.GetComponent<Text>().text = "Usando Unity\n(motor de juegos) por";
			thanksLabel.GetComponent<Text>().text = "Agradecimientos especiales a";
			thanksCredits.GetComponent<Text>().text = "El hermano de Alva\nLa madre de Alva\nDavid Gómez\n";
			if (PlayerPrefs.GetInt("YouCredits") == 1)
			{
				thanksCredits.GetComponent<Text>().text = "El hermano de Alva\nLa madre de Alva\nDavid Gómez\ny a ti";
			}
			disclaimer.GetComponent<Text>().text = "Majotori es una obra de ficción.\nNo se pretende ninguna identificación con entidades reales.\nEsto es una decompilación y reconstrucción del código fuente.";
		}
	}
}
