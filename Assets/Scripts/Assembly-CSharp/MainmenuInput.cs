using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainmenuInput : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	private GlobalInput globalInput;

	public GameObject mainmenuScripter;

	private MainmenuController mainmenuController;

	private SettingsInput settingsInput;

	private CreditsController creditsController;

	private PlayClip playClip;

	public AudioClip thump;

	public AudioClip fileDeleted;

	public GameObject mainmenuButtonCanvas;

	public GameObject settingsButtonCanvas;

	public GameObject transition;

	public GameObject selectionShadow;

	public GameObject holder1;

	public GameObject holder2;

	public GameObject holder3;

	public GameObject holder4;

	private int selection;

	private Color selectedColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	private Color unselectedColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 150);

	public GameObject savemenu;

	public GameObject SMselectionShadow;

	private int deleteSelection;

	public GameObject SMholder1;

	public GameObject SMholder2;

	public GameObject SMholder3;

	public GameObject SMholder4;

	public GameObject Blob1;

	public GameObject Blob2;

	public GameObject BlobShadow;

	public GameObject savemenuButtonCanvas;

	public GameObject mainmenu;

	public GameObject logo;

	public GameObject settings;

	public GameObject settingsMobile;

	public GameObject credits;

	private bool inDeleteConfirm;

	private int delteConfirmSelection;

	private int saveToDelete;

	public GameObject deleteConfirm;

	public GameObject deleteConfirmButtonCanvas;

	public GameObject deleteConfirmQuestion;

	public GameObject deleteConfirmYes;

	public GameObject deleteConfirmSelectionShadow;

	public GameObject panel4;

	private bool up;

	private bool down;

	private bool left;

	private bool right;

	private bool enter;

	private bool back;

	private bool esc;

	public bool inMainmenu = true;

	private bool inSaveMenu;

	private int deleteSecretPanelClicks;

	private void Start()
	{
		inMainmenu = true;
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		globalInput = globalScripter.GetComponent<GlobalInput>();
		settingsInput = mainmenuScripter.GetComponent<SettingsInput>();
		mainmenuController = mainmenuScripter.GetComponent<MainmenuController>();
		creditsController = credits.GetComponent<CreditsController>();
		playClip = mainmenuScripter.GetComponent<PlayClip>();
		selection = 1;
		holder1.GetComponent<SpriteRenderer>().color = selectedColor;
		if (generalController.mobile)
		{
			holder4.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
			panel4.SetActive(false);
		}
	}

	private void Update()
	{
		if (inMainmenu)
		{
			up = globalInput.up;
			down = globalInput.down;
			left = globalInput.left;
			right = globalInput.right;
			enter = globalInput.enter;
			back = globalInput.back;
			esc = globalInput.esc;
			if (up || down || left || right || esc || back)
			{
				ManageInput();
			}
			else if (enter && deleteSelection != 0)
			{
				ManageInput();
			}
			else if (enter)
			{
				ManageInput();
				globalInput.pulsable = false;
			}
		}
	}

	private void ManageInput()
	{
		if (!globalInput.pulsable)
		{
			return;
		}
		if (inDeleteConfirm)
		{
			if (left && delteConfirmSelection != 1)
			{
				DeleteConfirmYesIn();
			}
			else if (right && delteConfirmSelection != 2)
			{
				DeleteConfirmNoIn();
			}
			else if (enter && delteConfirmSelection != 0)
			{
				if (delteConfirmSelection == 1)
				{
					DeleteConfirmYesClick();
				}
				else if (delteConfirmSelection == 2)
				{
					DeleteConfirmNoClick();
				}
			}
			else if (esc || back)
			{
				DeleteConfirmNoClick();
			}
			else if (up)
			{
				DeleteSecretPanelClick();
				playClip.PlayCustom(thump);
			}
			else
			{
				playClip.PlayCustom(thump);
			}
		}
		else if (inSaveMenu)
		{
			if (down)
			{
				if (selection == 0)
				{
					Save1In();
				}
				else if (selection == 1)
				{
					OutSM();
					Save2In();
				}
				else if (selection == 2)
				{
					OutSM();
					TriviaIn();
				}
				else if (selection == 3)
				{
					OutSM();
					BackIn();
				}
				else if (selection == 4)
				{
					playClip.PlayCustom(thump);
				}
			}
			else if (up)
			{
				if (selection == 0)
				{
					Save1In();
				}
				else if (selection == 4)
				{
					OutSM();
					TriviaIn();
				}
				else if (selection == 3)
				{
					OutSM();
					Save2In();
				}
				else if (selection == 2)
				{
					OutSM();
					Save1In();
				}
				else if (selection == 1)
				{
					playClip.PlayCustom(thump);
				}
			}
			else if (left)
			{
				if (selection == 0)
				{
					Save1In();
				}
				else if (deleteSelection != 0)
				{
					OutSMBlobs();
				}
				else
				{
					playClip.PlayCustom(thump);
				}
			}
			else if (right)
			{
				if (selection == 0)
				{
					Save1In();
				}
				else if (selection == 1 && deleteSelection == 0)
				{
					Delete1In();
				}
				else if (selection == 2 && deleteSelection == 0)
				{
					Delete2In();
				}
				else
				{
					playClip.PlayCustom(thump);
				}
			}
			else if (enter)
			{
				if (deleteSelection == 0)
				{
					if (selection == 1)
					{
						Save1Click();
					}
					else if (selection == 2)
					{
						Save2Click();
					}
					else if (selection == 3)
					{
						TriviaClick();
					}
					else if (selection == 4)
					{
						BackClick();
					}
				}
				else if (deleteSelection == 1)
				{
					Delete1Click();
				}
				else if (deleteSelection == 2)
				{
					Delete2Click();
				}
			}
			else if (esc || back)
			{
				BackClick();
			}
		}
		else if (down)
		{
			if (selection == 0)
			{
				PlayIn();
			}
			else if (selection == 1)
			{
				Out();
				SettingsIn();
			}
			else if (selection == 2)
			{
				Out();
				CreditsIn();
			}
			else if (selection == 3)
			{
				if (generalController.mobile)
				{
					playClip.PlayCustom(thump);
					return;
				}
				Out();
				ExitIn();
			}
			else if (selection == 4)
			{
				playClip.PlayCustom(thump);
			}
		}
		else if (up)
		{
			if (selection == 0)
			{
				PlayIn();
			}
			else if (selection == 4)
			{
				Out();
				CreditsIn();
			}
			else if (selection == 3)
			{
				Out();
				SettingsIn();
			}
			else if (selection == 2)
			{
				Out();
				PlayIn();
			}
			else if (selection == 1)
			{
				playClip.PlayCustom(thump);
			}
		}
		else if (left)
		{
			if (selection == 0)
			{
				PlayIn();
			}
			else
			{
				playClip.PlayCustom(thump);
			}
		}
		else if (right)
		{
			if (selection == 0)
			{
				PlayIn();
			}
			else
			{
				playClip.PlayCustom(thump);
			}
		}
		else if (enter)
		{
			if (selection == 1)
			{
				PlayClick();
			}
			else if (selection == 2)
			{
				SettingsClick();
			}
			else if (selection == 3)
			{
				CreditsClick();
			}
			else if (selection == 4)
			{
				ExitClick();
			}
		}
		else if (esc)
		{
			ExitClick();
		}
	}

	private void Transition()
	{
		transition.GetComponent<Animator>().SetTrigger("in");
	}

	public void PlayIn()
	{
		Out();
		selection = 1;
		selectionShadow.GetComponent<Animator>().SetInteger("selection", selection);
		holder1.GetComponent<SpriteRenderer>().color = selectedColor;
	}

	public void PlayInCursor()
	{
		if (!(globalInput.inputMethod != "mouse") || generalController.mobile)
		{
			PlayIn();
		}
	}

	private void SettingsIn()
	{
		Out();
		selection = 2;
		selectionShadow.GetComponent<Animator>().SetInteger("selection", selection);
		holder2.GetComponent<SpriteRenderer>().color = selectedColor;
	}

	public void SettingsInCursor()
	{
		if (!(globalInput.inputMethod != "mouse") || generalController.mobile)
		{
			SettingsIn();
		}
	}

	private void CreditsIn()
	{
		Out();
		selection = 3;
		selectionShadow.GetComponent<Animator>().SetInteger("selection", selection);
		holder3.GetComponent<SpriteRenderer>().color = selectedColor;
	}

	public void CreditsInCursor()
	{
		if (!(globalInput.inputMethod != "mouse") || generalController.mobile)
		{
			CreditsIn();
		}
	}

	public void ExitIn()
	{
		Out();
		selection = 4;
		selectionShadow.GetComponent<Animator>().SetInteger("selection", selection);
		holder4.GetComponent<SpriteRenderer>().color = selectedColor;
	}

	public void ExitInCursor()
	{
		if (!(globalInput.inputMethod != "mouse") || generalController.mobile)
		{
			ExitIn();
		}
	}

	public void Out()
	{
		selection = 0;
		selectionShadow.GetComponent<Animator>().SetInteger("selection", selection);
		holder1.GetComponent<SpriteRenderer>().color = unselectedColor;
		holder2.GetComponent<SpriteRenderer>().color = unselectedColor;
		holder3.GetComponent<SpriteRenderer>().color = unselectedColor;
		if (!generalController.mobile)
		{
			holder4.GetComponent<SpriteRenderer>().color = unselectedColor;
		}
	}

	public void PlayClick()
	{
		if (generalController.demo)
		{
			generalController.DeleteProgress(1);
			Save1Click();
		}
		else
		{
			StartCoroutine(ShowSaveMenu());
		}
	}

	private IEnumerator ShowSaveMenu()
	{
		globalInput.pulsable = false;
		mainmenuButtonCanvas.SetActive(false);
		Out();
		mainmenu.GetComponent<Animator>().SetBool("visible", false);
		yield return new WaitForSeconds(0.1f);
		savemenu.GetComponent<Animator>().SetBool("visible", true);
		inSaveMenu = true;
		yield return new WaitForSeconds(0.16f);
		if (globalInput.inputMethod != "mouse")
		{
			Save1In();
		}
		yield return new WaitForSeconds(0.1f);
		savemenuButtonCanvas.SetActive(true);
		globalInput.pulsable = true;
	}

	public void SettingsClick()
	{
		mainmenuButtonCanvas.SetActive(false);
		if (selection != 2)
		{
			SettingsIn();
			Invoke("CallShowSettings", 0.3f);
		}
		else
		{
			StartCoroutine(ShowSettings());
		}
	}

	private void CallShowSettings()
	{
		StartCoroutine(ShowSettings());
	}

	private IEnumerator ShowSettings()
	{
		inMainmenu = false;
		logo.GetComponent<Animator>().SetBool("visible", false);
		mainmenu.GetComponent<Animator>().SetBool("visible", false);
		globalInput.pulsable = false;
		selection = 0;
		selectionShadow.GetComponent<Animator>().SetInteger("selection", 0);
		yield return new WaitForSeconds(0.2f);
		Out();
		settingsInput.Initialize();
		if (generalController.mobile)
		{
			settingsMobile.GetComponent<Animator>().SetBool("visible", true);
		}
		else
		{
			settings.GetComponent<Animator>().SetBool("visible", true);
		}
		yield return new WaitForSeconds(0.2f);
		globalInput.pulsable = true;
		settingsInput.inSettings = true;
		settingsButtonCanvas.SetActive(true);
	}

	public void CreditsClick()
	{
		mainmenuButtonCanvas.SetActive(false);
		if (selection != 3)
		{
			CreditsIn();
		}
		StartCoroutine(ShowCredits());
	}

	private IEnumerator ShowCredits()
	{
		inMainmenu = false;
		generalController.currentScene = "credits";
		globalInput.pulsable = false;
		mainmenuButtonCanvas.SetActive(false);
		creditsController.TranslateCredits();
		credits.GetComponent<Animator>().SetBool("visible", true);
		yield return new WaitForSeconds(0.3f);
		globalInput.pulsable = true;
	}

	public void CreditsPanelClick()
	{
		Out();
		HideCredits();
	}

	public void HideCredits()
	{
		generalController.currentScene = "mainmenu";
		globalInput.pulsable = false;
		credits.GetComponent<Animator>().SetBool("visible", false);
		Invoke("ReactivateButtonCanvas", 0.16f);
	}

	private void ReactivateButtonCanvas()
	{
		mainmenuButtonCanvas.SetActive(true);
		inMainmenu = true;
		globalInput.pulsable = true;
	}

	public void BackToMainmenu()
	{
		mainmenuController.ChangeLang();
		generalController.Initialize();
		settingsButtonCanvas.SetActive(false);
		mainmenu.GetComponent<Animator>().SetBool("visible", true);
		logo.GetComponent<Animator>().SetBool("visible", true);
		StartCoroutine(EnableMainmenu());
	}

	private IEnumerator EnableMainmenu()
	{
		yield return new WaitForSeconds(0.2f);
		mainmenuButtonCanvas.SetActive(true);
		globalInput.pulsable = true;
		inMainmenu = true;
		if (globalInput.inputMethod == "keys")
		{
			SettingsIn();
		}
	}

	public void ExitClick()
	{
		mainmenuButtonCanvas.SetActive(false);
		if (selection != 4)
		{
			if (!generalController.mobile)
			{
				ExitIn();
			}
			Invoke("Quit", 0.3f);
		}
		else
		{
			Quit();
		}
	}

	private void Quit()
	{
		if (generalController.steam)
		{
			SteamManager steamManager = Object.FindObjectOfType<SteamManager>();
			if (steamManager != null)
			{
				Object.Destroy(steamManager);
			}
		}
		Application.Quit();
	}

	private void Save1In()
	{
		OutSM();
		selection = 1;
		SMselectionShadow.GetComponent<Animator>().SetInteger("selection", selection);
		SMholder1.GetComponent<SpriteRenderer>().color = selectedColor;
	}

	public void Save1InCursor()
	{
		if (!(globalInput.inputMethod != "mouse") || generalController.mobile)
		{
			Save1In();
		}
	}

	private void Save2In()
	{
		OutSM();
		selection = 2;
		SMselectionShadow.GetComponent<Animator>().SetInteger("selection", selection);
		SMholder2.GetComponent<SpriteRenderer>().color = selectedColor;
	}

	public void Save2InCursor()
	{
		if (!(globalInput.inputMethod != "mouse") || generalController.mobile)
		{
			Save2In();
		}
	}

	private void TriviaIn()
	{
		OutSM();
		selection = 3;
		SMselectionShadow.GetComponent<Animator>().SetInteger("selection", selection);
		SMholder3.GetComponent<SpriteRenderer>().color = selectedColor;
	}

	public void TriviaInCursor()
	{
		if (!(globalInput.inputMethod != "mouse") || generalController.mobile)
		{
			TriviaIn();
		}
	}

	private void BackIn()
	{
		OutSM();
		selection = 4;
		SMselectionShadow.GetComponent<Animator>().SetInteger("selection", selection);
		SMholder4.GetComponent<SpriteRenderer>().color = selectedColor;
	}

	public void BackInCursor()
	{
		if (!(globalInput.inputMethod != "mouse") || generalController.mobile)
		{
			BackIn();
		}
	}

	private void Delete1In()
	{
		if (selection != 1)
		{
			Save1In();
		}
		deleteSelection = selection;
		BlobShadow.GetComponent<Animator>().SetInteger("selection", selection);
		Blob1.GetComponent<SpriteRenderer>().color = selectedColor;
	}

	public void Delete1InCursor()
	{
		if (!(globalInput.inputMethod != "mouse") || generalController.mobile)
		{
			Delete1In();
		}
	}

	private void Delete2In()
	{
		if (selection != 2)
		{
			Save2In();
		}
		deleteSelection = selection;
		BlobShadow.GetComponent<Animator>().SetInteger("selection", selection);
		Blob2.GetComponent<SpriteRenderer>().color = selectedColor;
	}

	public void Delete2InCursor()
	{
		if (!(globalInput.inputMethod != "mouse") || generalController.mobile)
		{
			Delete2In();
		}
	}

	public void OutSM()
	{
		selection = 0;
		SMselectionShadow.GetComponent<Animator>().SetInteger("selection", selection);
		deleteSelection = 0;
		BlobShadow.GetComponent<Animator>().SetInteger("selection", deleteSelection);
		SMholder1.GetComponent<SpriteRenderer>().color = unselectedColor;
		SMholder2.GetComponent<SpriteRenderer>().color = unselectedColor;
		SMholder3.GetComponent<SpriteRenderer>().color = unselectedColor;
		SMholder4.GetComponent<SpriteRenderer>().color = unselectedColor;
		Blob1.GetComponent<SpriteRenderer>().color = unselectedColor;
		Blob2.GetComponent<SpriteRenderer>().color = unselectedColor;
	}

	public void OutSMBlobs()
	{
		deleteSelection = 0;
		BlobShadow.GetComponent<Animator>().SetInteger("selection", deleteSelection);
		Blob1.GetComponent<SpriteRenderer>().color = unselectedColor;
		Blob2.GetComponent<SpriteRenderer>().color = unselectedColor;
	}

	public void Save1Click()
	{
		generalController.justTrivia = false;
		savemenuButtonCanvas.SetActive(false);
		if (selection != 1)
		{
			Save1In();
			Invoke("Transition", 0.3f);
			return;
		}
		generalController.saveFile = 1;
		generalController.StartSave(1);
		Transition();
		globalInput.pulsable = false;
	}

	public void Save2Click()
	{
		generalController.justTrivia = false;
		savemenuButtonCanvas.SetActive(false);
		if (selection != 2)
		{
			Save2In();
			Invoke("Transition", 0.3f);
			return;
		}
		generalController.saveFile = 2;
		generalController.StartSave(2);
		Transition();
		globalInput.pulsable = false;
	}

	public void Delete1Click()
	{
		saveToDelete = 1;
		StartCoroutine(ShowDeleteConfirm());
	}

	public void Delete2Click()
	{
		saveToDelete = 2;
		StartCoroutine(ShowDeleteConfirm());
	}

	private IEnumerator ShowDeleteConfirm()
	{
		globalInput.pulsable = false;
		if (generalController.lang == "en")
		{
			deleteConfirmQuestion.GetComponent<Text>().text = "Do you wish to delete this save file?";
			deleteConfirmYes.GetComponent<Text>().text = "Yes";
		}
		else
		{
			deleteConfirmQuestion.GetComponent<Text>().text = "¿Deseas borrar este archivo de guardado?";
			deleteConfirmYes.GetComponent<Text>().text = "Sí";
		}
		inDeleteConfirm = true;
		savemenu.GetComponent<Animator>().SetBool("visible", false);
		SMselectionShadow.GetComponent<Animator>().SetInteger("selection", 0);
		OutSMBlobs();
		deleteConfirm.SetActive(true);
		deleteConfirmButtonCanvas.SetActive(false);
		savemenuButtonCanvas.SetActive(false);
		deleteConfirm.GetComponent<Animator>().SetBool("visible", true);
		yield return new WaitForSeconds(0.5f);
		deleteConfirmButtonCanvas.SetActive(true);
		if (globalInput.inputMethod != "mouse")
		{
			DeleteConfirmNoIn();
		}
		globalInput.pulsable = true;
		deleteSecretPanelClicks = 0;
	}

	private void DeleteConfirmYesIn()
	{
		DeleteConfirmOut();
		delteConfirmSelection = 1;
		deleteConfirmSelectionShadow.GetComponent<Animator>().SetInteger("selection", delteConfirmSelection);
	}

	public void DeleteConfirmYesInCursor()
	{
		if (!(globalInput.inputMethod != "mouse") || generalController.mobile)
		{
			DeleteConfirmYesIn();
		}
	}

	private void DeleteConfirmNoIn()
	{
		DeleteConfirmOut();
		delteConfirmSelection = 2;
		deleteConfirmSelectionShadow.GetComponent<Animator>().SetInteger("selection", delteConfirmSelection);
	}

	public void DeleteConfirmNoInCursor()
	{
		if (!(globalInput.inputMethod != "mouse") || generalController.mobile)
		{
			DeleteConfirmNoIn();
		}
	}

	public void DeleteConfirmOut()
	{
		delteConfirmSelection = 0;
		deleteConfirmSelectionShadow.GetComponent<Animator>().SetInteger("selection", delteConfirmSelection);
	}

	public void DeleteSecretPanelClick()
	{
		deleteSecretPanelClicks++;
		if (deleteSecretPanelClicks > 9)
		{
			deleteSecretPanelClicks = 0;
			DeleteConfirmNoClick();
		}
		else if (deleteSecretPanelClicks == 9)
		{
			if (generalController.lang == "en")
			{
				deleteConfirmQuestion.GetComponent<Text>().text = "DO YOU WISH TO DELETE ALL THE DATA AND CLOSE THE GAME?";
			}
			else
			{
				deleteConfirmQuestion.GetComponent<Text>().text = "¿DESEAS BORRAR TODOS LOS DATOS Y CERRAR EL JUEGO?";
			}
		}
	}

	public void DeleteConfirmYesClick()
	{
		if (deleteSecretPanelClicks == 9)
		{
			Debug.Log("ALL DELETED");
			PlayerPrefs.DeleteAll();
			generalController.saveFile = 1;
			generalController.ResetSave();
			generalController.saveFile = 2;
			generalController.ResetSave();
			generalController.ResetUsedQuestions();
			Quit();
		}
		else
		{
			generalController.DeleteProgress(saveToDelete);
			mainmenuController.ShowSavesData();
			playClip.PlayCustom(fileDeleted);
			StartCoroutine(PauseBeforeHideDeleteConfirm());
		}
	}

	public void DeleteConfirmNoClick()
	{
		StartCoroutine(HideDeleteConfirm());
	}

	private IEnumerator PauseBeforeHideDeleteConfirm()
	{
		globalInput.pulsable = false;
		yield return new WaitForSeconds(0.3f);
		StartCoroutine(HideDeleteConfirm());
	}

	private IEnumerator HideDeleteConfirm()
	{
		globalInput.pulsable = false;
		inDeleteConfirm = false;
		DeleteConfirmOut();
		deleteConfirm.GetComponent<Animator>().SetBool("visible", false);
		deleteConfirmButtonCanvas.SetActive(false);
		yield return new WaitForSeconds(0.2f);
		savemenu.GetComponent<Animator>().SetBool("visible", true);
		yield return new WaitForSeconds(0.2f);
		savemenuButtonCanvas.SetActive(true);
		deleteConfirm.SetActive(false);
		if (globalInput.inputMethod != "mouse")
		{
			if (saveToDelete == 1)
			{
				Save1In();
			}
			else
			{
				Save2In();
			}
		}
		globalInput.pulsable = true;
	}

	public void TriviaClick()
	{
		savemenuButtonCanvas.SetActive(false);
		generalController.justTrivia = true;
		if (selection != 3)
		{
			TriviaIn();
			Invoke("Transition", 0.3f);
		}
		else
		{
			Transition();
			globalInput.pulsable = false;
			generalController.StartJustTrivia();
		}
	}

	public void BackClick()
	{
		if (selection != 4)
		{
			BackIn();
			StartCoroutine(BackToMainMenu());
		}
		else
		{
			StartCoroutine(BackToMainMenu());
		}
	}

	private IEnumerator BackToMainMenu()
	{
		globalInput.pulsable = false;
		savemenuButtonCanvas.SetActive(false);
		OutSM();
		savemenu.GetComponent<Animator>().SetBool("visible", false);
		yield return new WaitForSeconds(0.1f);
		mainmenu.GetComponent<Animator>().SetBool("visible", true);
		yield return new WaitForSeconds(0.1f);
		if (globalInput.inputMethod != "mouse")
		{
			PlayIn();
		}
		yield return new WaitForSeconds(0.1f);
		mainmenuButtonCanvas.SetActive(true);
		inSaveMenu = false;
		globalInput.pulsable = true;
	}
}
