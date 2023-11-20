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
			var startLinePos = mousePos; // Start line drawing
			Debug.Log($" Mouse XY {mousePos}, Ball xy {ball.transform.position}");
			if (ball != null && ball.IsCollidingWith(startLinePos.x,startLinePos.y))
			{
				Debug.Log(" IN BALL!");
				drawnLine = lineFactory.GetLine(ball.Position.ToUnityVector2(),startLinePos,10,Color.gray);
				drawnLine.EnableDrawing(true);
			}
		}
		
		else if (Input.GetMouseButtonUp(0) && drawnLine != null)
		{
			drawnLine.EnableDrawing(false);
			
			//update the velocity of the white ball.
			HVector2D v = ball.Position - new HVector2D(mousePos.x,mousePos.y);
			ball.Velocity = v;
		
			drawnLine = null; // End line drawing            
		}

		if (drawnLine != null)
		{
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
