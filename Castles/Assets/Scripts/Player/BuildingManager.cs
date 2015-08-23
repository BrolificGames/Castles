using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour 
{
	private Ray placementRay;
	private RaycastHit placement;
	private Vector3 floatPosition = new Vector3(0f, 1.3f, 0f);
	private GameController.InputState inputState;

	// show the building preview and move it around with drag
	public void displayBuildingPlacement(GameObject building)
	{
		placementRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if (Physics.Raycast(placementRay, out placement))
		{
			building.transform.position = placement.point + floatPosition;
		}
	}

	// place the building if it can be placed
	public bool placeBuilding(GameObject building)
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
	public void rotateBuilding(GameObject building)
	{
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(camRay, out hit))
		{
			Vector3 buildingToMouse = hit.point - transform.position;
			Debug.DrawLine(building.transform.position, buildingToMouse, Color.cyan);
			buildingToMouse.y = 0f;
			
			Debug.DrawLine(building.transform.position, Vector3.up, Color.blue);
			Debug.DrawLine(building.transform.position, Vector3.forward, Color.grey);
			Debug.DrawLine(building.transform.position, Vector3.down, Color.green);
			
			Quaternion newRotation = Quaternion.LookRotation(buildingToMouse);
			building.transform.rotation = newRotation;
		}
	}

	public void acceptPlacement()
	{
		inputState.placing = false;
		inputState.contextPlacement = false;
		inputState.rotating = false;
	}
	
	public void cancelPlacement()
	{
		inputState.placing = true;
		inputState.contextPlacement = false;
		inputState.rotating = false;
	}
}