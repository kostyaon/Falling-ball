using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public Rigidbody2D rb;
    //public float thrust; //толчок, сила толчка

    public float interpolateDist;//[0,1] 0 - vector 1, 1 - vector 2

    private Touch theTouch;
    private Vector2 startTouchPosition, endTouchPosition;


    private void Movements(Vector2 start, Vector2 end)
    {
        float x, y;
        x = end.x - start.x;
        y = end.y - start.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x < 0)
            {
                Debug.Log("Move to the LEFT");
                //Move on the LEFT SIDE
                SmoothMoves("left");
            }
            else
            {
                Debug.Log("Move to the RIGHT");
                SmoothMoves("right");
                //Move on the RIGHT SIDE
            }
        }
    }

    public void SmoothMoves(string direction)
    {
        Vector2 startBallPosition, endBallPosition;
        startBallPosition = transform.position;

        if (direction == "left")
        {
            endBallPosition = new Vector2(startBallPosition.x - 1.55f, startBallPosition.y);
            transform.position = Vector2.Lerp(startBallPosition, endBallPosition, interpolateDist * Time.deltaTime);
        }
        else if (direction == "right")
        {
            endBallPosition = new Vector2(startBallPosition.x + 1.55f, startBallPosition.y);
            transform.position = Vector2.Lerp(startBallPosition, endBallPosition, interpolateDist * Time.deltaTime);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                startTouchPosition = theTouch.position;
            }

            if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                endTouchPosition = theTouch.position;
                Movements(startTouchPosition, endTouchPosition);
            }
        }
    }
}
