using UnityEngine;
using UnityEngine.Events;
using System.Collections;

// this script handles all menu actions
public class MenuInput : MonoBehaviour 
{
	public GameObject[] availableBuildings { get; set; }

	private ContextMenu contextMenu;
	private PlayerInput playerInput;

	void Awake()
	{
		playerInput = gameObject.GetComponent<PlayerInput>();
		contextMenu = ContextMenu.Instance();
	}

	public void ShowContextMenu()
	{
		gameObject.SetActive(true);
		contextMenu.Choice(AcceptPlacement, CancelPlacement);
	}

	public void CancelPlacement()
	{
		playerInput.cancelPlacement(); 
	}

	public void AcceptPlacement()
	{
		playerInput.acceptPlacement();
	}
}
