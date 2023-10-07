using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform PlayerTransform;
    private bool CanMove = true;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject PlayerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = PlayerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            agent.SetDestination(PlayerTransform.position);
        }
        transform.LookAt(PlayerTransform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanMove = false;
            agent.ResetPath();
            Invoke("ContinueChasing", 5);
            print("Collision with player");
        }    
    }

    private void ContinueChasing()
    {
        CanMove = true;
    }
}
