using UnityEngine;
using System.Collections;

public class MerchantController : WorldObjects 
{
	public Canvas merchantCanvas;

	protected override void Awake()
	{
		base.Awake();
	}
	
	protected override void Update()
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

