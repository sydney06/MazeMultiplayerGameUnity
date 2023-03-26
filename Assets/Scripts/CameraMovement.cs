using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _player;

    private Transform _camera;

    private Vector3 _offset;

    private bool canBeginOp = false;


    private void Awake()
    {
        _camera = this.transform;
        //_player = GameObject.FindGameObjectWithTag("Player").transform;
        //_offset = _camera.position - _player.position;
    }

    private void Start()
    {
        StartCoroutine(DelayedOperation());
    }

    private void Update()
    {
        if (canBeginOp)
        {
            Follow(); 
        }
    }

    private void Follow()
    {
        _camera.DOMoveX(_player.position.x + _offset.x, _speed * Time.deltaTime);
        _camera.DOMoveZ(_player.position.z + _offset.z, _speed * Time.deltaTime);
    }

    IEnumerator DelayedOperation()
    {
        yield return new WaitForSeconds(1);
        
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _offset = _camera.position - _player.position;

        canBeginOp = true;
    }
}
