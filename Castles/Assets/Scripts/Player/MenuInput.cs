using UnityEngine;
using UnityEngine.Events;
using System.Collections;

// this script handles all menu actions
public class MenuInput : MonoBehaviour 
{
	public GameObject[] availableBuildings { get; set; }

	private ContextMenu contextMenu;
	private BuildingManager buildingManager;

	void Start()
	{
		buildingManager = gameObject.GetComponent<BuildingManager>();
		contextMenu = ContextMenu.Instance();
	}

	public void ShowContextMenu()
	{
		contextMenu.Choice(AcceptPlacement, CancelPlacement);
	}

	public void CancelPlacement()
	{
		buildingManager.cancelPlacement(); 
	}

	public void AcceptPlacement()
	{
		buildingManager.acceptPlacement();
	}
}
