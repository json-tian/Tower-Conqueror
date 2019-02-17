using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{

    public Transform target;
    public float speed = 2f;

    public float damage = 5f;
    // Start is called before the first frame update
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

        if (obj.tag == "Army")
        {
            obj.SendMessage("Hurt", damage);
            Destroy(gameObject);
        }
    }
}
