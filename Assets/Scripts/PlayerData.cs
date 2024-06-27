using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public string name;

	public int levelTimer;

	public List<int> allhighScores = new List<int>();

	public List<string> names = new List<string>();

	public int highScore;

	public int noofEnemiesKilled;
}
