using UnityEngine;

public class CreditsInput : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	private GlobalInput globalInput;

	public GameObject mainmenuScripter;

	private MainmenuInput mainmenuInput;

	private bool enter;

	private bool back;

	private bool esc;

	private bool start;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		globalInput = globalScripter.GetComponent<GlobalInput>();
		mainmenuInput = mainmenuScripter.GetComponent<MainmenuInput>();
	}

	private void Update()
	{
		if (!(generalController.currentScene != "credits"))
		{
			enter = globalInput.enter;
			back = globalInput.back;
			esc = globalInput.esc;
			start = globalInput.start;
			if ((enter || back || esc || start) && globalInput.pulsable)
			{
				mainmenuInput.HideCredits();
			}
		}
	}
}
