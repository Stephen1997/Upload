using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UPLOAD.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;

        void Update()
        {
            GetComponent<NavMeshAgent>().destination = target.position;
        }
    }
}
