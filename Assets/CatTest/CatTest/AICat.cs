using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public class AICat : MonoBehaviour
{
    private NavMeshAgent _navAgent;

    [SerializeField]
    private List<Transform> _waypoints;
    private int _target;

    private void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        if (_waypoints.Count > 1 && _waypoints[0])
            _navAgent.SetDestination(_waypoints[0].position);

    }


    public GameObject catUI;

    private void FixedUpdate()
    {
        catUI.transform.eulerAngles = new Vector3(45, -45, 0);    
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WayPoint"))
        {
            _target++;
            if(_target == _waypoints.Count)
            {
                _waypoints.Reverse();
                StartCoroutine(lookToCam());
                _target = 1;
            }
        }

        if (_waypoints.Count >= _target && _waypoints[_target])
            _navAgent.SetDestination(_waypoints[_target].position);
        
    }


    public Rig _aimRig;
    public Animator _animator;
    public IEnumerator lookToCam()
    {
        _navAgent.speed = 0;
        _animator.SetBool("sit", true);
        for (int i = 0; i <= 100; i++)
        {
            _aimRig.weight = i / 100f;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.1f);
        for (int i = 100; i >= 0; i--)
        {
            _aimRig.weight = i / 100f;
            yield return new WaitForSeconds(0.01f);
        }
        _animator.SetBool("sit", false);
        _navAgent.speed = 0.2f;
    }
}
