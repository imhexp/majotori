using UnityEngine;

public class PlayClip : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	public AudioClip clip;

	public AudioClip clipAlt;

	private AudioSource audioSource1;

	private AudioSource audioSource2;

	private AudioSource audioSource3;

	private AudioSource audioSource4;

	private AudioSource audioSource5;

	private AudioSource audioSource6;

	private AudioSource audioSource7;

	private AudioSource audioSource8;

	private float exp = 2f;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
	}

	public void Play()
	{
		CreateSource(clip);
	}

	public void PlayAlt()
	{
		CreateSource(clipAlt);
	}

	public void PlayCustom(AudioClip customClip)
	{
		CreateSource(customClip);
	}

	private void CreateSource(AudioClip theclip)
	{
		if (audioSource1 == null)
		{
			audioSource1 = base.gameObject.AddComponent<AudioSource>();
			audioSource1.clip = theclip;
			audioSource1.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource1.Play();
			Invoke("DeleteAS1", theclip.length);
		}
		else if (audioSource2 == null)
		{
			audioSource2 = base.gameObject.AddComponent<AudioSource>();
			audioSource2.clip = theclip;
			audioSource2.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource2.Play();
			Invoke("DeleteAS2", theclip.length);
		}
		else if (audioSource3 == null)
		{
			audioSource3 = base.gameObject.AddComponent<AudioSource>();
			audioSource3.clip = theclip;
			audioSource3.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource3.Play();
			Invoke("DeleteAS3", theclip.length);
		}
		else if (audioSource4 == null)
		{
			audioSource4 = base.gameObject.AddComponent<AudioSource>();
			audioSource4.clip = theclip;
			audioSource4.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource4.Play();
			Invoke("DeleteAS4", theclip.length);
		}
		else if (audioSource5 == null)
		{
			audioSource5 = base.gameObject.AddComponent<AudioSource>();
			audioSource5.clip = theclip;
			audioSource5.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource5.Play();
			Invoke("DeleteAS5", theclip.length);
		}
		else if (audioSource6 == null)
		{
			audioSource6 = base.gameObject.AddComponent<AudioSource>();
			audioSource6.clip = theclip;
			audioSource6.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource6.Play();
			Invoke("DeleteAS6", theclip.length);
		}
		else if (audioSource7 == null)
		{
			audioSource7 = base.gameObject.AddComponent<AudioSource>();
			audioSource7.clip = theclip;
			audioSource7.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource7.Play();
			Invoke("DeleteAS7", theclip.length);
		}
		else if (audioSource8 == null)
		{
			audioSource8 = base.gameObject.AddComponent<AudioSource>();
			audioSource8.clip = theclip;
			audioSource8.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource8.Play();
			Invoke("DeleteAS8", theclip.length);
		}
	}

	private void DeleteAS1()
	{
		Object.Destroy(audioSource1);
	}

	private void DeleteAS2()
	{
		Object.Destroy(audioSource2);
	}

	private void DeleteAS3()
	{
		Object.Destroy(audioSource3);
	}

	private void DeleteAS4()
	{
		Object.Destroy(audioSource4);
	}

	private void DeleteAS5()
	{
		Object.Destroy(audioSource5);
	}

	private void DeleteAS6()
	{
		Object.Destroy(audioSource6);
	}

	private void DeleteAS7()
	{
		Object.Destroy(audioSource7);
	}

	private void DeleteAS8()
	{
		Object.Destroy(audioSource8);
	}
}
