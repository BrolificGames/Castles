using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour 
{
	public bool isClear {get; set;}
	public float groundCheckRadius;

	void Update()
	{
		isClear = checkGround();
	}

	private bool checkGround()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform, groundCheckRadius);
		foreach (Collider collider in hitColliders)
		{
			if (collider.tag != "Ground")
			{
				return false;
			}
		}

		// if we make it through all colliders and all are "Ground" then we are clear
		return true;
	}
}
