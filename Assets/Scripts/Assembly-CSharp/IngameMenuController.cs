using System.Collections;
using UnityEngine;

public class IngameMenuController : MonoBehaviour
{
	public bool inMenu;

	private GameObject globalScripter;

	private GeneralController generalController;

	private GlobalInput globalInput;

	private SettingsInput settingsInput;

	public GameObject narratorScripter;

	private ScriptParser scriptParser;

	private PlayClip playClip;

	private GameObject quizScripter;

	private QuizController quizController;

	private IngameMenuInput ingameMenuInput;

	private AudioSource NarratorAudioSource;

	private FadeMusic fadeMusic;

	public GameObject buttonCanvas;

	public GameObject settings;

	public GameObject settingsButtonCanvas;

	public GameObject settingsMobile;

	public GameObject settingsButtonCanvasMobile;

	public GameObject textHolder;

	public string selection = string.Empty;

	public GameObject transition;

	private bool deployed;

	public GameObject ingame_menu;

	public GameObject menu_button;

	public GameObject settings_button;

	public GameObject skip_button;

	public GameObject previous_button;

	public GameObject translate_button;

	public GameObject exit_button;

	public GameObject settings_panel;

	public GameObject skip_panel;

	public GameObject previous_panel;

	public GameObject translate_panel;

	public GameObject exit_panel;

