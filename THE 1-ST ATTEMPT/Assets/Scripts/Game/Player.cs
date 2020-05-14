using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int highScore = 0;
	public int money = 1000;
	public string skinName = "ball";

	public void Save()
	{
		SaveSystem.SavePlayerData(this);
	}

	public void Load()
	{
		PlayerData data = SaveSystem.LoadPlayerData();
		if (data == null)
		{
			Save();
		}
		highScore = data.highScore;
		money = data.money;
		skinName = data.skinName;
	}
}

