using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour 
{
	private Canvas canvas;

	void Start()
	{
//		ShowContextMenu();
	}

	private void ShowContextMenu()
	{
		canvas = gameObject.GetComponentInChildren<Canvas>();
		canvas.enabled = true;
	}
}
