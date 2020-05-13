using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_basket : MonoBehaviour
{
	public GameObject bask_prefab;
	public float waitSec;
	private float[] pos_x = { -1.55f, 0f, 1.55f };
	private Clone cl_1;

	private void Awake()
	{
		cl_1 = (new GameObject("Clone_class").AddComponent<Clone>());
	}
	private void Start()
	{
		bask_prefab.transform.position = new Vector3(pos_x[Random.Range(0, 3)], -8.9f, 0);
		StartCoroutine(BasketSpawn());
	}

	private IEnumerator BasketSpawn()
	{
		while (true)
		{
			yield return new WaitForSeconds(waitSec);
			cl_1.clone(bask_prefab);
		}
	}
}
