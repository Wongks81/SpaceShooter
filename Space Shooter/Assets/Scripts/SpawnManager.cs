﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _tripleshotpowerUpPrefab;
    [SerializeField]
    private GameObject _speedpowerUpPrefab;
    [SerializeField]
    private GameObject _shieldpowerUpPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private int _maxEnemies=0;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator SpawnEnemyRoutine()
    {
       
        while (_stopSpawning == false && _maxEnemies < 5)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(Random.Range(-10f, 10f), 8.0f, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
            _maxEnemies++;
        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        int randomID;
        
        while(_stopSpawning == false )
        {
            randomID = Random.Range(0, 3);
            Debug.Log("ID " + randomID);

            switch (randomID)
            {
                case 0:
                    Instantiate(_tripleshotpowerUpPrefab, new Vector3(Random.Range(-8f, 8f), 8.0f, 0), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(_speedpowerUpPrefab, new Vector3(Random.Range(-8f, 8f), 8.0f, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(_shieldpowerUpPrefab, new Vector3(Random.Range(-8f, 8f), 8.0f, 0), Quaternion.identity);
                    break;
                default:
                    Debug.Log("Random ID not in range");
                    break;

            }
           
            yield return new WaitForSeconds(Random.Range(3.0f,7.0f));
        }
    }

    public void PlayerDeath()
    {
        _stopSpawning = true;
    }
}
