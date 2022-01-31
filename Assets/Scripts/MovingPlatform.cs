using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform _pointA, _pointB;
    float _speed = 3f;
    bool _goToPointB = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_goToPointB == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, Time.deltaTime * _speed);
        }
        else if (_goToPointB == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, Time.deltaTime * _speed);
        }

        if (transform.position == _pointB.position)
        {
            _goToPointB = false;
            
        }
        else if (transform.position == _pointA.position)
        {
            _goToPointB = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
