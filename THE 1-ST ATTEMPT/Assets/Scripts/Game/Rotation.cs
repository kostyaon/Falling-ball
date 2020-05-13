using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
	public float speed;
    private void Start()
    {
        transform.position = new Vector3(0, 0, -0.5f);
    }

    void Update()
    {
		transform.Rotate(0, 0, speed);
    }
}
