using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public GameObject columnPrefab;
    public int columnPoolSize = 5;
    public float spawnRate = 2f;
    private float timeSinceLastSpawn;

    private float spawnXPosition = 10f;

    private GameObject[] columns;
    private int currentColumn = 0;

    private Vector2 objectPoolPosition = new Vector2(-15, -25);
    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];

        for(int i = 0; i<columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;
        if(GameController.instance.gameOver == false && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0f;
            float spawnYPosition = Random.Range(-3.5f, 1f);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;

            if(currentColumn >= 5)
            {
                currentColumn = 0;
            }
        }
    }
}
