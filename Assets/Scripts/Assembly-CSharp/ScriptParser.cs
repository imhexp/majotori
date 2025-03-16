using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptParser : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	private GameObject narratorScripter;

	public GameObject narratorText;

	public GameObject textHolder;

	private bool firstTextAfterImage = true;

	private bool backFromQuiz;

	public bool backFromSettings;

	private GameObject image1;

	private GameObject image2;

	public GameObject transition;

	public GameObject screenPanel;

	private GlobalInput globalInput;

	private FadeMusic fadeMusic;

	private bool skipping;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		globalInput = globalScripter.GetComponent<GlobalInput>();
		fadeMusic = globalScripter.GetComponent<FadeMusic>();
		narratorScripter = GameObject.Find("NarratorScripter");
	}

	public bool ParseNextLine(List<string> lines, int lineNumber)
	{
		if (skipping)
		{
			return true;
		}
		globalInput.pulsable = false;
		if (lines.Count <= lineNumber)
		{
			generalController.SaveProgress();
			transition.GetComponent<Animator>().SetBool("visible", false);
			fadeMusic.FadeWithPause(generalController.NarratorAudioSource);
			transition.GetComponent<Animator>().SetTrigger("toCharaselector");
		}
		else
		{
			string text = lines[lineNumber];
			if (text.Contains("<txt>"))
			{
				string[] array = Regex.Split(text, "<txt>");
				if (firstTextAfterImage)
				{
					StartCoroutine("TextAppears", array[1]);
					firstTextAfterImage = false;
				}
				else if (backFromQuiz || backFromSettings)
				{
					StartCoroutine("TextAppearsQuick", array[1]);
					backFromQuiz = false;
				}
				else
				{
					StartCoroutine("ChangeText", array[1]);
				}
				firstTextAfterImage = false;
			}
			else
			{
				if (text.Contains("<img>"))
				{
					string[] array = Regex.Split(text, "<img>");
					StartCoroutine("ChangeImage", array[1]);
					firstTextAfterImage = true;
					return false;
				}
				if (text.Contains("<quiz>"))
				{
					backFromQuiz = true;
					StartCoroutine("LoadQuiz");
				}
				else
				{
					if (!text.Contains("<reset>"))
					{
						lines.RemoveAt(0);
						return false;
					}
					StartCoroutine(LoadMainmenu());
				}
			}
		}
		return true;
	}

	public bool ParsePreviousLine(List<string> lines, int lineNumber)
	{
		globalInput.pulsable = false;
		lineNumber -= 2;
		if (lineNumber <= 0)
		{
			return true;
		}
		string text = lines[lineNumber];
		if (text.Contains("<txt>"))
		{
			ParseNextLine(lines, lineNumber);
			generalController.lineNumber = lineNumber + 1;
			return true;
		}
		if (text.Contains("<img>"))
		{
			bool flag = false;
			bool flag2 = false;
			int num = lineNumber;
			while (!flag && num >= 1)
			{
				num--;
				text = lines[num];
				if (text.Contains("<img>"))
				{
					flag = true;
					string[] array = Regex.Split(text, "<img>");
					StartCoroutine("ChangeImageBack", array[1]);
				}
				else if (!flag2 && text.Contains("<txt>"))
				{
					flag2 = true;
					lineNumber = num;
					ParseNextLine(lines, lineNumber);
				}
			}
			generalController.lineNumber = lineNumber + 1;
			return true;
		}
		if (text.Contains("<quiz>"))
		{
			globalInput.pulsable = true;
			return true;
		}
		return false;
	}

	private IEnumerator TextAppears(string line)
	{
		yield return new WaitForSeconds(0.3f);
		textHolder.GetComponent<Animator>().SetBool("visible", false);
		yield return new WaitForSeconds(1.5f);
		narratorText.GetComponent<Text>().text = line;
		if (!skipping)
		{
			textHolder.GetComponent<Animator>().SetBool("visible", true);
			yield return new WaitForSeconds(0.5f);
			screenPanel.SetActive(true);
			globalInput.pulsable = true;
		}
	}

	private IEnumerator TextAppearsQuick(string line)
	{
		if (!narratorScripter.GetComponent<NarratorInput>().settingsInput.inSettings)
		{
			narratorText.GetComponent<Text>().text = line;
			if (!skipping)
			{
				textHolder.GetComponent<Animator>().SetBool("visible", true);
				yield return new WaitForSeconds(0.43f);
				screenPanel.SetActive(true);
				globalInput.pulsable = true;
			}
		}
	}

	private IEnumerator ChangeText(string line)
	{
		textHolder.GetComponent<Animator>().SetTrigger("refresh");
		yield return new WaitForSeconds(0.16f);
		narratorText.GetComponent<Text>().text = line;
		yield return new WaitForSeconds(0.43f);
		screenPanel.SetActive(true);
		globalInput.pulsable = true;
	}

	private IEnumerator ChangeImage(string line)
	{
		textHolder.GetComponent<Animator>().SetBool("visible", false);
		yield return new WaitForSeconds(0.5f);
		image2 = image1;
		if (image2 != null)
		{
			image2.transform.position = new Vector3(0f, 0f, 10f);
		}
		image1 = (GameObject)Object.Instantiate(Resources.Load(line), new Vector3(0f, 0f, -1f), new Quaternion(0f, 0f, 0f, 0f));
		yield return new WaitForSeconds(0.7f);
		Object.Destroy(image2);
	}

	private IEnumerator ChangeImageBack(string line)
	{
		image2 = image1;
		if (image2 != null)
		{
			image2.transform.position = new Vector3(0f, 0f, 10f);
		}
		image1 = (GameObject)Object.Instantiate(Resources.Load(line), new Vector3(0f, 0f, -1f), new Quaternion(0f, 0f, 0f, 0f));
		yield return new WaitForSeconds(0.7f);
		Object.Destroy(image2);
	}

	private IEnumerator LoadQuiz()
	{
		textHolder.GetComponent<Animator>().SetBool("visible", false);
		textHolder.GetComponent<Animator>().ResetTrigger("refresh");
		narratorScripter = GameObject.Find("NarratorScripter");
		narratorScripter.GetComponent<NarratorController>().DisableNarrator();
		yield return new WaitForSeconds(0.5f);
		generalController.currentScene = "quiz";
		SceneManager.LoadSceneAsync("quiz", LoadSceneMode.Additive);
		skipping = false;
		backFromQuiz = true;
	}

	public void Skip(List<string> lines, int lineNumber)
	{
		skipping = true;
		textHolder.GetComponent<Animator>().SetBool("visible", false);
		string text = string.Empty;
		bool flag = false;
		for (int i = lineNumber; i < lines.Count; i++)
		{
			string text2 = lines[i];
			if (text2.Contains("<img>"))
			{
				text = text2;
			}
			else if (text2.Contains("<quiz>"))
			{
				flag = true;
				generalController.lineNumber = i + 1;
			}
			else if (text2.Contains("<reset>"))
			{
				StartCoroutine(LoadMainmenu());
				return;
			}
		}
		if (text != string.Empty && flag)
		{
			string[] array = Regex.Split(text, "<img>");
			text = array[1];
			StartCoroutine("ChangeImage", text);
			StartCoroutine("LoadQuizWithSkip");
		}
		else if (flag)
		{
			StartCoroutine("LoadQuiz");
		}
		else
		{
			generalController.SaveProgress();
			transition.GetComponent<Animator>().SetBool("visible", false);
			fadeMusic.FadeWithPause(generalController.NarratorAudioSource);
			transition.GetComponent<Animator>().SetTrigger("toCharaselector");
		}
	}

	private IEnumerator LoadQuizWithSkip()
	{
		generalController.currentScene = "quiz";
		yield return new WaitForSeconds(1.3f);
		StartCoroutine("LoadQuiz");
		backFromQuiz = true;
	}

	public void LoadCharaselector()
	{
		if (generalController.file == "trivia")
		{
			generalController.justTrivia = false;
			StartCoroutine("LoadMainmenu");
		}
		else if (generalController.routes["lariat"] == "end")
		{
			generalController.NarratorAudioSource.Stop();
			generalController.CharaselectorAudioSource.Stop();
			StartCoroutine("LoadCredits");
		}
		else
		{
			StartCoroutine("ActuallyLoadCharaselector");
		}
	}

	private IEnumerator ActuallyLoadCharaselector()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("charaselector", LoadSceneMode.Single);
		yield return new WaitForSeconds(1f);
		async.allowSceneActivation = true;
	}

	private IEnumerator LoadMainmenu()
	{
		generalController.PreloadMainmenu();
		fadeMusic.Fade(generalController.NarratorAudioSource);
		yield return new WaitForSeconds(0.2f);
		transition.GetComponent<Animator>().SetTrigger("in");
		yield return new WaitForSeconds(1f);
		generalController.LoadMainmenu();
	}

	private IEnumerator LoadCredits()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("credits", LoadSceneMode.Single);
		async.allowSceneActivation = false;
		fadeMusic.Fade(generalController.NarratorAudioSource);
		yield return new WaitForSeconds(0.2f);
		transition.GetComponent<Animator>().SetTrigger("in");
		yield return new WaitForSeconds(1f);
		async.allowSceneActivation = true;
	}
}
