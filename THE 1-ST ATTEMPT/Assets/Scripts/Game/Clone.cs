using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
	public bool check;
	public float sec
	{
		get
		{
			return waitSec;
		}
		set
		{
			waitSec = value;
		}
	}
	[SerializeField]
	private float waitSec;
	private float[] pos_x = { -1.55f, 0f, 1.55f };

	public void Spawner(GameObject prefab)
	{
		prefab.transform.position = new Vector3(pos_x[Random.Range(0, 3)], -8.9f, 0);
		StartCoroutine(Spawn(prefab));
	}
	public void clone(GameObject prefab)
	{
		GameObject clone = Instantiate(prefab) as GameObject;
		clone.transform.position = new Vector3(pos_x[Random.Range(0, 3)], prefab.transform.position.y, prefab.transform.position.z);
		check = false;
	}

	public IEnumerator Spawn(GameObject prefab)
	{
		while (true)
		{
			yield return new WaitForSeconds(waitSec);
			clone(prefab);
		}
	}
}
