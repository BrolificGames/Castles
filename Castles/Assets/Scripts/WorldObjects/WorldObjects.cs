using UnityEngine;
using System.Collections;

public class WorldObjects : MonoBehaviour 
{
	public int cost, sellValue, hitPoints, maxHitPoints;

	protected Canvas contextMenu;
	protected Player player;
	protected string[] actions = {};
	protected bool currentlySelected = false;

	protected virtual void Awake() 
	{
		contextMenu = GameObject.FindGameObjectWithTag("ContextMenu").GetComponent<Canvas>();
	}
	
	protected virtual void Start() 
	{
//		player = transform.root.GetComponentInChildren<Player>();
	}
	
	protected virtual void Update() 
	{
		if (currentlySelected)
		{
			showSelection();
		}
	}

	public void SetSelection(bool selected) 
	{
		currentlySelected = selected;
		showSelection();
	}

	public string[] GetActions() 
	{
		return actions;
	}
	
	public virtual void PerformAction(string actionToPerform)
	{

	}

	private void showSelection()
	{
		if (currentlySelected)
		{
			var render = transform.GetComponent<Renderer>();
			var shader = Shader.Find("SelectedHighlight");
			render.material.shader = shader;
		} 
		else
		{
			var render = transform.GetComponent<Renderer>();
			var shader = Shader.Find("Standard");
			render.material.shader = shader;
		}
	}
}
