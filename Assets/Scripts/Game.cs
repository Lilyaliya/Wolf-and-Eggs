<<<<<<< HEAD:Assets/Scripts/Game.cs
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject zero;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public int playerPos;
    [HideInInspector]
    public Transform egg;
    [HideInInspector]
    public GameObject[] egg1;
    [HideInInspector]
    public GameObject[] egg2;
    [HideInInspector]
    public GameObject[] egg3;
    [HideInInspector]
    public GameObject[] egg4;

    public float time = 1;
    public int count;
    public int hp;

    public TextMesh counter;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;

    public GameObject pressStart;
    public GameObject gameOver;

    public AudioSource soundStep;
    public AudioSource soundCrash;
    public AudioSource soundCount;
    public bool isPlaying=false;
    /*void Awake()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.StartGame();
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        
        egg = GameObject.Find("Spawn1").transform;
        egg1 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++) egg1[i] = egg.Find(i.ToString()).gameObject;

        egg = GameObject.Find("Spawn2").transform;
        egg2 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++) egg2[i] = egg.Find(i.ToString()).gameObject;

        egg = GameObject.Find("Spawn3").transform;
        egg3 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++) egg3[i] = egg.Find(i.ToString()).gameObject;

        egg = GameObject.Find("Spawn4").transform;
        egg4 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++) egg4[i] = egg.Find(i.ToString()).gameObject;

        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        hp1.SetActive(false);
        hp2.SetActive(false);
        hp3.SetActive(false);

        pressStart.SetActive(true);
        gameOver.SetActive(false);

        foreach (GameObject eg in egg1) eg.SetActive(false);
        foreach (GameObject eg in egg2) eg.SetActive(false);
        foreach (GameObject eg in egg3) eg.SetActive(false);
        foreach (GameObject eg in egg4) eg.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {//вызываю стартгейм напрямую здесь,
     /*if (Input.GetKeyDown(KeyCode.Space))
     {
         StartGame();
         pressStart.SetActive(false);
         gameOver.SetActive(false);
     }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressStart.SetActive(false);
            this.StartGame();
        }
        /* if (isPlaying)
         {
             pressStart.SetActive(false);
             gameOver.SetActive(false);
         }
         else gameOver.SetActive(true);*/

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerPos = 1;
            player1.SetActive(true);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            playerPos = 2;
            player1.SetActive(false);
            player2.SetActive(true);
            player3.SetActive(false);
            player4.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerPos = 3;
            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(true);
            player4.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            playerPos = 4;
            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(true);
        }

    }

   public IEnumerator Timer()
    {
        GameObject egg = Instantiate(zero);
        Egg comp = egg.AddComponent<Egg>();
        comp.game = this;
        comp.spawn = Random.Range(1, 5);
        //comp.egg=comp.spawn == 1?egg1:comp.spawn == 2?egg2:comp.spawn == 3?egg3:comp.spawn == 4?egg4:egg1;
        if (comp.spawn == 1) comp.egg = egg1;
        if (comp.spawn == 2) comp.egg = egg2;
        if (comp.spawn == 3) comp.egg = egg3;
        if (comp.spawn == 4) comp.egg = egg4;
        yield return new WaitForSeconds(time);
        StartCoroutine(Timer());
    }

    public void Step() { soundStep.Play(); }
        public void Count()
        {
            count++;
            counter.text = count.ToString();
            soundCount.Play();
        }
        public void Crash()
        {
            hp++;
            soundCrash.Play();
            if (hp >= 1) hp1.SetActive(true);
            if (hp >= 2) hp2.SetActive(true);
            if (hp >= 3) hp3.SetActive(true);
            if (hp > 3) StopGame();
        }


    public void StartGame()
        {
            isPlaying = true;
            playerPos = 1;
            player1.SetActive(true);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            count = 0;
            hp = 0;
            hp1.SetActive(false);
            hp2.SetActive(false);
            hp3.SetActive(false);
            StartCoroutine(Timer());
        }


    void StopGame()
        {

            gameOver.SetActive(true);
            isPlaying = false;
            StopAllCoroutines();
            foreach (GameObject eg in egg1) eg.SetActive(false);
            foreach (GameObject eg in egg2) eg.SetActive(false);
            foreach (GameObject eg in egg3) eg.SetActive(false);
            foreach (GameObject eg in egg4) eg.SetActive(false);

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);

            pressStart.SetActive(true);

            GameObject[] eggsArray = GameObject.FindGameObjectsWithTag("zero");
            foreach (GameObject eg in eggsArray) if (egg.name == "Egg(Clone)") Destroy(eg);
        }
    
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject zero;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public int playerPos;

    [HideInInspector]
    public Transform egg;
    [HideInInspector]
    public GameObject[] egg1;
    [HideInInspector]
    public GameObject[] egg2;
    [HideInInspector]
    public GameObject[] egg3;
    [HideInInspector]
    public GameObject[] egg4;

    public float time = 1;
    public int count;
    public int hp;

    public TextMesh counter;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;

    public GameObject pressStart;
    public GameObject gameOver;

    public AudioSource soundStep;
    public AudioSource soundCrash;
    public AudioSource soundCount;
    public bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
        egg = GameObject.Find("Spawn1").transform;
        egg1 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++) egg1[i] = egg.Find(i.ToString()).gameObject;

        egg = GameObject.Find("Spawn2").transform;
        egg2 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++) egg2[i] = egg.Find(i.ToString()).gameObject;

        egg = GameObject.Find("Spawn3").transform;
        egg3 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++) egg3[i] = egg.Find(i.ToString()).gameObject;

        egg = GameObject.Find("Spawn4").transform;
        egg4 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++) egg4[i] = egg.Find(i.ToString()).gameObject;

        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        hp1.SetActive(false);
        hp2.SetActive(false);
        hp3.SetActive(false);

        pressStart.SetActive(true);
        gameOver.SetActive(false);

        foreach (GameObject eg in egg1) eg.SetActive(false);
        foreach (GameObject eg in egg2) eg.SetActive(false);
        foreach (GameObject eg in egg3) eg.SetActive(false);
        foreach (GameObject eg in egg4) eg.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {//вызываю стартгейм напрямую здесь,
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
            pressStart.SetActive(false);
            gameOver.SetActive(false);
        }

       /* if (isPlaying)
        {
            pressStart.SetActive(false);
            gameOver.SetActive(false);
        }
        else gameOver.SetActive(true);*/

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerPos = 1;
            player1.SetActive(true);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            playerPos = 2;
            player1.SetActive(false);
            player2.SetActive(true);
            player3.SetActive(false);
            player4.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerPos = 3;
            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(true);
            player4.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            playerPos = 4;
            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(true);
        }

    }

   public IEnumerator Timer()
    {
        GameObject egg = Instantiate(zero);
        Egg comp = egg.AddComponent<Egg>();
        comp.game = this;
        comp.spawn = Random.Range(1, 5);
        //comp.egg=comp.spawn == 1?egg1:comp.spawn == 2?egg2:comp.spawn == 3?egg3:comp.spawn == 4?egg4:egg1;
        if (comp.spawn == 1) comp.egg = egg1;
        if (comp.spawn == 2) comp.egg = egg2;
        if (comp.spawn == 3) comp.egg = egg3;
        if (comp.spawn == 4) comp.egg = egg4;
        yield return new WaitForSeconds(time);
        StartCoroutine(Timer());
    }

    public void Step() { soundStep.Play(); }
        public void Count()
        {
            count++;
            counter.text = count.ToString();
            soundCount.Play();
        }
        public void Crash()
        {
            hp++;
            soundCrash.Play();
            if (hp >= 1) hp1.SetActive(true);
            if (hp >= 2) hp2.SetActive(true);
            if (hp >= 3) hp3.SetActive(true);
            if (hp > 3) StopGame();
        }


    void StartGame()
        {// иду на апдейт, если нажата спейс, возвращаю тру, здесь проверяю тру?значит инит и корутина
            isPlaying = true;
            playerPos = 1;
            player1.SetActive(true);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            count = 0;
            hp = 0;
            hp1.SetActive(false);
            hp2.SetActive(false);
            hp3.SetActive(false);
            StartCoroutine(Timer());
        }


    void StopGame()
        {

            gameOver.SetActive(true);
            isPlaying = false;
            StopAllCoroutines();
            foreach (GameObject eg in egg1) eg.SetActive(false);
            foreach (GameObject eg in egg2) eg.SetActive(false);
            foreach (GameObject eg in egg3) eg.SetActive(false);
            foreach (GameObject eg in egg4) eg.SetActive(false);

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);

            pressStart.SetActive(true);

            GameObject[] eggsArray = GameObject.FindGameObjectsWithTag("zero");
            foreach (GameObject eg in eggsArray) if (egg.name == "Egg(Clone)") Destroy(eg);
        }
    
}
>>>>>>> 50503b438cf11ba90fd2e3cc3dd6cb7959ff579f:Backgr/Assets/Scripts/Game.cs
