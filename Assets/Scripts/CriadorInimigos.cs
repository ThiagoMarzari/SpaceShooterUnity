using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriadorInimigos : MonoBehaviour
{
    //Variavel de quem ele vai criar
    public GameObject inimigo;


    //Onde vou criar ele
    public float xMin = -2.5f;
    public float xMax = 2.5f;
    public float yMin = 6f;
    public float yMax = 9f;

    //Tempo para criar ele
    //Criando a espera para ele criar o inimigo
    public float espera = 3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        espera -= Time.deltaTime; //Diminuindo o valor da espera;
        //Fazendo a espera acabar
        if (espera <= 0)
        {
            //Criando o inimigo
            Vector3 posicao = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            
            Instantiate(inimigo, posicao, Quaternion.identity);

            espera = 3;
        }
        
    }
}
