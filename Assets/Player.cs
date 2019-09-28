using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 14f;
    [Tooltip("In ms^-1")] [SerializeField] float xRange = 5f;
    [Tooltip("In ms^-1")] [SerializeField] float yRange = 4.3f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveVertically();
        MoveHorizontally();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(-30f, 30f, 0f);
    }

    private void MoveVertically()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * xSpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }

    void MoveHorizontally() {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }
}
