using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public Transform trigger;
    [Header("Attack settings")]
    public int damage = 10;
    public float cooldown = 0.5f;
    private bool isAttacking = false;
    public AudioClip chompSound;

    public NavMeshAgent agent;
    AudioSource src;
    TriggerAI triggered;
    // Start is called before the first frame update
    void Start()
    {
        triggered = trigger.GetComponent<TriggerAI>();
        agent = GetComponent<NavMeshAgent>();
        src = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
         if (target != null && agent.enabled)
         {
            agent.SetDestination(target.position);

            var targetRotation = target.position - transform.position;
            targetRotation.y = 0;

            Quaternion rotation = Quaternion.LookRotation(targetRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
        }
        var distance = Vector3.Distance(transform.position, target.position);

        if (distance - agent.stoppingDistance <= 0.3f && !isAttacking && target.GetComponent<Health>().health != 0)
        {
            StartCoroutine(Attack());
            isAttacking = true;
        }
    }

    IEnumerator StopAndWait()
    {
        agent.enabled = false;
        yield return new WaitForSeconds(2f);
        agent.enabled = true;
    }
    IEnumerator Attack()
    {

        target.GetComponent<Health>().TakeDamage(damage);

        agent.enabled = false;
        
        src.PlayOneShot(chompSound);
        print("chomp");

        yield return new WaitForSeconds(cooldown);
        isAttacking = false;
        agent.enabled = true;
    }
}
