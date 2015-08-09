using UnityEngine;
using System.Collections;

// This script handles mouse clicks/touch and then delegates actions based on game state
// (eg placing a building) and what was clicked on as well as touch input
public class PlayerInput : MonoBehaviour 
{
	public bool placingBuilding;
	public bool contextPlacement;
	public GameObject buildingToPlace;
	public float rotationRate = 20f;

	private Ray placementRay;
	private RaycastHit placement;
	private bool rotating;
	private Vector3 currentMousePosition;
	private GameObject building;
	private Vector3 floatPosition = new Vector3(0f, 1.3f, 0f);
	private Vector3 updatedMousePosition;
	private Player player;
	private MenuInput menuInput;

	void Start()
	{
		rotating = false;
		building = Instantiate(buildingToPlace, new Vector3(100f, 100f, 100f), Quaternion.identity) as GameObject;
		player = transform.GetComponent<Player>();
		menuInput = transform.GetComponentInChildren<MenuInput>();
	}

	void Update()
	{
		if (placingBuilding)
		{
			displayBuildingPlacement(building);
		}

		detectPlayerInput();

		if (rotating)
		{
			rotateBuilding(building);
		}
	}

	private void detectPlayerInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (placingBuilding)
			{
				bool placed = placeBuilding(building);
				if (placed)
				{
					placingBuilding = false;
					contextPlacement = true;
				}
				return;
			}

			if (contextPlacement)
			{
				// get position of mouse when first clicked to use as point of reference when rotating
				//			currentMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				rotating = true;
				menuInput.ShowContextMenu();
				return;
			}

			findClickedObject();
		}
		
		if (contextPlacement && Input.GetMouseButtonUp(0))
		{
			rotating = false;
		}
	}

	public void acceptPlacement()
	{
		placingBuilding = false;
		contextPlacement = false;
		rotating = false;
	}

	public void cancelPlacement()
	{
		placingBuilding = true;
		contextPlacement = false;
		rotating = false;
	}

	private void findClickedObject()
	{
		// if we clicked on an object that is selectable, then set it to selected
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(camRay, out hit))
		{
			if (player.selectedObject != null)
			{
				player.selectedObject.SetSelection(false);
			}

			if (hit.transform.tag != "Ground")
			{	
				WorldObjects worldObject = hit.transform.GetComponent<WorldObjects>();
				worldObject.SetSelection(true);

				// set player selection
				player.selectedObject = worldObject;
			}
			else 
			{
				// unselect anything if we clicked on ground
				player.selectedObject = null;
			}
		}
	}

	// show the building preview and move it around with drag
	private void displayBuildingPlacement(GameObject building)
	{
		placementRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(placementRay, out placement))
		{
			building.transform.position = placement.point + floatPosition;
		}
	}

	// place the building if it can be placed
	private bool placeBuilding(GameObject building)
	{
		placementRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(placementRay, out placement))
		{
			if (placement.transform.tag != "Ground")
			{
				return false;
			}
		}

		building.transform.position = new Vector3(placement.point.x, 0.5f, placement.point.z);
		return true;
	}

	// rotate object around center relative to amount dragged from the starting position on mouse
	private void rotateBuilding(GameObject building)
	{
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(camRay, out hit))
		{
			Vector3 buildingToMouse = hit.point - transform.position;
			Debug.DrawLine(building.transform.position, buildingToMouse, Color.cyan);
			buildingToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(buildingToMouse);
			building.transform.rotation = newRotation;
		}
	}
}
