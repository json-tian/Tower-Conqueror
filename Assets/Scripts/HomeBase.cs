using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{

    public static float health = 1000f;
    public float counter;

    public Transform self;
    // Start is called before the first frame update
    void Start()
    {
        counter = Cash.Interval;
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;

        if (counter <= 0)
        {
            Cash.Amount += 1;
            counter = Cash.Interval;
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
