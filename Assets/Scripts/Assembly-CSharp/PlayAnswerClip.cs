using UnityEngine;

public class PlayAnswerClip : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	private AudioSource AS1;

	private AudioSource AS2;

	private AudioSource AS3;

	private AudioSource AS4;

	public AudioClip clip1;

	public AudioClip clip2;

	public AudioClip clip3;

	public AudioClip clip4;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
	}

	public void PlayA()
	{
		AS1 = base.gameObject.AddComponent<AudioSource>();
		AS1.clip = clip1;
		AS1.volume = (float)generalController.soundVol / 100f;
		AS1.Play();
		Invoke("DeleteASA", clip1.length);
	}

	public void PlayB()
	{
		AS2 = base.gameObject.AddComponent<AudioSource>();
		AS2.clip = clip2;
		AS2.volume = (float)generalController.soundVol / 100f;
		AS2.Play();
		Invoke("DeleteASB", clip2.length);
	}

	public void PlayC()
	{
		AS3 = base.gameObject.AddComponent<AudioSource>();
		AS3.clip = clip3;
		AS3.volume = (float)generalController.soundVol / 100f;
		AS3.Play();
		Invoke("DeleteASC", clip3.length);
	}

	public void PlayD()
	{
		AS4 = base.gameObject.AddComponent<AudioSource>();
		AS4.clip = clip4;
		AS4.volume = (float)generalController.soundVol / 100f;
		AS4.Play();
		Invoke("DeleteASD", clip4.length);
	}

	private void DeleteASA()
	{
		Object.Destroy(AS1);
	}

	private void DeleteASB()
	{
		Object.Destroy(AS2);
	}

	private void DeleteASC()
	{
		Object.Destroy(AS3);
	}

	private void DeleteASD()
	{
		Object.Destroy(AS4);
	}
}
