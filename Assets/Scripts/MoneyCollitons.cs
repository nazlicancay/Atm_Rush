using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;


[SelectionBase]
public class MoneyCollitons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Dollar;
    public GameObject gold;
    public GameObject diamond;
    public static bool finish;
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
        if (transform.position.x <= -10)
        {
            gameObject.SetActive(false);
        }
        
    }

    public Vector3 Randomplace()
    {

        return new Vector3(Random.Range(4, -3), -1f, Random.Range(transform.position.z+3, transform.position.z + 6)); ;
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
            CubeManager.cubeManagerInstanse.collactList.Remove(gameObject);
            transform.DOJump(Randomplace(), 1f, 2, 2f).OnComplete(()=> gameObject.SetActive(false));
           
            //gameObject.GetComponent<Collactor>().enabled = false;
            Debug.Log(gameObject.tag.ToString());
            CubeManager.cubeManagerInstanse.ReOrder();
            
            
        }

        if (other.gameObject.CompareTag("creditCart"))
        {
           transform.gameObject.SetActive(false);
            transform.DOKill(true);
            Debug.Log("credi kart ");
            CubeManager.cubeManagerInstanse.ReOrder();

        }

        if (other.gameObject.CompareTag("Finish"))
        {
            gameObject.tag = "Untagged";
            CubeManager.cubeManagerInstanse.collactList.Remove(gameObject);
            transform.DOMoveX(-10, 1f);
            finish = true;



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
