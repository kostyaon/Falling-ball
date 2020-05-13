using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonuse_score : MonoBehaviour
{
	private GameObject scorePlus;
	private GameObject ball;
	private Scores obj;
	Player player;

	private void Awake()
	{
		ball = GameObject.FindGameObjectWithTag("Player");
		scorePlus = GameObject.FindGameObjectWithTag("Bonus");
		scorePlus.SetActive(false);
		obj = ball.GetComponent<Scores>();
		player = ball.GetComponent<Player>();
	}
	public void doubleTouch()
	{
		//animation
		if (player.money < 100)
		{
			return;
		}
		player.money -= 100;
		scorePlus.SetActive(true);
		obj.bonus = true;
		obj.moneyAmount();
		StartCoroutine(Timer());
	}

	private IEnumerator Timer()
	{
		while (true)
		{
			yield return new WaitForSeconds(15f);
			obj.bonus = false;
			scorePlus.SetActive(false);
			//destroy animation
			break;
		}
	}

}
