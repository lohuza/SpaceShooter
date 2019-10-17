using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.5f;
    private float _maxYAxis = 8;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        LaserMovement();
        DestroyObject();
    }

    private void LaserMovement()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    private void DestroyObject()
    {
        if(transform.position.y > _maxYAxis)
        {
            if(this.gameObject.transform.parent != null)
            {
                Destroy(this.gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
