using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Room_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private GameObject roomPrefab1;
    [SerializeField] private GameObject roomPrefab2;
    [SerializeField] private GameObject roomPrefab3;
    public Transform spawnPoint;
    private int b;
    private bool canCreate = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateRandomRoom()
    {
        int a = Random.Range(0, 4);
        if (a == 0)
        {
            Instantiate(roomPrefab, spawnPoint.transform.position, Quaternion.identity);

        }
        else if (a == 1)
        {
            Instantiate(roomPrefab1, spawnPoint.transform.position, Quaternion.identity);

        }
        else if (a == 2)
        {
            Instantiate(roomPrefab2, spawnPoint.transform.position, Quaternion.identity);

        }
        else
        {
            Instantiate(roomPrefab3, spawnPoint.transform.position, Quaternion.identity);

        }
        //count ++;
        //Debug.Log(count);
        b = a;

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision && canCreate)
        {
            CreateRandomRoom();
            canCreate = false;


        }
    }
}
