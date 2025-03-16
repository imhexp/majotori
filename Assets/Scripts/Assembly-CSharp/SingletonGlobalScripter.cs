using UnityEngine;

public class SingletonGlobalScripter : MonoBehaviour
{
	private static SingletonGlobalScripter instance;

	public void Awake()
	{
		if (instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}
}
