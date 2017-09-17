using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Ctrl : MonoBehaviour

{

	int distance = 5;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Vector3 position = this.transform.position;
			position.x = position.x - distance;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Vector3 position = this.transform.position;
			position.x = position.x + distance;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			Vector3 position = this.transform.position;
			position.y = position.y + distance;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			Vector3 position = this.transform.position;
			position.y = position.y - distance;
			this.transform.position = position;
		}
	}
}