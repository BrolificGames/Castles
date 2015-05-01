using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour 
{
	private Canvas canvas;

	void Start()
	{
		ShowContextMenu();
	}

	
	public void selected()
	{
		// show object is selected

		// open context menu for info, and building-specific options eg: wall show anchors for creating more wall
		// other building, research, upgrades etc <=== this can probably be a gui menu that is separate from gameobject
	}

	private void ShowContextMenu()
	{
		canvas = gameObject.GetComponentInChildren<Canvas>();
		canvas.enabled = true;
	}
}
