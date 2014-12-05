using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
 
public class InteractiveCamera : MonoBehaviour
{
	
	public float turnSpeed = 4.0f;		// Speed of camera turning when mouse moves in along an axis
	public float zoomSpeed = 2.0f;		// Speed of the camera going back and forth
	
	private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
	private bool isRotating;	// Is the camera being rotated?
	private bool isZooming;		// Is the camera zooming?

	public string touched;
	public bool isUsing = false;

	public void EventTouch(string which)
	{
		AudioClip SoundFX = Resources.Load("Audio/FXClick") as AudioClip;
    	audio.PlayOneShot(SoundFX);
		touched = which;

	}

	public void EventTouch(bool setting)
	{
		isUsing = setting;
	}
	
	public void Update () 
	{
		if(!isUsing)
			return;
		if(Input.GetMouseButtonDown(0) && (touched == "rotate"))
		{// Get the left mouse button
			mouseOrigin = Input.mousePosition;
			isRotating = true;
		}
		else if(Input.GetMouseButtonUp(0) && (touched == "rotate"))
			isRotating = false;
		
		if(Input.GetMouseButtonDown(0) && (touched == "zoom"))
		{// Get the middle mouse button
			mouseOrigin = Input.mousePosition;
			isZooming = true;
		}
		else if(Input.GetMouseButtonUp(0) && (touched == "zoom"))
			isZooming = false;
		
		if ((touched == "rotate") && isRotating)
		{// Rotate camera along X and Y axis
	        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
			transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
		}
		
		if ((touched == "zoom") && isZooming)
		{// Move the camera linearly along Z axis
	        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
	        Vector3 move = pos.y * zoomSpeed * transform.forward; 
	        transform.Translate(move, Space.World);
		}
	}
}