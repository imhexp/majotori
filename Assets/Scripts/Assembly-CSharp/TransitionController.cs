using UnityEngine;

public class TransitionController : MonoBehaviour
{
	public GameObject narratorScripter;

	private ScriptParser scriptParser;

	private AsyncOperation async;

	public void visibleFalse()
	{
		base.gameObject.GetComponent<Animator>().SetBool("visible", false);
		base.gameObject.GetComponent<Animator>().SetBool("visibleOver", false);
	}

	public void CallLoadCharaselector()
	{
		narratorScripter = GameObject.Find("NarratorScripter");
		scriptParser = narratorScripter.GetComponent<ScriptParser>();
		scriptParser.LoadCharaselector();
	}
}
