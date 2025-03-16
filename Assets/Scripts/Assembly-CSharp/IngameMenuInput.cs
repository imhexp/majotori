using UnityEngine;

public class IngameMenuInput : MonoBehaviour
{
	private GameObject globalScripter;

	private GlobalInput globalInput;

	private IngameMenuController ingameMenuController;

	private bool up;

	private bool down;

	private bool left;

	private bool right;

	private bool enter;

	private bool back;

	private bool esc;

	private bool start;

	public bool menuInputActive;

	public bool denyInputActiveNextFrame;

	private bool denyInputActiveNextFrame2;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		globalInput = globalScripter.GetComponent<GlobalInput>();
		ingameMenuController = base.gameObject.GetComponent<IngameMenuController>();
	}

	private void Update()
	{
		if (denyInputActiveNextFrame)
		{
			if (denyInputActiveNextFrame2)
			{
				denyInputActiveNextFrame = false;
				denyInputActiveNextFrame2 = false;
				menuInputActive = false;
			}
			else
			{
				denyInputActiveNextFrame2 = true;
			}
		}
		if (ingameMenuController.selection == string.Empty && menuInputActive && !denyInputActiveNextFrame)
		{
			menuInputActive = false;
		}
		else
		{
			if (!(ingameMenuController.selection != string.Empty))
			{
				return;
			}
			menuInputActive = true;
		}
		up = globalInput.up;
		down = globalInput.down;
		left = globalInput.left;
		right = globalInput.right;
		enter = globalInput.enter;
		back = globalInput.back;
		esc = globalInput.esc;
		start = globalInput.start;
		if (left || right || up || down || enter || back || esc || start)
		{
			ManageInput();
		}
	}

	private void ManageInput()
	{
		if (left)
		{
			if (ingameMenuController.selection == "menu")
			{
				ingameMenuController.SettingsIn();
			}
			else if (ingameMenuController.selection == "settings")
			{
				ingameMenuController.SkipIn();
			}
			else if (ingameMenuController.selection == "skip")
			{
				ingameMenuController.PreviousIn();
			}
			else if (ingameMenuController.selection == "previous")
			{
				ingameMenuController.TranslateIn();
			}
			else if (ingameMenuController.selection == "translate")
			{
				ingameMenuController.ExitIn();
			}
			else if (ingameMenuController.selection == "exit")
			{
				ingameMenuController.PlayThump();
			}
		}
		else if (right)
		{
			if (ingameMenuController.selection == "menu")
			{
				ingameMenuController.PlayThump();
			}
			else if (ingameMenuController.selection == "settings")
			{
				ingameMenuController.MenuIn();
			}
			else if (ingameMenuController.selection == "skip")
			{
				ingameMenuController.SettingsIn();
			}
			else if (ingameMenuController.selection == "previous")
			{
				ingameMenuController.SkipIn();
			}
			else if (ingameMenuController.selection == "translate")
			{
				ingameMenuController.PreviousIn();
			}
			else if (ingameMenuController.selection == "exit")
			{
				ingameMenuController.TranslateIn();
			}
		}
		else if (enter)
		{
			if (ingameMenuController.selection == "menu")
			{
				ingameMenuController.MenuClick();
				ingameMenuController.MenuOut();
				denyInputActiveNextFrame = true;
			}
			else if (ingameMenuController.selection == "settings")
			{
				ingameMenuController.SettingsClick();
			}
			else if (ingameMenuController.selection == "skip")
			{
				ingameMenuController.SkipClick();
			}
			else if (ingameMenuController.selection == "previous")
			{
				ingameMenuController.PreviousClick();
			}
			else if (ingameMenuController.selection == "translate")
			{
				ingameMenuController.TranslateClick();
			}
			else if (ingameMenuController.selection == "exit")
			{
				ingameMenuController.ExitClick();
			}
		}
		else if (down || esc || back || start)
		{
			if (ingameMenuController.inMenu)
			{
				ingameMenuController.MenuClick();
				ingameMenuController.MenuOut();
				denyInputActiveNextFrame = true;
			}
			else
			{
				ingameMenuController.MenuClick();
			}
		}
		else if (up)
		{
			ingameMenuController.PlayThump();
		}
	}
}
