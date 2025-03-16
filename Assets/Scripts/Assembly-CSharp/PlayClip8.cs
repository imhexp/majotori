using UnityEngine;

public class PlayClip8 : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	public AudioClip clip1;

	public AudioClip clip2;

	public AudioClip clip3;

	public AudioClip clip4;

	public AudioClip clip5;

	public AudioClip clip6;

	public AudioClip clip7;

	public AudioClip clip8;

	private AudioSource audioSource1;

	private AudioSource audioSource2;

	private AudioSource audioSource3;

	private AudioSource audioSource4;

	private AudioSource audioSource5;

	private AudioSource audioSource6;

	private AudioSource audioSource7;

	private AudioSource audioSource8;

	private float exp = 2f;

	private void Awake()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		if (globalScripter != null)
		{
			generalController = globalScripter.GetComponent<GeneralController>();
		}
	}

	private void CreateSource(AudioClip clip)
	{
		if (audioSource1 == null)
		{
			audioSource1 = base.gameObject.AddComponent<AudioSource>();
			audioSource1.clip = clip;
			audioSource1.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource1.Play();
			Invoke("DeleteAS1", clip.length);
		}
		else if (audioSource2 == null)
		{
			audioSource2 = base.gameObject.AddComponent<AudioSource>();
			audioSource2.clip = clip;
			audioSource2.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource2.Play();
			Invoke("DeleteAS2", clip.length);
		}
		else if (audioSource3 == null)
		{
			audioSource3 = base.gameObject.AddComponent<AudioSource>();
			audioSource3.clip = clip;
			audioSource3.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource3.Play();
			Invoke("DeleteAS3", clip.length);
		}
		else if (audioSource4 == null)
		{
			audioSource4 = base.gameObject.AddComponent<AudioSource>();
			audioSource4.clip = clip;
			audioSource4.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource4.Play();
			Invoke("DeleteAS4", clip.length);
		}
		else if (audioSource5 == null)
		{
			audioSource5 = base.gameObject.AddComponent<AudioSource>();
			audioSource5.clip = clip;
			audioSource5.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource5.Play();
			Invoke("DeleteAS5", clip.length);
		}
		else if (audioSource6 == null)
		{
			audioSource6 = base.gameObject.AddComponent<AudioSource>();
			audioSource6.clip = clip;
			audioSource6.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource6.Play();
			Invoke("DeleteAS6", clip.length);
		}
		else if (audioSource7 == null)
		{
			audioSource7 = base.gameObject.AddComponent<AudioSource>();
			audioSource7.clip = clip;
			audioSource7.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource7.Play();
			Invoke("DeleteAS7", clip.length);
		}
		else if (audioSource8 == null)
		{
			audioSource8 = base.gameObject.AddComponent<AudioSource>();
			audioSource8.clip = clip;
			audioSource8.volume = Mathf.Pow((float)generalController.soundVol / 100f, exp);
			audioSource8.Play();
			Invoke("DeleteAS8", clip.length);
		}
	}

	public void Play1()
	{
		CreateSource(clip1);
	}

	public void Play2()
	{
		CreateSource(clip2);
	}

	public void Play3()
	{
		CreateSource(clip3);
	}

	public void Play4()
	{
		CreateSource(clip5);
	}

	public void Play5()
	{
		CreateSource(clip5);
	}

	public void Play6()
	{
		CreateSource(clip6);
	}

	public void Play7()
	{
		CreateSource(clip7);
	}

	public void Play8()
	{
		CreateSource(clip8);
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