	private Color selectedC = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	private Color unselectedC = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 100);

	private Color unselectedNarratorC = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 100);

	private Color unselectedQuizC = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 200);

	private Color selectedExitC = new Color32(190, 0, 0, byte.MaxValue);

	public AudioClip selectedSound1;

	public AudioClip selectedSound2;

	public AudioClip thump;

	public AudioClip incorrect;

	private float timer;

	private bool deployFade;

	private bool visible;

	private bool alreadySkipped;

	private bool passedThroughQuiz;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		globalInput = globalScripter.GetComponent<GlobalInput>();
		playClip = narratorScripter.GetComponent<PlayClip>();
		fadeMusic = globalScripter.GetComponent<FadeMusic>();
		settingsInput = narratorScripter.GetComponent<SettingsInput>();
		scriptParser = narratorScripter.GetComponent<ScriptParser>();
		ingameMenuInput = base.gameObject.GetComponent<IngameMenuInput>();
		GameObject gameObject = GameObject.Find("NarratorAudioSource");
		NarratorAudioSource = gameObject.GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (!visible && globalInput.pulsable)
		{
			visible = true;
			ingame_menu.GetComponent<Animator>().SetBool("visible", true);
		}
		if (generalController.currentScene == "quiz" && !passedThroughQuiz)
		{
			passedThroughQuiz = true;
			unselectedC = unselectedQuizC;
			if (selection != "menu" && menu_button.GetComponent<SpriteRenderer>().color != unselectedC)
			{
				menu_button.GetComponent<SpriteRenderer>().color = unselectedC;
			}
			if (selection != "settings" && settings_button.GetComponent<SpriteRenderer>().color != unselectedC)
			{
				settings_button.GetComponent<SpriteRenderer>().color = unselectedC;
			}
			if (selection != "skip" && skip_button.GetComponent<SpriteRenderer>().color != unselectedC)
			{
				skip_button.GetComponent<SpriteRenderer>().color = unselectedC;
			}
			if (selection != "previous" && previous_button.GetComponent<SpriteRenderer>().color != unselectedC)
			{
				previous_button.GetComponent<SpriteRenderer>().color = unselectedC;
			}
			if (selection != "translate" && translate_button.GetComponent<SpriteRenderer>().color != unselectedC)
			{
				translate_button.GetComponent<SpriteRenderer>().color = unselectedC;
			}
			if (selection != "exit" && exit_button.GetComponent<SpriteRenderer>().color != unselectedC)
			{
				exit_button.GetComponent<SpriteRenderer>().color = unselectedC;
			}
		}
		else if (generalController.currentScene == "narrator" && passedThroughQuiz)
		{
			passedThroughQuiz = false;
			alreadySkipped = false;
			unselectedC = unselectedNarratorC;
			if (selection != "menu" && menu_button.GetComponent<SpriteRenderer>().color != unselectedC)
			{
				menu_button.GetComponent<SpriteRenderer>().color = unselectedC;
			}
			if (selection != "settings" && settings_button.GetComponent<SpriteRenderer>().color != unselectedC)
			{
				settings_button.GetComponent<SpriteRenderer>().color = unselectedC;
			}
			if (selection != "skip" && skip_button.GetComponent<SpriteRenderer>().color != unselectedC)
			{
				skip_button.GetComponent<SpriteRenderer>().color = unselectedC;
			}
			if (selection != "previous" && previous_button.GetComponent<SpriteRenderer>().color != unselectedC)
			{
				previous_button.GetComponent<SpriteRenderer>().color = unselectedC;
			}
			if (selection != "translate" && translate_button.GetComponent<SpriteRenderer>().color != unselectedC)
			{
				translate_button.GetComponent<SpriteRenderer>().color = unselectedC;
			}
			if (selection != "exit" && exit_button.GetComponent<SpriteRenderer>().color != unselectedC)
			{
				exit_button.GetComponent<SpriteRenderer>().color = unselectedC;
			}
		}
		if (!inMenu)
		{
			return;
		}
		if (deployFade)
		{
			timer += Time.deltaTime * 2f;
			float num = 1f - timer;
			if (num > unselectedC.a)
			{
				if (selection != "settings")
				{
					settings_button.GetComponent<SpriteRenderer>().color = new Color(selectedC.r, selectedC.g, selectedC.b, num);
				}
				if (selection != "skip")
				{
					skip_button.GetComponent<SpriteRenderer>().color = new Color(selectedC.r, selectedC.g, selectedC.b, num);
				}
				if (selection != "previous")
				{
					previous_button.GetComponent<SpriteRenderer>().color = new Color(selectedC.r, selectedC.g, selectedC.b, num);
				}
				if (selection != "translate")
				{
					translate_button.GetComponent<SpriteRenderer>().color = new Color(selectedC.r, selectedC.g, selectedC.b, num);
				}
				if (selection != "exit")
				{
					exit_button.GetComponent<SpriteRenderer>().color = new Color(selectedC.r, selectedC.g, selectedC.b, num);
				}
			}
			else
			{
				if (selection != "settings")
				{
					settings_button.GetComponent<SpriteRenderer>().color = unselectedC;
				}
				if (selection != "skip")
				{
					skip_button.GetComponent<SpriteRenderer>().color = unselectedC;
				}
				if (selection != "previous")
				{
					previous_button.GetComponent<SpriteRenderer>().color = unselectedC;
				}
				if (selection != "translate")
				{
					translate_button.GetComponent<SpriteRenderer>().color = unselectedC;
				}
				if (selection != "exit")
				{
					exit_button.GetComponent<SpriteRenderer>().color = unselectedC;
				}
				deployFade = false;
				timer = 0f;
			}
		}
		else if (globalInput.pulsable && deployed)
		{
			settings_button.GetComponent<Animator>().SetBool("enabled", true);
			if (generalController.currentScene == "quiz")
			{
				skip_button.GetComponent<Animator>().SetBool("enabled", false);
				previous_button.GetComponent<Animator>().SetBool("enabled", false);
			}
			else
			{
				if (!alreadySkipped)
				{
					skip_button.GetComponent<Animator>().SetBool("enabled", true);
				}
				previous_button.GetComponent<Animator>().SetBool("enabled", true);
			}
			exit_button.GetComponent<Animator>().SetBool("enabled", true);
			if (generalController.currentScene == "quiz")
			{
				if (quizController == null)
				{
					quizScripter = GameObject.Find("QuizScripter");
					if (quizScripter != null)
					{
						quizController = quizScripter.GetComponent<QuizController>();
					}
				}
				if (quizController != null)
				{
					if (quizController.quizInput != null)
					{
						if (quizController.quizInput.currentSituation == "roulette")
						{
							translate_button.GetComponent<Animator>().SetBool("enabled", false);
						}
						else
						{
							translate_button.GetComponent<Animator>().SetBool("enabled", true);
						}
					}
					else
					{
						translate_button.GetComponent<Animator>().SetBool("enabled", true);
					}
				}
				else
				{
					translate_button.GetComponent<Animator>().SetBool("enabled", true);
				}
			}
			else
			{
				translate_button.GetComponent<Animator>().SetBool("enabled", true);
			}
		}
		else if (!globalInput.pulsable && deployed)
		{
			if (selection == "settings")
			{
				settings_button.GetComponent<Animator>().SetBool("enabled", false);
			}
			if (selection == "skip")
			{
				skip_button.GetComponent<Animator>().SetBool("enabled", false);
			}
			if (selection == "previous")
			{
				previous_button.GetComponent<Animator>().SetBool("enabled", false);
			}
			if (selection == "translate")
			{
				translate_button.GetComponent<Animator>().SetBool("enabled", false);
			}
		}
		menu_button.GetComponent<Animator>().SetBool("selected", true);
	}

	public void AllOut()
	{
		selection = string.Empty;
		MenuOut();
		SettingsOut();
		SkipOut();
		PreviousOut();
		TranslateOut();
		ExitOut();
	}

	public void MenuIn()
	{
		AllOut();
		selection = "menu";
		ingame_menu.GetComponent<Animator>().SetBool("selected", true);
		menu_button.GetComponent<Animator>().SetBool("selected", true);
		menu_button.GetComponent<SpriteRenderer>().color = selectedC;
		playClip.PlayCustom(selectedSound1);
	}

	public void MenuOut()
	{
		selection = string.Empty;
		ingame_menu.GetComponent<Animator>().SetBool("selected", false);
		if (!deployed)
		{
			menu_button.GetComponent<Animator>().SetBool("selected", false);
		}
		menu_button.GetComponent<SpriteRenderer>().color = unselectedC;
	}

	public void MenuClick()
	{
		if (deployed)
		{
			inMenu = false;
			ingame_menu.GetComponent<Animator>().SetBool("deployed", false);
			menu_button.GetComponent<Animator>().SetTrigger("pressed");
			menu_button.GetComponent<Animator>().SetBool("deployed", false);
			deployed = false;
			Invoke("DeactivatePanels", 0.16f);
			return;
		}
		if (!inMenu)
		{
			AllOut();
			selection = "menu";
			ingame_menu.GetComponent<Animator>().SetBool("selected", true);
			menu_button.GetComponent<Animator>().SetBool("selected", true);
			menu_button.GetComponent<SpriteRenderer>().color = selectedC;
		}
		ingame_menu.GetComponent<Animator>().SetBool("deployed", true);
		menu_button.GetComponent<Animator>().SetTrigger("pressed");
		menu_button.GetComponent<Animator>().SetBool("deployed", true);
		deployed = true;
		settings_button.GetComponent<SpriteRenderer>().color = selectedC;
		skip_button.GetComponent<SpriteRenderer>().color = selectedC;
		previous_button.GetComponent<SpriteRenderer>().color = selectedC;
		translate_button.GetComponent<SpriteRenderer>().color = selectedC;
		exit_button.GetComponent<SpriteRenderer>().color = selectedC;
		settings_panel.SetActive(true);
		skip_panel.SetActive(true);
		previous_panel.SetActive(true);
		translate_panel.SetActive(true);
		exit_panel.SetActive(true);
		deployFade = true;
		inMenu = true;
	}

	private void DeactivatePanels()
	{
		settings_panel.SetActive(false);
		skip_panel.SetActive(false);
		previous_panel.SetActive(false);
		translate_panel.SetActive(false);
		exit_panel.SetActive(false);
		globalInput.pulsable = true;
	}

	public void SettingsIn()
	{
		if (deployed)
		{
			AllOut();
			selection = "settings";
			settings_button.GetComponent<SpriteRenderer>().color = selectedC;
			playClip.PlayCustom(selectedSound2);
		}
	}

	public void SettingsOut()
	{
		selection = string.Empty;
		if (deployed)
		{
			settings_button.GetComponent<SpriteRenderer>().color = unselectedC;
		}
	}

	public void SettingsClick()
	{
		if (!deployed)
		{
			return;
		}
		if (globalInput.pulsable)
		{
			inMenu = false;
			buttonCanvas.SetActive(false);
			settings_button.GetComponent<Animator>().SetTrigger("pressed");
			globalInput.pulsable = false;
			settingsInput.Initialize();
			if (generalController.currentScene == "narrator")
			{
				textHolder.GetComponent<Animator>().SetBool("visible", false);
			}
			else if (generalController.currentScene == "quiz")
			{
				quizScripter = GameObject.Find("QuizScripter");
				quizController = quizScripter.GetComponent<QuizController>();
				quizController.HideHolders();
			}
			StartCoroutine(ShowSettings());
		}
		else
		{
			playClip.PlayCustom(thump);
		}
	}

	private IEnumerator ShowSettings()
	{
		yield return new WaitForSeconds(0.2f);
		if (generalController.mobile)
		{
			settingsMobile.GetComponent<Animator>().SetBool("visible", true);
		}
		else
		{
			settings.GetComponent<Animator>().SetBool("visible", true);
		}
		yield return new WaitForSeconds(0.2f);
		SettingsOut();
		globalInput.pulsable = true;
		settingsInput.inSettings = true;
		if (generalController.mobile)
		{
			settingsButtonCanvasMobile.SetActive(true);
		}
		else
		{
			settingsButtonCanvas.SetActive(true);
		}
	}

	public void SkipIn()
	{
		if (deployed)
		{
			AllOut();
			selection = "skip";
			skip_button.GetComponent<SpriteRenderer>().color = selectedC;
			playClip.PlayCustom(selectedSound1);
		}
	}

	public void SkipOut()
	{
		selection = string.Empty;
		if (deployed)
		{
			skip_button.GetComponent<SpriteRenderer>().color = unselectedC;
		}
	}

	public void SkipClick()
	{
		if (!deployed)
		{
			return;
		}
		if (globalInput.pulsable && generalController.currentScene != "quiz" && !alreadySkipped)
		{
			globalInput.pulsable = false;
			alreadySkipped = true;
			skip_button.GetComponent<Animator>().SetTrigger("pressed");
			if (globalInput.inputMethod != "mouse")
			{
				MenuClick();
				MenuOut();
			}
			generalController.Skip();
		}
		else
		{
			playClip.PlayCustom(thump);
			globalInput.pulsable = true;
		}
	}

	public void PreviousIn()
	{
		if (deployed)
		{
			AllOut();
			selection = "previous";
			previous_button.GetComponent<SpriteRenderer>().color = selectedC;
			playClip.PlayCustom(selectedSound2);
		}
	}

	public void PreviousOut()
	{
		selection = string.Empty;
		if (deployed)
		{
			previous_button.GetComponent<SpriteRenderer>().color = unselectedC;
		}
	}

	public void PreviousClick()
	{
		if (deployed)
		{
			if (globalInput.pulsable && generalController.currentScene != "quiz")
			{
				previous_button.GetComponent<Animator>().SetTrigger("pressed");
				generalController.PreviousLine();
			}
			else
			{
				playClip.PlayCustom(thump);
				globalInput.pulsable = true;
			}
		}
	}

	public void TranslateIn()
	{
		if (deployed)
		{
			AllOut();
			selection = "translate";
			translate_button.GetComponent<SpriteRenderer>().color = selectedC;
			playClip.PlayCustom(selectedSound1);
		}
	}

	public void TranslateOut()
	{
		selection = string.Empty;
		if (deployed)
		{
			translate_button.GetComponent<SpriteRenderer>().color = unselectedC;
		}
	}

	public void TranslateClick()
	{
		if (!deployed)
		{
			return;
		}
		if (globalInput.pulsable)
		{
			translate_button.GetComponent<Animator>().SetTrigger("pressed");
			if (generalController.currentScene == "narrator")
			{
				generalController.TranslateNarrator();
			}
			else if (generalController.currentScene == "quiz")
			{
				quizScripter = GameObject.Find("QuizScripter");
				quizController = quizScripter.GetComponent<QuizController>();
				if (quizController.quizInput.currentSituation == "roulette")
				{
					playClip.PlayCustom(thump);
				}
				else
				{
					quizController.TranslateQuestion();
				}
			}
		}
		else
		{
			playClip.PlayCustom(thump);
		}
	}

	public void ExitIn()
	{
		if (deployed)
		{
			AllOut();
			selection = "exit";
			exit_button.GetComponent<SpriteRenderer>().color = selectedExitC;
			playClip.PlayCustom(selectedSound2);
		}
	}

	public void ExitOut()
	{
		selection = string.Empty;
		if (deployed)
		{
			exit_button.GetComponent<SpriteRenderer>().color = unselectedC;
		}
	}

	public void ExitClick()
	{
		if (deployed)
		{
			globalInput.pulsable = false;
			playClip.PlayCustom(incorrect);
			exit_button.GetComponent<Animator>().SetTrigger("pressed");
			StartCoroutine(LoadMainmenu());
		}
	}

	private IEnumerator LoadMainmenu()
	{
		generalController.PreloadMainmenu();
		yield return new WaitForSeconds(0.1f);
		ingame_menu.GetComponent<Animator>().SetBool("deployed", false);
		fadeMusic.Fade(NarratorAudioSource);
		yield return new WaitForSeconds(0.2f);
		transition.GetComponent<Animator>().SetTrigger("in");
		yield return new WaitForSeconds(1f);
		generalController.LoadMainmenu();
	}

	public void BackToNarrator()
	{
		if (generalController.mobile)
		{
			settingsButtonCanvasMobile.SetActive(false);
		}
		else
		{
			settingsButtonCanvas.SetActive(false);
		}
		int lineNumber = generalController.lineNumber;
		if (generalController.afterQuiz)
		{
			generalController.CallLoadScript();
			if (generalController.win)
			{
				generalController.LoadWinLines();
			}
			else
			{
				generalController.LoadLoseLines();
			}
		}
		else
		{
			generalController.CallLoadScript();
		}
		generalController.lineNumber = lineNumber - 1;
		scriptParser.backFromSettings = true;
		generalController.NextLine();
		scriptParser.backFromSettings = false;
		StartCoroutine(EnableNarrator());
	}

	private IEnumerator EnableNarrator()
	{
		yield return new WaitForSeconds(0.2f);
		buttonCanvas.SetActive(true);
		if (globalInput.inputMethod != "mouse")
		{
			inMenu = false;
			ingame_menu.GetComponent<Animator>().SetBool("deployed", false);
			menu_button.GetComponent<Animator>().SetTrigger("pressed");
			menu_button.GetComponent<Animator>().SetBool("deployed", false);
			deployed = false;
			Invoke("DeactivatePanels", 0.16f);
		}
		else
		{
			inMenu = true;
		}
		ingameMenuInput.denyInputActiveNextFrame = true;
		globalInput.pulsable = true;
	}

	public void BackToQuiz()
	{
		quizScripter = GameObject.Find("QuizScripter");
		quizController = quizScripter.GetComponent<QuizController>();
		quizController.ReloadQuestion();
		quizController.ShowHolders();
		quizController.alreadyTranslated = false;
		StartCoroutine(EnableQuiz());
	}

	private IEnumerator EnableQuiz()
	{
		yield return new WaitForSeconds(0.2f);
		if (globalInput.inputMethod != "mouse")
		{
			inMenu = false;
			ingame_menu.GetComponent<Animator>().SetBool("deployed", false);
			menu_button.GetComponent<Animator>().SetTrigger("pressed");
			menu_button.GetComponent<Animator>().SetBool("deployed", false);
			deployed = false;
			Invoke("DeactivatePanels", 0.16f);
		}
		else
		{
			inMenu = true;
		}
		ingameMenuInput.denyInputActiveNextFrame = true;
		globalInput.pulsable = true;
		buttonCanvas.SetActive(true);
	}

	public void PlayThump()
	{
		playClip.PlayCustom(thump);
	}
}
