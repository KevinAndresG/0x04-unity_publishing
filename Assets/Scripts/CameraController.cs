using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	// Update is called once per frame
	public GameObject player;
	public Vector3 offset;
	void Start()
	{
		offset = new Vector3(-1, 24.75f, -9);
	}
	void Update()
	{
		transform.position = player.transform.position + offset;
	}
}
