using UnityEngine;

public class NarratorInput : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	private GlobalInput globalInput;

	private GameObject menu;

	private IngameMenuController ingameMenuController;

	private IngameMenuInput ingameMenuInput;

	public SettingsInput settingsInput;

	public GameObject screenPanel;

	public GameObject textHolder;

	private bool up;

	private bool left;

	private bool right;

	private bool enter;

	private bool back;

	private bool esc;

	private bool start;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		globalInput = globalScripter.GetComponent<GlobalInput>();
		menu = GameObject.Find("IngameMenu");
		ingameMenuController = menu.GetComponent<IngameMenuController>();
		ingameMenuInput = menu.GetComponent<IngameMenuInput>();
		settingsInput = base.gameObject.GetComponent<SettingsInput>();
	}

	private void Update()
	{
		if (!(generalController.currentScene != "narrator") && !ingameMenuInput.menuInputActive && !settingsInput.inSettings)
		{
			up = globalInput.up;
			left = globalInput.left;
			right = globalInput.right;
			enter = globalInput.enter;
			back = globalInput.back;
			esc = globalInput.esc;
			start = globalInput.start;
			if (enter || right || left || up || esc || start || back)
			{
				ManageInput();
			}
			if (Input.GetKeyDown("t") && globalInput.pulsable)
			{
				generalController.TranslateNarrator();
			}
			else if (Input.GetKeyDown("h") && globalInput.pulsable)
			{
				ToggleTextHolder();
			}
		}
	}

	private void ManageInput()
	{
		if (!globalInput.pulsable)
		{
			return;
		}
		if (enter || right)
		{
			Click();
		}
		else if (left || back)
		{
			generalController.PreviousLine();
		}
		else if (up || esc || start)
		{
			if (ingameMenuController.inMenu)
			{
				ingameMenuController.MenuIn();
				return;
			}
			ingameMenuController.MenuIn();
			ingameMenuController.MenuClick();
		}
	}

	public void Click()
	{
		if (globalInput.pulsable)
		{
			if (!textHolder.GetComponent<Animator>().GetBool("visible"))
			{
				textHolder.GetComponent<Animator>().SetBool("visible", true);
				return;
			}
			screenPanel.SetActive(false);
			globalInput.pulsable = false;
			generalController.NextLine();
		}
	}

	private void ToggleTextHolder()
	{
		if (textHolder.GetComponent<Animator>().GetBool("visible"))
		{
			textHolder.GetComponent<Animator>().SetBool("visible", false);
		}
		else
		{
			textHolder.GetComponent<Animator>().SetBool("visible", true);
		}
	}
}
