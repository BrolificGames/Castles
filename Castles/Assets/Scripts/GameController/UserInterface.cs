using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UserInterface : MonoBehaviour 
{
	public Button backButton;
	public GameObject containerPanel;
	public float speed = 0.2f;

	private static UserInterface userInterface;
	private bool closing = false;
	private Transform panelTransform;

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
	void Update()
	{
		if (closing)
		{
			CloseMenu();
		}
	}
	
	public void Choice(UnityAction backEvent)
	{
		// slide the menu out
		
		backButton.onClick.RemoveAllListeners();
		backButton.onClick.AddListener(backEvent);
		backButton.onClick.AddListener(SetCloseMenu);
	}

	private void SetCloseMenu()
	{
		closing = true;
	}
	
	public void CloseMenu()
	{
		// slide the menu back
		if (panelTransform.position.x <= -65f)
		{
			closing = false;
		}

		panelTransform.position = Vector3.Lerp(panelTransform.position, 
		                                     new Vector3(-70f, panelTransform.position.y, 0f), 
		                                     speed * Time.time);
	}
}
