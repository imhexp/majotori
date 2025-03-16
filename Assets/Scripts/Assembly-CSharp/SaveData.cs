using System;
using System.IO;
using System.Xml.Serialization;

[Serializable]
[XmlRoot("SaveData")]
public class SaveData
{
	public string ava;

	public string bcde;

	public string fatima;

	public string gloria;

	public string hector_ingrid;

	public string juliet_romeo;

	public string kony;

	public string lariat;

	public string mariano;

	public string nikola;

	public string oliver;

	public string paca;

	public string queralt;

	public string sebastian;

	public string tsubasa;

	public string umberto_viviana;

	public string woolie_xiang;

	public string yvette_zelotes;

	public int wins;

	public int fails;

	public string deaths;

	public string oliver_harmed;

	public string kony_harmed;

	public bool youCredits;

	public bool finished_once;

	public object this[string propertyName]
	{
		get
		{
			return GetType().GetProperty(propertyName).GetValue(this, null);
		}
		set
		{
			GetType().GetProperty(propertyName).SetValue(this, value, null);
		}
	}

	public void Save(string path)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveData));
		using (StreamWriter textWriter = new StreamWriter(path))
		{
			xmlSerializer.Serialize(textWriter, this);
		}
	}

	public static SaveData Load(string path)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveData));
		using (StreamReader textReader = new StreamReader(path))
		{
			return xmlSerializer.Deserialize(textReader) as SaveData;
		}
	}
}
