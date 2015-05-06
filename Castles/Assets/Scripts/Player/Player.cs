using UnityEngine;
using System.Collections;

// player settings
public class Player : MonoBehaviour 
{
	public WorldObjects selectedObject { get; set; }

	public void SetSelection(WorldObjects worldObject)
	{
		if (selectedObject != null)
		{
			selectedObject.SetSelection(false);
		}

		selectedObject = worldObject;
	}
}
