using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float _maxYPosition = -5.5f;
    [SerializeField]
    private float _speed = 3f;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        DestroyWhenOutOfScreen();
    }

    private void Movement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<Player>().ActivateTripleShot();
            Destroy(this.gameObject);
        }
    }

    private void DestroyWhenOutOfScreen()
    {
        if(transform.position.y < _maxYPosition)
        {
            Destroy(this.gameObject);
        }
    }
}
