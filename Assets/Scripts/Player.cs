using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private float _maxXAxis = 10.5f;
    private float _minXAxis = -10.5f;
    private float _maxYAxis = 0;
    private float _minYAxis = -3.9f;
    private float _laserPositionOffset = 1.05f;
    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private float _fireRate = 0.2f;
    private float _nextFire = 0f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The spawn manager is null");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();
        RestrictPlayerMovement();
        Keybinds();
    }

    private void Keybinds()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            FireTheLaser();
        }
    }

    private void FireTheLaser()
    {
        _nextFire = Time.time + _fireRate;
        Vector3 laserPosition = new Vector3(transform.position.x, transform.position.y + _laserPositionOffset);
        Instantiate(_laser, laserPosition, Quaternion.identity);
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput);

        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void RestrictPlayerMovement()
    {
        XAxisRestrictions();
        YAxisRestrictions();
    }

    private void XAxisRestrictions()
    {
        if (transform.position.x >= _maxXAxis)
        {
            transform.position = new Vector3(_minXAxis, transform.position.y);
        }
        else if (transform.position.x <= _minXAxis)
        {
            transform.position = new Vector3(_maxXAxis, transform.position.y);
        }
    }

    private void YAxisRestrictions()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, _minYAxis, _maxYAxis));
    }

    public void Damage()
    {
        _lives -= 1;
        if(_lives < 1)
        {
            _spawnManager.StopSpawning();
            Destroy(this.gameObject);
        }
    }
}
