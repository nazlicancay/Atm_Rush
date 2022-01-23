using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager gameManagerInstance;
    public bool isGameActive = false;
    public int CoinNumber;
    public int atmCoinNumber;
    public List<MeshFilter> MeshList = new List<MeshFilter>();
    public Animator anim;


    private void Awake()
    {
        gameManagerInstance = this;
       

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
