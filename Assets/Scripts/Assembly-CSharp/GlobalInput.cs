using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalInput : MonoBehaviour
{
	private GeneralController generalController;

	private QuizController quizController;

	private GameObject screenPanelEnd;

	public GameObject screenPanel;

	public bool pulsable = true;

	public string inputMethod = string.Empty;

	public bool up;

	public bool down;

	public bool left;

	public bool right;

	public bool enter;

	public bool back;

	public bool esc;

	public bool start;

	private bool upRegistered;

	private bool downRegistered;

	private bool leftRegistered;

	private bool rightRegistered;

	private float timer;

	private int frameCount;

	private int AxisXYStrikes;

	private bool AxisXYMalfunctioning;

	private int Axis45Strikes;

	private bool Axis45Malfunctioning;

	private int Axis67Strikes;

	private bool Axis67Malfunctioning;

	private float afkTimer;

	private void Start()
	{
		generalController = base.gameObject.GetComponent<GeneralController>();
	}

	private void Update()
	{
		if (frameCount < 11)
		{
			AxisCheck();
			return;
		}
		bool mouseButtonDown = Input.GetMouseButtonDown(0);
		bool keyDown = Input.GetKeyDown("return");
		bool keyDown2 = Input.GetKeyDown("space");
		bool keyDown3 = Input.GetKeyDown("backspace");
		bool keyDown4 = Input.GetKeyDown("escape");
		bool key = Input.GetKey("up");
		bool key2 = Input.GetKey("w");
		bool key3 = Input.GetKey("down");
		bool key4 = Input.GetKey("s");
		bool key5 = Input.GetKey("left");
		bool key6 = Input.GetKey("a");
		bool key7 = Input.GetKey("right");
		bool key8 = Input.GetKey("d");
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		bool flag8 = false;
		bool flag9 = false;
		bool flag10 = false;
		bool flag11 = false;
		bool flag12 = false;
		bool flag13 = false;
		bool flag14 = false;
		bool flag15 = false;
		bool flag16 = false;
		flag = Input.GetButtonDown("AButton");
		flag2 = Input.GetButtonDown("BButton");
		flag3 = Input.GetButtonDown("BackButton");
		flag4 = Input.GetButtonDown("StartButton");
		if (Input.GetAxis("YAxisUp") < -0.5f)
		{
			flag5 = true;
		}
		if (Input.GetAxis("7AxisUp") > 0.5f)
		{
			flag6 = true;
		}
		if (Input.GetAxis("5AxisUp") < -0.5f)
		{
			flag7 = true;
		}
		if (Input.GetAxis("YAxisDown") > 0.5f)
		{
			flag8 = true;
		}
		if (Input.GetAxis("7AxisDown") < -0.5f)
		{
			flag9 = true;
		}
		if (Input.GetAxis("5AxisDown") > 0.5f)
		{
			flag10 = true;
		}
		if (Input.GetAxis("XAxisUp") < -0.5f)
		{
			flag11 = true;
		}
		if (Input.GetAxis("6AxisUp") < -0.5f)
		{
			flag12 = true;
		}
		if (Input.GetAxis("4AxisUp") < -0.5f)
		{
			flag13 = true;
		}
		if (Input.GetAxis("XAxisDown") > 0.5f)
		{
			flag14 = true;
		}
		if (Input.GetAxis("6AxisDown") > 0.5f)
		{
			flag15 = true;
		}
		if (Input.GetAxis("4AxisDown") > 0.5f)
		{
			flag16 = true;
		}
		if (flag || keyDown || keyDown2)
		{
			inputMethod = "keys";
			enter = true;
			afkTimer = 0f;
		}
		else
		{
			enter = false;
		}
		if (flag2 || keyDown3)
		{
			inputMethod = "keys";
			back = true;
			afkTimer = 0f;
		}
		else
		{
			back = false;
		}
		if (flag3 || keyDown4)
		{
			inputMethod = "keys";
			esc = true;
			afkTimer = 0f;
		}
		else
		{
			esc = false;
		}
		if (flag4)
		{
			inputMethod = "keys";
			start = true;
			afkTimer = 0f;
		}
		else
		{
			start = false;
		}
		if (key || key2 || (flag5 && !AxisXYMalfunctioning) || (flag6 && !Axis67Malfunctioning) || (flag7 && !Axis45Malfunctioning))
		{
			inputMethod = "keys";
			up = true;
			afkTimer = 0f;
		}
		else
		{
			up = false;
			upRegistered = false;
		}
		if (key3 || key4 || (flag8 && !AxisXYMalfunctioning) || (flag9 && !Axis67Malfunctioning) || (flag10 && !Axis45Malfunctioning))
		{
			inputMethod = "keys";
			down = true;
			afkTimer = 0f;
		}
		else
		{
			down = false;
			downRegistered = false;
		}
		if (key5 || key6 || (flag11 && !AxisXYMalfunctioning) || (flag12 && !Axis67Malfunctioning) || (flag13 && !Axis45Malfunctioning))
		{
			inputMethod = "keys";
			left = true;
			afkTimer = 0f;
		}
		else
		{
			left = false;
			leftRegistered = false;
		}
		if (key7 || key8 || (flag14 && !AxisXYMalfunctioning) || (flag15 && !Axis67Malfunctioning) || (flag16 && !Axis45Malfunctioning))
		{
			inputMethod = "keys";
			right = true;
			afkTimer = 0f;
		}
		else
		{
			right = false;
			rightRegistered = false;
		}
		if (mouseButtonDown)
		{
			inputMethod = "mouse";
			afkTimer = 0f;
		}
		if (upRegistered || downRegistered || leftRegistered || rightRegistered)
		{
			timer += Time.deltaTime;
			if ((double)timer >= 0.4)
			{
				if (up && !upRegistered)
				{
					up = true;
				}
				if (down && !downRegistered)
				{
					down = true;
				}
				if (left && !leftRegistered)
				{
					left = true;
				}
				if (right && !rightRegistered)
				{
					right = true;
				}
				SettingsInput settingsInput = null;
				if (generalController.currentScene == "mainmenu")
				{
					settingsInput = GameObject.Find("MainmenuScripter").GetComponent<SettingsInput>();
				}
				else if (generalController.currentScene == "narrator" || generalController.currentScene == "quiz")
				{
					settingsInput = GameObject.Find("NarratorScripter").GetComponent<SettingsInput>();
				}
				if (settingsInput == null)
				{
					timer = 0.1f;
				}
				else if (settingsInput.inSettings)
				{
					timer = 0.3f;
				}
				else
				{
					timer = 0.1f;
				}
			}
			else
			{
				if (up && upRegistered)
				{
					up = false;
				}
				if (down && downRegistered)
				{
					down = false;
				}
				if (left && leftRegistered)
				{
					left = false;
				}
				if (right && rightRegistered)
				{
					right = false;
				}
			}
		}
		else
		{
			timer = 0f;
		}
		if (up && !upRegistered)
		{
			upRegistered = true;
		}
		if (down && !downRegistered)
		{
			downRegistered = true;
		}
		if (left && !leftRegistered)
		{
			leftRegistered = true;
		}
		if (right && !rightRegistered)
		{
			rightRegistered = true;
		}
		if (Input.GetKeyDown("left alt") && Input.GetKeyDown("enter"))
		{
			Screen.fullScreen = !Screen.fullScreen;
			PlayerPrefs.SetString("fullscreen", "true");
		}
		if (Input.GetKeyDown("r") && generalController.justTrivia)
		{
			generalController.StartJustTrivia();
		}
		if (generalController.demo)
		{
			if (flag4 && flag3)
			{
				Application.Quit();
			}
			if (generalController.currentScene != "mainmenu")
			{
				afkTimer += Time.deltaTime;
			}
			if (!generalController.justTrivia && (Input.GetKeyDown("r") || keyDown3 || flag3))
			{
				RebootGame();
			}
			else if (afkTimer > 300f)
			{
				afkTimer = 0f;
				RebootGame();
			}
		}
	}

	private void RebootGame()
	{
		PlayerPrefs.SetString("lang", "en");
		PlayerPrefs.SetString("misc", string.Empty);
		PlayerPrefs.SetString("vidya", string.Empty);
		PlayerPrefs.SetString("cinema", string.Empty);
		PlayerPrefs.SetString("animation", string.Empty);
		Object.Destroy(generalController.gameObject);
		SceneManager.LoadSceneAsync("loading", LoadSceneMode.Single);
	}

	private void AxisCheck()
	{
		frameCount++;
		if (Input.GetAxis("YAxisDown") == 1f || Input.GetAxis("YAxisDown") == -1f || Input.GetAxis("XAxisUp") == -1f || Input.GetAxis("XAxisUp") == 1f)
		{
			AxisXYStrikes++;
		}
		else
		{
			AxisXYStrikes = 0;
		}
		if (Input.GetAxisRaw("7AxisDown") == -1f || Input.GetAxisRaw("7AxisDown") == 1f || Input.GetAxisRaw("6AxisUp") == -1f || Input.GetAxisRaw("6AxisUp") == 1f)
		{
			Axis67Strikes++;
		}
		else
		{
			Axis67Strikes = 0;
		}
		if (Input.GetAxisRaw("5AxisDown") == 1f || Input.GetAxisRaw("5AxisDown") == -1f || Input.GetAxisRaw("4AxisUp") == -1f || Input.GetAxisRaw("4AxisUp") == 1f)
		{
			Axis45Strikes++;
		}
		else
		{
			Axis45Strikes = 0;
		}
		if (frameCount == 10)
		{
			if (AxisXYStrikes > 4)
			{
				AxisXYMalfunctioning = true;
				Debug.Log("XY Axis Malfunctioning. Strikes: " + AxisXYStrikes);
			}
			if (Axis67Strikes > 4)
			{
				Axis67Malfunctioning = true;
				Debug.Log("67 Axis Malfunctioning. Strikes: " + Axis67Strikes);
			}
			if (Axis45Strikes > 4)
			{
				Axis45Malfunctioning = true;
				Debug.Log("45 Axis Malfunctioning. Strikes: " + Axis45Strikes);
			}
		}
	}
}
