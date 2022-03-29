using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPointsFire;
    public SpawnObject[] bullets;
    public Transform spawnPointsRockL;

    public float timeStartSpawnRock;
    public GameObject player;
    Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.isDead == false){
            if(bullets[0].timeBtwSpawns <= 0){
                Transform randomSpawnPoint = spawnPointsFire[Random.Range(0,spawnPointsFire.Length)];
                Instantiate(bullets[0].bullet,randomSpawnPoint.position, Quaternion.identity);

                if (bullets[0].startTimeBtwSpawns > bullets[0].minTimeBtwSpawn){
                    bullets[0].startTimeBtwSpawns -= bullets[0].decrease;
                }
                bullets[0].timeBtwSpawns = bullets[0].startTimeBtwSpawns;
            }else {
                bullets[0].timeBtwSpawns -= Time.deltaTime;
            }
            if(timeStartSpawnRock<0){
                if(bullets[1].timeBtwSpawns <= 0){
                    Instantiate(bullets[1].bullet,spawnPointsRockL.position, Quaternion.identity);

                    if (bullets[1].startTimeBtwSpawns > bullets[1].minTimeBtwSpawn){
                        bullets[1].startTimeBtwSpawns -= bullets[1].decrease;
                    }

                    bullets[1].timeBtwSpawns = bullets[1].startTimeBtwSpawns;
                }else {
                bullets[1].timeBtwSpawns -= Time.deltaTime;
                }
            }else{
                timeStartSpawnRock -= Time.deltaTime;
            }
        }
    }
}
