using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RouletteController : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	private GameObject quizScripter;

	private QuizController quizController;

	public Sprite correctCard;

	public Sprite incorrectCard;

	private int spins = 1;

	public GameObject roulette;

	public GameObject card1;

	public GameObject card2;

	public GameObject card3;

	public GameObject card4;

	public GameObject card5;

	public GameObject card6;

	public GameObject card7;

	public GameObject card8;

	public GameObject card9;

	public AudioClip correct;

	public AudioClip incorrect;

	private GameObject[] cards = new GameObject[11];

	private bool[] answers = new bool[11];

	private int winner;

	private bool trollResultPrev;

	private bool trollResultNext;

	private bool trollNextControl;

	private SteamStatsAndAchievements m_StatsAndAchievements;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		quizScripter = GameObject.Find("QuizScripter");
		quizController = quizScripter.GetComponent<QuizController>();
		if (generalController.steam)
		{
			m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
		}
		winner = quizController.winnerAnswer;
		answers = quizController.answers;
		if (!generalController.demo)
		{
			if (winner == 1)
			{
				if (answers[winner] != answers[winner + 1])
				{
					trollResultNext = true;
				}
				if (answers[winner] != answers[9])
				{
					trollResultPrev = true;
				}
			}
			else if (winner == 9)
			{
				if (answers[winner] != answers[1])
				{
					trollResultNext = true;
				}
				if (answers[winner] != answers[winner - 1])
				{
					trollResultPrev = true;
				}
			}
			else
			{
				if (answers[winner] != answers[winner + 1])
				{
					trollResultNext = true;
				}
				if (answers[winner] != answers[winner - 1])
				{
					trollResultPrev = true;
				}
			}
		}
		int num = 0;
		num = ((!answers[quizController.winnerAnswer]) ? Random.Range(0, 6) : Random.Range(0, 3));
		if (trollResultPrev && trollResultNext)
		{
			trollResultPrev = false;
			trollResultNext = false;
			switch (num)
			{
			case 0:
				trollResultPrev = true;
				winner--;
				break;
			case 1:
				trollResultNext = true;
				winner++;
				break;
			}
		}
		else if (trollResultPrev)
		{
			trollResultPrev = false;
			trollResultNext = false;
			if (num == 0)
			{
				trollResultPrev = true;
				winner--;
			}
		}
		else if (trollResultNext)
		{
			trollResultPrev = false;
			trollResultNext = false;
			if (num == 0)
			{
				trollResultNext = true;
				winner++;
			}
		}
		cards[1] = card1;
		cards[2] = card2;
		cards[3] = card3;
		cards[4] = card4;
		cards[5] = card5;
		cards[6] = card6;
		cards[7] = card7;
		cards[8] = card8;
		cards[9] = card9;
		if (generalController.demo)
		{
			for (int i = 1; i < 6; i++)
			{
				if (!answers[i])
				{
					cards[i].GetComponent<SpriteRenderer>().sprite = incorrectCard;
				}
			}
			return;
		}
		for (int j = 1; j < 10; j++)
		{
			if (!answers[j])
			{
				cards[j].GetComponent<SpriteRenderer>().sprite = incorrectCard;
			}
		}
	}

	public void NextSpin()
	{
		if (generalController.demo)
		{
			for (int i = 1; i < 6; i++)
			{
				int num;
				for (num = i + spins; num > 5; num -= 5)
				{
				}
				if (!answers[i])
				{
					cards[num].GetComponent<SpriteRenderer>().sprite = incorrectCard;
				}
				else
				{
					cards[num].GetComponent<SpriteRenderer>().sprite = correctCard;
				}
			}
			if (spins > 6 - winner)
			{
				if (roulette.GetComponent<Animator>().speed <= 0.1f)
				{
					roulette.GetComponent<Animator>().SetTrigger("result");
					StartCoroutine(Finish());
				}
				else
				{
					roulette.GetComponent<Animator>().speed -= 0.1f;
				}
			}
		}
		else
		{
			for (int j = 1; j < 10; j++)
			{
				int num2;
				for (num2 = j + spins; num2 > 9; num2 -= 9)
				{
				}
				if (!answers[j])
				{
					cards[num2].GetComponent<SpriteRenderer>().sprite = incorrectCard;
				}
				else
				{
					cards[num2].GetComponent<SpriteRenderer>().sprite = correctCard;
				}
			}
			if (winner > 4)
			{
				if (spins > 18 - winner)
				{
					RouletteSpinControl();
				}
			}
			else if (spins > 9 - winner)
			{
				RouletteSpinControl();
			}
		}
		spins++;
	}

	private void RouletteSpinControl()
	{
		if (trollResultPrev)
		{
			if (roulette.GetComponent<Animator>().speed <= 0.2f)
			{
				winner--;
				roulette.GetComponent<Animator>().speed -= 0.1f;
				StartCoroutine(FinishTroll());
			}
			else if (roulette.GetComponent<Animator>().speed <= 0.3f)
			{
				roulette.GetComponent<Animator>().speed -= 0.1f;
				roulette.GetComponent<Animator>().SetTrigger("trollSpin");
			}
			else
			{
				roulette.GetComponent<Animator>().speed -= 0.1f;
			}
		}
		else if (trollResultNext)
		{
			if (roulette.GetComponent<Animator>().speed <= 0.1f)
			{
				if (!trollNextControl)
				{
					trollNextControl = true;
					return;
				}
				winner++;
				roulette.GetComponent<Animator>().SetTrigger("result");
				StartCoroutine(Finish());
			}
			else
			{
				roulette.GetComponent<Animator>().speed -= 0.1f;
			}
		}
		else if (roulette.GetComponent<Animator>().speed <= 0.1f)
		{
			roulette.GetComponent<Animator>().SetTrigger("result");
			StartCoroutine(Finish());
		}
		else
		{
			roulette.GetComponent<Animator>().speed -= 0.1f;
		}
	}

	public void PlayResult()
	{
		AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
		if (generalController.win)
		{
			audioSource.clip = correct;
		}
		else
		{
			audioSource.clip = incorrect;
		}
		audioSource.volume = (float)generalController.soundVol / 100f;
		audioSource.Play();
	}

	public void CallFinish()
	{
		StartCoroutine(Finish());
	}

	private IEnumerator Finish()
	{
		yield return new WaitForSeconds(0.1f);
		roulette.GetComponent<Animator>().speed = 1f;
		yield return new WaitForSeconds(2.1f);
		Finish2();
	}

	private IEnumerator FinishTroll()
	{
		yield return new WaitForSeconds(2.3f);
		roulette.GetComponent<Animator>().speed = 1f;
		yield return new WaitForSeconds(2.1f);
		if (generalController.steam)
		{
			if (m_StatsAndAchievements == null)
			{
				m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
			}
			m_StatsAndAchievements.trolled = true;
		}
		Finish2();
	}

	private void Finish2()
	{
		generalController = GameObject.Find("GlobalScripter").GetComponent<GeneralController>();
		if (generalController.win)
		{
			generalController.LoadWinLines();
		}
		else
		{
			generalController.LoadLoseLines();
		}
		generalController.NextLine();
		GameObject gameObject = GameObject.Find("NarratorScripter");
		gameObject.GetComponent<NarratorController>().EnableNarrator();
		generalController.currentScene = "narrator";
		SceneManager.UnloadSceneAsync("quiz");
	}
}
