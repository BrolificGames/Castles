using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UserInterface : MonoBehaviour 
{
	public Button backButton;
	public Button showButton;
	public GameObject containerPanel;
	public float speed = 0.2f;

	private static UserInterface userInterface;
	private bool closing = false;
	private bool opening = false;
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

	void Awake()
	{
		showButton.onClick.RemoveAllListeners();
		showButton.onClick.AddListener(SetOpenMenu);
		panelTransform = containerPanel.transform;
	}

	void Update()
	{
		if (closing)
		{
			CloseMenu();
		}

		if (opening)
		{
			OpenMenu();
		}
	}
	
	public void SetOpenMenu()
	{
		// slide the menu out
		opening = true;
		showButton.gameObject.SetActive(false);
		backButton.gameObject.SetActive(true);
		backButton.onClick.RemoveAllListeners();
		backButton.onClick.AddListener(SetCloseMenu);
	}

	private void SetCloseMenu()
	{
		closing = true;
		showButton.gameObject.SetActive(true);
		backButton.gameObject.SetActive(false);
		showButton.onClick.RemoveAllListeners();
		showButton.onClick.AddListener(SetOpenMenu);
	}

	private void OpenMenu()
	{
		if (panelTransform.position.x <= 0)
		{
			opening = false;
		}

		panelTransform.position = Vector3.Lerp(panelTransform.position, 
		                                       new Vector3(0f, panelTransform.position.y, 0f),
		                                       speed * Time.time);
	}
	
	private void CloseMenu()
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
