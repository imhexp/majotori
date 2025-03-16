using UnityEngine;

public class NarratorController : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	public GameObject transition;

	public GameObject narratorPanel;

	public GameObject steamAchievements;

	private void Start()
	{
		transition.GetComponent<Animator>().SetBool("visible", true);
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		if (generalController.steam)
		{
			Object.Instantiate(steamAchievements);
		}
		generalController.NextLine();
		Invoke("HideTransition", 2f);
	}

	private void HideTransition()
	{
		transition.GetComponent<Animator>().SetBool("visible", false);
	}

	public void DisableNarrator()
	{
		narratorPanel.SetActive(false);
	}

	public void EnableNarrator()
	{
		narratorPanel.SetActive(true);
	}
}
