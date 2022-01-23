using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> collactList = new List<GameObject>();
    public static CubeManager cubeManagerInstanse;
    public List<GameObject> BounceList = new List<GameObject>();
    public List<GameObject> MoveList = new List<GameObject>();
    public List<GameObject> MoveUpList = new List<GameObject>();


    public bool bounce = false;
    public Transform stackHolder;





    private void Awake()
    {
        cubeManagerInstanse = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            moveRightLeft();
           

    }

   public  IEnumerator Bounce()
    {
        var wait = new WaitForSeconds(0.05f);

        BounceList = CubeManager.cubeManagerInstanse.collactList;
        
        for (int i = BounceList.Count; i >= 2 ; i--)
        {
            

            BounceList[i-1].GetComponent<Resize>().ResizeObj();

            yield return wait;
        }

    }

    public void moveRightLeft()
    {
        MoveList = CubeManager.cubeManagerInstanse.collactList;

        for (int i = 0; i < MoveList.Count-1; i++)
        {

            MoveList[i+1].transform.DOMoveX(MoveList[i].transform.position.x, 0.08f).SetEase(Ease.InOutBounce);
            
        }

    }


}
