using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour 
{
	public bool placingBuilding;
	public bool contextPlacement;
	public GameObject buildingToPlace;

	private Ray placementRay;
	private RaycastHit placement;
	private bool rotating;
	private Ray currentMousePosition;
	private GameObject building;
	private Vector3 floatPosition = new Vector3(0f, 1.3f, 0f);

	void Start()
	{
		rotating = false;
		building = Instantiate(buildingToPlace, new Vector3(100f, 100f, 100f), Quaternion.identity) as GameObject;
	}

	void Update()
	{
		if (placingBuilding)
		{
			displayBuildingPlacement(building);
		}

		if (placingBuilding && Input.GetMouseButtonUp(0))
		{
			placeBuilding(building);
			placingBuilding = false;
			contextPlacement = true;
		}

		if (contextPlacement && Input.GetMouseButtonDown(0))
		{
			// get position of mouse when first clicked to use as point of reference when rotating
			currentMousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
			rotating = true;
		}

		if (contextPlacement && Input.GetMouseButtonUp(0))
		{
			rotating = false;
		}

		if (rotating)
		{
			rotateBuilding(building);
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

	// rotate around center relative to amount dragged from the starting position on mouse
	private void rotateBuilding(GameObject building)
	{
//		Ray updatedMousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
		Quaternion target = Quaternion.Euler(20f, 0f, 20f);

		building.transform.rotation = Quaternion.Slerp(transform.rotation, target, 20f * Time.deltaTime);
	}
}
