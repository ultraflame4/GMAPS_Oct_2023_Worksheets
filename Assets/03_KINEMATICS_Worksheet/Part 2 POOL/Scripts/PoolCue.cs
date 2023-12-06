using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
	public LineFactory lineFactory;
	public GameObject ballObject;

	private Line drawnLine;
	private Ball2D ball;

	private void Start()
	{
		ball = ballObject.GetComponent<Ball2D>();
	}

	void Update()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		if (Input.GetMouseButtonDown(0))
		{
			// start position of the line
			var startLinePos = mousePos;
			Debug.Log($" Mouse XY {mousePos}, Ball xy {ball.transform.position}");
			// If the position is in the ball, start drawing the line
			if (ball != null && ball.IsCollidingWith(startLinePos.x,startLinePos.y))
			{
				Debug.Log(" IN BALL!");
				// Get line from line factory and assign it to drawLine
				drawnLine = lineFactory.GetLine(ball.Position.ToUnityVector2(),startLinePos,10,Color.gray);
				drawnLine.EnableDrawing(true);
			}
		}
		// If the mouse button is released, and there is a line being drawn
		else if (Input.GetMouseButtonUp(0) && drawnLine != null)
		{
			// Disable line drawing
			drawnLine.EnableDrawing(false);
			
			// Calculate the velocity of the white ball
			HVector2D v = ball.Position - new HVector2D(mousePos.x,mousePos.y);
			// Update the velocity of the white ball.
			ball.Velocity = v;
			// End line drawing by setting drawnLine to null
			drawnLine = null;             
		}

		// If there is a line that is being drawn
		if (drawnLine != null)
		{
			// Update the end position of the line to be where the mouse is.
			drawnLine.end = mousePos; // Update line end
		}
	}

	/// <summary>
	/// Get a list of active lines and deactivates them.
	/// </summary>
	public void Clear()
	{
		var activeLines = lineFactory.GetActive();

		foreach (var line in activeLines)
		{
			line.gameObject.SetActive(false);
		}
	}
}
