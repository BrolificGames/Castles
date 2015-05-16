using UnityEngine;
using System.Collections;

// this script handles all menu actions
public class MenuInput : MonoBehaviour 
{
	public GameObject[] availableBuildings { get; set; }
	public Canvas contextMenu;

	private PlayerInput playerInput;

	void Awake()
	{
		playerInput = gameObject.GetComponent<PlayerInput>();
	}

	public void ShowContextMenu(Vector3 worldPosition)
	{
		contextMenu.transform.position = worldPosition + new Vector3(0f, 5f, 0f);
	}

	public void CancelPlacement()
	{

	}

	public void AcceptPlacement()
	{

	}
}
