using UnityEngine;
using UnityEngine.Events;
using System.Collections;

// this script handles all menu actions
public class MenuInput : MonoBehaviour 
{
	public GameObject[] availableBuildings { get; set; }

	private ContextMenu contextMenu;
	private PlayerInput playerInput;

	private UnityAction cancelAction;
	private UnityAction acceptAction;

	void Awake()
	{
		playerInput = gameObject.GetComponent<PlayerInput>();
		contextMenu = ContextMenu.Instance();

		cancelAction = new UnityAction(CancelPlacement);
		acceptAction = new UnityAction(AcceptPlacement);
	}

	public void ShowContextMenu(Vector3 worldPosition)
	{
		contextMenu.transform.position = worldPosition + new Vector3(0f, 5f, 0f);
		contextMenu.Choice(acceptAction, cancelAction);
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
