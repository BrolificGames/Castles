using UnityEngine;
using System.Collections;

public class MerchantController : WorldObjects 
{
	public Canvas merchantCanvas;

	void Update()
	{
		if (currentlySelected)
		{
			base.Update();
			showMenu();
		}
	}

	private void showMenu()
	{
		merchantCanvas.enabled = true;
	}
}

