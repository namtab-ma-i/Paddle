using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public static int Level = 1;

    public static void Load(int level)
    {
        //todo: show loading scene 
        Level = level;
        SceneManager.LoadScene (0);
    }
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string path = "Assets/Levels/level" + Level + ".json"; //todo: encrypt & decrypt file!!!
        StreamReader reader = new StreamReader(path);
        string jsonData = reader.ReadToEnd();
        reader.Close();
        LevelConfig conf = JsonUtility.FromJson<LevelConfig>(jsonData);
        
        //todo: make separate setup functions for enemy and level
        //todo: add more level config properties
        
        GameObject levelObj = GameObject.FindGameObjectWithTag ("Level");
        Level levelScript = levelObj.GetComponent<Level>();
        levelScript.points = conf.points;
        levelScript.currentLevel = Level;
        levelScript.playerScore = GameObject.Find("/DeadZone/Back");
        levelScript.enemyScore = GameObject.Find("/DeadZone/Front");
        
        GameObject enemyObj = GameObject.FindGameObjectWithTag ("Enemy");
        enemyObj.GetComponent<Enemy>().speed = conf.aispeed;
    }

    private class LevelConfig
    {
        public int points;
        public int aispeed;
    }
    
    
}
