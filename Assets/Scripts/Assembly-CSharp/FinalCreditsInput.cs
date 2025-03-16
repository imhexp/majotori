using System.Collections;
using UnityEngine;

public class FinalCreditsInput : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	private GlobalInput globalInput;

	private PlayClip playClip;

	public GameObject exitButton;

	public GameObject exitButtonPanel;

	public GameObject transition;

	public GameObject FinalCreditsTextCanvas;

	public GameObject FinalCreditsResultsTextCanvas;

	private bool up;

	private bool down;

	private bool left;

	private bool right;

	private bool enter;

	private bool back;

	private bool esc;

	private bool start;

	private Color unselectedColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 50);

	private Color selectedColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	private Color invisibleColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0);

	private FadeMusic fadeMusic;

	private AudioSource FinalCreditsAudioSource;

	public AudioClip whoosh1;

	public AudioClip whoosh2;

	public AudioClip incorrect;

	private bool exitSelected;

	private float timer;

	private bool pulsableActivated;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		globalInput = globalScripter.GetComponent<GlobalInput>();
		fadeMusic = globalScripter.GetComponent<FadeMusic>();
		playClip = base.gameObject.GetComponent<PlayClip>();
		GameObject gameObject = GameObject.Find("CreditsAudioSource");
		FinalCreditsAudioSource = gameObject.GetComponent<AudioSource>();
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer >= 1f && !pulsableActivated)
		{
			globalInput.pulsable = true;
			pulsableActivated = true;
		}
		if (Cursor.visible && !exitSelected && timer >= 1f)
		{
			exitButton.GetComponent<SpriteRenderer>().color = unselectedColor;
		}
		else if (!exitSelected)
		{
			exitButton.GetComponent<SpriteRenderer>().color = invisibleColor;
		}
		up = globalInput.up;
		down = globalInput.down;
		left = globalInput.left;
		right = globalInput.right;
		enter = globalInput.enter;
		back = globalInput.back;
		esc = globalInput.esc;
		start = globalInput.start;
		if (!globalInput.pulsable)
		{
			return;
		}
		if (!exitSelected)
		{
			if (esc || start || enter || back || up)
			{
				ExitIn();
			}
		}
		else if (exitSelected)
		{
			if (enter)
			{
				ExitClick();
			}
			else if (up || down || left || right || back || esc || enter)
			{
				ExitOut();
			}
		}
	}

	public void ExitIn()
	{
		playClip.PlayCustom(whoosh2);
		exitSelected = true;
		exitButton.GetComponent<SpriteRenderer>().color = selectedColor;
	}

	public void ExitOut()
	{
		playClip.PlayCustom(whoosh1);
		exitSelected = false;
		exitButton.GetComponent<SpriteRenderer>().color = invisibleColor;
	}

	public void ExitClick()
	{
		playClip.PlayCustom(incorrect);
		globalInput.pulsable = false;
		exitButtonPanel.SetActive(false);
		StartCoroutine(LoadMainmenu());
	}

	private IEnumerator LoadMainmenu()
	{
		generalController.PreloadMainmenu();
		yield return new WaitForSeconds(0.1f);
		fadeMusic.Fade(FinalCreditsAudioSource);
		yield return new WaitForSeconds(0.2f);
		FinalCreditsTextCanvas.SetActive(false);
		FinalCreditsResultsTextCanvas.SetActive(false);
		transition.GetComponent<Animator>().SetBool("visible", false);
		transition.GetComponent<Animator>().SetBool("visibleOver", true);
		transition.GetComponent<Animator>().SetTrigger("in");
		yield return new WaitForSeconds(1f);
		generalController.LoadMainmenu();
	}
}
