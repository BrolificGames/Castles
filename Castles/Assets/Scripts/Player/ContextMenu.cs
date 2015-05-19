using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class ContextMenu : MonoBehaviour 
{
	public Button okButton;
	public Button cancelButton;
	public GameObject containerPanel;

	private static ContextMenu contextMenu;

	public static ContextMenu Instance()
	{
		if (!contextMenu) 
		{
			contextMenu = FindObjectOfType(typeof (ContextMenu)) as ContextMenu;
			if (!contextMenu)
			{
				Debug.LogError ("There needs to be one active ContextMenu script on a GameObject in your scene.");
			}
		}
		
		return contextMenu;
	}

	public void Choice(UnityAction okEvent, UnityAction cancelEvent)
	{
		containerPanel.SetActive(true);

		okButton.onClick.RemoveAllListeners();
		okButton.onClick.AddListener(okEvent);
		okButton.onClick.AddListener(CloseMenu);

		cancelButton.onClick.RemoveAllListeners();
		cancelButton.onClick.AddListener(cancelEvent);
		cancelButton.onClick.AddListener(CloseMenu);
	}

	public void CloseMenu()
	{
		containerPanel.SetActive(false);
	}
}
