using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour 
{
	public bool placingBuilding;
	public bool contextPlacement;
	public GameObject building;

	private Ray placementRay;
	private RaycastHit placement;
	private bool rotating;
	private Ray currentMousePosition;

	void Start()
	{
		rotating = false;
	}

	void Update()
	{
		if (placingBuilding && Input.GetMouseButtonDown(0))
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

			Instantiate(building, placement.point, Quaternion.identity);
		}
	}

	private void rotateBuilding(GameObject building)
	{
		// rotate around center relative to amount dragged from the starting position on mouse
	}
}
