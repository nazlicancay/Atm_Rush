using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;


public class MoneyCollitons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Dollar;
    public GameObject gold;
    public GameObject diamond;

    public enum MoneyState
    {
        Dollar,
        Gold,
        Diamond
    }

    public MoneyState currentMoneyState;

    public void ChangeState(MoneyState newState)
    {
        if (newState == MoneyState.Gold)
        {
            Dollar.SetActive(false);
            gold.SetActive(true);
        }

        if (newState == MoneyState.Diamond)
        {
            gold.SetActive(false);
            diamond.SetActive(true);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 Randomplace()
    {

        return new Vector3(Random.Range(4, -3), 0.01f, Random.Range(transform.position.z+3, transform.position.z + 6)); ;
    }

    

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("door"))
        {
            bool once = false;
            if (currentMoneyState == MoneyState.Dollar && !once)
            {
                ChangeState(MoneyState.Gold);
                currentMoneyState = MoneyState.Gold;
                once = true;
            }

            if (currentMoneyState == MoneyState.Gold && !once)
            {
                ChangeState(MoneyState.Diamond);
                currentMoneyState = MoneyState.Diamond;
                once = true;
            }
        }
        if (other.CompareTag("sarkac"))
        {
            transform.DOJump(Randomplace(), 1f, 2, 0.2f);
            //Debug.Log("sarkaç ");
        }

        if (other.gameObject.CompareTag("creditCart"))
        {
           transform.gameObject.SetActive(false);
            transform.DOKill(true);
            Debug.Log("credi kart ");

        }

        if (other.gameObject.CompareTag("Finish"))
        {
            gameObject.tag = "Untagged";
            CubeManager.cubeManagerInstanse.collactList.Remove(gameObject);
            CubeManager.cubeManagerInstanse.MoveUpList.Add(gameObject);
            transform.DOMoveX(-10, 1f);
           GameManager.gameManagerInstance.anim.SetTrigger("sit");
           

        }

        if (other.gameObject.CompareTag("atm"))
        {
            CubeManager.cubeManagerInstanse.collactList.Remove(gameObject);
            GameManager.gameManagerInstance.atmCoinNumber++;

            transform.parent = null;
            Destroy(gameObject);
            Debug.Log("atm");

        }

        
    }

  

   
}
