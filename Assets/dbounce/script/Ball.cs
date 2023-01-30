using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
	Vector2 MousePosition;
	Camera Camera;

	coin coinsManager;
	public int Coin;
	public int ScoreCount = 0;
	public GameObject block2;
	

	public Text textCoins;
	public Text textScoreCounts;
	
	public Text highScoreText;
	public Text highCoinText;

	//sound
	
	public AudioSource mySfx;
	public AudioClip getcoin;
	public AudioClip goalin;
	public AudioClip heatwall;

	



	[HideInInspector] public Rigidbody2D rb;
	[HideInInspector] public CircleCollider2D col;
	
	


	[HideInInspector] public Vector3 pos { get { return transform.position; } }

	public GameObject GameOver;
	public GameObject Pannel;
	public GameObject wall;
	//public GameObject wall_right;
	public int hiScoreCount;
	public int hiCoinCount;





	//------coin managing-------------------------
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<CircleCollider2D>();
	}

	
	void Start()
    {

		// coin, score initialize
		PlayerPrefs.SetInt("Score", 0);
		PlayerPrefs.SetInt("HighScore", 0);
		PlayerPrefs.SetInt("HighCoin", 0);





		PlayerPrefs.SetInt("Score", ScoreCount);

		if (PlayerPrefs.GetInt("HighScore",0) != null)
        {

			hiScoreCount = PlayerPrefs.GetInt("HighScore");
			//PlayerPrefs.GetFloat("HighScore", hiScoreCount);
		}
		if (PlayerPrefs.GetInt("HighCoin", 0) != null)
		{




			hiCoinCount = PlayerPrefs.GetInt("HighCoin");
		}

		rb = GetComponent<Rigidbody2D>();
		//
		//Camera = GameObject.Find("Camera").GetComponent<Camera>();


	}


	// OnTriggerEnter2D는 충돌이 일어날때 한번만 호출되는 함수


	public float speed = 5f;

	

	void Update()
    {

		float xMove = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
		float yMove = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
		this.transform.Translate(new Vector3(xMove, yMove, 0));

	}



	//sound function
	public void Getcoinsound()
    {
		mySfx.PlayOneShot(getcoin);
    }

	public void shotgoal()
	{
		mySfx.PlayOneShot(goalin);
	}

	public void hitwall()
	{
		mySfx.PlayOneShot(heatwall);
	}



	private void OnTriggerEnter2D(Collider2D other)
	{
		//if (other.transform.tag == "block2")
		//{
			//Debug.Log("block");
			//block2.SetActive(false);
			//block2.SetActive(false);
			//Destroy(other.gameObject);

//		}


		if (other.transform.tag == "coin")
		{
			Coin++;
			textCoins.text = "Coin :" + Coin.ToString();

			Getcoinsound();
			//if (Coin > hiCoinCount)
			//	{
			hiCoinCount ++;
			PlayerPrefs.SetInt("HighCoin", hiCoinCount);
			//}
			//highCoinText.text = "High Coin:" + hiCoinCount;


			Destroy(other.gameObject);

		}
		
		if (other.transform.tag == "SC")
		{
			shotgoal();
			//ScoreCount++;
			ScoreCount += 2;
			
			textScoreCounts.text = "" + ScoreCount.ToString();
			PlayerPrefs.SetInt("Score", ScoreCount);

			if (ScoreCount > hiScoreCount)
            {
				hiScoreCount = ScoreCount;
				PlayerPrefs.SetInt("HighScore", hiScoreCount);
            }
			highScoreText.text = "BEST" + hiScoreCount;

			Destroy(other.transform.parent.gameObject);

			Debug.Log("GOAL!!!");
			
		}


	}

	

   // private void OnCollisionEnter2D(Collision2D colli)
    //{
       // if(colli.gameObject.tag =="GameOver")
        //{
			//Debug.Log("GAMEOVER");

			

//			SceneManager.LoadScene("Gameover");
//
	//		Pannel.SetActive(true);
	//		//시간을 멈춰라
	//		Time.timeScale = 0.0f;
			
	//	}

		//양쪽 벽에 부딛혔을때 핸드폰 진동 울리는 함수
		//if (colli.transform.tag == "wall")
		//{
			
		//	int call = PlayerPrefs.GetInt("vibmuted");
		//	if (call == 0)
		//	{
		//		Debug.Log("vib");
		//		vib();
		//	}

//		}
//	}

	//public void vib()
	//{
//		Handheld.Vibrate();
//		Debug.Log("vibration");
//	}

    //end coin managing-------------------------------



    public void Push(Vector2 force)
	{
		rb.AddForce(force, ForceMode2D.Impulse);
	}

	public void ActivateRb()
	{
		rb.isKinematic = false;
	}

	public void DesactivateRb()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0f;
		rb.isKinematic = true;
	}


		
	private float jumpforce = 300f;



	public void jumpright()
	{
		// if(Input.GetMouseButtonDown(0))
		//{
		rb.velocity = new Vector2(0, 0);
		rb.AddForce(new Vector2(50f, jumpforce));
		//}
	}
	public void jumpleft()
	{
		// if(Input.GetMouseButtonDown(0))
		//{
		rb.velocity = new Vector2(0, 0);
		rb.AddForce(new Vector2(-50f, jumpforce));
		//}
	}




}