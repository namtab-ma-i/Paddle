using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

	public int points;
	public int currentLevel = 1;
	public GameObject playerScore;
	public GameObject enemyScore;

	//todo: add end features; not only by score, but also by time etc
	public void checkEnd(int playerScore, int enemyScore)
	{
		if (playerScore >= points)
		{
			PlayerPrefs.SetInt("level", currentLevel);
			Loader.Load(++currentLevel);
		} else if (enemyScore >= points)
		{
			Loader.Load(currentLevel);
		}
	}

	void FixedUpdate()
	{
		int playerScore = this.playerScore.GetComponent<Score>().playerScore;
		int enemyScore = this.enemyScore.GetComponent<Score>().playerScore;
		checkEnd(playerScore, enemyScore);
	}
}
