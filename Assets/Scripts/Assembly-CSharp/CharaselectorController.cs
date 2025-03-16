using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaselectorController : MonoBehaviour
{
	public GameObject characards;

	public GameObject characard_selection;

	public GameObject cardL;

	public GameObject cardM;

	public GameObject cardR;

	public GameObject LPanel;

	public GameObject RPanel;

	public GameObject MPanel;

	public string file1;

	public string file2;

	public string file3;

	public string route1;

	public string route2;

	public string route3;

	public string name1;

	public string name2;

	public string name3;

	public int cards;

	public GameObject nameL;

	public GameObject nameM;

	public GameObject nameR;

	private GameObject globalScripter;

	private GeneralController generalController;

	public GameObject transition;

	private float exp = 2f;

	private void Start()
	{
		transition.GetComponent<Animator>().SetBool("visible", true);
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		generalController.currentScene = "charaselector";
		PickCards();
		AdjustPanels();
		generalController.CharaselectorAudioSource.volume = Mathf.Pow((float)generalController.musicVol / 100f, exp);
		generalController.CharaselectorAudioSource.Play();
		GC.Collect();
	}

	private void AdjustPanels()
	{
		if (cards == 2)
		{
			LPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-0.1675f, 0f);
			RPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.1675f, 0f);
			MPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-2f, 0f);
			characard_selection.GetComponent<Animator>().SetBool("2cards", true);
		}
		else if (cards == 1)
		{
			LPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-2f, 0f);
			RPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(2f, 0f);
		}
	}

	private void PickCards()
	{
		string[] files = generalController.files;
		Dictionary<string, string> routes = generalController.routes;
		cards = 0;
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		for (int i = 0; i < files.Length; i++)
		{
			if (!(files[i] == "lariat"))
			{
				if (routes[files[i]] == string.Empty)
				{
					list.Add(files[i]);
				}
				else if (routes[files[i]] != "end")
				{
					list2.Add(files[i]);
				}
			}
		}
		string text = string.Empty;
		if (list2.Count > 0)
		{
			for (int j = 0; j < list2.Count; j++)
			{
				if (list2[j] == generalController.file)
				{
					text = generalController.file;
				}
			}
		}
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = string.Empty;
		if (list.Count + list2.Count > 2)
		{
			cards = 3;
			if (text != string.Empty)
			{
				text2 = text;
				if (list.Count > 0)
				{
					text3 = list[UnityEngine.Random.Range(0, list.Count)];
					if (list2.Count > 0 && list2[0] != text)
					{
						if (list2.Count < 3 && UnityEngine.Random.Range(0, 2) == 0 && list.Count > 1)
						{
							text4 = list[UnityEngine.Random.Range(0, list.Count)];
							int num = 0;
							while (text4 == text3 && num < 1000)
							{
								text4 = list[UnityEngine.Random.Range(0, list.Count)];
								num++;
							}
						}
						else
						{
							text4 = list2[UnityEngine.Random.Range(0, list2.Count)];
							int num2 = 0;
							while (text4 == text2 && num2 < 1000)
							{
								text4 = list2[UnityEngine.Random.Range(0, list2.Count)];
								num2++;
							}
						}
					}
					else
					{
						text4 = list[UnityEngine.Random.Range(0, list.Count)];
						int num3 = 0;
						while (text4 == text3 && num3 < 1000)
						{
							text4 = list[UnityEngine.Random.Range(0, list.Count)];
							num3++;
						}
					}
				}
				else
				{
					text3 = list2[UnityEngine.Random.Range(0, list2.Count)];
					int num4 = 0;
					while (text3 == text2 && num4 < 1000)
					{
						text3 = list2[UnityEngine.Random.Range(0, list2.Count)];
						num4++;
					}
					text4 = list2[UnityEngine.Random.Range(0, list2.Count)];
					num4 = 0;
					while ((text4 == text2 || text4 == text3) && num4 < 1000)
					{
						text4 = list2[UnityEngine.Random.Range(0, list2.Count)];
						num4++;
					}
				}
			}
			else if (list.Count >= 2)
			{
				text2 = list[UnityEngine.Random.Range(0, list.Count)];
				text3 = list[UnityEngine.Random.Range(0, list.Count)];
				int num5 = 0;
				while (text3 == text2 && num5 < 1000)
				{
					text3 = list[UnityEngine.Random.Range(0, list.Count)];
					num5++;
				}
				if (num5 >= 1000)
				{
					text2 = list[0];
					text3 = list[1];
				}
				if (list2.Count > 0 && list2[0] != text)
				{
					text4 = list2[UnityEngine.Random.Range(0, list2.Count)];
				}
				else
				{
					text4 = list[UnityEngine.Random.Range(0, list.Count)];
					num5 = 0;
					while ((text4 == text2 || text4 == text3) && num5 < 100)
					{
						text4 = list[UnityEngine.Random.Range(0, list.Count)];
						num5++;
					}
					if (num5 >= 100)
					{
						text2 = list[0];
						text3 = list[1];
						text4 = list[2];
					}
				}
			}
			else if (list.Count == 1)
			{
				text2 = list[0];
				text3 = list2[UnityEngine.Random.Range(0, list2.Count)];
				text4 = list2[UnityEngine.Random.Range(0, list2.Count)];
				int num6 = 0;
				while (text4 == text3 && num6 < 100)
				{
					text4 = list2[UnityEngine.Random.Range(0, list2.Count)];
					num6++;
				}
				if (num6 >= 100)
				{
					text3 = list2[0];
					text4 = list2[1];
				}
			}
			else
			{
				text2 = list2[UnityEngine.Random.Range(0, list2.Count)];
				text3 = list2[UnityEngine.Random.Range(0, list2.Count)];
				int num7 = 0;
				while (text3 == text2 && num7 < 100)
				{
					text3 = list2[UnityEngine.Random.Range(0, list2.Count)];
					num7++;
				}
				if (num7 >= 100)
				{
					text2 = list2[0];
					text3 = list2[1];
				}
				text4 = list2[UnityEngine.Random.Range(0, list2.Count)];
				num7 = 0;
				while ((text4 == text2 || text4 == text3) && num7 < 100)
				{
					text4 = list2[UnityEngine.Random.Range(0, list2.Count)];
					num7++;
				}
				if (num7 >= 100)
				{
					text2 = list2[0];
					text3 = list2[1];
					text4 = list2[1];
				}
			}
		}
		else if (list.Count == 1 && list2.Count == 1)
		{
			cards = 2;
			text2 = list[0];
			text4 = list2[0];
		}
		else if (list.Count == 0 && list2.Count == 2)
		{
			cards = 2;
			text2 = list2[0];
			text4 = list2[1];
		}
		else if (list.Count == 0 && list2.Count == 1)
		{
			cards = 1;
			text3 = list2[0];
		}
		else if (list.Count == 2 && list2.Count == 0)
		{
			cards = 2;
			text2 = list[0];
			text4 = list[1];
		}
		else if (list.Count == 1 && list2.Count == 0)
		{
			cards = 1;
			text3 = list[0];
		}
		else
		{
			cards = 1;
			text3 = "lariat";
		}
		if (cards == 3 && (text2 == text3 || text2 == text4 || text3 == text4))
		{
			if (list2.Count > 2)
			{
				text2 = list2[0];
				text3 = list2[1];
				text4 = list2[2];
			}
			else if (list.Count > 2)
			{
				text2 = list[0];
				text3 = list[1];
				text4 = list[2];
			}
			else if (list2.Count > 1)
			{
				text2 = list2[0];
				text3 = list2[1];
				text4 = list[0];
			}
			else if (list.Count > 1)
			{
				text2 = list[0];
				text3 = list[1];
				text4 = list2[0];
			}
		}
		if (cards == 3)
		{
			int num8 = UnityEngine.Random.Range(0, 3);
			string text5 = text2;
			string text6 = text3;
			string text7 = text4;
			switch (num8)
			{
			case 1:
				text2 = text6;
				text3 = text7;
				text4 = text5;
				break;
			case 2:
				text2 = text7;
				text3 = text5;
				text4 = text6;
				break;
			}
		}
		else if (cards == 2)
		{
			int num9 = UnityEngine.Random.Range(0, 2);
			string text8 = text2;
			string text9 = text4;
			if (num9 == 1)
			{
				text2 = text9;
				text4 = text8;
			}
		}
		route1 = string.Empty;
		route2 = string.Empty;
		route3 = string.Empty;
		if (text2 != string.Empty)
		{
			route1 = generalController.routes[text2];
		}
		if (text3 != string.Empty)
		{
			route2 = generalController.routes[text3];
		}
		if (text4 != string.Empty)
		{
			route3 = generalController.routes[text4];
		}
		for (int k = 1; k < 4; k++)
		{
			string empty = string.Empty;
			switch (k)
			{
			case 1:
				empty = text2;
				break;
			case 2:
				empty = text3;
				break;
			default:
				empty = text4;
				break;
			}
			string empty2 = string.Empty;
			switch (k)
			{
			case 1:
				empty2 = route1;
				break;
			case 2:
				empty2 = route2;
				break;
			default:
				empty2 = route3;
				break;
			}
			switch (empty + "_" + empty2)
			{
			case "ava_a1a1a1a1a0":
			case "bcde_a1":
				empty2 = ((UnityEngine.Random.Range(0, 2) != 0) ? (empty2 + "b") : (empty2 + "a"));
				break;
			case "queralt_":
				empty2 = ((!(UnityEngine.Random.Range(0f, 1f) < 0.9f)) ? (empty2 + "b") : (empty2 + "a"));
				break;
			case "kony_":
				switch (UnityEngine.Random.Range(0, 3))
				{
				case 0:
					empty2 = "a";
					break;
				case 1:
					empty2 = "b";
					break;
				default:
					empty2 = "c";
					break;
				}
				break;
			case "gloria_":
				switch (UnityEngine.Random.Range(0, 4))
				{
				case 0:
					empty2 = "a";
					break;
				case 1:
					empty2 = "b";
					break;
				case 2:
					empty2 = "c";
					break;
				default:
					empty2 = "d";
					break;
				}
				break;
			case "bcde_a0":
				empty2 = ((UnityEngine.Random.Range(0, 2) != 0) ? "a1b0a" : "a1a0a");
				break;
			case "woolie_xiang_a0a1":
			case "woolie_xiang_a0a0":
				empty2 = "a1a0a";
				break;
			default:
				empty2 += "a";
				break;
			}
			switch (k)
			{
			case 1:
				route1 = empty2;
				break;
			case 2:
				route2 = empty2;
				break;
			default:
				route3 = empty2;
				break;
			}
		}
		for (int l = 1; l < 4; l++)
		{
			string empty3 = string.Empty;
			switch (l)
			{
			case 1:
				empty3 = text2;
				break;
			case 2:
				empty3 = text3;
				break;
			default:
				empty3 = text4;
				break;
			}
			string empty4 = string.Empty;
			switch (l)
			{
			case 1:
				empty4 = route1;
				break;
			case 2:
				empty4 = route2;
				break;
			default:
				empty4 = route3;
				break;
			}
			switch (empty3)
			{
			case "ava":
				empty3 = "Ava";
				break;
			case "bcde":
				switch (empty4)
				{
				case "a":
				case "a1a1a1a":
				case "a1b1a1a":
					empty3 = "Carl";
					break;
				case "a1b":
				case "a1b1a":
					empty3 = "Barbara";
					break;
				case "a1a":
				case "a1a1a":
					empty3 = "Daisy";
					break;
				default:
					empty3 = "Elsa";
					break;
				}
				break;
			case "fatima":
				empty3 = "Fatima";
				break;
			case "gloria":
				empty3 = "Gloria";
				break;
			case "hector_ingrid":
				empty3 = ((!(empty4 == "a")) ? "Ingrid" : "Hector");
				break;
			case "juliet_romeo":
				empty3 = ((!(empty4 == "a") && !(empty4 == "a1a1a")) ? "Romeo" : "Juliet");
				break;
			case "kony":
				empty3 = "Kony";
				break;
			case "lariat":
				empty3 = "Lariat";
				break;
			case "mariano":
				empty3 = "Mariano";
				break;
			case "nikola":
				empty3 = "Nikola";
				break;
			case "oliver":
				empty3 = "Oliver";
				break;
			case "paca":
				empty3 = "Paca";
				break;
			case "queralt":
				empty3 = "Queralt";
				break;
			case "sebastian":
				empty3 = "Sebastian";
				break;
			case "tsubasa":
				empty3 = "Tsubasa";
				break;
			case "umberto_viviana":
				empty3 = ((!(empty4 == "a")) ? "Viviana" : "Umberto");
				break;
			case "woolie_xiang":
				empty3 = ((!(empty4 == "a1a1a") && !(empty4 == "a1a0a")) ? "Woolie" : "Xiang");
				break;
			case "yvette_zelotes":
				empty3 = ((!(empty4 == "a")) ? "Zelotes" : "Yvette");
				break;
			}
			switch (l)
			{
			case 1:
				name1 = empty3;
				break;
			case 2:
				name2 = empty3;
				break;
			default:
				name3 = empty3;
				break;
			}
		}
		file1 = text2;
		file2 = text3;
		file3 = text4;
		cardL.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(text2 + "_" + route1);
		cardM.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(text3 + "_" + route2);
		cardR.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(text4 + "_" + route3);
		nameL.GetComponent<Text>().text = name1;
		nameM.GetComponent<Text>().text = name2;
		nameR.GetComponent<Text>().text = name3;
		characards.GetComponent<Animator>().SetInteger("cards", cards);
	}

	public void Shuffle()
	{
		generalController.file = string.Empty;
		PickCards();
	}
}
