using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    //Saber quem é o meu rigidbody2d
    public Rigidbody2D meuRB;
    public GameObject minhaExplosao;     //Pegando a minha explosao

    public float velocidade = 2f; //Velocidade do inimigo
    public AudioClip somExplosao;
    private float timerEspera;
    [SerializeField] private float timerDemora;

    //Pegando o tiroinimigo
    [SerializeField] private GameObject tiroInimigo01;

    [SerializeField] private GameObject eu;

    void Start()
    {
        //Quando voce iniciar eu vou dar uma velocidade para o rigidybody
        //A velocidade do meu Rb é 1 parra baixo (0,-1) * velocidade;
        meuRB.velocity = Vector2.down * velocidade;


    }

    // Update is called once per frame
    void Update()
    {
        Atirando();


        if (transform.position.y <= -7)
        {
            Destroy(eu);

        }
    }

    //O que fazer quando eu for destru

    //Criar a morte do inimigo
    public void Morrendo()
    {
        GameObject explosao = Instantiate(minhaExplosao, transform.position, transform.rotation);  //Variavel que criei para minha explosão, para depois destruir ela
        Destroy(explosao, .4f);
        //Som da explosão
        AudioSource.PlayClipAtPoint(somExplosao, new Vector3(0, 0, -10f));

    }

    //Testando para ver se o inimigo entrou na caixa de colisão


    private void Atirando()
    {
        timerEspera -= Time.deltaTime;

        if (timerEspera <= 0)
        {
            Instantiate(tiroInimigo01, transform.position, transform.rotation);

            timerEspera = timerDemora;
        }
        
    }



}
