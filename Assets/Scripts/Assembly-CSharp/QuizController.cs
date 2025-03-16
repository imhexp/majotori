using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
	public GameObject QuestionHolder;

	public GameObject QuestionText;

	public GameObject AHolder;

	public GameObject ALabel;

	public GameObject AText;

	public GameObject APanel;

	public GameObject BHolder;

	public GameObject BLabel;

	public GameObject BText;

	public GameObject BPanel;

	public GameObject CHolder;

	public GameObject CLabel;

	public GameObject CText;

	public GameObject CPanel;

	public GameObject DHolder;

	public GameObject DLabel;

	public GameObject DText;

	public GameObject DPanel;

	public GameObject AnswerShadow;

	public GameObject AnswerWhiteShadow;

	public GameObject ScreenPanel;

	public GameObject CardCorrect;

	public GameObject CardIncorrect;

	public GameObject CardShadow;

	public GameObject Arrow;

	public GameObject roulettePrefab;

	public GameObject rouletteDemoPrefab;

	private GameObject roulette;

	public Sprite cardIncorrect;

	private GameObject[] scoreboardResults = new GameObject[10];

	public GameObject scoreboard;

	public GameObject result1;

	public GameObject result2;

	public GameObject result3;

	public GameObject result4;

	public GameObject result5;

	public GameObject result6;

	public GameObject result7;

	public GameObject result8;

	public GameObject result9;

	public Sprite correctCardSprite;

	public Sprite incorrectCardSprite;

	public Sprite correctScoreSprite;

	public Sprite incorrectScoreSprite;

	public GameObject scripter;

	public QuizInput quizInput;

	private ChooseQuestion chooseQuestion;

	private Question question;

	private string correctAnswer;

	private int aNumber;

	private int bNumber;

	private int cNumber;

	private int dNumber;

	private AudioSource AS;

	public AudioClip correctClip;

	public AudioClip incorrectClip;

	public bool isQuestionFullyLoaded;

	private Color32 defaultColor = new Color32(0, 0, 0, byte.MaxValue);

	private Color32 correctColor = new Color32(0, 180, 0, byte.MaxValue);

	private Color32 incorrectColor = new Color32(180, 0, 0, byte.MaxValue);

	private int questionNumber;

	private bool correct = true;

	public bool[] answers = new bool[10];

	private GameObject globalScripter;

	private GeneralController generalController;

	private GlobalInput globalInput;

	private GameObject narratorScripter;

	private SettingsInput settingsInput;

	public int winnerAnswer;

	public bool alreadyTranslated;

	private int AnswerWhiteShadowSelection;

	public bool translating;

	private SteamStatsAndAchievements m_StatsAndAchievements;

	public bool controller;

	private void Start()
	{
		AS = base.gameObject.AddComponent<AudioSource>();
		chooseQuestion = scripter.GetComponent<ChooseQuestion>();
		quizInput = scripter.GetComponent<QuizInput>();
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		globalInput = globalScripter.GetComponent<GlobalInput>();
		narratorScripter = GameObject.Find("NarratorScripter");
		settingsInput = narratorScripter.GetComponent<SettingsInput>();
		if (generalController.steam)
		{
			m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
		}
		LoadNewQuestion();
		questionNumber++;
		StartCoroutine("ShowTextHolders");
		generalController.currentScene = "quiz";
		scoreboardResults[1] = result1;
		scoreboardResults[2] = result2;
		scoreboardResults[3] = result3;
		scoreboardResults[4] = result4;
		scoreboardResults[5] = result5;
		scoreboardResults[6] = result6;
		scoreboardResults[7] = result7;
		scoreboardResults[8] = result8;
		scoreboardResults[9] = result9;
	}

	public void NextQuestion()
	{
		ScreenPanel.SetActive(false);
		globalInput.pulsable = false;
		alreadyTranslated = false;
		if (generalController.demo)
		{
			if (questionNumber < 6)
			{
				StartCoroutine("ShowNextQuestion");
			}
			else
			{
				StartCoroutine("ShowResults");
			}
		}
		else if (questionNumber < 10)
		{
			StartCoroutine("ShowNextQuestion");
		}
		else
		{
			StartCoroutine("ShowResults");
		}
		isQuestionFullyLoaded = false;
	}

	private IEnumerator ShowNextQuestion()
	{
		Arrow.GetComponent<Animator>().SetBool("visible", false);
		yield return new WaitForSeconds(0.25f);
		AnswerShadow.GetComponent<Animator>().SetInteger("selection", 0);
		AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", 0);
		AHolder.GetComponent<Animator>().SetBool("visible", false);
		BHolder.GetComponent<Animator>().SetBool("visible", false);
		CHolder.GetComponent<Animator>().SetBool("visible", false);
		DHolder.GetComponent<Animator>().SetBool("visible", false);
		yield return new WaitForSeconds(0.4f);
		QuestionHolder.GetComponent<Animator>().SetTrigger("refresh");
		yield return new WaitForSeconds(0.16f);
		LoadNewQuestion();
		StartCoroutine("ShowTextHolders");
		yield return null;
	}

	private void LoadNewQuestion()
	{
		question = chooseQuestion.NewQuestion();
		QuestionText.GetComponent<Text>().text = question.q;
		int num = Random.Range(1, 5);
		switch (num)
		{
		case 1:
			correctAnswer = "a";
			aNumber = 1;
			AText.GetComponent<Text>().text = question.a1;
			break;
		case 2:
			correctAnswer = "b";
			bNumber = 1;
			BText.GetComponent<Text>().text = question.a1;
			break;
		case 3:
			correctAnswer = "c";
			cNumber = 1;
			CText.GetComponent<Text>().text = question.a1;
			break;
		case 4:
			correctAnswer = "d";
			dNumber = 1;
			DText.GetComponent<Text>().text = question.a1;
			break;
		}
		int num2 = Random.Range(1, 5);
		while (num2 == num)
		{
			num2++;
			if (num2 > 4)
			{
				num2 = 1;
			}
		}
		switch (num2)
		{
		case 1:
			AText.GetComponent<Text>().text = question.a2;
			aNumber = 2;
			break;
		case 2:
			BText.GetComponent<Text>().text = question.a2;
			bNumber = 2;
			break;
		case 3:
			CText.GetComponent<Text>().text = question.a2;
			cNumber = 2;
			break;
		case 4:
			DText.GetComponent<Text>().text = question.a2;
			dNumber = 2;
			break;
		}
		int num3 = Random.Range(1, 5);
		while (num3 == num || num3 == num2)
		{
			num3++;
			if (num3 > 4)
			{
				num3 = 1;
			}
		}
		switch (num3)
		{
		case 1:
			AText.GetComponent<Text>().text = question.a3;
			aNumber = 3;
			break;
		case 2:
			BText.GetComponent<Text>().text = question.a3;
			bNumber = 3;
			break;
		case 3:
			CText.GetComponent<Text>().text = question.a3;
			cNumber = 3;
			break;
		case 4:
			DText.GetComponent<Text>().text = question.a3;
			dNumber = 3;
			break;
		}
		int num4 = Random.Range(1, 5);
		while (num4 == num || num4 == num2 || num4 == num3)
		{
			num4++;
			if (num4 > 4)
			{
				num4 = 1;
			}
		}
		switch (num4)
		{
		case 1:
			AText.GetComponent<Text>().text = question.a4;
			aNumber = 4;
			break;
		case 2:
			BText.GetComponent<Text>().text = question.a4;
			bNumber = 4;
			break;
		case 3:
			CText.GetComponent<Text>().text = question.a4;
			cNumber = 4;
			break;
		case 4:
			DText.GetComponent<Text>().text = question.a4;
			dNumber = 4;
			break;
		}
		isQuestionFullyLoaded = true;
	}

	public void TranslateQuestion()
	{
		StartCoroutine(ShowTranslatedQuestion());
		isQuestionFullyLoaded = false;
	}

	private IEnumerator ShowTranslatedQuestion()
	{
		translating = true;
		ScreenPanel.SetActive(false);
		globalInput.pulsable = false;
		APanel.SetActive(false);
		BPanel.SetActive(false);
		CPanel.SetActive(false);
		DPanel.SetActive(false);
		AHolder.GetComponent<Animator>().SetBool("visible", false);
		BHolder.GetComponent<Animator>().SetBool("visible", false);
		CHolder.GetComponent<Animator>().SetBool("visible", false);
		DHolder.GetComponent<Animator>().SetBool("visible", false);
		int AnswerShadowSelection = AnswerShadow.GetComponent<Animator>().GetInteger("selection");
		AnswerShadow.GetComponent<Animator>().SetInteger("selection", 0);
		AnswerWhiteShadowSelection = AnswerWhiteShadow.GetComponent<Animator>().GetInteger("selection");
		AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", 0);
		yield return new WaitForSeconds(0.4f);
		QuestionHolder.GetComponent<Animator>().SetTrigger("refresh");
		yield return new WaitForSeconds(0.16f);
		if (!alreadyTranslated)
		{
			if (generalController.lang == "en")
			{
				generalController.lang = "es";
			}
			else
			{
				generalController.lang = "en";
			}
		}
		ReloadQuestion();
		isQuestionFullyLoaded = true;
		QuestionHolder.GetComponent<Animator>().SetBool("visible", true);
		AHolder.GetComponent<Animator>().SetBool("visible", true);
		BHolder.GetComponent<Animator>().SetBool("visible", true);
		CHolder.GetComponent<Animator>().SetBool("visible", true);
		DHolder.GetComponent<Animator>().SetBool("visible", true);
		if (!alreadyTranslated)
		{
			if (generalController.lang == "en")
			{
				generalController.lang = "es";
			}
			else
			{
				generalController.lang = "en";
			}
			alreadyTranslated = true;
		}
		else
		{
			alreadyTranslated = false;
		}
		yield return new WaitForSeconds(1f);
		AnswerShadow.GetComponent<Animator>().SetInteger("selection", AnswerShadowSelection);
		AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", AnswerWhiteShadowSelection);
		yield return new WaitForSeconds(0.16f);
		if (quizInput.currentSituation == "answer" && !settingsInput.inSettings)
		{
			APanel.SetActive(true);
			BPanel.SetActive(true);
			CPanel.SetActive(true);
			DPanel.SetActive(true);
		}
		else if (quizInput.currentSituation == "result")
		{
			ScreenPanel.SetActive(true);
		}
		globalInput.pulsable = true;
		translating = false;
	}

	public void ReloadQuestion()
	{
		question = chooseQuestion.RepeatQuestion();
		QuestionText.GetComponent<Text>().text = question.q;
		if (aNumber == 1)
		{
			AText.GetComponent<Text>().text = question.a1;
		}
		else if (aNumber == 2)
		{
			AText.GetComponent<Text>().text = question.a2;
		}
		else if (aNumber == 3)
		{
			AText.GetComponent<Text>().text = question.a3;
		}
		else if (aNumber == 4)
		{
			AText.GetComponent<Text>().text = question.a4;
		}
		if (bNumber == 1)
		{
			BText.GetComponent<Text>().text = question.a1;
		}
		else if (bNumber == 2)
		{
			BText.GetComponent<Text>().text = question.a2;
		}
		else if (bNumber == 3)
		{
			BText.GetComponent<Text>().text = question.a3;
		}
		else if (bNumber == 4)
		{
			BText.GetComponent<Text>().text = question.a4;
		}
		if (cNumber == 1)
		{
			CText.GetComponent<Text>().text = question.a1;
		}
		else if (cNumber == 2)
		{
			CText.GetComponent<Text>().text = question.a2;
		}
		else if (cNumber == 3)
		{
			CText.GetComponent<Text>().text = question.a3;
		}
		else if (cNumber == 4)
		{
			CText.GetComponent<Text>().text = question.a4;
		}
		if (dNumber == 1)
		{
			DText.GetComponent<Text>().text = question.a1;
		}
		else if (dNumber == 2)
		{
			DText.GetComponent<Text>().text = question.a2;
		}
		else if (dNumber == 3)
		{
			DText.GetComponent<Text>().text = question.a3;
		}
		else if (dNumber == 4)
		{
			DText.GetComponent<Text>().text = question.a4;
		}
	}

	public void Result(string answer)
	{
		if (controller)
		{
			return;
		}
		controller = true;
		APanel.SetActive(false);
		BPanel.SetActive(false);
		CPanel.SetActive(false);
		DPanel.SetActive(false);
		globalInput.pulsable = false;
		correct = false;
		switch (answer)
		{
		case "a":
			if (answer == correctAnswer)
			{
				AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", 1);
				ALabel.GetComponent<Text>().color = correctColor;
				AText.GetComponent<Text>().color = correctColor;
				correct = true;
			}
			else
			{
				ALabel.GetComponent<Text>().color = incorrectColor;
				AText.GetComponent<Text>().color = incorrectColor;
				correct = false;
			}
			break;
		case "b":
			if (answer == correctAnswer)
			{
				AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", 2);
				BLabel.GetComponent<Text>().color = correctColor;
				BText.GetComponent<Text>().color = correctColor;
				correct = true;
			}
			else
			{
				BLabel.GetComponent<Text>().color = incorrectColor;
				BText.GetComponent<Text>().color = incorrectColor;
				correct = false;
			}
			break;
		case "c":
			if (answer == correctAnswer)
			{
				AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", 3);
				CLabel.GetComponent<Text>().color = correctColor;
				CText.GetComponent<Text>().color = correctColor;
				correct = true;
			}
			else
			{
				CLabel.GetComponent<Text>().color = incorrectColor;
				CText.GetComponent<Text>().color = incorrectColor;
				correct = false;
			}
			break;
		case "d":
			if (answer == correctAnswer)
			{
				AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", 4);
				DLabel.GetComponent<Text>().color = correctColor;
				DText.GetComponent<Text>().color = correctColor;
				correct = true;
			}
			else
			{
				DLabel.GetComponent<Text>().color = incorrectColor;
				DText.GetComponent<Text>().color = incorrectColor;
				correct = false;
			}
			break;
		}
		if (correct)
		{
			PlayClip(correctClip);
			answers[questionNumber] = true;
		}
		else
		{
			PlayClip(incorrectClip);
			answers[questionNumber] = false;
			if (correctAnswer == "a")
			{
				AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", 1);
				ALabel.GetComponent<Text>().color = correctColor;
				AText.GetComponent<Text>().color = correctColor;
			}
			else if (correctAnswer == "b")
			{
				AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", 2);
				BLabel.GetComponent<Text>().color = correctColor;
				BText.GetComponent<Text>().color = correctColor;
			}
			else if (correctAnswer == "c")
			{
				AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", 3);
				CLabel.GetComponent<Text>().color = correctColor;
				CText.GetComponent<Text>().color = correctColor;
			}
			else if (correctAnswer == "d")
			{
				AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", 4);
				DLabel.GetComponent<Text>().color = correctColor;
				DText.GetComponent<Text>().color = correctColor;
			}
		}
		questionNumber++;
		CardCorrect.GetComponent<Animator>().ResetTrigger("appear");
		CardIncorrect.GetComponent<Animator>().ResetTrigger("appear");
		CardShadow.GetComponent<Animator>().ResetTrigger("appear");
		if (correct)
		{
			CardCorrect.GetComponent<Animator>().SetTrigger("appear");
			CardShadow.GetComponent<Animator>().SetTrigger("appear");
		}
		else
		{
			CardIncorrect.GetComponent<Animator>().SetTrigger("appear");
			CardShadow.GetComponent<Animator>().SetTrigger("appear");
		}
		StartCoroutine("ActivateScreenPanel");
	}

	private IEnumerator ActivateScreenPanel()
	{
		yield return new WaitForSeconds(1f);
		if (correct)
		{
			scoreboardResults[questionNumber - 1].GetComponent<SpriteRenderer>().sprite = correctScoreSprite;
		}
		else
		{
			scoreboardResults[questionNumber - 1].GetComponent<SpriteRenderer>().sprite = incorrectScoreSprite;
		}
		scoreboardResults[questionNumber - 1].GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		Arrow.GetComponent<Animator>().SetBool("visible", true);
		yield return new WaitForSeconds(0.2f);
		ScreenPanel.SetActive(true);
		globalInput.pulsable = true;
		yield return new WaitForSeconds(0.5f);
		controller = false;
		yield return null;
	}

	private IEnumerator ShowResults()
	{
		quizInput.currentSituation = "roulette";
		Arrow.GetComponent<Animator>().SetBool("visible", false);
		scoreboard.GetComponent<Animator>().SetBool("visible", false);
		AHolder.GetComponent<Animator>().SetBool("visible", false);
		BHolder.GetComponent<Animator>().SetBool("visible", false);
		CHolder.GetComponent<Animator>().SetBool("visible", false);
		DHolder.GetComponent<Animator>().SetBool("visible", false);
		APanel.SetActive(false);
		BPanel.SetActive(false);
		CPanel.SetActive(false);
		DPanel.SetActive(false);
		AnswerShadow.GetComponent<Animator>().SetInteger("selection", 0);
		AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", 0);
		yield return new WaitForSeconds(0.4f);
		QuestionHolder.GetComponent<Animator>().SetBool("visible", false);
		yield return new WaitForSeconds(0.3f);
		if (generalController.demo)
		{
			winnerAnswer = Random.Range(1, 6);
			int num = 0;
			int num2 = 0;
			for (int i = 1; i < 6; i++)
			{
				if (answers[i])
				{
					num++;
				}
				else
				{
					num2++;
				}
			}
			roulette = Object.Instantiate(rouletteDemoPrefab);
			if (num == 5 || num2 == 5)
			{
				roulette.GetComponent<Animator>().SetBool("perfect", true);
			}
			else
			{
				roulette.GetComponent<Animator>().SetBool("imperfect", true);
			}
		}
		else
		{
			winnerAnswer = Random.Range(1, 10);
			int num3 = 0;
			int num4 = 0;
			for (int j = 1; j < answers.Length; j++)
			{
				if (answers[j])
				{
					num3++;
				}
				else
				{
					num4++;
				}
			}
			roulette = Object.Instantiate(roulettePrefab);
			if (num3 == answers.Length - 1 || num4 == answers.Length - 1)
			{
				roulette.GetComponent<Animator>().SetBool("perfect", true);
				if (num3 == answers.Length - 1 && generalController.steam)
				{
					if (m_StatsAndAchievements == null)
					{
						m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
					}
					m_StatsAndAchievements.perfect = true;
				}
			}
			else
			{
				roulette.GetComponent<Animator>().SetBool("imperfect", true);
			}
		}
		if (answers[winnerAnswer])
		{
			generalController.win = true;
		}
		else
		{
			generalController.win = false;
		}
	}

	public void PlayClip(AudioClip clip)
	{
		AS.clip = clip;
		AS.volume = (float)generalController.soundVol / 100f;
		AS.Play();
	}

	private IEnumerator ShowTextHolders()
	{
		QuestionHolder.GetComponent<Animator>().SetBool("visible", true);
		ALabel.GetComponent<Text>().color = defaultColor;
		AText.GetComponent<Text>().color = defaultColor;
		BLabel.GetComponent<Text>().color = defaultColor;
		BText.GetComponent<Text>().color = defaultColor;
		CLabel.GetComponent<Text>().color = defaultColor;
		CText.GetComponent<Text>().color = defaultColor;
		DLabel.GetComponent<Text>().color = defaultColor;
		DText.GetComponent<Text>().color = defaultColor;
		AHolder.GetComponent<Animator>().SetBool("visible", true);
		BHolder.GetComponent<Animator>().SetBool("visible", true);
		CHolder.GetComponent<Animator>().SetBool("visible", true);
		DHolder.GetComponent<Animator>().SetBool("visible", true);
		yield return new WaitForSeconds(1.16f);
		if (quizInput.currentSituation != "roulette")
		{
			APanel.SetActive(true);
			BPanel.SetActive(true);
			CPanel.SetActive(true);
			DPanel.SetActive(true);
			globalInput.pulsable = true;
		}
		else
		{
			AHolder.GetComponent<Animator>().SetBool("visible", false);
			BHolder.GetComponent<Animator>().SetBool("visible", false);
			CHolder.GetComponent<Animator>().SetBool("visible", false);
			DHolder.GetComponent<Animator>().SetBool("visible", false);
		}
		if (generalController.demo)
		{
			scoreboard.GetComponent<Animator>().SetBool("demo", true);
		}
		scoreboard.GetComponent<Animator>().SetBool("visible", true);
		quizInput.currentSituation = "answer";
	}

	public void CheatQuiz(string cheatCode)
	{
		for (int i = 0; i < answers.Length - 1; i++)
		{
			if (cheatCode[i] == 'o')
			{
				scoreboardResults[i + 1].GetComponent<SpriteRenderer>().sprite = correctScoreSprite;
				scoreboardResults[i + 1].GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				answers[i + 1] = true;
			}
			else
			{
				scoreboardResults[i + 1].GetComponent<SpriteRenderer>().sprite = incorrectScoreSprite;
				scoreboardResults[i + 1].GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				answers[i + 1] = false;
			}
		}
		StartCoroutine(ShowResults());
	}

	public void HideHolders()
	{
		QuestionHolder.GetComponent<Animator>().SetBool("visible", false);
		AHolder.GetComponent<Animator>().SetBool("visible", false);
		BHolder.GetComponent<Animator>().SetBool("visible", false);
		CHolder.GetComponent<Animator>().SetBool("visible", false);
		DHolder.GetComponent<Animator>().SetBool("visible", false);
		APanel.SetActive(false);
		BPanel.SetActive(false);
		CPanel.SetActive(false);
		DPanel.SetActive(false);
		AnswerShadow.GetComponent<Animator>().SetInteger("selection", 0);
		AnswerWhiteShadow.GetComponent<Animator>().GetInteger("selection");
		AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", 0);
		Arrow.GetComponent<Animator>().SetBool("visible", false);
	}

	public void ShowHolders()
	{
		QuestionHolder.GetComponent<Animator>().SetBool("visible", true);
		AHolder.GetComponent<Animator>().SetBool("visible", true);
		BHolder.GetComponent<Animator>().SetBool("visible", true);
		CHolder.GetComponent<Animator>().SetBool("visible", true);
		DHolder.GetComponent<Animator>().SetBool("visible", true);
		AnswerShadow.GetComponent<Animator>().SetInteger("selection", quizInput.selection);
		AnswerWhiteShadow.GetComponent<Animator>().SetInteger("selection", AnswerWhiteShadowSelection);
		if (quizInput.currentSituation == "result")
		{
			Arrow.GetComponent<Animator>().SetBool("visible", true);
		}
		else
		{
			Invoke("ActivateAnswerPanels", 1f);
		}
	}

	private void ActivateAnswerPanels()
	{
		APanel.SetActive(true);
		BPanel.SetActive(true);
		CPanel.SetActive(true);
		DPanel.SetActive(true);
	}
}
