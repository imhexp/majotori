using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
	public static SaveLoadManager saveLoadManager;

	private void Awake()
	{
		saveLoadManager = this;
	}

	public void Save(int saveFile)
	{
		SaveData saveData = new SaveData();
		GeneralController generalController = GeneralController.generalController;
		saveData.ava = generalController.routes["ava"];
		saveData.bcde = generalController.routes["bcde"];
		saveData.fatima = generalController.routes["fatima"];
		saveData.gloria = generalController.routes["gloria"];
		saveData.hector_ingrid = generalController.routes["hector_ingrid"];
		saveData.juliet_romeo = generalController.routes["juliet_romeo"];
		saveData.kony = generalController.routes["kony"];
		saveData.lariat = generalController.routes["lariat"];
		saveData.mariano = generalController.routes["mariano"];
		saveData.nikola = generalController.routes["nikola"];
		saveData.oliver = generalController.routes["oliver"];
		saveData.paca = generalController.routes["paca"];
		saveData.queralt = generalController.routes["queralt"];
		saveData.sebastian = generalController.routes["sebastian"];
		saveData.tsubasa = generalController.routes["tsubasa"];
		saveData.umberto_viviana = generalController.routes["umberto_viviana"];
		saveData.woolie_xiang = generalController.routes["woolie_xiang"];
		saveData.yvette_zelotes = generalController.routes["yvette_zelotes"];
		saveData.wins = generalController.wins;
		saveData.fails = generalController.fails;
		saveData.deaths = generalController.deaths;
		saveData.oliver_harmed = generalController.oliver_harmed;
		saveData.kony_harmed = generalController.kony_harmed;
		saveData.youCredits = generalController.youCredits;
		saveData.finished_once = generalController.finished_once;
		SaveLoad.saveLoad.WriteData(saveData, saveFile);
	}

	public void Load(int saveFile)
	{
		SaveData saveData = SaveLoad.saveLoad.Load(saveFile);
		if (saveData == null)
		{
			saveData = ResetSave(saveFile);
		}
		ParseLoadedData(saveData);
	}

	public void ParseLoadedData(SaveData data)
	{
		GeneralController generalController = GeneralController.generalController;
		generalController.routes = new Dictionary<string, string>();
		generalController.routes.Add("ava", data.ava);
		generalController.routes.Add("bcde", data.bcde);
		generalController.routes.Add("fatima", data.fatima);
		generalController.routes.Add("gloria", data.gloria);
		generalController.routes.Add("hector_ingrid", data.hector_ingrid);
		generalController.routes.Add("juliet_romeo", data.juliet_romeo);
		generalController.routes.Add("kony", data.kony);
		generalController.routes.Add("lariat", data.lariat);
		generalController.routes.Add("mariano", data.mariano);
		generalController.routes.Add("nikola", data.nikola);
		generalController.routes.Add("oliver", data.oliver);
		generalController.routes.Add("paca", data.paca);
		generalController.routes.Add("queralt", data.queralt);
		generalController.routes.Add("sebastian", data.sebastian);
		generalController.routes.Add("tsubasa", data.tsubasa);
		generalController.routes.Add("umberto_viviana", data.umberto_viviana);
		generalController.routes.Add("woolie_xiang", data.woolie_xiang);
		generalController.routes.Add("yvette_zelotes", data.yvette_zelotes);
		generalController.wins = data.wins;
		generalController.fails = data.fails;
		generalController.deaths = data.deaths;
		generalController.oliver_harmed = data.oliver_harmed;
		generalController.kony_harmed = data.kony_harmed;
		generalController.youCredits = data.youCredits;
		generalController.finished_once = data.finished_once;
		generalController.CheckFinishedOnceAchievement();
	}

	public SaveData ResetSave(int saveFile)
	{
		GeneralController generalController = GeneralController.generalController;
		SaveData saveData = new SaveData();
		saveData.ava = string.Empty;
		saveData.bcde = string.Empty;
		saveData.fatima = string.Empty;
		saveData.gloria = string.Empty;
		saveData.hector_ingrid = string.Empty;
		saveData.juliet_romeo = string.Empty;
		saveData.kony = string.Empty;
		saveData.lariat = string.Empty;
		saveData.mariano = string.Empty;
		saveData.nikola = string.Empty;
		saveData.oliver = string.Empty;
		saveData.paca = string.Empty;
		saveData.queralt = string.Empty;
		saveData.sebastian = string.Empty;
		saveData.tsubasa = string.Empty;
		saveData.umberto_viviana = string.Empty;
		saveData.woolie_xiang = string.Empty;
		saveData.yvette_zelotes = string.Empty;
		saveData.wins = 0;
		saveData.fails = 0;
		saveData.deaths = string.Empty;
		saveData.oliver_harmed = string.Empty;
		saveData.kony_harmed = string.Empty;
		saveData.youCredits = false;
		saveData.finished_once = false;
		SaveLoad.saveLoad.WriteData(saveData, saveFile);
		return saveData;
	}

	public void SaveUsedQuestions()
	{
		UsedQuestionsData usedQuestionsData = new UsedQuestionsData();
		GeneralController generalController = GeneralController.generalController;
		usedQuestionsData.used_questions_misc = PlayerPrefs.GetString("used_questions_misc");
		usedQuestionsData.used_questions_cinema = PlayerPrefs.GetString("used_questions_cinema");
		usedQuestionsData.used_questions_vidya = PlayerPrefs.GetString("used_questions_vidya");
		usedQuestionsData.used_questions_animation = PlayerPrefs.GetString("used_questions_animation");
		usedQuestionsData.used_questions_custom = PlayerPrefs.GetString("used_questions_custom");
		SaveLoad.saveLoad.WriteUsedQuestions(usedQuestionsData);
	}

	public void LoadUsedQuestions()
	{
		UsedQuestionsData usedQuestionsData = SaveLoad.saveLoad.LoadUsedQuestions();
		if (usedQuestionsData == null)
		{
			usedQuestionsData = ResetUsedQuestions();
		}
		ParseLoadedUsedQuestions(usedQuestionsData);
	}

	public void ParseLoadedUsedQuestions(UsedQuestionsData data)
	{
		GeneralController generalController = GeneralController.generalController;
		if (data.used_questions_misc != null)
		{
			PlayerPrefs.SetString("used_questions_misc", data.used_questions_misc);
			PlayerPrefs.SetString("used_questions_cinema", data.used_questions_cinema);
			PlayerPrefs.SetString("used_questions_vidya", data.used_questions_vidya);
			PlayerPrefs.SetString("used_questions_animation", data.used_questions_animation);
			if (data.used_questions_custom != null)
			{
				PlayerPrefs.SetString("used_questions_custom", data.used_questions_custom);
			}
		}
		else
		{
			ParseLoadedUsedQuestions(ResetUsedQuestions());
		}
	}

	public UsedQuestionsData ResetUsedQuestions()
	{
		UsedQuestionsData usedQuestionsData = new UsedQuestionsData();
		usedQuestionsData.used_questions_misc = string.Empty;
		usedQuestionsData.used_questions_cinema = string.Empty;
		usedQuestionsData.used_questions_vidya = string.Empty;
		usedQuestionsData.used_questions_animation = string.Empty;
		usedQuestionsData.used_questions_custom = string.Empty;
		return usedQuestionsData;
	}

	private bool IsSteamInitialized()
	{
		if (GeneralController.generalController.steam)
		{
			return SteamManager.Initialized;
		}
		return false;
	}

	private string StringListToString(List<string> list)
	{
		string text = string.Empty;
		foreach (string item in list)
		{
			text = ((!(text == string.Empty)) ? (text + "," + item) : (text + item));
		}
		return text;
	}

	private string IntListToString(List<int> list)
	{
		string text = string.Empty;
		foreach (int item in list)
		{
			text = ((!(text == string.Empty)) ? (text + "," + item) : (text + item));
		}
		return text;
	}

	private List<string> LoadStringList(string line)
	{
		List<string> list = new List<string>();
		string[] array = line.Split(new string[1] { "," }, StringSplitOptions.None);
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text != string.Empty && text != null)
			{
				list.Add(text);
			}
		}
		return list;
	}

	private List<int> LoadIntList(string line)
	{
		List<int> list = new List<int>();
		string[] array = line.Split(new string[1] { "," }, StringSplitOptions.None);
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text != string.Empty && text != null)
			{
				int item = int.Parse(text);
				list.Add(item);
			}
		}
		return list;
	}

	private int[] StringToIntArray(string line)
	{
		if (line == string.Empty)
		{
			return null;
		}
		string[] array = line.Split(new string[1] { "," }, StringSplitOptions.None);
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = int.Parse(array[i]);
		}
		return array2;
	}

	private string IntArrayToString(int[] array)
	{
		string text = string.Empty;
		for (int i = 0; i < array.Length; i++)
		{
			text = ((!(text == string.Empty)) ? (text + "," + array[i]) : (text + array[i]));
		}
		return text;
	}

	private string SkinsArrayToString(int[] skins)
	{
		string text = string.Empty;
		foreach (int num in skins)
		{
			text = text + num + "_";
		}
		return text.Substring(0, text.Length - 1);
	}

	private int[] SkinsStringToArray(string s)
	{
		string[] array = s.Split("_"[0]);
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = int.Parse(array[i]);
		}
		return array2;
	}
}
