using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 2f;
    public Vector2 damageRange = new Vector2(10, 20);
    public float damage;
    public GameObject shooter;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        DoShit(collision);
    }
    public void DoShit(Collision collision)
    {
        
        Destroy(gameObject);
    }
    public float TakeDamage()
    {
        return damage;
    }
}
