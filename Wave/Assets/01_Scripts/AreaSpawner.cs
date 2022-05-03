using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] areaPrefabs;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private int spawnAreaAtStart = 2; //���� ����
    [SerializeField]
    private float distanceToNext = 30f; //���� ���� �Ÿ�

    List<int> a;
    private int areaIndex = 0; //���� �ε���

    private void Awake()
    {
        for (int i = 0; i < spawnAreaAtStart; ++i)
        {
            SpawnArea();
        }
        
    }
    private void Update()
    {
        int playerIndex = (int)(playerTransform.position.y / distanceToNext);

        if(playerIndex == areaIndex - 1)
        {
            SpawnArea();
        }
    }

    public void SpawnArea()
    {
        int randomIndex = Random.Range(0, areaPrefabs.Length);

        GameObject clone = Instantiate(areaPrefabs[randomIndex]);

        clone.transform.position = Vector3.up * distanceToNext * areaIndex;

        areaIndex++;
    }
}
