using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
	public static SaveLoad saveLoad;

	private bool portablePermissions;

	private string sharedSavesPath;

	private string persistentSavesPath;

	private string portableSavesPath;

	private bool filesOnPortable;

	private bool filesOnPersistent;

	private bool filesOnSteam;

	private SteamManager steamManager;

	private int firstSaveFile = 1;

	private int lastSaveFile = 9;

	private bool initialized;

	private bool useShared;

	private void Start()
	{
		saveLoad = this;
		sharedSavesPath = Application.persistentDataPath + "/SharedSaves";
		persistentSavesPath = Application.persistentDataPath + "/Saves";
		portableSavesPath = Application.dataPath + "/../Saves";
		if (steamManager == null && GeneralController.generalController.steam)
		{
			steamManager = Object.FindObjectOfType<SteamManager>();
		}
		if (!IsSteamInitialized())
		{
			useShared = true;
			CheckPortablePermissions();
			EnsurePersistentPath();
			EnsureSharedPath();
			ManageMoveOldSaves();
			ManageCopyFromShared();
			UpdateSharedSaves();
		}
		initialized = true;
	}

	public bool IsInitialized()
	{
		return initialized;
	}

	private void CheckPortablePermissions()
	{
		portablePermissions = true;
		try
		{
			if (!Directory.Exists(portableSavesPath))
			{
				Directory.CreateDirectory(portableSavesPath);
			}
			string path = portableSavesPath + "/permissions_test.txt";
			SaveData saveData = new SaveData();
			saveData.Save(path);
			SaveData.Load(path);
			File.Delete(path);
		}
		catch
		{
			portablePermissions = false;
		}
	}

	private void EnsurePersistentPath()
	{
		if (!portablePermissions && !Directory.Exists(persistentSavesPath))
		{
			Directory.CreateDirectory(persistentSavesPath);
		}
	}

	private void EnsureSharedPath()
	{
		if (!Directory.Exists(sharedSavesPath))
		{
			Directory.CreateDirectory(sharedSavesPath);
		}
	}

	private void ManageMoveOldSaves()
	{
		bool flag = false;
		if (useShared)
		{
			for (int i = firstSaveFile; i <= lastSaveFile; i++)
			{
				if (File.Exists(Path.Combine(sharedSavesPath, "save" + i + ".xml")))
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			return;
		}
		if (useShared)
		{
			for (int j = firstSaveFile; j <= lastSaveFile; j++)
			{
				if (File.Exists(Path.Combine(persistentSavesPath + "/../", "save" + j + ".xml")))
				{
					File.Move(Path.Combine(persistentSavesPath + "/../", "save" + j + ".xml"), Path.Combine(sharedSavesPath, "save" + j + ".xml"));
				}
			}
			if (File.Exists(Path.Combine(persistentSavesPath + "/../", "usedQuestions.xml")))
			{
				File.Move(Path.Combine(persistentSavesPath + "/../", "usedQuestions.xml"), Path.Combine(sharedSavesPath, "usedQuestions.xml"));
			}
			return;
		}
		for (int k = firstSaveFile; k <= lastSaveFile; k++)
		{
			if (File.Exists(Path.Combine(persistentSavesPath + "/../", "save" + k + ".xml")))
			{
				File.Move(Path.Combine(persistentSavesPath + "/../", "save" + k + ".xml"), Path.Combine(persistentSavesPath, "save" + k + ".xml"));
			}
		}
		if (File.Exists(Path.Combine(persistentSavesPath + "/../", "usedQuestions.xml")))
		{
			File.Move(Path.Combine(persistentSavesPath + "/../", "usedQuestions.xml"), Path.Combine(persistentSavesPath, "usedQuestions.xml"));
		}
	}

	private void ManageCopyFromShared()
	{
		bool flag = false;
		for (int i = firstSaveFile; i <= lastSaveFile; i++)
		{
			if (File.Exists(Path.Combine(sharedSavesPath, "save" + i + ".xml")))
			{
				flag = true;
				break;
			}
		}
		for (int j = firstSaveFile; j <= lastSaveFile; j++)
		{
			if (File.Exists(Path.Combine(portableSavesPath, "save" + j + ".xml")))
			{
				filesOnPortable = true;
			}
			if (File.Exists(Path.Combine(persistentSavesPath, "save" + j + ".xml")))
			{
				filesOnPersistent = true;
			}
			if (filesOnPortable && filesOnPersistent)
			{
				break;
			}
		}
		if (portablePermissions && !filesOnPortable && flag)
		{
			for (int k = firstSaveFile; k <= lastSaveFile; k++)
			{
				if (File.Exists(Path.Combine(sharedSavesPath, "save" + k + ".xml")))
				{
					File.Copy(Path.Combine(sharedSavesPath, "save" + k + ".xml"), Path.Combine(portableSavesPath, "save" + k + ".xml"), true);
					filesOnPortable = true;
				}
			}
			if (filesOnPortable && File.Exists(Path.Combine(sharedSavesPath, "usedQuestions.xml")))
			{
				File.Copy(Path.Combine(sharedSavesPath, "usedQuestions.xml"), Path.Combine(portableSavesPath, "usedQuestions.xml"), true);
			}
		}
		else
		{
			if (portablePermissions || filesOnPersistent || !flag)
			{
				return;
			}
			for (int l = firstSaveFile; l <= lastSaveFile; l++)
			{
				if (File.Exists(Path.Combine(sharedSavesPath, "save" + l + ".xml")))
				{
					File.Copy(Path.Combine(sharedSavesPath, "save" + l + ".xml"), Path.Combine(persistentSavesPath, "save" + l + ".xml"), true);
					filesOnPersistent = true;
				}
			}
			if (filesOnPersistent && File.Exists(Path.Combine(sharedSavesPath, "usedQuestions.xml")))
			{
				File.Copy(Path.Combine(sharedSavesPath, "usedQuestions.xml"), Path.Combine(persistentSavesPath, "usedQuestions.xml"), true);
			}
		}
	}

	private void UpdateSharedSaves()
	{
		if (portablePermissions)
		{
			if (filesOnPortable)
			{
				ReplaceSharedSavesForPortableSaves();
			}
		}
		else if (!IsSteamInitialized() && filesOnPersistent)
		{
			ReplaceSharedSavesForPersistentSaves();
		}
	}

	private void ReplaceSharedSavesForPortableSaves()
	{
		for (int i = firstSaveFile; i <= lastSaveFile; i++)
		{
			if (File.Exists(Path.Combine(sharedSavesPath, "save" + i + ".xml")))
			{
				File.Delete(Path.Combine(sharedSavesPath, "save" + i + ".xml"));
			}
		}
		if (File.Exists(Path.Combine(sharedSavesPath, "usedQuestions.xml")))
		{
			File.Delete(Path.Combine(sharedSavesPath, "usedQuestions.xml"));
		}
		for (int j = firstSaveFile; j <= lastSaveFile; j++)
		{
			if (File.Exists(Path.Combine(portableSavesPath, "save" + j + ".xml")))
			{
				File.Copy(Path.Combine(portableSavesPath, "save" + j + ".xml"), Path.Combine(sharedSavesPath, "save" + j + ".xml"), true);
			}
		}
		if (File.Exists(Path.Combine(portableSavesPath, "usedQuestions.xml")))
		{
			File.Copy(Path.Combine(portableSavesPath, "usedQuestions.xml"), Path.Combine(sharedSavesPath, "usedQuestions.xml"), true);
		}
	}

	private void ReplaceSharedSavesForPersistentSaves()
	{
		for (int i = firstSaveFile; i <= lastSaveFile; i++)
		{
			if (File.Exists(Path.Combine(sharedSavesPath, "save" + i + ".xml")))
			{
				File.Delete(Path.Combine(sharedSavesPath, "save" + i + ".xml"));
			}
		}
		if (File.Exists(Path.Combine(sharedSavesPath, "usedQuestions.xml")))
		{
			File.Delete(Path.Combine(sharedSavesPath, "usedQuestions.xml"));
		}
		for (int j = firstSaveFile; j <= lastSaveFile; j++)
		{
			if (File.Exists(Path.Combine(persistentSavesPath, "save" + j + ".xml")))
			{
				File.Copy(Path.Combine(persistentSavesPath, "save" + j + ".xml"), Path.Combine(sharedSavesPath, "save" + j + ".xml"), true);
			}
		}
		if (File.Exists(Path.Combine(persistentSavesPath, "usedQuestions.xml")))
		{
			File.Copy(Path.Combine(persistentSavesPath, "usedQuestions.xml"), Path.Combine(sharedSavesPath, "usedQuestions.xml"), true);
		}
	}

	public void WriteData(SaveData data, int saveFile)
	{
		if (IsSteamInitialized())
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			byte[] array;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				binaryFormatter.Serialize(memoryStream, data);
				array = memoryStream.ToArray();
			}
			steamManager.SaveCloudData("save" + saveFile + ".xml", array, array.Length);
			return;
		}
		if (portablePermissions)
		{
			try
			{
				data.Save(Path.Combine(portableSavesPath, "save" + saveFile + ".xml"));
			}
			catch
			{
			}
		}
		else
		{
			data.Save(Path.Combine(persistentSavesPath, "save" + saveFile + ".xml"));
		}
		if (useShared)
		{
			data.Save(Path.Combine(sharedSavesPath, "save" + saveFile + ".xml"));
		}
	}

	public SaveData Load(int saveFile)
	{
		if (IsSteamInitialized())
		{
			if (steamManager.FileExists("save" + saveFile + ".xml"))
			{
				try
				{
					byte[] array = steamManager.LoadCloudData("save" + saveFile + ".xml");
					using (MemoryStream memoryStream = new MemoryStream())
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						memoryStream.Write(array, 0, array.Length);
						memoryStream.Seek(0L, SeekOrigin.Begin);
						return (SaveData)binaryFormatter.Deserialize(memoryStream);
					}
				}
				catch
				{
				}
			}
		}
		else if (portablePermissions && File.Exists(Path.Combine(portableSavesPath, "save" + saveFile + ".xml")))
		{
			try
			{
				return SaveData.Load(Path.Combine(portableSavesPath, "save" + saveFile + ".xml"));
			}
			catch
			{
			}
		}
		else if (!portablePermissions && File.Exists(Path.Combine(persistentSavesPath, "save" + saveFile + ".xml")))
		{
			return SaveData.Load(Path.Combine(persistentSavesPath, "save" + saveFile + ".xml"));
		}
		return null;
	}

	public void WriteUsedQuestions(UsedQuestionsData data)
	{
		if (IsSteamInitialized())
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			byte[] array;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				binaryFormatter.Serialize(memoryStream, data);
				array = memoryStream.ToArray();
			}
			steamManager.SaveCloudData("usedQuestions.xml", array, array.Length);
			return;
		}
		if (portablePermissions)
		{
			try
			{
				data.Save(Path.Combine(portableSavesPath, "usedQuestions.xml"));
			}
			catch
			{
			}
		}
		else
		{
			data.Save(Path.Combine(persistentSavesPath, "usedQuestions.xml"));
		}
		if (useShared)
		{
			data.Save(Path.Combine(sharedSavesPath, "usedQuestions.xml"));
		}
	}

	public UsedQuestionsData LoadUsedQuestions()
	{
		if (IsSteamInitialized())
		{
			if (steamManager.FileExists("usedQuestions.xml"))
			{
				try
				{
					byte[] array = steamManager.LoadCloudData("usedQuestions.xml");
					using (MemoryStream memoryStream = new MemoryStream())
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						memoryStream.Write(array, 0, array.Length);
						memoryStream.Seek(0L, SeekOrigin.Begin);
						return (UsedQuestionsData)binaryFormatter.Deserialize(memoryStream);
					}
				}
				catch
				{
				}
			}
		}
		else if (portablePermissions && File.Exists(Path.Combine(portableSavesPath, "usedQuestions.xml")))
		{
			try
			{
				return UsedQuestionsData.Load(Path.Combine(portableSavesPath, "usedQuestions.xml"));
			}
			catch
			{
			}
		}
		else if (!portablePermissions && File.Exists(Path.Combine(persistentSavesPath, "usedQuestions.xml")))
		{
			return UsedQuestionsData.Load(Path.Combine(persistentSavesPath, "usedQuestions.xml"));
		}
		return null;
	}

	private bool IsSteamInitialized()
	{
		return false;
	}
}
