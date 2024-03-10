using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Pointy : MonoBehaviour
{
    public GameObject Player;
    private GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.GetComponent<GameManager>().GameOver();

        }
    }
}
