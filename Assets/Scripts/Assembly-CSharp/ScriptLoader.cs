using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ScriptLoader : MonoBehaviour
{
	private string[] abc = new string[26]
	{
		"a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
		"k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
		"u", "v", "w", "x", "y", "z"
	};

	public void LoadScript(string file, string lang, string route, out List<string> script_lines, out List<string> win_lines, out List<string> lose_lines)
	{
		script_lines = new List<string>();
		win_lines = new List<string>();
		lose_lines = new List<string>();
		TextAsset textAsset = Resources.Load("Stories/" + lang + "/" + file) as TextAsset;
		if (textAsset == null)
		{
			Debug.Log("Could not read script file " + lang + "/" + file + " on ScriptLoader");
		}
		string[] array = textAsset.text.Split("\n"[0]);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = array[i].Trim();
		}
		string[] array2 = new string[2];
		array2 = Regex.Split(textAsset.text, "<" + route + ">");
		array2 = Regex.Split(array2[1], "</" + route + ">");
		string text = array2[0];
		array = text.Split("\n"[0]);
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = array[j].Trim();
		}
		for (int k = 0; k < array.Length; k++)
		{
			if (array[k].Contains("<txt>") || array[k].Contains("<img>") || array[k].Contains("<quiz>"))
			{
				script_lines.Add(array[k]);
			}
		}
		array2 = Regex.Split(textAsset.text, "<" + route + "1>");
		if (array2.Length != 2)
		{
			Debug.Log("Couldn't find block " + route + "1 on file " + lang + "/" + file + " on ScriptLoader.");
		}
		array2 = Regex.Split(array2[1], "</" + route + "1>");
		text = array2[0];
		array = text.Split("\n"[0]);
		for (int l = 0; l < array.Length; l++)
		{
			array[l] = array[l].Trim();
		}
		for (int m = 0; m < array.Length; m++)
		{
			if (array[m].Contains("<txt>") || array[m].Contains("<img>") || array[m].Contains("<quiz>"))
			{
				win_lines.Add(array[m]);
			}
		}
		array2 = Regex.Split(textAsset.text, "<" + route + "0>");
		if (array2.Length != 2)
		{
			Debug.Log("Couldn't find block " + route + "0 on file " + lang + "/" + file + " on ScriptLoader.");
		}
		array2 = Regex.Split(array2[1], "</" + route + "0>");
		text = array2[0];
		array = text.Split("\n"[0]);
		for (int n = 0; n < array.Length; n++)
		{
			array[n] = array[n].Trim();
		}
		for (int num = 0; num < array.Length; num++)
		{
			if (array[num].Contains("<txt>") || array[num].Contains("<img>") || array[num].Contains("<quiz>"))
			{
				lose_lines.Add(array[num]);
			}
		}
	}

	public bool CharacterEnd(string file, string lang, Dictionary<string, string> routes)
	{
		if (file == "bcde" && routes[file] == "a0")
		{
			return false;
		}
		if (file == "woolie_xiang" && (routes[file] == "a0a1" || routes[file] == "a0a0"))
		{
			return false;
		}
		TextAsset textAsset = Resources.Load("Stories/" + lang + "/" + file) as TextAsset;
		string[] array = textAsset.text.Split("\n"[0]);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = array[i].Trim();
		}
		for (int j = 0; j < array.Length; j++)
		{
			for (int k = 0; k < abc.Length; k++)
			{
				if (array[j].Contains("<" + routes[file] + abc[k] + ">"))
				{
					return false;
				}
			}
		}
		return true;
	}
}
