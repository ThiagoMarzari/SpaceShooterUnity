using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    ///////Inimigo 01/////////
    public GameObject inimigo;
    //Posições
    public float x = 8.3f;

    public float yMin = 6f;
    public float yMax = 9f;

    //Tempo para criar ele
    //Criando a espera para ele criar o inimigo
    public float espera = 3f;



    ///////Pontos//////
    [SerializeField] private float pontos = 0f;
    [SerializeField] private int level = 1;
    private float proximoLevel = 20;



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        GanhaPontos();

        CriaInimigo();

    }


    private void GanhaPontos() //Arrumar
    {

        pontos += Time.deltaTime * level; //Dando 5 pontos por segundo

        if (pontos >= proximoLevel)
        {
            //Subindo de level
            level++; //Incremento em 1

            proximoLevel *= level;
        }        
        
    }

    private void CriaInimigo()
    {
        espera -= Time.deltaTime; //Diminuindo o valor da espera;
        //Fazendo a espera acabar
        if (espera <= 0)
        {
            //Criando o inimigo
            Vector3 posicao = new Vector3(Random.Range(-x, x), Random.Range(yMin, yMax));

            Instantiate(inimigo, posicao, Quaternion.identity);

            espera = 3;
        }
    }



}
