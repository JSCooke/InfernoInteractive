using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EMPBehaviour : Damageable
{

    public GameObject exitDoor;

    float healthIncreamentTime = 1f;
    float timer;

    int empIncreaseValue = 1;

    bool win = false;
    bool first = true;
    bool damaged = false;



    // Use this for initialization
    void Start()
    {
        UIAdapter.changeEMP();
        timer = 0f;
        maxHealth = 100;
        currentHealth = 80;
    }

    // Update is called once per frame
    void Update()
    {

        if (first)
        {
            UIAdapter.bossVal = 80;
            first = false;
        }

        timer += Time.deltaTime;

        if (!win)
        {
            //increase
            if (timer >= healthIncreamentTime)
            {
                increaseHealth();
                timer = 0f;
            }
        }
    }

    public void takeDamage(int amount)
    {
        
        //damage
        int health = currentHealth - amount;

        if (health < 0)
        {
            currentHealth = 1;
            amount = currentHealth - 1;
        }

        UIAdapter.damageBoss((float)amount);
        timer = 0f;

        //player not get achevement
        if (!damaged)
        {
            damaged = true;
        }
    }

    void increaseHealth()
    {
        currentHealth = currentHealth + empIncreaseValue;
        UIAdapter.damageBoss((float)-empIncreaseValue);
        if (currentHealth >= 100)
        {
            win = true;
            
            //if emp has never taken damage then unlock achievement
            if (!damaged)
            {
                AchievementController.updateAchievement("EMP Saver", true);
                List<string> achievementsToDisplay = new List<string>();
                achievementsToDisplay.Add("EMP Saver");
                AchievementController.displayAchievements(achievementsToDisplay);
            }
            //TODO Pop up dialogue to get them to drive  to exit

            //kill all attack robots
            AlienEnemyBehavour[] en = GameObject.FindObjectsOfType<AlienEnemyBehavour>();
            for(int i=0;i<en.Length;i++)
            {
                en[i].death();
            }

            //stop spawning
            AlienSpawnManager alienMan = GameObject.FindObjectOfType<AlienSpawnManager>();
            alienMan.stopSpawn();

            //open top door
            exitDoor.SetActive(false);
        }
    }

}
