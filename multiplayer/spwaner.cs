using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class spwaner : NetworkBehaviour
{

    public GameObject Dount;
    public GameObject SmallMoney;
    public GameObject MoneyBag;
    public GameObject Gold;
    public GameObject BlueDount;


    void Start()
    {
        StartCoroutine(DountSpwaner());
        StartCoroutine(MoneySpwaner());
        StartCoroutine(MoneyBagSpwaner());
        Invoke("SpwanGold", 90);
    }

    IEnumerator DountSpwaner()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            GameObject Spwan = Instantiate(Dount, new Vector2(Random.Range(-50, 50), Random.Range(5, -35)), Quaternion.identity);
            NetworkServer.Spawn(Spwan);
            yield return new WaitForSeconds(1);
            GameObject Spwan1 = Instantiate(Dount, new Vector2(Random.Range(-50, 50), Random.Range(5, -35)), Quaternion.identity);
            NetworkServer.Spawn(Spwan1);
            yield return new WaitForSeconds(1);
            GameObject Spwan2 = Instantiate(Dount, new Vector2(Random.Range(160, 210), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(Spwan2);
            yield return new WaitForSeconds(1);
            GameObject SpwanBlueDount = Instantiate(BlueDount, new Vector2(Random.Range(-50, 50), Random.Range(5, -35)), Quaternion.identity);
            NetworkServer.Spawn(SpwanBlueDount);
            yield return new WaitForSeconds(1);
            GameObject SpwanBlueDount1 = Instantiate(BlueDount, new Vector2(Random.Range(160, 210), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(SpwanBlueDount1);
        }
    }

    IEnumerator MoneySpwaner()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            GameObject SpwanMoney1 = Instantiate(SmallMoney, new Vector2(Random.Range(-55, 50), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(SpwanMoney1);
            yield return new WaitForSeconds(1);
            GameObject SpwanMoney2 = Instantiate(SmallMoney, new Vector2(Random.Range(-55, 50), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(SpwanMoney2);
            yield return new WaitForSeconds(1);
            GameObject SpwanMoney3 = Instantiate(SmallMoney, new Vector2(Random.Range(-55, 50), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(SpwanMoney3);
            yield return new WaitForSeconds(1);
            GameObject SpwanMoney4 = Instantiate(SmallMoney, new Vector2(Random.Range(-55, 50), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(SpwanMoney4);
            yield return new WaitForSeconds(1);
            GameObject SpwanMoney5 = Instantiate(SmallMoney, new Vector2(Random.Range(-55, 50), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(SpwanMoney5);
            yield return new WaitForSeconds(1);
            GameObject SpwanMoney6 = Instantiate(SmallMoney, new Vector2(Random.Range(-55, 50), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(SpwanMoney6);
            yield return new WaitForSeconds(1);
            GameObject SpwanMoney7 = Instantiate(SmallMoney, new Vector2(Random.Range(160, 210), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(SpwanMoney7);
            yield return new WaitForSeconds(1);
            GameObject SpwanMoney8 = Instantiate(SmallMoney, new Vector2(Random.Range(160, 210), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(SpwanMoney8);

        }
    }

    IEnumerator MoneyBagSpwaner()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            GameObject SpwanBag1 = Instantiate(MoneyBag, new Vector2(Random.Range(-55, 50), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(SpwanBag1);
            yield return new WaitForSeconds(1);
            GameObject SpwanBag2 = Instantiate(MoneyBag, new Vector2(Random.Range(-55, 50), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(SpwanBag2);
            yield return new WaitForSeconds(1);
            GameObject SpwanBag3 = Instantiate(MoneyBag, new Vector2(Random.Range(-55, 50), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(SpwanBag3);
            yield return new WaitForSeconds(1);
            GameObject SpwanBag4 = Instantiate(MoneyBag, new Vector2(Random.Range(160, 210), Random.Range(15, -40)), Quaternion.identity);
            NetworkServer.Spawn(SpwanBag4);
        }
    }

    void SpwanGold()
    {
        GameObject SpwanGold = Instantiate(Gold, new Vector2(Random.Range(-50, 50), Random.Range(15, -35)), Quaternion.identity);
        NetworkServer.Spawn(SpwanGold);
    }
}
