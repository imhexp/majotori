using UnityEngine;

public class CustomCanvasScaler : MonoBehaviour
{
	private float previousCamAspect;

	private void Update()
	{
		if (previousCamAspect != Camera.main.aspect)
		{
			if (Camera.main.aspect < 1.777778f)
			{
				base.gameObject.transform.localScale = new Vector2(Camera.main.aspect, Camera.main.aspect / 1.777778f);
			}
			else if (Camera.main.aspect >= 1.777778f)
			{
				base.gameObject.transform.localScale = new Vector2(1.777778f, 1f);
			}
		}
	}
}
