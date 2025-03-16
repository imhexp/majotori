using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class QuestionsLoader : MonoBehaviour
{
	public void LoadQuestions(out Dictionary<string, List<Question>> q_lists, out Dictionary<string, List<int>> used_questions)
	{
		q_lists = new Dictionary<string, List<Question>>();
		used_questions = new Dictionary<string, List<int>>();
		string[] array = new string[6] { "vidya", "animation", "anime", "cinema", "misc", "custom" };
		for (int i = 0; i < array.Length; i++)
		{
			List<Question> q_list = new List<Question>();
			string text = "en";
			LoadQuestionsFromFile(array[i], text, out q_list);
			if (array[i] == "anime")
			{
				q_lists["animation_" + text].AddRange(q_list);
			}
			else
			{
				q_lists.Add(array[i] + "_" + text, q_list);
			}
			q_list = new List<Question>();
			text = "es";
			LoadQuestionsFromFile(array[i], text, out q_list);
			if (array[i] == "anime")
			{
				q_lists["animation_" + text].AddRange(q_list);
			}
			else
			{
				q_lists.Add(array[i] + "_" + text, q_list);
			}
		}
		for (int j = 0; j < array.Length; j++)
		{
			string[] array2 = PlayerPrefs.GetString("used_questions_" + array[j]).Split(","[0]);
			List<int> list = new List<int>();
			for (int k = 0; k < array2.Length; k++)
			{
				int result;
				if (int.TryParse(array2[k], out result))
				{
					list.Add(int.Parse(array2[k]));
				}
			}
			used_questions.Add(array[j], list);
		}
	}

	public void LoadQuestionsFromFile(string file, string lang, out List<Question> q_list)
	{
		q_list = new List<Question>();
		TextAsset textAsset = new TextAsset();
		string[] array;
		if (file == "custom")
		{
			string path = Path.GetFullPath(".") + "/custom_questions.txt";
			string path2 = Application.persistentDataPath + "/custom_questions.txt";
			List<string> list = new List<string>();
			if (File.Exists(path))
			{
				StreamReader streamReader = new StreamReader(path);
				string empty = string.Empty;
				using (streamReader)
				{
					do
					{
						empty = streamReader.ReadLine();
						if (empty != null)
						{
							list.Add(empty);
						}
					}
					while (empty != null);
				}
				array = list.ToArray();
				streamReader.Close();
			}
			else
			{
				if (!File.Exists(path2))
				{
					return;
				}
				StreamReader streamReader3 = new StreamReader(path2);
				string empty2 = string.Empty;
				using (streamReader3)
				{
					do
					{
						empty2 = streamReader3.ReadLine();
						if (empty2 != null)
						{
							list.Add(empty2);
						}
					}
					while (empty2 != null);
				}
				array = list.ToArray();
				streamReader3.Close();
			}
		}
		else
		{
			textAsset = Resources.Load("Questions/" + lang + "/" + file) as TextAsset;
			if (textAsset == null)
			{
				Debug.Log("Could not read questions file [" + lang + "/" + file + "] on LoadQuestionsFromFile");
			}
			array = textAsset.text.Trim().Split("\n"[0]);
		}
		List<int> list2 = new List<int>();
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = string.Empty;
		string empty3 = string.Empty;
		string empty4 = string.Empty;
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].Length <= 1)
			{
				continue;
			}
			if (text == string.Empty)
			{
				string[] array2 = Regex.Split(array[i], "<q>");
				if (array2.Length == 2 && array2[1].Length > 2)
				{
					text = array2[1];
				}
				else
				{
					list2.Add(i);
				}
			}
			else if (text2 == string.Empty)
			{
				string[] array2 = Regex.Split(array[i], "<a1>");
				if (array2.Length == 2)
				{
					text2 = array2[1];
				}
				else
				{
					list2.Add(i);
				}
			}
			else if (text3 == string.Empty)
			{
				string[] array2 = Regex.Split(array[i], "<a2>");
				if (array2.Length == 2)
				{
					text3 = array2[1];
				}
				else
				{
					list2.Add(i);
				}
			}
			else if (text4 == string.Empty)
			{
				string[] array2 = Regex.Split(array[i], "<a3>");
				if (array2.Length == 2)
				{
					text4 = array2[1];
				}
				else
				{
					list2.Add(i);
				}
			}
			else if (empty3 == string.Empty)
			{
				string[] array2 = Regex.Split(array[i], "<a4>");
				if (array2.Length == 2)
				{
					num++;
					empty3 = array2[1];
					empty4 = ((!(file == "anime")) ? file : "animation");
					q_list.Add(new Question(text, text2, text3, text4, empty3, empty4));
					text = string.Empty;
					text2 = string.Empty;
					text3 = string.Empty;
					text4 = string.Empty;
					empty3 = string.Empty;
				}
				else
				{
					list2.Add(i + 1);
				}
			}
		}
		if (list2.Count > 0)
		{
			Debug.Log("ERROR LINES IN FILE " + lang + "/" + file);
			for (int j = 0; j < list2.Count; j++)
			{
				Debug.Log("ERROR LINE: " + list2[j]);
			}
		}
	}
}
