using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{

	public float speed = -0.035f;
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(new Vector3(0f, speed, 0f));
		if (transform.position.y < -12f)
		{
			transform.position = new Vector3(0f, 13f, 0f);
		}
	}
}
