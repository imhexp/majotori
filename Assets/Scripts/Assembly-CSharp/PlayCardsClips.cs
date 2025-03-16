using UnityEngine;

public class PlayCardsClips : MonoBehaviour
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

	public AudioClip clipShuffle;

	public AudioClip clipRoulette;

	private AudioSource audioSource9;

	private AudioSource audioSource10;

	private AudioSource audioSource11;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
	}

	public void Play1()
	{
		audioSource1 = base.gameObject.AddComponent<AudioSource>();
		audioSource1.clip = clip1;
		audioSource1.volume = (float)generalController.soundVol / 100f;
		audioSource1.Play();
		Invoke("DeleteAS1", clip1.length);
	}

	public void Play2()
	{
		audioSource2 = base.gameObject.AddComponent<AudioSource>();
		audioSource2.clip = clip2;
		audioSource2.volume = (float)generalController.soundVol / 100f;
		audioSource2.Play();
		Invoke("DeleteAS2", clip2.length);
	}

	public void Play3()
	{
		audioSource3 = base.gameObject.AddComponent<AudioSource>();
		audioSource3.clip = clip3;
		audioSource3.volume = (float)generalController.soundVol / 100f;
		audioSource3.Play();
		Invoke("DeleteAS3", clip3.length);
	}

	public void Play4()
	{
		audioSource4 = base.gameObject.AddComponent<AudioSource>();
		audioSource4.clip = clip4;
		audioSource4.volume = (float)generalController.soundVol / 100f;
		audioSource4.Play();
		Invoke("DeleteAS4", clip4.length);
	}

	public void Play5()
	{
		audioSource5 = base.gameObject.AddComponent<AudioSource>();
		audioSource5.clip = clip5;
		audioSource5.volume = (float)generalController.soundVol / 100f;
		audioSource5.Play();
		Invoke("DeleteAS5", clip5.length);
	}

	public void Play6()
	{
		audioSource6 = base.gameObject.AddComponent<AudioSource>();
		audioSource6.clip = clip6;
		audioSource6.volume = (float)generalController.soundVol / 100f;
		audioSource6.Play();
		Invoke("DeleteAS6", clip6.length);
	}

	public void Play7()
	{
		audioSource7 = base.gameObject.AddComponent<AudioSource>();
		audioSource7.clip = clip7;
		audioSource7.volume = (float)generalController.soundVol / 100f;
		audioSource7.Play();
		Invoke("DeleteAS7", clip7.length);
	}

	public void Play8()
	{
		audioSource8 = base.gameObject.AddComponent<AudioSource>();
		audioSource8.clip = clip8;
		audioSource8.volume = (float)generalController.soundVol / 100f;
		audioSource8.Play();
		Invoke("DeleteAS8", clip8.length);
	}

	public void PlayShuffle()
	{
		audioSource9 = base.gameObject.AddComponent<AudioSource>();
		audioSource9.clip = clipShuffle;
		audioSource9.volume = (float)generalController.soundVol / 100f;
		audioSource9.Play();
		Invoke("DeleteAS9", clipShuffle.length);
	}

	public void PlayRouletteOdd()
	{
		audioSource10 = base.gameObject.AddComponent<AudioSource>();
		audioSource10.clip = clipRoulette;
		audioSource10.volume = (float)generalController.soundVol / 100f;
		audioSource10.Play();
		Invoke("DeleteAS10", clipRoulette.length);
	}

	public void PlayRouletteEven()
	{
		audioSource11 = base.gameObject.AddComponent<AudioSource>();
		audioSource11.clip = clipRoulette;
		audioSource11.volume = (float)generalController.soundVol / 100f;
		audioSource11.Play();
		Invoke("DeleteAS11", clipRoulette.length);
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

	private void DeleteAS9()
	{
		Object.Destroy(audioSource9);
	}

	private void DeleteAS10()
	{
		Object.Destroy(audioSource10);
	}

	private void DeleteAS11()
	{
		Object.Destroy(audioSource10);
	}
}
