using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    public static float health = 1000f;
    public float spawnCount = 0;
    public float spawnRate = 10f;

    public GameObject monsterPrefab;
    public Transform self;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCount <= 0)
        {
            GameObject newMonster = Instantiate(monsterPrefab, self.position, Quaternion.identity);
            if (spawnRate >= 1.5f)
            {
                spawnRate -= 0.15f;
            }
            spawnCount = spawnRate;
        }
        else
        {
            spawnCount -= Time.deltaTime;
        }
    }

    public void Hurt(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
