using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour { 

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave 
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
        // public int health;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 3f;
    public float waveCountDown;

    private float searchCountDown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemyisAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }


        if (waveCountDown <= 0) 
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine( SpawnWave ( waves [nextWave] ));
            }
         }
        else
        {
        waveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Player Wins!");
            Time.timeScale = 0;
            return;

        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyisAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        
        for(int i = 0; i < _wave.count; i++)
        {   
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds( 1f/_wave.rate );

        }

        state = SpawnState.WAITING;


        yield break;
    }
    
    void SpawnEnemy (Transform _enemy)
    {
        Debug.Log("Spawning Enemy:" + _enemy.name);

        Instantiate(_enemy);
        _enemy.transform.position = new Vector3(0, 1, 0);
        float angle = Random.Range(0, 360);
        _enemy.transform.Rotate(0, angle, 0);

        /*Instantiate (_enemy, transform.position = new Vector3(0,1,0));
        float angle = Random.Range(0, 360);
        _enemy.transform.Rotate(0, angle, 0);*/


    }


}
