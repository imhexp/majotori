using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
	public GameObject transition;

	private AsyncOperation async;

	public GameObject googlePlayPassManager;

	private void Start()
	{
		Invoke("ShowMajotoriLogo", 2f);
		Invoke("StartLoading", 2.5f);
		Invoke("ActivateScene", 3f);
	}

	private void StartLoading()
	{
		async = SceneManager.LoadSceneAsync("mainmenu", LoadSceneMode.Single);
		async.allowSceneActivation = false;
	}

	private void ActivateScene()
	{
		async.allowSceneActivation = true;
	}

	private void ShowMajotoriLogo()
	{
		transition.GetComponent<Animator>().SetBool("fadeIn", true);
		transition.GetComponent<Animator>().SetBool("visible", true);
	}
}
