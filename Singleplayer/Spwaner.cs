using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour
{
    public GameObject SMoney;
    public GameObject SBag;
    public GameObject Pdonut;
    public GameObject Bdonut;
    public GameObject Invisabilty;
    public GameObject SlightOfHand;
    public float XX;
    public float XY;
    public float YX;
    public float YY;
    public int TimtForSpwan;
    public int NumberOfSMoneyToSpwan;
    public int NumberOfSBagToSpwan;
    public int NumberOfPdonutToSpwan;
    public int NumberOfBdonutToSpwan;
    public int NumberOfInvisabiltyToSpwan;
    public int NumberOfSlight;
    private int SpwanedSMoney = 0;
    private int SpwanedSBag = 0;
    private int SpwanedPdonut = 0;
    private int SpwanedBdonut = 0;
    private int SpwanedInvisabilty = 0;
    private int SpwanedSlight = 0;


    void Start()
    {
        StartCoroutine(MoneySpwan());
        StartCoroutine(EffectsSpwan());
        while (SpwanedSMoney < NumberOfSMoneyToSpwan)
        {
            Instantiate(SMoney, new Vector2(Random.Range(XX, XY), Random.Range(YX, YY)), Quaternion.identity);
            SpwanedSMoney++;
        }
        while (SpwanedSBag < NumberOfSBagToSpwan)
        {
            Instantiate(SBag, new Vector2(Random.Range(XX, XY), Random.Range(YX, YY)), Quaternion.identity);
            SpwanedSBag++;
        }
        SpwanedSMoney = 0;
        SpwanedSBag = 0;
    }


    void Update()
    {
        
    }

    IEnumerator MoneySpwan()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimtForSpwan);
            while(SpwanedSMoney < NumberOfSMoneyToSpwan)
            {
                Instantiate(SMoney, new Vector2(Random.Range(XX, XY), Random.Range(YX, YY)), Quaternion.identity);
                SpwanedSMoney++;
            }
            while(SpwanedSBag < NumberOfSBagToSpwan)
            {
                Instantiate(SBag, new Vector2(Random.Range(XX, XY), Random.Range(YX, YY)), Quaternion.identity);
                SpwanedSBag++;
            }
            SpwanedSMoney = 0;
            SpwanedSBag = 0;
        }
    }

    IEnumerator EffectsSpwan()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimtForSpwan);
            while (SpwanedPdonut < NumberOfPdonutToSpwan)
            {
                Instantiate(Pdonut, new Vector2(Random.Range(XX, XY), Random.Range(YX, YY)), Quaternion.identity);
                SpwanedPdonut++;
            }
            while (SpwanedBdonut < NumberOfBdonutToSpwan)
            {
                Instantiate(Bdonut, new Vector2(Random.Range(XX, XY), Random.Range(YX, YY)), Quaternion.identity);
                SpwanedBdonut++;
            }
            while (SpwanedInvisabilty < NumberOfInvisabiltyToSpwan)
            {
                Instantiate(Invisabilty, new Vector2(Random.Range(XX, XY), Random.Range(YX, YY)), Quaternion.identity);
                SpwanedInvisabilty++;
            }
            while(SpwanedSlight < NumberOfSlight)
            {
                Instantiate(SlightOfHand, new Vector2(Random.Range(XX, XY), Random.Range(YX, YY)), Quaternion.identity);
                SpwanedSlight++;
            }
            SpwanedPdonut = 0;
            SpwanedBdonut = 0;
            SpwanedInvisabilty = 0;
            SpwanedSlight = 0;
        }
    }
}
