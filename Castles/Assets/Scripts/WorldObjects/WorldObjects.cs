using UnityEngine;
using System.Collections;

public class WorldObjects : MonoBehaviour 
{
	public int cost, sellValue, hitPoints, maxHitPoints;
	protected Player player;
	protected string[] actions = {};
	protected bool currentlySelected = false;

	protected virtual void Awake() 
	{
		
	}
	
	protected virtual void Start() 
	{
//		player = transform.root.GetComponentInChildren<Player>();
	}
	
	protected virtual void Update() 
	{
		
	}

	public void SetSelection(bool selected) 
	{
		currentlySelected = selected;
	}

	public string[] GetActions() 
	{
		return actions;
	}
	
	public virtual void PerformAction(string actionToPerform)
	{

	}

	public virtual void MouseClick(GameObject hitObject, Vector3 hitPoint, Player controller) {
		if (currentlySelected && hitObject && hitObject.name != "Ground")
		{
			WorldObjects worldObject = hitObject.transform.GetComponent< WorldObjects >();
			//clicked on another selectable object
			if (worldObject)
			{
				ChangeSelection(worldObject, controller);
			}
		}
	}

	private void ChangeSelection(WorldObjects worldObject, Player controller)
	{
		SetSelection(false);
		if (controller.selectedObject)
		{
			controller.selectedObject.SetSelection(false);
		}

		controller.selectedObject = worldObject;
		worldObject.SetSelection(true);
	}
}
