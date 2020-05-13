using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(Timer());
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if (Scores.health < 2)
			{
				Debug.Log("+1 Health");
				Scores.health++;
				Debug.Log("HEALTH: " + Scores.health);
			}
		}
		Destroy(this);
	}
	private IEnumerator Timer()
	{
		while (true)
		{
			yield return new WaitForSeconds(5f);
			gameObject.SetActive(false); 
		}
	}
}
