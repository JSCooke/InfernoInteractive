using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EMPBehaviour : Damageable
{

    public BossDoorController exitDoor;

    float healthIncreamentTime = 1f;
    float timer;

    int empIncreaseValue = 5;

    bool win = false;
    bool first = true;
    bool damaged = false;

    public Image bossPortrait;
    public Text bossBarValueText;
    public Sprite bossImage;

    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        timer = 0f;
        maxHealth = 100;
        currentHealth = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (first)
        {
            UIAdapter.bossVal = 0;
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
        else
        {
            winFuntion();
        }
    }

    public override void takeDamage(float amount)
    {
        
        //damage
        float health = currentHealth - amount;

        if (health < 0)
        {
            currentHealth = 1;
            amount = currentHealth - 1;
        }
        else
        {
            currentHealth = health;
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
        }
    }

    void winFuntion()
    {

        Debug.Log("win");

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
        for (int i = 0; i < en.Length; i++)
        {
            Destroy(en[i].gameObject);
        }

        //stop spawning
        AlienSpawnManager alienMan = GameObject.FindObjectOfType<AlienSpawnManager>();
        alienMan.stopSpawn();

        //open top door
        exitDoor.open = true;

        //Unset EMP mode
        UIAdapter.setEMPMode(false);
        //Reset the boss health bar
        UIAdapter.setBossUI(false);
        UIAdapter.bossVal = 100;
        UIAdapter.damageBoss(0);

        //Set the portrait to the boss
        bossPortrait.sprite = bossImage;

        bossBarValueText.text = "Namelom: 100%";
        Destroy(gameObject);
    }

    void OnDestroy() {
		SoundAdapter.playPopSound ();
		SoundAdapter.playBombSound ();
        explosion.SetActive(true);
    }
}
