﻿using System.Collections;
using UnityEngine;
// Найти объект по имени
//GameObject go = GameObject.Find("MyObject");
// взять его компонент где лежит скорость
//SpeedController speedController = go.GetComponent<SpeedController>();
// взять переменную скорости
//float courrentSpeed = speedController.speed;
public class Egg : MonoBehaviour
{

    public Game game;
    public GameObject[] egg;
    public int spawn;
    public int step = 0;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject egg = Instantiate(game.zero);
        //Game comp = egg.AddComponent<Game>();
        /*spawn= Random.Range(1, 5);
        if (spawn == 1) this.egg = game.egg1;
        if (spawn == 2) this.egg = game.egg2;
        if (spawn == 3) this.egg = game.egg3;
        if (spawn == 4) this.egg = game.egg4;*/
        // StartCoroutine(Timer());
        //StartCoroutine(game.Timer());
        if (game.isPlaying)
        StartCoroutine(Steps());
    }

    // Update is called once per frame
    void Update()
    {
        if (game.isPlaying)
        {
            if (step == 5 && game.playerPos == spawn)
            {
                game.Count();
                egg[4].SetActive(false);
                Destroy(this.gameObject);
            }
        }
    
    }

   /* IEnumerator Timer()
    {
        spawn = Random.Range(1, 5);
        if (spawn == 1) this.egg = game.egg1;
        if (spawn == 2) this.egg = game.egg2;
        if (spawn == 3) this.egg = game.egg3;
        if (spawn == 4) this.egg = game.egg4;
        yield return new WaitForSeconds(game.time);
        StartCoroutine(Timer());
    }*/
    IEnumerator Steps()
    {
        if (step == 0)
        {
            egg[step].SetActive(true);
        }
        else if (step == 10)
        {
            Destroy(this.gameObject);
        }
        else
        {
            egg[step].SetActive(true);
            egg[step - 1].SetActive(false);
            if (step == 5) game.Crash();
            else game.Step();
        }
        step++;
        yield return new WaitForSeconds(game.time);
        StartCoroutine(Steps());
    }
}
