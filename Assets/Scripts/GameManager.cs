using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Borders")]
    public static float leftSide = 1.2f;
    public static float rightSide = 7.8f;
    public float borderLeft;
    public float borderRight;

    [Header("Collectibel Spawns")]
    public GameObject collectible;
    public GameObject player;
    public float randomX;
    public float randomZ;
    public float posZ;
    public bool creatCollectible = false;

    [Header("Destroy Collectible")]
    public GameObject[] objs;
    public bool desClone = false;

    [Header("Enemy Spawner")]
    public GameObject enemy;
    public bool spawnEnemy = false;

    [Header("Destroy Enemies")]
    public GameObject[] enemyObjs;
    public bool desEnemy;

    [Header("Game Over")]
    public GameObject gameOverText;
    public static bool isGameOver = false;
    public AudioSource music;

    private void Start()
    {
        isGameOver = false; 
        Time.timeScale = 1;
        music.Play();
    }
    private void Update() 
    {
        borderLeft = leftSide;
        borderRight = rightSide;

        posZ = Random.Range(100,130);
        randomX = Random.Range(leftSide+1,rightSide-1);
        randomZ = Random.Range(player.transform.position.z+40,player.transform.position.z+posZ);
        
        if(creatCollectible == false)
            {   
                creatCollectible = true;
                StartCoroutine(CollectibleSpawn());
            }

        if(desClone == false)
        {
            desClone = true;
            StartCoroutine(DestroyCollectibles());
        }

        if(spawnEnemy == false)
        {
            spawnEnemy = true;
            StartCoroutine(SpawnEnemy());
        }

        if(desEnemy == false)
        {
            desEnemy = true;
            StartCoroutine(DestroyEnemies());
        }

        if (isGameOver == true)
        {
            Time.timeScale = 0;
            gameOverText.SetActive(true);
            music.Stop();
            player.GetComponent<PlayerMovement>().enabled = false;
        }

        if(PauseGame.isGamePaused == true)
        {
            music.volume = .1f;
        }
        else{
            music.volume = 0.25f;
        }
    }

    IEnumerator CollectibleSpawn()
    {
        Instantiate(collectible,new Vector3(randomX,-1,randomZ),Quaternion.identity);
        yield return new WaitForSeconds(3);
        creatCollectible = false;
    }
    
    IEnumerator DestroyCollectibles()
    {
        objs = GameObject.FindGameObjectsWithTag("Sword");
         for(int i = 0; i < objs.Length-1; i++)
        {
            if(player.transform.position.z > objs[i].transform.position.z+80)
            {
                Destroy(objs[i]);   
            }
            
        }
        yield return new WaitForSeconds(4);
        desClone = false;
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemy,new Vector3(randomX,-2,randomZ),Quaternion.identity);
        yield return new WaitForSeconds(5);
        spawnEnemy = false;
    }

    IEnumerator DestroyEnemies()
    {
        enemyObjs = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemyObjs.Length-1; i++)
        {
            if(player.transform.position.z > enemyObjs[i].transform.position.z)
            {
                Destroy(enemyObjs[i]);
            }
        }
        yield return new WaitForSeconds(2);
        desEnemy = false;
    }
}   

