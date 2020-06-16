using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public string path = "Assets/Playerdata";

	public const int levelTimer = 120;

	public BallMovement playerBase;

    public PlayerData data;

	public GameObject mainObjects;

	#region Singleton
	private void CreateSingleton()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(this.gameObject);
		}
		// DontDestroyOnLoad(this.gameObject);
	}
	#endregion

	private void Awake()
    {
        CreateSingleton();

        ReadData();
    }

    public void SaveData()
    {
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();

            PlayerData pData = data;

            string jReader = JsonUtility.ToJson(pData, true);

            File.WriteAllText(path, jReader);
        }
		else
		{
			PlayerData pData = data;

			string jReader = JsonUtility.ToJson(pData, true);

			File.WriteAllText(path, jReader);
		}
    }

	public void ReadData()
    {
        if (File.Exists(path))
        {
            var str = File.ReadAllText(path);

            var playerData = JsonUtility.FromJson<PlayerData>(str);

            data = playerData;

            string jReader = JsonUtility.ToJson(playerData, true);

            File.WriteAllText(path, jReader);
        }
    }

    private void OnApplicationQuit()
    {
		if (!string.IsNullOrEmpty(data.name) && data.name != "")
			SaveData();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
			if (!string.IsNullOrEmpty(data.name) && data.name != "")
				SaveData();
        }
    }
}
