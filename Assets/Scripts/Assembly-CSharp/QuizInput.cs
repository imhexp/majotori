using UnityEngine;

public class QuizInput : MonoBehaviour
{
	public Animator AnswerShadow;

	private Animator animator;

	public GameObject scripter;

	private QuizController quizController;

	public GameObject AHolder;

	public GameObject BHolder;

	public GameObject CHolder;

	public GameObject DHolder;

	private GameObject globalScripter;

	private GeneralController generalController;

	private GlobalInput globalInput;

	private GameObject menu;

	private IngameMenuController ingameMenuController;

	private IngameMenuInput ingameMenuInput;

	private GameObject narratorScripter;

	private SettingsInput settingsInput;

	private bool up;

	private bool down;

	private bool right;

	private bool enter;

	private bool back;

	private bool esc;

	private bool start;

	public int selection;

	public string currentSituation = "answer";

	private string cheatCode = string.Empty;

	public Vector3 cursorPosition;

	private void Start()
	{
		animator = AnswerShadow.GetComponent<Animator>();
		quizController = scripter.GetComponent<QuizController>();
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		globalInput = globalScripter.GetComponent<GlobalInput>();
		menu = GameObject.Find("IngameMenu");
		ingameMenuController = menu.GetComponent<IngameMenuController>();
		ingameMenuInput = menu.GetComponent<IngameMenuInput>();
		narratorScripter = GameObject.Find("NarratorScripter");
		settingsInput = narratorScripter.GetComponent<SettingsInput>();
		cursorPosition = Input.mousePosition;
	}

	private void Update()
	{
		if (generalController.currentScene != "quiz" || ingameMenuInput.menuInputActive || settingsInput.inSettings)
		{
			return;
		}
		up = globalInput.up;
		down = globalInput.down;
		right = globalInput.right;
		enter = globalInput.enter;
		back = globalInput.back;
		esc = globalInput.esc;
		start = globalInput.start;
		if ((down || up) && globalInput.pulsable && currentSituation == "answer")
		{
			ManageInput();
			globalInput.pulsable = false;
		}
		else if ((enter || esc || start || right) && globalInput.pulsable)
		{
			ManageInput();
		}
		else if (!down && !up && !enter && !esc && !start && currentSituation == "answer" && !quizController.translating)
		{
			globalInput.pulsable = true;
		}
		if (Input.GetKeyDown("o") && cheatCode.Length < 9)
		{
			cheatCode += "o";
			if (cheatCode.Length == 9)
			{
				quizController.CheatQuiz(cheatCode);
			}
		}
		else if (Input.GetKeyDown("x") && cheatCode.Length < 9)
		{
			cheatCode += "x";
			if (cheatCode.Length == 9)
			{
				quizController.CheatQuiz(cheatCode);
			}
		}
		if (Input.GetKeyDown("t") && globalInput.pulsable)
		{
			quizController.TranslateQuestion();
		}
	}

	private void ManageInput()
	{
		if (!globalInput.pulsable)
		{
			return;
		}
		if (currentSituation == "answer")
		{
			if (down)
			{
				if (selection == 1)
				{
					AOut();
					BIn();
				}
				else if (selection == 2)
				{
					BOut();
					CIn();
				}
				else if (selection == 3)
				{
					COut();
					DIn();
				}
				else if (selection == 0)
				{
					selection = 0;
					AIn();
				}
			}
			else if (up)
			{
				if (selection == 4)
				{
					DOut();
					CIn();
				}
				else if (selection == 3)
				{
					COut();
					BIn();
				}
				else if (selection == 2)
				{
					BOut();
					AIn();
				}
				else if (selection == 0)
				{
					selection = 0;
					AIn();
				}
			}
			else if (enter)
			{
				if (selection == 1)
				{
					AClick();
				}
				else if (selection == 2)
				{
					BClick();
				}
				else if (selection == 3)
				{
					CClick();
				}
				else if (selection == 4)
				{
					DClick();
				}
			}
			else if (esc || back || start)
			{
				if (ingameMenuController.inMenu)
				{
					CallMenuIn();
					return;
				}
				CallMenuIn();
				ingameMenuController.MenuClick();
			}
		}
		else if (currentSituation == "result")
		{
			if (enter || right)
			{
				ArrowClick();
				globalInput.pulsable = false;
			}
			else if (esc || start)
			{
				CallMenuIn();
				ingameMenuController.MenuClick();
			}
		}
	}

	private void CallMenuIn()
	{
		ingameMenuController.MenuIn();
		if (selection == 1)
		{
			AOut();
		}
		else if (selection == 2)
		{
			BOut();
		}
		else if (selection == 3)
		{
			COut();
		}
		else if (selection == 4)
		{
			DOut();
		}
	}

	public void AIn()
	{
		selection = 1;
		animator.SetInteger("selection", selection);
		AHolder.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
	}

	public void AInMouse()
	{
		if (!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition))
		{
			selection = 1;
			animator.SetInteger("selection", selection);
			AHolder.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}
	}

	public void AOut()
	{
		selection = 0;
		animator.SetInteger("selection", selection);
		AHolder.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 230);
	}

	public void AClick()
	{
		if (globalInput.pulsable)
		{
			globalInput.pulsable = false;
			quizController.Result("a");
			currentSituation = "result";
			selection = 0;
			cursorPosition = Input.mousePosition;
		}
	}

	public void BIn()
	{
		selection = 2;
		animator.SetInteger("selection", selection);
		BHolder.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
	}

	public void BInMouse()
	{
		if (!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition))
		{
			selection = 2;
			animator.SetInteger("selection", selection);
			BHolder.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}
	}

	public void BOut()
	{
		selection = 0;
		animator.SetInteger("selection", selection);
		BHolder.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 230);
	}

	public void BClick()
	{
		if (globalInput.pulsable)
		{
			globalInput.pulsable = false;
			quizController.Result("b");
			currentSituation = "result";
			selection = 0;
			cursorPosition = Input.mousePosition;
		}
	}

	public void CIn()
	{
		selection = 3;
		animator.SetInteger("selection", selection);
		CHolder.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
	}

	public void CInMouse()
	{
		if (!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition))
		{
			selection = 3;
			animator.SetInteger("selection", selection);
			CHolder.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}
	}

	public void COut()
	{
		selection = 0;
		animator.SetInteger("selection", selection);
		CHolder.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 230);
	}

	public void CClick()
	{
		if (globalInput.pulsable)
		{
			globalInput.pulsable = false;
			quizController.Result("c");
			currentSituation = "result";
			selection = 0;
			cursorPosition = Input.mousePosition;
		}
	}

	public void DIn()
	{
		selection = 4;
		animator.SetInteger("selection", selection);
		DHolder.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
	}

	public void DInMouse()
	{
		if (!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition))
		{
			selection = 4;
			animator.SetInteger("selection", selection);
			DHolder.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}
	}

	public void DOut()
	{
		selection = 0;
		animator.SetInteger("selection", selection);
		DHolder.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 230);
	}

	public void DClick()
	{
		if (globalInput.pulsable)
		{
			globalInput.pulsable = false;
			quizController.Result("d");
			currentSituation = "result";
			selection = 0;
			cursorPosition = Input.mousePosition;
		}
	}

	public void ArrowClick()
	{
		cursorPosition = Input.mousePosition;
		AOut();
		BOut();
		COut();
		DOut();
		quizController.NextQuestion();
	}
}
