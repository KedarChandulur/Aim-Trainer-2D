using UnityEngine;

public class Base : MonoBehaviour
{
    Vector3 attackermove;
    public BallMovement playerBase;
    [SerializeField] private float movementspeed;
	private UIManager score;
	public bool gameOver;
	
	void Start ()
	{
		if(GameManager.Instance.playerBase!=null)
		playerBase = GameManager.Instance.playerBase;
	}	
	
	public void Setup(UIManager score)
	{
		this.score = score;
	}

	void FixedUpdate ()
	{
		if (!gameOver)
		{
			attackermove = playerBase.transform.localPosition - transform.localPosition;
			transform.Translate(attackermove *Random.Range(2,5) * Time.deltaTime);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{ 
		if (collision.gameObject.CompareTag("Player"))
		{
			Destroy(this.gameObject);

			score.health -= 25;

			score.healthBar.text = "Health : " + score.health.ToString();

			if (score.health <= 0)
			{
				gameOver = true;

				playerBase.playerDead = true;

				GameManager.Instance.data.highScore = score.Count;

				GameManager.Instance.data.names.Add(GameManager.Instance.data.name + " : " + score.Count);

				collision.gameObject.SetActive(false);

				if (!string.IsNullOrEmpty(GameManager.Instance.data.name) && GameManager.Instance.data.name != "")
					GameManager.Instance.SaveData();

				UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");			
			}
		}
	}

	protected void OnMouseDown()
    {
        score.Count++;
		score.UpdateScoreUI();
        Destroy(gameObject);
	}        
}