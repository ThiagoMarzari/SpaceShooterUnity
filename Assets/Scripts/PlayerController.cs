using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f; //Velocidade padrão do jogador

    //Pegando o meu tiro
    public GameObject meuTiro;

    private float x = 8.3f;
    private float yMin = -5f;
    private float yMax = 4.15f;

    //Pegando o audio
    public AudioClip somTiro;
    //Alarme
    private float timer_espera = 0f;
    public float timer_demora = 0.3f;

    private int vida = 3;
    [SerializeField] private Text vidaUI;



    void Start()
    {

    }


    void Update()
    {
        Movimento(); //metodo de movimento do player

        Atirando(); //Método de atirar do player        

        vidaUI.text = vida.ToString();

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
        movimento.y += Input.GetAxis("Vertical") * velocidade * Time.deltaTime;

        //Garatindo que o player não saia do limite X da tela
        movimento.x = Mathf.Clamp(movimento.x, -x, x);
        movimento.y = Mathf.Clamp(movimento.y, yMin, yMax);

        transform.position = movimento; //O meu transform.position vai ser igual meu movimento
    }

    public void PerdeVida()
    {
        vida--;
        vidaUI.text = vida.ToString();

        if (vida <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }

    }



}
