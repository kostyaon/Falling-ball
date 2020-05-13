using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private Touch theTouch;
	private Vector2 startTouchPosition, endTouchPosition;
	private Bonuse_score bonus;
	private GameObject ball;
	private bool thisTouch;

	private void Awake()
	{
		ball = GameObject.FindGameObjectWithTag("Player");
		bonus = ball.AddComponent<Bonuse_score>();
	}
	private void Update()
	{
		//For testing on some PC
		if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -1.54f) StartCoroutine(SmoothMove("left"));
		if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 1.55f) StartCoroutine(SmoothMove("right"));
		if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < 3.5f) StartCoroutine(SmoothMove("up"));
		if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > -3.5f) StartCoroutine(SmoothMove("down"));
		if (Input.GetKeyDown(KeyCode.Space)) bonus.doubleTouch();


		if (Input.touchCount > 0)
		{
			theTouch = Input.GetTouch(0);

			if (theTouch.phase == TouchPhase.Began)
			{
				startTouchPosition = theTouch.position;
				thisTouch = true;
			}

			if (theTouch.phase == TouchPhase.Moved)
			{
				endTouchPosition = theTouch.position;
				if (thisTouch == true)
				{
					if (Mathf.Abs(endTouchPosition.x - startTouchPosition.x) > Mathf.Abs(endTouchPosition.y - startTouchPosition.y))
					{
						if (endTouchPosition.x > startTouchPosition.x && transform.position.x < 1.55f)
						{
							StartCoroutine(SmoothMove("right"));
						}
						else if (endTouchPosition.x < startTouchPosition.x && transform.position.x > -1.54f)
						{
							StartCoroutine(SmoothMove("left"));
						}
					}
					else
					{
						if (endTouchPosition.y > startTouchPosition.y && transform.position.y < 3.5f)
						{
							StartCoroutine(SmoothMove("up"));
						}
						else if (endTouchPosition.y < startTouchPosition.y && transform.position.y > -3.5f)
						{
							StartCoroutine(SmoothMove("down"));
						}
					}
				}
				thisTouch = false;
			}

			if (theTouch.phase == TouchPhase.Stationary && theTouch.tapCount == 2)
			{
				bonus.doubleTouch();
			}

			if (theTouch.phase == TouchPhase.Ended)
			{
				thisTouch = true;
			}
		}

	}


	private IEnumerator SmoothMove(string direction)
	{
		Vector3 startBallPosition, endBallPosition;
		float ballTime = 0f;
		float interpolate = 0.1f;
		startBallPosition = endBallPosition = transform.position;
		if (direction == "left")
		{
			endBallPosition = new Vector3(startBallPosition.x - 1.55f, startBallPosition.y, startBallPosition.z);
		}
		if (direction == "right")
		{
			endBallPosition = new Vector3(startBallPosition.x + 1.55f, startBallPosition.y, startBallPosition.z);
		}
		if (direction == "up")
		{
			endBallPosition = new Vector3(startBallPosition.x, startBallPosition.y + 1.75f, startBallPosition.z);
		}
		if (direction == "down")
		{
			endBallPosition = new Vector3(startBallPosition.x, startBallPosition.y - 1.75f, startBallPosition.z);
		}
		while (ballTime < interpolate)
		{
			ballTime += Time.deltaTime;
			FindObjectOfType<AudioManager>().Play("Swipe");
			transform.position = Vector3.Lerp(startBallPosition, endBallPosition, ballTime / interpolate);
			yield return null;
		}
	}
}