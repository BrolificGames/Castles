using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UserInterface : MonoBehaviour 
{
	public Button backButton;
	private static UserInterface userInterface;
	
	public static UserInterface Instance()
	{
		if (!userInterface) 
		{
			userInterface = FindObjectOfType(typeof (UserInterface)) as UserInterface;
			if (!userInterface)
			{
				Debug.LogError ("There needs to be one active UserInterface script on a GameObject in your scene.");
			}
		}
		
		return userInterface;
	}
	
	public void Choice(UnityAction backEvent)
	{
		// slide the menu out
		
		backButton.onClick.RemoveAllListeners();
		backButton.onClick.AddListener(backEvent);
		backButton.onClick.AddListener(CloseMenu);
	}
	
	public void CloseMenu()
	{
		// slide the menu back
	}
}
