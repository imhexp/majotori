using System;
using System.IO;
using System.Xml.Serialization;

[Serializable]
[XmlRoot("UsedQuestionsData")]
public class UsedQuestionsData
{
	public string used_questions_misc;

	public string used_questions_cinema;

	public string used_questions_vidya;

	public string used_questions_animation;

	public string used_questions_custom;

	public void Save(string path)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(UsedQuestionsData));
		using (StreamWriter textWriter = new StreamWriter(path))
		{
			xmlSerializer.Serialize(textWriter, this);
		}
	}

	public static UsedQuestionsData Load(string path)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(UsedQuestionsData));
		using (StreamReader textReader = new StreamReader(path))
		{
			return xmlSerializer.Deserialize(textReader) as UsedQuestionsData;
		}
	}
}
