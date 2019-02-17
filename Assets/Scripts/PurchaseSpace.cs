using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //IMPORT UI! IMPORTANT!!!!

public class PurchaseSpace : MonoBehaviour
{

    public Text moneyText;
    public Text upgradeText;
    public Text homebaseText;
    public Text enemybaseText;

    public GameObject armyPrefab;
    public Transform self;

    public static float cost1 = 50;

    public int level = 1;
    public int[] cost = new int[7] {50, 100, 150, 250, 400, 500, 800};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "" + Cash.Amount;
        homebaseText.text = "Health: " + HomeBase.health;
        enemybaseText.text = "Health: " + EnemyBase.health;
    }

    public void BuyArmy1()
    {
        if (Cash.Amount - cost1 >= 0)
        {
            GameObject newArmy = Instantiate(armyPrefab, self.position, Quaternion.identity);
            Cash.Amount -= cost1;
        }
    }

    public void levelUp()
    {
        if (level < 8) {
            if (Cash.Amount >= cost[level - 1])
            {
                Cash.Interval -= 0.01f;
                Cash.Amount -= cost[level - 1];
                level++;
                if (level != 8)
                {
                    upgradeText.text = "Level " + level + "\n(" + cost[level - 1] + ")";

                } else
                {
                    upgradeText.text = "Level " + level + "\n(MAX)";

                }
            }
        }
    }
}
