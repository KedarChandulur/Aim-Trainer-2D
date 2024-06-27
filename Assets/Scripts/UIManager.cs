using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public Text score;
	public Text WinText;
	public int Count;
	[SerializeField] private InputField inputField;
	[SerializeField] private Text playerName;
	[SerializeField] private Button goButton;
	[SerializeField] private Button restartButton;
	private int newTargetScore;
	[SerializeField] private GameObject panel;
	public Text healthBar;
	public Text howTo;
	[SerializeField]private float timerCount;
	private bool playerDead;
	public Text timerText;
	public int health;

	private void Awake()
	{
		restartButton.onClick.AddListener(Restart);
		goButton.onClick.AddListener(UpdateTargetScore);
	}

	void Start()
	{
		howTo.text = "Move around using WASD/Arrow Keys,Aiming on enemy and press Left Click to Kill the Enemy.";
		health = 100;
		playerName.text = "Name : " + GameManager.Instance.data.name;
		restartButton.gameObject.SetActive(false);
		WinText.gameObject.SetActive(false);
		Count = 0;
		score.text = "Score: " + Count.ToString();
		//panel.SetActive(true);
		timerCount = GameManager.Instance.data.levelTimer;
	}

	private void Update()
	{
		if (!playerDead)
		{
			timerCount -= Time.deltaTime;

			if ((int)(timerCount) < 0)
			{
				playerDead = true;
			}

			if ((int)timerCount % 60 < 10)
			{
				timerText.text = "0" + ((int)(timerCount / 60)).ToString() + ":0" + ((int)(timerCount % 60)).ToString();
			}
			else
			{
				timerText.text = "0" + ((int)(timerCount / 60)).ToString() + ":" + ((int)(timerCount % 60)).ToString();
			}
		}
		else
		{
			howTo.text = "PlayerDead,Restart the Game.";
		}
	}

	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	void UpdateTargetScore()
	{
		newTargetScore = int.Parse(inputField.text);
		panel.SetActive(false);
	}

	public void UpdateScoreUI()
	{
		score.text = "Score: " + Count.ToString();
		if (Count == newTargetScore)
		{
			WinText.gameObject.SetActive(true);

			Time.timeScale = 0;
		}
	}
}