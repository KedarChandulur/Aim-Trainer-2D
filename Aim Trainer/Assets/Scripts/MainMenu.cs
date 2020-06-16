using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public InputField playerName;

	public InputField score;

	public GameObject highScorepanel;

	public GameObject mainhighScorepanel;

	public Toggle highScoreButton;

	public Button gotoGameButton;

	public Text highScore;

	public List<int> highScores = new List<int>();

	public List<string> names = new List<string>();

	public GameObject highScoreprefab;

	private void Awake()
	{
		gotoGameButton.onClick.AddListener(UpdateDetails);

		highScoreButton.onValueChanged.AddListener(ActivateHighScoresPanel);
	}

	private void Start()
	{
		GameManager.Instance.data.names.Sort((x, y) => int.Parse(y.Substring(y.LastIndexOf(":") + 1)).CompareTo(int.Parse(x.Substring(x.LastIndexOf(":") + 1))));

		names.AddRange(GameManager.Instance.data.names);

		if (names.Count > 0)
		{
			for (int i = 0; i < names.Count; i++)
			{
				var go = Instantiate(highScoreprefab);

				go.transform.SetParent(highScorepanel.transform);

				go.GetComponentInChildren<Text>().text = names[i];
			}

			highScore.text = "Current HighScore :- " + GameManager.Instance.data.names[0];
		}
		else
		{
			highScore.text = "HighScore : 0";
		}


	}

	private void ActivateHighScoresPanel(bool status)
	{
		mainhighScorepanel.SetActive(!status);

		highScorepanel.SetActive(!status);

		playerName.gameObject.SetActive(status);

		highScore.gameObject.SetActive(status);

		gotoGameButton.gameObject.SetActive(status);
	}

	private void UpdateDetails()
	{
		if (GameManager.Instance != null && GameManager.Instance.mainObjects != null && GameManager.Instance.playerBase != null)
		{
			GameManager.Instance.data.name = playerName.text;

			GameManager.Instance.data.levelTimer = GameManager.levelTimer;

			GameManager.Instance.mainObjects.SetActive(true);

			this.gameObject.SetActive(false);
		}
	}
}