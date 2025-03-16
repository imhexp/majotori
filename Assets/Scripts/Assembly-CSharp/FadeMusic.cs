using UnityEngine;

public class FadeMusic : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	private AudioSource AS;

	private AudioSource AS2;

	private bool fading;

	private bool unfading;

	private bool pause;

	private bool lastFrame;

	private float exp = 2f;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
	}

	private void Update()
	{
		if (fading)
		{
			if (AS == null)
			{
				return;
			}
			AS.volume -= Time.deltaTime * 2f;
			if (AS.volume <= 0f && !lastFrame)
			{
				AS.volume = 0.0001f;
				lastFrame = true;
			}
			else if (lastFrame)
			{
				if (pause)
				{
					AS.Pause();
				}
				else
				{
					AS.Stop();
				}
				fading = false;
				lastFrame = false;
				AS = null;
			}
		}
		if (unfading && !(AS2 == null))
		{
			if ((float)generalController.musicVol / 100f != 0f)
			{
				AS2.volume += Time.deltaTime * 2f;
			}
			if (AS2.volume >= Mathf.Pow((float)generalController.musicVol / 100f, exp))
			{
				AS2.volume = Mathf.Pow((float)generalController.musicVol / 100f, exp);
				unfading = false;
				AS = null;
			}
		}
	}

	public void Fade(AudioSource audioSource)
	{
		AS = audioSource;
		fading = true;
		pause = false;
	}

	public void FadeWithPause(AudioSource audioSource)
	{
		AS = audioSource;
		fading = true;
		pause = true;
	}

	public void Unfade(AudioSource audioSource)
	{
		AS2 = audioSource;
		AS2.volume = 0f;
		AS2.Play();
		unfading = true;
	}
}
