using UnityEngine;

public class MenuController : MonoBehaviour
{
	public GameObject button;

	public Sprite menuButton;

	public Sprite menuButtonSelected;

	public void Select()
	{
		button.GetComponent<SpriteRenderer>().sprite = menuButtonSelected;
		button.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
	}

	public void Deselect()
	{
		button.GetComponent<SpriteRenderer>().sprite = menuButton;
		button.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 30);
	}

	public void Click()
	{
		GameObject.Find("GlobalScripter").GetComponent<GeneralController>().Skip();
	}
}
