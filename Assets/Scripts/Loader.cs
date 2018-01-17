using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Singleton utility for loading and configuring levels
 */
public class Loader : MonoBehaviour
{
    private static int Level = 1; // current level
    private Vector3 transformOriginal;
    private int playerLevel;
    
    /**
     * Initializing Loader instance that will be used in static context
     */
    void Awake()
    {
        playerLevel = PlayerPrefs.GetInt("level");
    }

    /**
     * Static method for loading next level outside the Loader class
     */
    public static void Load(int level)
    {
        Level = level;
        SceneManager.LoadScene (3); // screen scene
    }
    
    /**
     * Loading screen coroutine that shows Level <n> title for 2 seconds
     */
    IEnumerator LoadScreen()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene (0);
    }

    /**
     * Method that allows OnSceneLoaded to be called when the scene is fully loaded
     * Could be a single instance (main scene) or multiple instances (one for each level label on select level scene)
     */
    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            TextMesh levelLabel = GetComponent<TextMesh>();
            int level = int.Parse(levelLabel.text);
            if (level <= playerLevel)
            {
                levelLabel.color = Color.green;
            }
        }
        else
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }
    
    /**
     * Main scene configuring function
     */
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        //loading screen
        if (scene.buildIndex == 3)
        {
            TextMesh levelNum = GameObject.Find("/Number").GetComponent<TextMesh>();
            levelNum.text = "" + Level;
            StartCoroutine(LoadScreen());
            return;
        }
        
        // level config reading and setting up
        
        string path = "Assets/Levels/level" + Level + ".json"; //todo: encrypt & decrypt file!!!
        StreamReader reader = new StreamReader(path);
        string jsonData = reader.ReadToEnd();
        reader.Close();
        LevelConfig conf = JsonUtility.FromJson<LevelConfig>(jsonData);
        
        //todo: make separate setup functions for enemy and level in Level class
        //todo: add more level config properties
        
        GameObject levelObj = GameObject.FindGameObjectWithTag ("Level");
        Level levelScript = levelObj.GetComponent<Level>();
        levelScript.points = conf.points;
        levelScript.currentLevel = Level;
        levelScript.playerScore = GameObject.Find("/DeadZone/Back"); // setting score objects for dynamical update
        levelScript.enemyScore = GameObject.Find("/DeadZone/Front");
        
        GameObject enemyObj = GameObject.FindGameObjectWithTag ("Enemy");
        enemyObj.GetComponent<Enemy>().speed = conf.aispeed;
    }
    
    /**
     * If added to collider makes a game object smaller
     */
    void OnMouseEnter () {
        transformOriginal = transform.localScale;
        transform.localScale *= 0.9f;
    }

    /**
     * If added to collider makes a game object bigger again
     */
    void OnMouseExit () {
        transform.localScale = transformOriginal;
    }

    /**
     * If added to collider checks if player has already opened a level and loads it
     */
    void OnMouseDown ()
    {
        int playerLevel = PlayerPrefs.GetInt("level");
        int level = int.Parse(GetComponent<TextMesh> ().text);
        if (playerLevel >= level)
        {
            Load(level);
        }
    }

    /**
     * Represents JSON level file structure 
     */
    private class LevelConfig
    {
        public int points;
        public int aispeed;
    }
    
    
}
