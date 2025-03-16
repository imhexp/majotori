using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FinalResultsController : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	public GameObject death_frame;

	public AudioSource creditsAudioSource;

	public AudioSource deathsAudioSource;

	public GameObject deathsText;

	private string[] deaths;

	private int death_n;

	private int death_total;

	private float exp = 2f;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		string text = generalController.deaths;
		deathsText.GetComponent<Text>().text = "0";
		deaths = text.Split('_');
	}

	public void FirstDeath()
	{
		if (deaths.Length == 0 || (deaths.Length == 1 && deaths[0] == string.Empty))
		{
			base.gameObject.GetComponent<Animator>().SetBool("death", false);
			return;
		}
		while (deaths.Length > death_n && deaths[death_n] == string.Empty)
		{
			death_n++;
		}
		if (deaths.Length > death_n)
		{
			StartCoroutine(PauseNoClip1());
			death_total++;
			death_frame.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("death_frames/" + deaths[death_n]);
			base.gameObject.GetComponent<Animator>().SetBool("death", true);
		}
		else
		{
			base.gameObject.GetComponent<Animator>().SetBool("death", false);
		}
		death_n++;
	}

	private IEnumerator PauseNoClip1()
	{
		creditsAudioSource.volume /= 2f;
		yield return new WaitForSeconds(0.05f);
		creditsAudioSource.volume /= 2f;
		yield return new WaitForSeconds(0.05f);
		creditsAudioSource.volume /= 2f;
		yield return new WaitForSeconds(0.05f);
		if (creditsAudioSource.volume > 0.0001f)
		{
			creditsAudioSource.volume = 0.0001f;
		}
		yield return new WaitForSeconds(0.05f);
		creditsAudioSource.Pause();
		yield return new WaitForSeconds(0.1f);
		deathsAudioSource.Play();
	}

	private IEnumerator PauseNoClip2()
	{
		deathsAudioSource.volume = creditsAudioSource.volume / 2f;
		yield return new WaitForSeconds(0.05f);
		deathsAudioSource.volume = creditsAudioSource.volume / 2f;
		yield return new WaitForSeconds(0.05f);
		deathsAudioSource.volume = creditsAudioSource.volume / 2f;
		yield return new WaitForSeconds(0.05f);
		if (deathsAudioSource.volume > 0.0001f)
		{
			deathsAudioSource.volume = 0.0001f;
		}
		yield return new WaitForSeconds(0.05f);
		deathsAudioSource.Pause();
		creditsAudioSource.volume = Mathf.Pow((float)generalController.musicVol / 100f, exp);
		yield return new WaitForSeconds(0.1f);
		if (!creditsAudioSource.isPlaying)
		{
			creditsAudioSource.Play();
		}
	}

	public void NextDeath()
	{
		while (deaths.Length > death_n && deaths[death_n] == string.Empty)
		{
			death_n++;
		}
		if (deaths.Length > death_n)
		{
			death_total++;
			death_frame.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("death_frames/" + deaths[death_n]);
			base.gameObject.GetComponent<Animator>().SetBool("death", true);
		}
		else
		{
			death_frame.GetComponent<SpriteRenderer>().sprite = null;
			deathsText.GetComponent<Text>().text = string.Empty + death_total;
			base.gameObject.GetComponent<Animator>().SetBool("death", false);
			StartCoroutine(PauseNoClip2());
		}
		death_n++;
	}

	public void PreloadMainmenu()
	{
		generalController.PreloadMainmenu();
	}

	public void LoadMainmenu()
	{
		generalController.LoadMainmenu();
	}
}
