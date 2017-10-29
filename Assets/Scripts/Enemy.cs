using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _navMesh;
    private GameObject _player;

    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        _navMesh.destination = _player.transform.position;
    }
}

