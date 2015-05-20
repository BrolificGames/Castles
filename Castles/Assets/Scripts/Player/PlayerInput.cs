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

	void Start()
	{
		rotating = false;
		building = Instantiate(buildingToPlace, new Vector3(100f, 100f, 100f), Quaternion.identity) as GameObject;
		player = transform.GetComponent<Player>();
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
				placeBuilding(building);
				placingBuilding = false;
				contextPlacement = true;
				return;
			}

			if (contextPlacement)
			{
				// get position of mouse when first clicked to use as point of reference when rotating
				//			currentMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				rotating = true;
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
		Debug.Log ("called");
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
			if (hit.transform.tag != "Ground")
			{			
				WorldObjects worldObject = hit.transform.GetComponent<WorldObjects>();
				worldObject.SetSelection(true);

				// set player selection
				player.selectedObject = worldObject;
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
	private void placeBuilding(GameObject building)
	{
		placementRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(placementRay, out placement))
		{
			if (placement.transform.tag != "Ground")
			{
				Debug.Log("not ground");
				return;
			}
		}

		building.transform.position = new Vector3(placement.point.x, 0.5f, placement.point.z);
	}

	// rotate object around center relative to amount dragged from the starting position on mouse
	private void rotateBuilding(GameObject building)
	{
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(camRay, out hit))
		{
			Vector3 buildingToMouse = hit.point - transform.position;
			buildingToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(buildingToMouse);
			building.transform.rotation = newRotation;
		}
	}
}
