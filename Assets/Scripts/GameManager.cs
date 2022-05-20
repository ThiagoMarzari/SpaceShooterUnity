using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checando se a pessoa apertou o enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Ir para a cena do jogo
            IniciaJogo();           
        }
    }

    public void IniciaJogo()
    {
        //Ir para a cena do jogo
        SceneManager.LoadScene("Jogo");   
    
    }
}
