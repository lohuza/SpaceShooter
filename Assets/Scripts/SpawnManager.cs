using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private int _spawnSpeed = 5;
    [SerializeField]
    private int _maxEnemy = 10;
    private IEnumerator _coroutine;
    private bool _stopSpawning = false;

    // Start is called before the first frame update
    private void Start()
    {
        _coroutine = SpawnEnemy();
        StartCoroutine(_coroutine);
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

    public void StopSpawning()
    {
        Debug.Log("stopping spawn");
        _stopSpawning = true;
    }
}
