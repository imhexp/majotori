using UnityEngine;
using UnityEngine.UI;

public class FinalCreditsController : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	public AudioSource creditsAudioSource;

	public AudioSource deathsAudioSource;

	public GameObject FinalResults;

	public GameObject lariatLabel;

	public GameObject lariatName;

	public GameObject alvaLabel;

	public GameObject konyLabel;

	public GameObject navarroLabel;

	public GameObject estherLabel;

	public GameObject unityLabel;

	public GameObject banksiaLabel;

	public GameObject whooshLabel;

	public GameObject thanksLabel;

	public GameObject thanksName;

	public GameObject youName;

	public GameObject wishText;

	public GameObject fulfilledText;

	public GameObject disclaimerText;

	public GameObject winsText;

	public GameObject failsText;

	private float exp = 2f;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		creditsAudioSource.volume = Mathf.Pow((float)generalController.musicVol / 100f, exp);
		deathsAudioSource.volume = Mathf.Pow((float)generalController.musicVol / 100f, exp);
		winsText.GetComponent<Text>().text = string.Empty + generalController.wins;
		failsText.GetComponent<Text>().text = string.Empty + generalController.fails;
		if (generalController.lang == "en")
		{
			lariatLabel.GetComponent<Text>().text = "Created by";
			lariatName.GetComponent<Text>().text = "Lariat the Witch";
			alvaLabel.GetComponent<Text>().text = "And";
			konyLabel.GetComponent<Text>().text = "With help from";
			navarroLabel.GetComponent<Text>().text = "And";
			estherLabel.GetComponent<Text>().text = "Music by";
			unityLabel.GetComponent<Text>().text = "Using Unity\n(game engine) by";
			banksiaLabel.GetComponent<Text>().text = "Using Banksia\n(text font) by";
			whooshLabel.GetComponent<Text>().text = "Using Whoosh Sound Pack\n(sounds) by";
			thanksLabel.GetComponent<Text>().text = "Special thanks to";
			thanksName.GetComponent<Text>().text = "Alva's brother\nAlva's mother\nDavid Gómez";
			if (generalController.youCredits)
			{
				youName.GetComponent<Text>().text = "And to you";
			}
			else
			{
				youName.GetComponent<Text>().text = string.Empty;
			}
			wishText.GetComponent<Text>().text = "You wished to be entertained";
			fulfilledText.GetComponent<Text>().text = "and I made it happen.";
			disclaimerText.GetComponent<Text>().text = "Majotori is a work of fiction.\nNo identification with actual entities is intended.";
		}
		else
		{
			lariatLabel.GetComponent<Text>().text = "Creado por";
			lariatName.GetComponent<Text>().text = "Lariat la Bruja";
			alvaLabel.GetComponent<Text>().text = "Y";
			konyLabel.GetComponent<Text>().text = "Con la ayuda de";
			navarroLabel.GetComponent<Text>().text = "Y";
			estherLabel.GetComponent<Text>().text = "Música por";
			unityLabel.GetComponent<Text>().text = "Usando Unity\n(motor de juegos) por";
			banksiaLabel.GetComponent<Text>().text = "Usando Banksia\n(fuente de texto) por";
			whooshLabel.GetComponent<Text>().text = "Usando Whoosh Sound Pack\n(sonidos) por";
			thanksLabel.GetComponent<Text>().text = "Agradecimientos especiales a";
			thanksName.GetComponent<Text>().text = "El hermano de Alva\nLa madre de Alva\nDavid Gómez";
			if (generalController.youCredits)
			{
				youName.GetComponent<Text>().text = "Y a ti";
			}
			else
			{
				youName.GetComponent<Text>().text = string.Empty;
			}
			wishText.GetComponent<Text>().text = "Tu deseo era divertirte";
			fulfilledText.GetComponent<Text>().text = "y te lo he concedido.";
			disclaimerText.GetComponent<Text>().text = "Majotori es una obra de ficción.\nNo se pretende ninguna identificación con entidades reales.";
		}
	}

	public void StartMusic()
	{
		creditsAudioSource.Play();
	}

	public void ShowFinalResults()
	{
		if (generalController.wins == 0 || generalController.fails == 0)
		{
			FinalResults.GetComponent<Animator>().SetTrigger("startPerfect");
		}
		else
		{
			FinalResults.GetComponent<Animator>().SetTrigger("start");
		}
		base.gameObject.SetActive(false);
	}
}
