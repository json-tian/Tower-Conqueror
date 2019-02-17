using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyBullet : MonoBehaviour
{

    public Transform target;
    public float speed = 2f;
    // Start is called before the first frame update
    public float damage = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;

        if (obj.tag == "Monster")
        {
            obj.SendMessage("Hurt", damage);
            Destroy(gameObject);
        }
    }
}
