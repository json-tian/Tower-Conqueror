using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : MonoBehaviour
{
    public float health = 50f;
    public float range = 2f;
    public float speed = 0.5f;

    public float damage = 5f;

    public Transform target;
    public Transform goal;

    public float worth = 5f;

    public GameObject bulletPrefab;
    public Transform self;

    public int fireRate = 1;
    public float attackCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = GameObject.Find("HomeBase");
        goal = temp.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FindNextTarget();

        if (target != null)
        {
            Attack();
        }
        else
        {
            attackCounter = fireRate;
            if (goal != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, goal.position, speed * Time.deltaTime);
            }
        }
    }

    void FindNextTarget()
    {
        int layerMask = 1 << 9;    //Bit shifting from layer 9
        Collider[] enemies = Physics.OverlapSphere(transform.position, range, layerMask);

        if (enemies.Length > 0)
        {
            target = enemies[0].gameObject.transform;

            foreach (Collider enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);

                if (distance < Vector3.Distance(transform.position, target.position))
                {
                    target = enemy.gameObject.transform;

                }
            }
        }
        else
        {
            target = null;
        }
    }

    void Attack()
    {
        if (attackCounter <= 0)
        {
            GameObject newBullet = Instantiate(bulletPrefab, self.position, Quaternion.identity);
            newBullet.GetComponent<MonsterBullet>().target = target;
            attackCounter = fireRate;
        }
        else
        {
            attackCounter -= Time.deltaTime;
        }
    }

    public void Hurt(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Cash.Amount += worth;
            Destroy(gameObject);
        }
    }
}
