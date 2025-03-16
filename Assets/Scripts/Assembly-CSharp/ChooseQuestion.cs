using System.Collections.Generic;
using UnityEngine;

public class ChooseQuestion : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	private Dictionary<string, List<Question>> q_lists;

	private Dictionary<string, List<int>> used_questions;

	private string cat;

	public int questionIndex;

	private int prevC = 5;

	private void Awake()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		q_lists = generalController.q_lists;
		used_questions = generalController.used_questions;
	}

	public Question NewQuestion()
	{
		CheckUnrepeatedQuestions();
		int unrepeatedQuestion = GetUnrepeatedQuestion();
		bool flag = false;
		while (!flag)
		{
			if ((q_lists[cat + "_" + generalController.lang][unrepeatedQuestion].c == "misc" && !generalController.misc) || (q_lists[cat + "_" + generalController.lang][unrepeatedQuestion].c == "vidya" && !generalController.vidya) || (q_lists[cat + "_" + generalController.lang][unrepeatedQuestion].c == "cinema" && !generalController.cinema) || (q_lists[cat + "_" + generalController.lang][unrepeatedQuestion].c == "animation" && !generalController.animation))
			{
				if (Random.Range(0, 20) != 0)
				{
					unrepeatedQuestion = GetUnrepeatedQuestion();
					flag = false;
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
		}
		used_questions[cat].Add(unrepeatedQuestion);
		generalController.used_questions = used_questions;
		questionIndex = unrepeatedQuestion;
		PlayerPrefs.SetString("used_questions_" + cat, PlayerPrefs.GetString("used_questions_" + cat) + "," + unrepeatedQuestion);
		generalController.SaveUsedQuestions();
		return q_lists[cat + "_" + generalController.lang][unrepeatedQuestion];
	}

	public Question RepeatQuestion()
	{
		return q_lists[cat + "_" + generalController.lang][questionIndex];
	}

	private int GetUnrepeatedQuestion()
	{
		bool flag = true;
		int count = q_lists["misc_" + generalController.lang].Count;
		int count2 = q_lists["vidya_" + generalController.lang].Count;
		int count3 = q_lists["cinema_" + generalController.lang].Count;
		int count4 = q_lists["animation_" + generalController.lang].Count;
		int count5 = q_lists["custom_" + generalController.lang].Count;
		int num = 0;
		cat = string.Empty;
		if (count5 > 0)
		{
			cat = "custom";
			num = Random.Range(0, count5);
			while (flag)
			{
				num++;
				flag = false;
				if (num >= count5)
				{
					num = 0;
				}
				for (int i = 0; i < used_questions[cat].Count; i++)
				{
					if (used_questions[cat][i] == num)
					{
						flag = true;
						break;
					}
				}
			}
			return num;
		}
		int num2 = Random.Range(0, 6);
		if (num2 == 5)
		{
			num2 = Random.Range(0, 4);
		}
		if (num2 == 4)
		{
			num2 = Random.Range(0, 3);
		}
		while (num2 == prevC)
		{
			num2 = Random.Range(0, 4);
		}
		prevC = num2;
		switch (num2)
		{
		case 0:
			cat = "misc";
			num = Random.Range(0, count);
			while (flag)
			{
				num++;
				flag = false;
				if (num >= count)
				{
					num = 0;
				}
				for (int m = 0; m < used_questions[cat].Count; m++)
				{
					if (used_questions[cat][m] == num)
					{
						flag = true;
						break;
					}
				}
			}
			break;
		case 1:
			cat = "vidya";
			num = Random.Range(0, count2);
			while (flag)
			{
				num++;
				flag = false;
				if (num >= count2)
				{
					num = 0;
				}
				for (int k = 0; k < used_questions[cat].Count; k++)
				{
					if (used_questions[cat][k] == num)
					{
						flag = true;
						break;
					}
				}
			}
			break;
		case 2:
			cat = "cinema";
			num = Random.Range(0, count3);
			while (flag)
			{
				num++;
				flag = false;
				if (num >= count3)
				{
					num = 0;
				}
				for (int l = 0; l < used_questions[cat].Count; l++)
				{
					if (used_questions[cat][l] == num)
					{
						flag = true;
						break;
					}
				}
			}
			break;
		case 3:
			cat = "animation";
			num = Random.Range(0, count4);
			while (flag)
			{
				num++;
				flag = false;
				if (num >= count4)
				{
					num = 0;
				}
				for (int j = 0; j < used_questions[cat].Count; j++)
				{
					if (used_questions[cat][j] == num)
					{
						flag = true;
						break;
					}
				}
			}
			break;
		}
		return num;
	}

	private void CheckUnrepeatedQuestions()
	{
		int count = q_lists["misc_" + generalController.lang].Count;
		int count2 = q_lists["vidya_" + generalController.lang].Count;
		int count3 = q_lists["cinema_" + generalController.lang].Count;
		int count4 = q_lists["animation_" + generalController.lang].Count;
		int count5 = q_lists["custom_" + generalController.lang].Count;
		int count6 = used_questions["misc"].Count;
		int count7 = used_questions["vidya"].Count;
		int count8 = used_questions["cinema"].Count;
		int count9 = used_questions["animation"].Count;
		int count10 = used_questions["custom"].Count;
		if (count6 >= count)
		{
			int num = count6 - count6 / 10;
			if (num == count6)
			{
				num--;
			}
			if (num == 0)
			{
				num = 1;
			}
			used_questions["misc"].RemoveRange(0, num);
			count = q_lists["misc_" + generalController.lang].Count;
			count6 = used_questions["misc"].Count;
			PlayerPrefs.SetString("used_questions_misc", string.Empty);
			string text = string.Empty;
			for (int i = 0; i < used_questions["misc"].Count; i++)
			{
				text = text + "," + used_questions["misc"][i];
			}
			PlayerPrefs.SetString("used_questions_misc", text);
		}
		if (count7 >= count2)
		{
			int num2 = count7 - count7 / 10;
			if (num2 == count7)
			{
				num2--;
			}
			if (num2 == 0)
			{
				num2 = 1;
			}
			used_questions["vidya"].RemoveRange(0, num2);
			count2 = q_lists["vidya_" + generalController.lang].Count;
			count7 = used_questions["vidya"].Count;
			PlayerPrefs.SetString("used_questions_vidya", string.Empty);
			string text2 = string.Empty;
			for (int j = 0; j < used_questions["vidya"].Count; j++)
			{
				text2 = text2 + "," + used_questions["vidya"][j];
			}
			PlayerPrefs.SetString("used_questions_vidya", text2);
		}
		if (count8 >= count3)
		{
			int num3 = count8 - count8 / 10;
			if (num3 == count8)
			{
				num3--;
			}
			if (num3 == 0)
			{
				num3 = 1;
			}
			used_questions["cinema"].RemoveRange(0, num3);
			count3 = q_lists["cinema_" + generalController.lang].Count;
			count8 = used_questions["cinema"].Count;
			PlayerPrefs.SetString("used_questions_cinema", string.Empty);
			string text3 = string.Empty;
			for (int k = 0; k < used_questions["cinema"].Count; k++)
			{
				text3 = text3 + "," + used_questions["cinema"][k];
			}
			PlayerPrefs.SetString("used_questions_cinema", text3);
		}
		if (count9 >= count4)
		{
			int num4 = count9 - count9 / 10;
			if (num4 == count9)
			{
				num4--;
			}
			if (num4 == 0)
			{
				num4 = 1;
			}
			used_questions["animation"].RemoveRange(0, num4);
			count4 = q_lists["animation_" + generalController.lang].Count;
			count9 = used_questions["animation"].Count;
			PlayerPrefs.SetString("used_questions_animation", string.Empty);
			string text4 = string.Empty;
			for (int l = 0; l < used_questions["animation"].Count; l++)
			{
				text4 = text4 + "," + used_questions["animation"][l];
			}
			PlayerPrefs.SetString("used_questions_animation", text4);
		}
		if (count10 >= count5)
		{
			if (count5 == 0)
			{
				return;
			}
			while (count10 >= count5)
			{
				int num5 = count10 - count10 / 10;
				if (num5 == count10)
				{
					num5--;
				}
				if (num5 == 0)
				{
					num5 = 1;
				}
				used_questions["custom"].RemoveRange(0, num5);
				count5 = q_lists["custom_" + generalController.lang].Count;
				count10 = used_questions["custom"].Count;
			}
			PlayerPrefs.SetString("used_questions_custom", string.Empty);
			string text5 = string.Empty;
			for (int m = 0; m < used_questions["custom"].Count; m++)
			{
				text5 = text5 + "," + used_questions["custom"][m];
			}
			PlayerPrefs.SetString("used_questions_custom", text5);
		}
		generalController.SaveUsedQuestions();
	}
}
