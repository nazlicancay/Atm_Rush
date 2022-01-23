using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UıManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas Startcanvas;
    public Canvas RestartCanvas;
    public Button restart;
    public TextMeshProUGUI scoretext;
    public static UıManager uıManagerInstance;

    private void Awake()
    {
        uıManagerInstance = this;
       

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        GameManager.gameManagerInstance.isGameActive = true;
        Startcanvas.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        CameraManager.cameraManagerInstance.ActivateCamera(1);




    }

    public void quit()
    {
        CameraManager.cameraManagerInstance.ActivateCamera(0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Startcanvas.gameObject.SetActive(false);



    }
}
