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
}
