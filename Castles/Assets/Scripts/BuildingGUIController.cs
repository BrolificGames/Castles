using UnityEngine;
using System.Collections;

public class BuildingGUIController : MonoBehaviour 
{
	private Vector3 localTransform;

	void Start()
	{
		localTransform = transform.position;
	}

	void Update()
	{
		hover();
	}

	private void hover()
	{
		float newPosition = Mathf.PingPong(15f, 20f);
		transform.position = new Vector3(localTransform.x, newPosition, localTransform.y); 
	}
}
