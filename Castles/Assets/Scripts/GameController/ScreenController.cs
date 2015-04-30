using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class ScreenController : MonoBehaviour 
{
	public Boundary boundary;

	private Vector3 dragOrigin;
	private bool dragging;

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && atEdge())
		{
			dragOrigin = Input.mousePosition;
			dragging = true;
		}

		if (Input.GetMouseButtonUp(0))
		{
			dragging = false;
		}

		if (dragging)
		{
			dragCamera();
		}
	}

	private void dragCamera()
	{
		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);

		Vector3 move = new Vector3(pos.x, 0, pos.z);
		transform.Translate(move, Space.World);
	}

	private bool atEdge()
	{
		// if the player is clicking and dragging over edge of screen, scroll the screen
		if (Input.mousePosition.x > boundary.xMax || Input.mousePosition.x < boundary.xMin || Input.mousePosition.z > boundary.zMax || Input.mousePosition.z < boundary.zMin)
		{
			return true;
		}

		return false;
	}
}
