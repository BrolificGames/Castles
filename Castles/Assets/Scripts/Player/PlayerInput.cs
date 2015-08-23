using UnityEngine;
using System.Collections;

// This script handles mouse clicks/touch and then delegates actions based on game state
// (eg placing a building) and what was clicked on as well as touch input
public class PlayerInput : MonoBehaviour 
{
	public GameObject buildingToPlace;
	public float rotationRate = 20f;

	private GameController.InputState inputState;
	private BuildingManager buildingManager;
	private Vector3 currentMousePosition;
	private GameObject building;
	private Vector3 updatedMousePosition;
	private Player player;
	private MenuInput menuInput;

	void Start()
	{
		inputState.rotating = false;
		building = Instantiate(buildingToPlace, new Vector3(100f, 100f, 100f), Quaternion.identity) as GameObject;
		player = transform.GetComponent<Player>();
		menuInput = transform.GetComponentInChildren<MenuInput>();
		buildingManager = gameObject.GetComponent<BuildingManager>();
	}

	void Update()
	{
		if (inputState.placing)
		{
			buildingManager.displayBuildingPlacement(building);
		}

		detectPlayerInput();

		if (inputState.rotating)
		{
			buildingManager.rotateBuilding(building);
		}
	}

	private void detectPlayerInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (inputState.placing)
			{
				bool placed = buildingManager.placeBuilding(building);
				if (placed)
				{
					inputState.placing = false;
					inputState.contextPlacement = true;
				}
				return;
			}

			if (inputState.contextPlacement)
			{
				// get position of mouse when first clicked to use as point of reference when rotating
				//			currentMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				inputState.rotating = true;
				menuInput.ShowContextMenu();
				return;
			}

			findClickedObject();
		}
		
		if (inputState.contextPlacement && Input.GetMouseButtonUp(0))
		{
			inputState.rotating = false;
		}
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
}
