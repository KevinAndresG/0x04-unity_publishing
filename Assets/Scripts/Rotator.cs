using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	public float RotatePerSec;
	void Start()
	{
		RotatePerSec = 100f;
	}
	// Update is called once per frame
	void Update()
	{
		transform.Rotate(RotatePerSec * Time.deltaTime, 0, 0);
	}
}
