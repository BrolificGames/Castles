using UnityEngine;
using System.Collections;

public class WallController : WorldObjects 
{
	protected override void Awake()
	{
		base.Awake();
	}

	protected override void Update()
	{
		base.Update();
		Debug.DrawLine(gameObject.transform.position, Vector3.forward);
	}
}
