using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
	public int highScore;
	public int money;
	public string skinName;

	public PlayerData(Player player)
	{
		highScore = player.highScore;
		money = player.money;
		skinName = player.skinName;
	}
}
