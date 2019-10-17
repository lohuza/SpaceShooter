using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _tripleShotPowerUp;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private int _spawnSpeed = 5;
    [SerializeField]
    private int _powerUpSpawnSpeed = 15;
    [SerializeField]
    private int _maxEnemy = 10;
    private IEnumerator _coroutine;
    private bool _stopSpawning = false;
    private float _maxXAxis = 9.68f;
    private float _mixXAxis = -9.68f;
    private float _maxYAxis = 7.23f;

    // Start is called before the first frame update
    private void Start()
    {
        _coroutine = SpawnEnemy();
        IEnumerator powerUpsSpawn = SpawnPowerUp();
        StartCoroutine(_coroutine);
        StartCoroutine(powerUpsSpawn);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator SpawnEnemy()
    {
        while (!_stopSpawning)
        {
            int enemyAmount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (enemyAmount <= _maxEnemy)
            {
                Instantiate(_enemy, _enemyContainer.transform);
            }

            yield return new WaitForSeconds(_spawnSpeed);
        }
    }

    private IEnumerator SpawnPowerUp()
    {
        while (!_stopSpawning)
        {
            Vector3 position = new Vector3(Random.Range(_mixXAxis, _maxXAxis), _maxYAxis);
            Instantiate(_tripleShotPowerUp, position, Quaternion.identity);

            yield return new WaitForSeconds(_powerUpSpawnSpeed);
        }
    }

    public void StopSpawning()
    {
        _stopSpawning = true;
    }
}
