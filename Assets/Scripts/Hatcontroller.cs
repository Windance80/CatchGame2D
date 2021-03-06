﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatcontroller : MonoBehaviour {

	public Camera cam;

	private Rigidbody2D rb2d;
	private float maxWidth;
	private SpriteRenderer render;
	private bool canControl;

	// Use this for initialization
	void Start () {
		if (cam == null)
			cam = Camera.main;
		rb2d = GetComponent<Rigidbody2D> ();
		render = GetComponentInChildren<SpriteRenderer> ();

		canControl = false;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float hatWidth = render.bounds.extents.x;
		maxWidth = targetWidth.x - hatWidth;
	}
	
	// Update is called once per physic timestep
	void FixedUpdate () {
		if (canControl) {
			Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
			Vector3 targetPosition = new Vector3 (rawPosition.x, 0.0f, 0.0f);
			float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);

			targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
			rb2d.MovePosition (targetPosition);
		}
	}

	public void ToggleControl(bool toggle) {
		canControl = toggle;
	}
}
