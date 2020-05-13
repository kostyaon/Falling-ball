using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public Button SettingBut, MoneyBut;
	public GameObject bg, ball, swipes, leftSide, rightSide, plane, record, bgWhite;
	public ParticleSystem speedEf, stars;
	public Text hs, score, money;
	private Rigidbody2D rb;
	private Animator ball_anim, left_anim, right_anim, record_anim, bgWhite_anim;
	private Touch theTouch;
	private Vector2 startTouchPosition, endTouchPosition;
	private Player player;


	private void Awake()
	{
		player = gameObject.AddComponent<Player>();
		LoadSaveElements(player);
	}
	private void Start()
	{
		SettingBut.onClick.AddListener(SetFun);
		MoneyBut.onClick.AddListener(MoneyFun);
		ball_anim = ball.GetComponent<Animator>();
		left_anim = leftSide.GetComponent<Animator>();
		right_anim = rightSide.GetComponent<Animator>();
		bgWhite_anim = bgWhite.GetComponent<Animator>();
		rb = bg.GetComponent<Rigidbody2D>();
		hs.text = player.highScore.ToString();
		money.text = player.money.ToString();
		score.text = Scores.totalScores.ToString();
		rb.simulated = false;
		bgWhite_anim.enabled = true;
		StartCoroutine(bgSound());
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) GameStart();


		if (Input.touchCount > 0)
		{
			theTouch = Input.GetTouch(0);

			if (theTouch.phase == TouchPhase.Began)
			{
				startTouchPosition = theTouch.position;
			}

			if (theTouch.phase == TouchPhase.Ended)
			{
				endTouchPosition = theTouch.position;
				if (Mathf.Abs(endTouchPosition.y - startTouchPosition.y) > 50f)
				{
					GameStart();
				}
			}
		}

		if (bg.transform.position.y <= -19.78f)
		{
			rb.simulated = false;
		}

		if (ball.transform.position.z == 0f)
		{
			StartCoroutine(LoadLevel());
		}
	}
	private void SetFun()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		Debug.Log("Settings CLICK");
	}

	private void MoneyFun()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		Debug.Log("MoneyClick");
	}

	private void GameStart()
	{
		FindObjectOfType<AudioManager>().Play("Swipe");
		FindObjectOfType<AudioManager>().Stop("Birds");
		FindObjectOfType<AudioManager>().Play("Space");
		speedEf.Play();
		StartCoroutine(stopEffect());
		StartCoroutine(windIn());
		StartCoroutine(starsStart());
		rb.simulated = true;
		Destroy(swipes);
		Destroy(plane);
		left_anim.enabled = true;
		right_anim.enabled = true;
		ball_anim.enabled = true;
	}

	private IEnumerator LoadLevel()
	{
		DontDestroyOnLoad(stars);
		AsyncOperation operation = SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
		while (!operation.isDone)
		{
			FindObjectOfType<AudioManager>().Play("Loading");
			yield return null;
		}
		FindObjectOfType<AudioManager>().Stop("Loading");
	}

	private IEnumerator bgSound()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.3f);
			FindObjectOfType<AudioManager>().Play("BeforeStart");
			StartCoroutine(bgOut());
			break;
		}
	}
	private IEnumerator bgOut()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);
			bgWhite.SetActive(false);
			FindObjectOfType<AudioManager>().Play("Birds");
			break;
		}
	}
	private IEnumerator windIn()
	{
		while (true)
		{
			yield return new WaitForSeconds(8f);
			FindObjectOfType<AudioManager>().Play("Wind");
			break;
		}
	}
	private IEnumerator stopEffect()
	{
		while (true)
		{
			yield return new WaitForSeconds(5f);
			speedEf.Stop();
		}
	}
	private IEnumerator starsStart()
	{
		while (true)
		{
			yield return new WaitForSeconds(2.5f);
			stars.Play();
			break;
		}
	}
	private void LoadSaveElements(Player play)
	{
		play.Load();
		if (play.highScore < Scores.totalScores)
		{
			play.highScore = Scores.totalScores;
			record_anim = record.GetComponent<Animator>();
			record_anim.enabled = true;
			FindObjectOfType<AudioManager>().Play("HS");
		}
		if (Scores.money != 0)
		{
			play.money = play.money + Scores.money;
		}
		play.Save();
	}
}
