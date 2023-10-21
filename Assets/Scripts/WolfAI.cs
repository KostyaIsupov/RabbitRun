using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class WolfAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform PlayerTransform;
    private bool CanMove = true;
    private Animator anim;
    private HealthSystem playerHS;
    public int hitDamage = 30;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        GameObject PlayerObject = GameObject.FindGameObjectWithTag("Player");
        playerHS = PlayerObject.GetComponent<HealthSystem>();
        PlayerTransform = PlayerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            agent.SetDestination(PlayerTransform.position);
            anim.SetFloat("speed", 1);
        }
        else
        {
            anim.SetFloat("speed", 0);
            agent.velocity.Set(0,0,0);
        }
        transform.LookAt(PlayerTransform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanMove = false;
            anim.SetTrigger("attack");
            agent.ResetPath();
            Invoke("ContinueChasing", 5);
            print("Collision with player");
        }    
    }

    private void ContinueChasing()
    {
        CanMove = true;
    }

    public void DamagePlayer()
    {
        playerHS.TakeDamage(hitDamage);
    }    
}
