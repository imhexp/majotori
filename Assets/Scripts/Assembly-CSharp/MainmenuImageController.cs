using UnityEngine;

public class MainmenuImageController : MonoBehaviour
{
	private GameObject audioSource;

	private AudioSource AS;

	public GameObject lariat;

	public GameObject oliver;

	public GameObject kony;

	public GameObject ava;

	public GameObject fatima;

	public GameObject gloria;

	public GameObject hector_ingrid;

	public GameObject juliet_romeo;

	public GameObject nikola;

	public GameObject mariano;

	public GameObject paca;

	public GameObject queralt;

	public GameObject sebastian;

	public GameObject tsubasa;

	public GameObject umberto;

	public GameObject viviana;

	public GameObject woolie_xiang;

	public GameObject yvette_zelotes;

	public GameObject bcde;

	private GameObject currentImage;

	private float timer;

	private int lastN;

	private void Start()
	{
		audioSource = GameObject.Find("MainmenuAudioSource");
		AS = audioSource.GetComponent<AudioSource>();
		NextImage();
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if ((double)AS.timeSamples % ((double)AS.clip.frequency * 2.125) < 4000.0 && timer >= 2f)
		{
			timer = 0f;
			NextImage();
		}
	}

	private void NextImage()
	{
		if ((bool)currentImage)
		{
			Object.Destroy(currentImage);
		}
		int num;
		for (num = Random.Range(1, 20); num == lastN; num = Random.Range(1, 20))
		{
		}
		lastN = num;
		switch (num)
		{
		case 1:
			currentImage = Object.Instantiate(lariat);
			break;
		case 2:
			currentImage = Object.Instantiate(oliver);
			break;
		case 3:
			currentImage = Object.Instantiate(kony);
			break;
		case 4:
			currentImage = Object.Instantiate(ava);
			break;
		case 5:
			currentImage = Object.Instantiate(fatima);
			break;
		case 6:
			currentImage = Object.Instantiate(gloria);
			break;
		case 7:
			currentImage = Object.Instantiate(hector_ingrid);
			break;
		case 8:
			currentImage = Object.Instantiate(juliet_romeo);
			break;
		case 9:
			currentImage = Object.Instantiate(nikola);
			break;
		case 10:
			currentImage = Object.Instantiate(mariano);
			break;
		case 11:
			currentImage = Object.Instantiate(paca);
			break;
		case 12:
			currentImage = Object.Instantiate(queralt);
			break;
		case 13:
			currentImage = Object.Instantiate(sebastian);
			break;
		case 14:
			currentImage = Object.Instantiate(tsubasa);
			break;
		case 15:
			currentImage = Object.Instantiate(umberto);
			break;
		case 16:
			currentImage = Object.Instantiate(viviana);
			break;
		case 17:
			currentImage = Object.Instantiate(woolie_xiang);
			break;
		case 18:
			currentImage = Object.Instantiate(yvette_zelotes);
			break;
		case 19:
			currentImage = Object.Instantiate(bcde);
			break;
		}
	}
}
