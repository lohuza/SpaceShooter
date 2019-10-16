using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _maxYAxis = 6.9f;
    private float _minYAxis = -5.21f;
    private float _maxXAxis = 9.5f;
    private float _minXAxis = -9.5f;
    private Random _random;
    [SerializeField]
    private float _speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        EnemySpawn();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        if (transform.position.y < _minYAxis)
        {
            EnemySpawn();
        }
    }

    private void EnemyMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void EnemySpawn()
    {
        float x = Random.Range(_minXAxis, _maxXAxis);
        transform.position = new Vector3(x, _maxYAxis);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            player?.Damage();
            Destroy(this.gameObject);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
