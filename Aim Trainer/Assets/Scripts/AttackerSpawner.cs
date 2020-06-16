using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
	public Base enemyprefab;
	Vector3 SpawnPos;
	public UIManager score;

	void Start()
	{
		InvokeRepeating("Spawn", 0.5f, 2f);
	}

	private void FixedUpdate()
	{
		if (!GameManager.Instance.playerBase.gameObject.activeInHierarchy)
			CancelInvoke("Spawn");
	}

	public void Spawn()
	{
		float x = Random.Range(10, -10);
		float y = Random.Range(-10, 10);
		SpawnPos = new Vector3(x, y, 0);
		Base base1 = Instantiate(enemyprefab, SpawnPos, Quaternion.identity).GetComponent<Base>();
		base1.transform.SetParent(GameManager.Instance.mainObjects.transform);
		base1.Setup(score);
	}
}