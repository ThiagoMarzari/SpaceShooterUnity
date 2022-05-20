using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    //Saber quem é o meu rigidbody2d
    public Rigidbody2D meuRB;

    //Pegando a minha explosao
    public GameObject minhaExplosao;

    public float velocidade = 2f; //Velocidade do inimigo

    public AudioClip somExplosao;    

    // Start is called before the first frame update
    void Start()
    {
        //Quando voce iniciar eu vou dar uma velocidade para o rigidybody
        //A velocidade do meu Rb é 1 parra baixo (0,-1) * velocidade;
        meuRB.velocity = Vector2.down * velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //O que fazer quando eu for destruido
    private void OnDestroy() 
    {

    }

    //Criar a morte do inimigo
    public void Morrendo()
    {
        GameObject explosao = Instantiate(minhaExplosao, transform.position, transform.rotation);  //Variavel que criei para minha explosão, para depois destruir ela
        Destroy(explosao, .4f);
        //Som da explosão
        AudioSource.PlayClipAtPoint(somExplosao, new Vector3(0,0,-10f));

    }

    //Testando para ver se o inimigo entrou na caixa de colisão
    private void OnTriggerEnter2D(Collider2D collision) //Collision == Inimigo
    {
        //Preciso identificar se com quem eu colidi é o fim do jogo
        if (collision.CompareTag("fim"))
        {
            //Reiniciando o jogo, vou por inicio
            SceneManager.LoadScene("Inicio");
        }
        
    }


}
