using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralController : MonoBehaviour
{
	public static GeneralController generalController;

	public bool demo;

	public bool isFristRoute = true;

	public bool mobile;

	public bool steam;

	public bool justTrivia;

	private AsyncOperation async;

	private ScriptLoader scriptLoader;

	private ScriptParser scriptParser;

	private QuestionsLoader questionsLoader;

	public GlobalInput globalInput;

	public AudioSource MainmenuAudioSource;

	public AudioSource NarratorAudioSource;

	public AudioSource CharaselectorAudioSource;

	public AudioClip mainTheme;

	private FadeMusic fadeMusic;

	private PlayClip playClip;

	public AudioClip thump;

	public string currentScene = "mainmenu";

	private List<string> script_lines;

	private List<string> win_lines;

	private List<string> lose_lines;

	public string[] files;

	public string file;

	public string route;

	public bool win;

	public bool afterQuiz;

	public int wins;

	public int fails;

	public string deaths = string.Empty;

	public string oliver_harmed = string.Empty;

	public string kony_harmed = string.Empty;

	public bool finished_once;

	public bool youCredits;

	public int lineNumber;

	public Dictionary<string, List<Question>> q_lists;

	public Dictionary<string, List<int>> used_questions;

	public List<string> lines;

	public string lang;

	public Resolution resolution;

	public bool fullscreen;

	public int soundVol;

	public int musicVol;

	public bool misc;

	public bool vidya;

	public bool cinema;

	public bool animation;

	public int saveFile;

	public bool progressSaved;

	public Dictionary<string, string> routes;

	private bool callNextLineNextFrame;

	private int previousScreenWidth;

	private int previousScreenHeight;

	private bool previousFullscreen;

	private bool alreadyTranslated;

	public AudioClip charaselectorTheme;

	private SteamStatsAndAchievements m_StatsAndAchievements;

	private string savesPath;

	private QuizController quizController;

	private bool justTriviaResultsRecorded;

	private int justTriviaWins;

	private int justTriviaLoses;

	private float exp = 2f;

	private void Start()
	{
		generalController = this;
		demo = false;
		previousScreenWidth = Screen.width;
		previousScreenHeight = Screen.height;
		previousFullscreen = Screen.fullScreen;
		LoadPrefs();
		scriptLoader = base.gameObject.GetComponent<ScriptLoader>();
		questionsLoader = base.gameObject.GetComponent<QuestionsLoader>();
		fadeMusic = base.gameObject.GetComponent<FadeMusic>();
		playClip = base.gameObject.GetComponent<PlayClip>();
		globalInput = base.gameObject.GetComponent<GlobalInput>();
	}

	private void Update()
	{
		if (currentScene != "settings" && (previousScreenWidth != Screen.width || previousScreenHeight != Screen.height || previousFullscreen != Screen.fullScreen))
		{
			previousScreenWidth = Screen.width;
			previousScreenHeight = Screen.height;
			previousFullscreen = Screen.fullScreen;
			resolution.width = Screen.width;
			resolution.height = Screen.height;
			fullscreen = Screen.fullScreen;
			PlayerPrefs.SetString("resolution", Screen.width + "x" + Screen.height);
			if (Screen.fullScreen)
			{
				PlayerPrefs.SetString("fullscreen", "true");
			}
			else
			{
				PlayerPrefs.SetString("fullscreen", "false");
			}
		}
		if (callNextLineNextFrame && (bool)GameObject.Find("NarratorScripter"))
		{
			callNextLineNextFrame = false;
			NextLine();
		}
	}

	private void LoadPrefs()
	{
		if (PlayerPrefs.GetString("lang") == string.Empty)
		{
			switch (string.Empty + Application.systemLanguage)
			{
			case "Catalan":
			case "Spanish":
			case "Basque":
				PlayerPrefs.SetString("lang", "es");
				break;
			default:
				PlayerPrefs.SetString("lang", "en");
				break;
			}
		}
		lang = PlayerPrefs.GetString("lang");
		if (PlayerPrefs.GetString("resolution") != string.Empty && PlayerPrefs.GetString("fullscreen") != string.Empty)
		{
			string[] array = PlayerPrefs.GetString("resolution").Split('x');
			resolution.width = int.Parse(array[0]);
			resolution.height = int.Parse(array[1]);
			if (PlayerPrefs.GetString("fullscreen") == "true")
			{
				fullscreen = true;
			}
			else
			{
				fullscreen = false;
			}
		}
		else
		{
			PlayerPrefs.SetString("fullscreen", string.Empty + Screen.fullScreen);
			PlayerPrefs.SetString("resolution", Screen.width + "x" + Screen.height);
		}
		if (PlayerPrefs.GetString("soundVol") == string.Empty)
		{
			soundVol = 100;
		}
		else
		{
			soundVol = int.Parse(PlayerPrefs.GetString("soundVol"));
		}
		if (PlayerPrefs.GetString("musicVol") == string.Empty)
		{
			musicVol = 100;
		}
		else
		{
			musicVol = int.Parse(PlayerPrefs.GetString("musicVol"));
		}
		if (PlayerPrefs.GetString("misc") != string.Empty)
		{
			misc = false;
		}
		else
		{
			misc = true;
		}
		if (PlayerPrefs.GetString("vidya") != string.Empty)
		{
			vidya = false;
		}
		else
		{
			vidya = true;
		}
		if (PlayerPrefs.GetString("cinema") != string.Empty)
		{
			cinema = false;
		}
		else
		{
			cinema = true;
		}
		if (PlayerPrefs.GetString("animation") != string.Empty)
		{
			animation = false;
		}
		else
		{
			animation = true;
		}
	}

	public void StartSave(int save)
	{
		saveFile = save;
		Load();
		if (routes["ava"] == string.Empty)
		{
			file = "ava";
			route = "a";
			CallLoadScript();
			fadeMusic.Fade(MainmenuAudioSource);
			async = SceneManager.LoadSceneAsync("narrator", LoadSceneMode.Single);
			async.allowSceneActivation = false;
			Invoke("LoadNarrator", 1f);
		}
		else if (routes["lariat"] == "end")
		{
			fadeMusic.Fade(MainmenuAudioSource);
			async = SceneManager.LoadSceneAsync("credits", LoadSceneMode.Single);
			async.allowSceneActivation = false;
			Invoke("LoadCredits", 1f);
		}
		else
		{
			fadeMusic.Fade(MainmenuAudioSource);
			async = SceneManager.LoadSceneAsync("charaselector", LoadSceneMode.Single);
			async.allowSceneActivation = false;
			Invoke("LoadCharaselector", 1f);
		}
	}

	private void TestingRoutesOverwrite()
	{
	}

	private void LoadNarrator()
	{
		currentScene = "narrator";
		NarratorAudioSource.Play();
		if (justTrivia)
		{
			int num = Random.Range(0, 7);
			float num2 = 0f;
			switch (num)
			{
			case 0:
				num2 = 0f;
				break;
			case 1:
				num2 = 51.42f;
				break;
			case 2:
				num2 = 85.7f;
				break;
			case 3:
				num2 = 154.27f;
				break;
			case 4:
				num2 = 188.56f;
				break;
			case 5:
				num2 = 222.85f;
				break;
			case 6:
				num2 = 257.14f;
				break;
			default:
				num2 = 0f;
				break;
			}
			NarratorAudioSource.timeSamples = (int)((float)NarratorAudioSource.clip.frequency * num2);
		}
		async.allowSceneActivation = true;
	}

	private void LoadCharaselector()
	{
		currentScene = "charaselector";
		async.allowSceneActivation = true;
	}

	private void LoadCredits()
	{
		currentScene = "credits";
		async.allowSceneActivation = true;
	}

	public void StartSaveDemo()
	{
	}

	public void Initialize()
	{
		ApplyVol();
		files = new string[18]
		{
			"ava", "bcde", "fatima", "gloria", "hector_ingrid", "juliet_romeo", "kony", "lariat", "mariano", "nikola",
			"oliver", "paca", "queralt", "sebastian", "tsubasa", "umberto_viviana", "woolie_xiang", "yvette_zelotes"
		};
		if (demo)
		{
			files = new string[12]
			{
				"ava", "hector_ingrid", "juliet_romeo", "kony", "lariat", "oliver", "queralt", "sebastian", "tsubasa", "umberto_viviana",
				"woolie_xiang", "yvette_zelotes"
			};
		}
		SaveLoadManager.saveLoadManager.LoadUsedQuestions();
		q_lists = new Dictionary<string, List<Question>>();
		used_questions = new Dictionary<string, List<int>>();
		questionsLoader.LoadQuestions(out q_lists, out used_questions);
	}

	public void SaveProgress()
	{
		progressSaved = true;
		if (saveFile == 0)
		{
			return;
		}
		string text = "1";
		if (!win)
		{
			text = "0";
			fails++;
		}
		else
		{
			text = "1";
			wins++;
		}
		routes[file] = route + text;
		string text2 = string.Empty;
		if (file == "ava")
		{
			if (routes[file] == "a0")
			{
				text2 = "mom";
			}
			else if (routes[file] == "a1a1a0")
			{
				text2 = "reporter";
			}
			else if (routes[file] == "a1a1a1a0a0" || routes[file] == "a1a1a1a1a0a1" || routes[file] == "a1a1a1a1a0b1")
			{
				text2 = "ava_reporter";
			}
			else if (routes[file] == "a1a1a1a1a1a0")
			{
				text2 = "wife";
			}
			else if (routes[file] == "a1a1a1a1a1a1")
			{
				text2 = "ava";
			}
		}
		else if (file == "fatima" && (routes[file] == "a1a0" || routes[file] == "a0a0"))
		{
			text2 = "fatima";
		}
		else if (file == "gloria")
		{
			if (routes[file] == "a0" || routes[file] == "b0" || routes[file] == "c0" || routes[file] == "d0")
			{
				text2 = "gloria";
			}
		}
		else if (file == "hector_ingrid")
		{
			if (routes[file] == "a1a1")
			{
				text2 = "hector";
			}
			else if (routes[file] == "a1a0")
			{
				text2 = "hector_ingrid";
			}
		}
		else if (file == "juliet_romeo" && routes[file] == "a1a1a0")
		{
			text2 = "juliet_romeo";
		}
		else if (file == "kony")
		{
			if (routes[file] == "a0")
			{
				text2 = "bird";
			}
			else if (routes[file] == "b0")
			{
				text2 = "deer";
			}
			else if (routes[file] == "c0")
			{
				text2 = "rabbit";
			}
		}
		else if (file == "paca" && routes[file] == "a0")
		{
			text2 = "groom_paca";
		}
		else if (file == "tsubasa" && routes[file] == "a0")
		{
			text2 = "tsubasa";
		}
		else if (file == "umberto_viviana")
		{
			if (routes[file] == "a0")
			{
				text2 = "umberto";
			}
			else if (routes[file] == "a0a0")
			{
				text2 = "viviana";
			}
		}
		else if (file == "yvette_zelotes")
		{
			if (routes[file] == "a0")
			{
				text2 = "yvette_zelotes1";
			}
			else if (routes[file] == "a1a1a0")
			{
				text2 = "zelotes2";
			}
		}
		if (routes["lariat"] == "a1" || routes["lariat"] == "a0a0" || routes["lariat"] == "a0a1")
		{
			if (steam)
			{
				if (m_StatsAndAchievements == null)
				{
					m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
				}
				if (routes["lariat"] == "a1")
				{
					m_StatsAndAchievements.you_are_welcome = true;
				}
				if (PlayerPrefs.GetString("finishedOnce") == "true" || finished_once)
				{
					m_StatsAndAchievements.i_needed_to_see_what_happens = true;
				}
				else
				{
					m_StatsAndAchievements.meta = true;
				}
			}
			finished_once = true;
		}
		if (file == "ava" && routes[file] == "a1a1a1a1a1a1" && steam)
		{
			if (m_StatsAndAchievements == null)
			{
				m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
			}
			m_StatsAndAchievements.see_you_space_princess = true;
		}
		if (file == "sebastian" && routes[file] == "a0a1" && steam)
		{
			if (m_StatsAndAchievements == null)
			{
				m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
			}
			m_StatsAndAchievements.master_chef = true;
		}
		if (file == "nikola" && routes[file] == "a1a1" && steam)
		{
			if (m_StatsAndAchievements == null)
			{
				m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
			}
			m_StatsAndAchievements.doujinshi_write_themselves = true;
		}
		if (file == "hector_ingrid" && routes[file] == "a1" && steam)
		{
			if (m_StatsAndAchievements == null)
			{
				m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
			}
			m_StatsAndAchievements.i_think_i_know_this_anime = true;
		}
		if (file == "juliet_romeo" && routes[file] == "a1a1a1" && steam)
		{
			if (m_StatsAndAchievements == null)
			{
				m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
			}
			m_StatsAndAchievements.rewriting_a_classic = true;
		}
		if (file == "oliver")
		{
			if (routes[file] == "a1")
			{
				oliver_harmed = "false";
				if (kony_harmed == "false" && steam)
				{
					if (m_StatsAndAchievements == null)
					{
						m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
					}
					m_StatsAndAchievements.no_animals_harmed = true;
				}
			}
			else
			{
				oliver_harmed = "true";
			}
		}
		if (file == "kony")
		{
			if (routes[file] == "a1" || routes[file] == "b1" || routes[file] == "c1")
			{
				kony_harmed = "false";
				if (oliver_harmed == "false" && steam)
				{
					if (m_StatsAndAchievements == null)
					{
						m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
					}
					m_StatsAndAchievements.no_animals_harmed = true;
				}
			}
			else
			{
				kony_harmed = "true";
			}
		}
		if (file == "mariano" && (routes[file] == "a1a1" || routes[file] == "a1a0") && steam)
		{
			if (m_StatsAndAchievements == null)
			{
				m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
			}
			m_StatsAndAchievements.anime_was_a_mistake = true;
		}
		if (file == "woolie_xiang" && (routes[file] == "a1a1a1" || routes[file] == "a1a0a1") && steam)
		{
			if (m_StatsAndAchievements == null)
			{
				m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
			}
			m_StatsAndAchievements.i_wish_to_be_her_right_now = true;
		}
		if (text2 != string.Empty)
		{
			deaths = deaths + text2 + "_";
			if (steam)
			{
				if (m_StatsAndAchievements == null)
				{
					m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
				}
				m_StatsAndAchievements.gone_fatal = true;
			}
		}
		if (routes["lariat"] == "a1")
		{
			youCredits = true;
			PlayerPrefs.SetInt("YouCredits", 1);
		}
		if (scriptLoader.CharacterEnd(file, lang, routes))
		{
			routes[file] = "end";
		}
		Save();
	}

	public void DeleteProgress(int save)
	{
		saveFile = save;
		SaveLoadManager.saveLoadManager.ResetSave(saveFile);
		SaveLoadManager.saveLoadManager.Load(saveFile);
	}

	public void ApplyVol()
	{
		MainmenuAudioSource.volume = Mathf.Pow((float)musicVol / 100f, exp);
		NarratorAudioSource.volume = Mathf.Pow((float)musicVol / 100f, exp);
		CharaselectorAudioSource.volume = Mathf.Pow((float)musicVol / 100f, exp);
	}

	public void CallLoadScript()
	{
		afterQuiz = false;
		script_lines = new List<string>();
		win_lines = new List<string>();
		lose_lines = new List<string>();
		scriptLoader.LoadScript(file, lang, route, out script_lines, out win_lines, out lose_lines);
		lineNumber = 0;
		lines = script_lines;
	}

	public void NextLine()
	{
		if (scriptParser == null)
		{
			if (!GameObject.Find("NarratorScripter"))
			{
				callNextLineNextFrame = true;
				return;
			}
			scriptParser = GameObject.Find("NarratorScripter").GetComponent<ScriptParser>();
		}
		bool flag = scriptParser.ParseNextLine(lines, lineNumber);
		while (!flag)
		{
			lineNumber++;
			flag = scriptParser.ParseNextLine(lines, lineNumber);
		}
		lineNumber++;
		alreadyTranslated = false;
	}

	public void PreviousLine()
	{
		int num = lineNumber;
		if (scriptParser == null)
		{
			if (!GameObject.Find("NarratorScripter"))
			{
				callNextLineNextFrame = true;
				return;
			}
			scriptParser = GameObject.Find("NarratorScripter").GetComponent<ScriptParser>();
		}
		bool flag = scriptParser.ParsePreviousLine(lines, lineNumber);
		while (!flag)
		{
			lineNumber--;
			flag = scriptParser.ParsePreviousLine(lines, lineNumber);
		}
		if (num == lineNumber)
		{
			playClip.PlayCustom(thump);
			globalInput.pulsable = true;
		}
		alreadyTranslated = false;
	}

	public void Skip()
	{
		globalInput.pulsable = false;
		scriptParser.Skip(lines, lineNumber);
	}

	public void LoadWinLines()
	{
		afterQuiz = true;
		lines.AddRange(win_lines);
		if (!demo && !justTrivia && steam)
		{
			if (m_StatsAndAchievements == null)
			{
				m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
			}
			m_StatsAndAchievements.wish_granted = true;
		}
		if (demo || !justTrivia)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		if (!justTriviaResultsRecorded)
		{
			quizController = GameObject.Find("QuizScripter").GetComponent<QuizController>();
			num = 0;
			num2 = 0;
			for (int i = 1; i < quizController.answers.Length; i++)
			{
				if (quizController.answers[i])
				{
					num++;
				}
				else
				{
					num2++;
				}
			}
			justTriviaResultsRecorded = true;
			justTriviaWins = num;
			justTriviaLoses = num2;
		}
		else
		{
			num = justTriviaWins;
			num2 = justTriviaLoses;
		}
		string text = ".";
		if (lang == "en")
		{
			if (num2 > 0 && num > 0)
			{
				text = ((!win) ? ", and luck against you." : ", and luck on your side.");
			}
			if (num != 1 && num2 != 1)
			{
				lines[lines.Count - 1] = "<txt>The results are: " + num + " correct answers, " + num2 + " incorrect answers" + text;
			}
			else if (num == 1)
			{
				lines[lines.Count - 1] = "<txt>The results are: " + num + " correct answer, " + num2 + " incorrect answers" + text;
			}
			else
			{
				lines[lines.Count - 1] = "<txt>The results are: " + num + " correct answers, " + num2 + " incorrect answer" + text;
			}
		}
		else
		{
			if (num2 > 0 && num > 0)
			{
				text = ((!win) ? ", y la suerte contra ti." : ", y la suerte de tu lado.");
			}
			if (num != 1 && num2 != 1)
			{
				lines[lines.Count - 1] = "<txt>Los resultados son: " + num + " respuestas correctas, " + num2 + " respuestas incorrectas" + text;
			}
			else if (num == 1)
			{
				lines[lines.Count - 1] = "<txt>Los resultados son: " + num + " respuesta correcta, " + num2 + " respuestas incorrectas" + text;
			}
			else
			{
				lines[lines.Count - 1] = "<txt>Los resultados son: " + num + " respuestas correctas, " + num2 + " respuesta incorrecta" + text;
			}
		}
	}

	public void LoadLoseLines()
	{
		afterQuiz = true;
		lines.AddRange(lose_lines);
		if (!demo && !justTrivia && steam)
		{
			if (m_StatsAndAchievements == null)
			{
				m_StatsAndAchievements = Object.FindObjectOfType<SteamStatsAndAchievements>();
			}
			m_StatsAndAchievements.life_ruined = true;
		}
		if (demo)
		{
			if (file == "oliver" || file == "hector_ingrid" || (file == "ava" && route != "a"))
			{
				if (lang == "en")
				{
					lines.Add("<txt>Thanks for playing Majotori's demo.");
					lines.Add("<txt>Majotori is available on Steam, Android and iOS, with a lot more characters and more than 1000 questions.");
					lines.Add("<txt>If you liked it, buy it!");
					lines.Add("<reset>");
				}
				else
				{
					lines.Add("<txt>Gracias por jugar a la demo de Majotori.");
					lines.Add("<txt>Majotori está disponible en Steam, Android y iOS, con muchos más personajes y más de 1000 preguntas.");
					lines.Add("<txt>¡Si te ha gustado, cómpralo y apoya el desarrollo mallorquín!");
					lines.Add("<reset>");
				}
			}
			else if (lang == "en")
			{
				lines.Add("<txt>You are playing Majotori's demo, a game available on Steam, Android & iOS.");
				lines.Add("<txt>One more round?");
			}
			else
			{
				lines.Add("<txt>Estás jugando a la demo de Majotori, un juego mallorquín disponible en Steam, Android y iOS.");
				lines.Add("<txt>¿Una ronda más?");
			}
		}
		else
		{
			if (!justTrivia)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			if (!justTriviaResultsRecorded)
			{
				quizController = GameObject.Find("QuizScripter").GetComponent<QuizController>();
				num = 0;
				num2 = 0;
				for (int i = 1; i < quizController.answers.Length; i++)
				{
					if (quizController.answers[i])
					{
						num++;
					}
					else
					{
						num2++;
					}
				}
				justTriviaResultsRecorded = true;
				justTriviaWins = num;
				justTriviaLoses = num2;
			}
			else
			{
				num = justTriviaWins;
				num2 = justTriviaLoses;
			}
			string text = ".";
			if (lang == "en")
			{
				if (num2 > 0 && num > 0)
				{
					text = ((!win) ? " and luck against you." : " and luck on your side.");
				}
				if (num != 1 && num2 != 1)
				{
					lines[lines.Count - 1] = "<txt>The results are: " + num + " correct answers, " + num2 + " incorrect answers" + text;
				}
				else if (num == 1)
				{
					lines[lines.Count - 1] = "<txt>The results are: " + num + " correct answer, " + num2 + " incorrect answers" + text;
				}
				else
				{
					lines[lines.Count - 1] = "<txt>The results are: " + num + " correct answers, " + num2 + " incorrect answer" + text;
				}
			}
			else
			{
				if (num2 > 0 && num > 0)
				{
					text = ((!win) ? " y la suerte contra ti." : " y la suerte de tu lado.");
				}
				if (num != 1 && num2 != 1)
				{
					lines[lines.Count - 1] = "<txt>Los resultados son: " + num + " respuestas correctas, " + num2 + " respuestas incorrectas" + text;
				}
				else if (num == 1)
				{
					lines[lines.Count - 1] = "<txt>Los resultados son: " + num + " respuesta correcta, " + num2 + " respuestas incorrectas" + text;
				}
				else
				{
					lines[lines.Count - 1] = "<txt>Los resultados son: " + num + " respuestas correctas, " + num2 + " respuesta incorrecta" + text;
				}
			}
		}
	}

	public void PreloadMainmenu()
	{
		if (async.allowSceneActivation)
		{
			async = SceneManager.LoadSceneAsync("mainmenu", LoadSceneMode.Single);
			async.allowSceneActivation = false;
		}
	}

	public void LoadMainmenu()
	{
		NarratorAudioSource.clip = mainTheme;
		currentScene = "mainmenu";
		async.allowSceneActivation = true;
		MainmenuAudioSource.Play();
		Initialize();
		globalInput.pulsable = true;
	}

	public void TranslateNarrator()
	{
		if (alreadyTranslated)
		{
			lineNumber--;
			NextLine();
			return;
		}
		if (lang == "en")
		{
			lang = "es";
		}
		else
		{
			lang = "en";
		}
		int num = lineNumber;
		if (afterQuiz)
		{
			CallLoadScript();
			if (win)
			{
				LoadWinLines();
			}
			else
			{
				LoadLoseLines();
			}
			lineNumber = num - 1;
			NextLine();
		}
		else
		{
			CallLoadScript();
			lineNumber = num - 1;
			NextLine();
		}
		if (lang == "en")
		{
			lang = "es";
		}
		else
		{
			lang = "en";
		}
		if (afterQuiz)
		{
			CallLoadScript();
			if (win)
			{
				LoadWinLines();
			}
			else
			{
				LoadLoseLines();
			}
		}
		else
		{
			CallLoadScript();
		}
		lineNumber = num;
		alreadyTranslated = true;
	}

	public void StartJustTrivia()
	{
		saveFile = 0;
		file = "trivia";
		route = "a";
		CallLoadScript();
		fadeMusic.Fade(MainmenuAudioSource);
		async = SceneManager.LoadSceneAsync("narrator", LoadSceneMode.Single);
		async.allowSceneActivation = false;
		Invoke("LoadNarrator", 1f);
		justTriviaResultsRecorded = false;
	}

	public void CheckFinishedOnceAchievement()
	{
		if (finished_once)
		{
			PlayerPrefs.SetString("finishedOnce", "true");
		}
	}

	public void Load()
	{
		SaveLoadManager.saveLoadManager.Load(saveFile);
	}

	public void Save()
	{
		SaveLoadManager.saveLoadManager.Save(saveFile);
	}

	public void ResetSave()
	{
		SaveLoadManager.saveLoadManager.ResetSave(saveFile);
	}

	public void SaveUsedQuestions()
	{
		SaveLoadManager.saveLoadManager.SaveUsedQuestions();
	}

	public void ResetUsedQuestions()
	{
		SaveLoadManager.saveLoadManager.ResetUsedQuestions();
	}
}
