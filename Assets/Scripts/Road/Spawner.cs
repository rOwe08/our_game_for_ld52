using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner spawner { get; set; }
    public GameObject prefabGround;
    public GameObject prefabRoad;
    public GameObject prefabShop;
    public GameObject prefabStrangers;

    public float spawnGroundRate = 13f;
    public float spawnRoadRate = 11f;
    public float spawnShopRate = 11f;
    public float spawnStrangersRate = 120f;

    public float heiGr = 0.44f;
    public float heiR = 9.75f;
    public float heiStr = 0.4f;
    public float heiSh = 0.5f;

    public float weiSh = 31f;
    public float weiStr = 31f;
    public float weiGr = 31f;
    public float weiR = 41f;

    public void Start()
    {
        spawner = this;
    }
    public void OnEnable()
    {
        InvokeRepeating(nameof(SpawnOfGround), spawnGroundRate, spawnGroundRate);
        InvokeRepeating(nameof(SpawnOfRoad), spawnRoadRate, spawnRoadRate);
        InvokeRepeating(nameof(SpawnOfStrangers), spawnStrangersRate, spawnStrangersRate);
        InvokeRepeating(nameof(SpawnOfShop), spawnShopRate, spawnShopRate);
    }

    public void OnDisable()
    {
        CancelInvoke(nameof(SpawnOfGround));
        CancelInvoke(nameof(SpawnOfRoad));
        CancelInvoke(nameof(SpawnOfShop));
        CancelInvoke(nameof(SpawnOfStrangers));
    }

    private void SpawnOfGround()
    {
        GameObject ButtomGround = Instantiate(prefabGround, transform.position, Quaternion.identity);
        ButtomGround.transform.position = Vector3.right * weiGr + Vector3.down * heiGr;
    }
    private void SpawnOfRoad()
    {
        GameObject Road = Instantiate(prefabRoad, transform.position, Quaternion.identity);
        Road.transform.position = Vector3.right * weiR + Vector3.down * heiR;
    }
    private void SpawnOfStrangers()
    {
        GameObject Strangers = Instantiate(prefabStrangers, transform.position, Quaternion.identity);
        Strangers.transform.position = Vector3.right * weiStr + Vector3.down * heiStr;
    }
    private void SpawnOfShop()
    {
        GameObject Shop = Instantiate(prefabShop, transform.position, Quaternion.identity);
        Shop.transform.position = Vector3.right * weiSh + Vector3.down * heiSh;
    }
}

