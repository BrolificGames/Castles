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
			showMenu(true);
		} else 
		{
			showMenu(false);
		}

	}

	private void showMenu(bool enabled)
	{
		merchantCanvas.enabled = enabled;
	}
}

