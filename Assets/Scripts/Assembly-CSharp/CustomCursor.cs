using UnityEngine;

public class CustomCursor : MonoBehaviour
{
	public Texture2D cursor;

	private GameObject globalScripter;

	private GeneralController generalController;

	private float timer;

	private float limit = 5f;

	private Vector3 cursorPosition;

	private bool visible = true;

	private void Start()
	{
		Cursor.SetCursor(cursor, new Vector2(0f, 0f), CursorMode.ForceSoftware);
		cursorPosition = Input.mousePosition;
		FindGeneralController();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Cursor.visible = true;
			visible = true;
			if (generalController == null)
			{
				FindGeneralController();
			}
			if (generalController.currentScene == "narrator")
			{
				limit = 5f;
			}
			else if (generalController.currentScene == "quiz")
			{
				limit = 20f;
			}
			else
			{
				limit = 10f;
			}
		}
		else if (cursorPosition != Input.mousePosition && !visible)
		{
			Cursor.visible = true;
			visible = true;
			timer = 0f;
		}
		else if (visible)
		{
			timer += Time.deltaTime;
			if (timer > limit)
			{
				if (generalController == null)
				{
					FindGeneralController();
				}
				if (generalController.currentScene == "quiz" && limit < 10f)
				{
					limit = 10f;
				}
				else
				{
					Cursor.visible = false;
					visible = false;
					timer = 0f;
					if (generalController == null)
					{
						FindGeneralController();
					}
					if (generalController.currentScene == "narrator")
					{
						limit = 3f;
					}
					else if (generalController.currentScene == "quiz")
					{
						limit = 10f;
					}
					else
					{
						limit = 6f;
					}
				}
			}
		}
		if (cursorPosition != Input.mousePosition)
		{
			generalController.globalInput.inputMethod = "mouse";
		}
		cursorPosition = Input.mousePosition;
	}

	private void FindGeneralController()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
	}
}
