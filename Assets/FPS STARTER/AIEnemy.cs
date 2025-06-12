using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent aiEnemy;
    [SerializeField] private GameObject playerPosition;
    void Start()
    {
        aiEnemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        aiEnemy.SetDestination(playerPosition.transform.position);
        aiEnemy.updateRotation = false;
    }
}
