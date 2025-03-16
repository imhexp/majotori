using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharaselectorInput : MonoBehaviour
{
	public GameObject lPanel;

	public GameObject mPanel;

	public GameObject rPanel;

	public GameObject exitPanel;

	public GameObject characard_selection;

	public GameObject gameSaved;

	public GameObject gameSavedText;

	public GameObject tipText;

	public GameObject wins;

	public GameObject fails;

	private int selection;

	public string charaName;

	private GameObject globalScripter;

	private GeneralController generalController;

	private GlobalInput globalInput;

	public GameObject charaselectorScripter;

	private CharaselectorController charaselectorController;

	public GameObject transition;

	private bool up;

	private bool down;

	private bool left;

	private bool right;

	private bool enter;

	private bool back;

	private bool esc;

	private bool start;

	private bool selectionMade;

	public AudioClip thump;

	public AudioClip whoosh7;

	public AudioClip incorrect;

	public GameObject exitButtonSprite;

	private Color unselectedColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 130);

	private Color selectedColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	public Sprite exitPressed;

	private AudioSource NarratorAudioSource;

	private AudioSource CharaselectorAudioSource;

	private FadeMusic fadeMusic;

	public AudioClip mainTheme;

	public AudioClip oliverTheme;

	public AudioClip tsubasaTheme;

	private float timer;

	private Vector3 cursorPosition;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		globalInput = globalScripter.GetComponent<GlobalInput>();
		charaselectorController = charaselectorScripter.GetComponent<CharaselectorController>();
		fadeMusic = globalScripter.GetComponent<FadeMusic>();
		GameObject gameObject = GameObject.Find("NarratorAudioSource");
		NarratorAudioSource = gameObject.GetComponent<AudioSource>();
		gameObject = GameObject.Find("CharaselectorAudioSource");
		CharaselectorAudioSource = gameObject.GetComponent<AudioSource>();
		generalController.currentScene = "charaselector";
		cursorPosition = Input.mousePosition;
		if (generalController.progressSaved && !generalController.demo)
		{
			if (generalController.lang == "en")
			{
				gameSavedText.GetComponent<Text>().text = "Game saved";
				tipText.GetComponent<Text>().text = "You can customize the question categories from the settings menu.";
			}
			else
			{
				gameSavedText.GetComponent<Text>().text = "Partida guardada";
				tipText.GetComponent<Text>().text = "Puedes personalizar las categorías de las preguntas desde el menú de ajustes.";
			}
			wins.GetComponent<Text>().text = string.Empty + generalController.wins;
			fails.GetComponent<Text>().text = string.Empty + generalController.fails;
			gameSaved.GetComponent<Animator>().SetTrigger("saved");
			if (generalController.file == "ava" && generalController.route == "a")
			{
				gameSaved.GetComponent<Animator>().SetBool("tip", true);
			}
		}
		if (generalController.file == "ava" && generalController.route == "a")
		{
			Invoke("ActivePanels", 4f);
		}
		else
		{
			Invoke("ActivePanels", 1.55f);
		}
	}

	private void Update()
	{
		if (!(generalController.currentScene != "charaselector"))
		{
			up = globalInput.up;
			down = globalInput.down;
			left = globalInput.left;
			right = globalInput.right;
			enter = globalInput.enter;
			back = globalInput.back;
			esc = globalInput.esc;
			start = globalInput.start;
			if (timer <= 2f)
			{
				timer += Time.deltaTime;
			}
			if ((left || right || up || down || start || back || esc) && globalInput.pulsable && !selectionMade)
			{
				ManageInput();
				globalInput.pulsable = false;
			}
			else if (enter && globalInput.pulsable && !selectionMade)
			{
				ManageInput();
				globalInput.pulsable = false;
			}
			else if (Input.GetKeyDown("o") && globalInput.pulsable && !selectionMade)
			{
				charaselectorController.Shuffle();
			}
			else if (!left && !right && !enter && !selectionMade && timer > 2f)
			{
				globalInput.pulsable = true;
			}
		}
	}

	private void ActivePanels()
	{
		lPanel.SetActive(true);
		mPanel.SetActive(true);
		rPanel.SetActive(true);
		exitPanel.SetActive(true);
		globalInput.pulsable = true;
		if (globalInput.inputMethod != "mouse")
		{
			if (charaselectorController.cards == 3 || charaselectorController.cards == 1)
			{
				MIn();
			}
			else
			{
				LIn();
			}
		}
	}

	private void ManageInput()
	{
		if (!globalInput.pulsable || selectionMade)
		{
			return;
		}
		if (left)
		{
			if (charaselectorController.cards == 3)
			{
				if (selection == 3)
				{
					Out();
					MIn();
				}
				else if (selection == 2)
				{
					Out();
					LIn();
				}
				else if (selection == 0)
				{
					Out();
					MIn();
				}
				else if (selection == 4)
				{
					ExitOut();
					Out();
					MIn();
				}
				else
				{
					base.gameObject.GetComponent<PlayClip>().PlayCustom(thump);
				}
			}
			else if (charaselectorController.cards == 2)
			{
				if (selection == 3)
				{
					Out();
					LIn();
				}
				else if (selection == 0)
				{
					Out();
					RIn();
				}
				else if (selection == 4)
				{
					ExitOut();
					Out();
					RIn();
				}
				else
				{
					base.gameObject.GetComponent<PlayClip>().PlayCustom(thump);
				}
			}
			else if (selection == 0)
			{
				ExitOut();
				Out();
				MIn();
			}
			else if (selection == 4)
			{
				ExitOut();
				Out();
				MIn();
			}
			else
			{
				base.gameObject.GetComponent<PlayClip>().PlayCustom(thump);
			}
		}
		else if (right)
		{
			if (charaselectorController.cards == 3)
			{
				if (selection == 1)
				{
					Out();
					MIn();
				}
				else if (selection == 2)
				{
					Out();
					RIn();
				}
				else if (selection == 0)
				{
					Out();
					MIn();
				}
				else if (selection == 4)
				{
					ExitOut();
					Out();
					MIn();
				}
				else
				{
					base.gameObject.GetComponent<PlayClip>().PlayCustom(thump);
				}
			}
			else if (charaselectorController.cards == 2)
			{
				if (selection == 1)
				{
					Out();
					RIn();
				}
				else if (selection == 0)
				{
					Out();
					LIn();
				}
				else if (selection == 4)
				{
					ExitOut();
					Out();
					RIn();
				}
				else
				{
					base.gameObject.GetComponent<PlayClip>().PlayCustom(thump);
				}
			}
			else if (selection == 0)
			{
				ExitOut();
				Out();
				MIn();
			}
			else if (selection == 4)
			{
				ExitOut();
				Out();
				MIn();
			}
			else
			{
				base.gameObject.GetComponent<PlayClip>().PlayCustom(thump);
			}
		}
		else if (enter)
		{
			if (selection == 1)
			{
				selectionMade = true;
				LClick();
			}
			else if (selection == 2)
			{
				selectionMade = true;
				MClick();
			}
			else if (selection == 3)
			{
				selectionMade = true;
				RClick();
			}
			else if (selection == 4)
			{
				selectionMade = true;
				ExitClick();
			}
			else
			{
				base.gameObject.GetComponent<PlayClip>().PlayCustom(thump);
			}
		}
		else if (up)
		{
			if (selection == 4)
			{
				base.gameObject.GetComponent<PlayClip>().PlayCustom(thump);
				return;
			}
			Out();
			ExitIn();
		}
		else if (down)
		{
			if (selection == 4)
			{
				ExitOut();
				Out();
				if (charaselectorController.cards == 1)
				{
					MIn();
				}
				else
				{
					RIn();
				}
			}
			else if (selection == 0)
			{
				MIn();
			}
			else
			{
				base.gameObject.GetComponent<PlayClip>().PlayCustom(thump);
			}
		}
		else if (esc || back || start)
		{
			if (selection == 4)
			{
				ExitClick();
				return;
			}
			Out();
			ExitIn();
		}
	}

	public void LIn()
	{
		selection = 1;
		characard_selection.GetComponent<Animator>().SetInteger("selection", selection);
	}

	public void LInMouse()
	{
		if (!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition))
		{
			selection = 1;
			characard_selection.GetComponent<Animator>().SetInteger("selection", selection);
		}
	}

	public void MIn()
	{
		selection = 2;
		characard_selection.GetComponent<Animator>().SetInteger("selection", selection);
	}

	public void MInMouse()
	{
		if (!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition))
		{
			selection = 2;
			characard_selection.GetComponent<Animator>().SetInteger("selection", selection);
		}
	}

	public void RIn()
	{
		selection = 3;
		characard_selection.GetComponent<Animator>().SetInteger("selection", selection);
	}

	public void RInMouse()
	{
		if (!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition))
		{
			selection = 3;
			characard_selection.GetComponent<Animator>().SetInteger("selection", selection);
		}
	}

	public void Out()
	{
		SelectionOut();
	}

	private void SelectionOut()
	{
		characard_selection.GetComponent<Animator>().SetInteger("selection", 0);
		selection = 0;
		ExitOut();
	}

	public void LClick()
	{
		if (selection != 1)
		{
			selection = 1;
			characard_selection.GetComponent<Animator>().SetInteger("selection", selection);
		}
		lPanel.SetActive(false);
		mPanel.SetActive(false);
		rPanel.SetActive(false);
		exitPanel.SetActive(false);
		generalController.file = charaselectorController.file1;
		generalController.route = charaselectorController.route1;
		LoadNarrator();
	}

	public void MClick()
	{
		if (selection != 2)
		{
			selection = 2;
			characard_selection.GetComponent<Animator>().SetInteger("selection", selection);
		}
		lPanel.SetActive(false);
		mPanel.SetActive(false);
		rPanel.SetActive(false);
		exitPanel.SetActive(false);
		generalController.file = charaselectorController.file2;
		generalController.route = charaselectorController.route2;
		LoadNarrator();
	}

	public void RClick()
	{
		if (selection != 3)
		{
			selection = 3;
			characard_selection.GetComponent<Animator>().SetInteger("selection", selection);
		}
		lPanel.SetActive(false);
		mPanel.SetActive(false);
		rPanel.SetActive(false);
		exitPanel.SetActive(false);
		generalController.file = charaselectorController.file3;
		generalController.route = charaselectorController.route3;
		LoadNarrator();
	}

	public void ExitIn()
	{
		Out();
		selection = 4;
		if (exitButtonSprite != null)
		{
			exitButtonSprite.GetComponent<SpriteRenderer>().color = selectedColor;
		}
		base.gameObject.GetComponent<PlayClip>().PlayCustom(whoosh7);
	}

	public void ExitOut()
	{
		selection = 0;
		if (exitButtonSprite != null)
		{
			exitButtonSprite.GetComponent<SpriteRenderer>().color = unselectedColor;
		}
	}

	public void ExitClick()
	{
		base.gameObject.GetComponent<PlayClip>().PlayCustom(incorrect);
		globalInput.pulsable = false;
		if (exitButtonSprite != null)
		{
			exitButtonSprite.GetComponent<SpriteRenderer>().sprite = exitPressed;
		}
		StartCoroutine(LoadMainmenu());
	}

	private IEnumerator LoadMainmenu()
	{
		generalController.PreloadMainmenu();
		yield return new WaitForSeconds(0.1f);
		fadeMusic.Fade(NarratorAudioSource);
		yield return new WaitForSeconds(0.2f);
		transition.GetComponent<Animator>().SetBool("visible", false);
		transition.GetComponent<Animator>().SetBool("visibleOver", true);
		transition.GetComponent<Animator>().SetTrigger("in");
		fadeMusic.Fade(CharaselectorAudioSource);
		yield return new WaitForSeconds(1f);
		generalController.LoadMainmenu();
	}

	private void LoadNarrator()
	{
		transition.GetComponent<Animator>().SetBool("visible", false);
		transition.GetComponent<Animator>().SetTrigger("in");
		generalController.CallLoadScript();
		fadeMusic.Fade(CharaselectorAudioSource);
		Invoke("UnfadeNarrator", 0.75f);
		Invoke("LoadNarratorScene", 1f);
	}

	private void UnfadeNarrator()
	{
		if (generalController.file == "oliver")
		{
			NarratorAudioSource.clip = oliverTheme;
		}
		else if (generalController.file == "tsubasa")
		{
			NarratorAudioSource.clip = tsubasaTheme;
		}
		else if (NarratorAudioSource.clip != mainTheme)
		{
			NarratorAudioSource.clip = mainTheme;
		}
		fadeMusic.Unfade(NarratorAudioSource);
	}

	private void LoadNarratorScene()
	{
		SceneManager.LoadScene("narrator");
		generalController.currentScene = "narrator";
		generalController.isFristRoute = false;
	}
}
