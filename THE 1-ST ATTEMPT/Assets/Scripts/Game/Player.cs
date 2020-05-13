using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int highScore = 0;
	public int money = 0;
	public string skinName = "ball";

	public void Save()
	{
		SaveSystem.SavePlayerData(this);
	}

	public void Load()
	{
		PlayerData data = SaveSystem.LoadPlayerData();
		highScore = data.highScore;
		money = data.money;
		skinName = data.skinName;
	}
}

