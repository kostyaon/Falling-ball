using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    public Text scores, moneyCloud;
    public GameObject baskPrefab, bgWhite;
    public static int health;
    public static int money;
    public static int totalScores
    {
        get
        {
            return score;
        }
    }
    [SerializeField]
    private float bask_speed;
    private float deltaBaskPos = 3.8f;
    private Coroutine cor;
    private Clone cl_1;
    private bool bon;
    private static int score;
    private Animator bgWhite_anim;
    private Player player;
    public float speed
    {
        get
        {
            return bask_speed;
        }
    }
    public bool objCheck
    {
        get
        {
            return cl_1.check;
        }
    }

    public bool bonus
    {
        set
        {
            bon = value;
        }
    }

    private void Awake()
    {
        cl_1 = (new GameObject("Clone_class").AddComponent<Clone>());
        bgWhite_anim = bgWhite.GetComponent<Animator>();
        player = gameObject.AddComponent<Player>();
        player.Load();
        moneyCloud.text = player.money.ToString();
    }
    private void Start()
    {
        score = 0;
        bask_speed = 2f;
        health = 2;
        cl_1.sec = deltaBaskPos / bask_speed;
        cl_1.Spawner(baskPrefab);
        cor = StartCoroutine(Speedup());
    }

    private void Update()
    {
        if (bask_speed > 5.7f)
        {
            StopCoroutine(cor);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        FindObjectOfType<AudioManager>().Play("Health");
        Basket.check = true;
        score += 2;
        if (transform.position.y < -1.7f)
        {
            score++;
        }
        if (bon == true)
        {
            score += 8;
        }
        scores.text = score.ToString();
        Destroy(other.GetComponent<Collider2D>());
    }

    public void checkHealth(int hp)
    {
        hp--;
        FindObjectOfType<AudioManager>().Play("Missed_basket");
        if (hp == 1)
        {
            //animation almost boom
            Debug.Log("have 1 health");
        }
        else if (hp == 0)
        {
            //animation boom
            //Menu GameOver
            FindObjectOfType<AudioManager>().Play("Boom");
            StartCoroutine(Wait());
            FindObjectOfType<AudioManager>().Stop("Wind");
            Debug.Log("have 0 health");
            money = totalScores / 10;
            bgWhite_anim.enabled = true;
            StartCoroutine(BgWhite());
        }
        health = hp;
    }

    private IEnumerator Speedup()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            cl_1.sec = deltaBaskPos / bask_speed;
            bask_speed += 0.01f;
        }
    }

    public static IEnumerator BgWhite()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.2f);
            SceneManager.LoadScene("MainMenu");
        }
    }

    private IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.7f);
        }
    }

    public void moneyAmount()
    {
            moneyCloud.text = player.money.ToString();
    }
}
