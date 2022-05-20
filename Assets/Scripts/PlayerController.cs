using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f; //Velocidade padrão do jogador

    //Pegando o meu tiro
    public GameObject meuTiro;

    public float x = 2.2f;

    //Pegando o audio
    public AudioClip somTiro;


    //Alarme
    private float timer_espera = 0f;
    public float timer_demora = 0.3f;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Movimento(); //metodo de movimento do player

        Atirando(); //Método de atirar do player

    }



    //Méotodo para fazer o player atirar de tempos em tempos
    private void Atirando()
    {
        //Atirando com um timer

        timer_espera -= Time.deltaTime; //Diminuindo meu Timer

        if (Input.GetButton("Fire1") && timer_espera <= 0)
        {
            //Criando o meu tiro
            Instantiate(meuTiro, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(somTiro, new Vector3(0, 0, -10f));

            timer_espera = timer_demora; //Adicionando um tempo depois de executar o código acima;
        }
    }


    //Movimento do player
    private void Movimento()
    {
        Vector3 movimento = transform.position;  //Passadno meu vector3 para o meu transform.position

        movimento.x += Input.GetAxis("Horizontal") * velocidade * Time.deltaTime; //Movimento do player horizontal

        //Garatindo que o player não saia do limite X da tela
        movimento.x = Mathf.Clamp(movimento.x, -x, x);

        transform.position = movimento; //O meu transform.position vai ser igual meu movimento

    }

}
