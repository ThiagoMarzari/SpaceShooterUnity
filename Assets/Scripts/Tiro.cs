using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float velocidade = 10f;

    public Rigidbody2D meuRB;
    // Start is called before the first frame update

    public GameObject meuTiro;
    void Start()
    {
        meuRB.velocity = Vector2.up * velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 5f)
        {
            Destroy(meuTiro);
        }
    }

    //Meu evento de trigger com o inimigo
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        //Esse evento vai rodar sempre que ele tiver uma "Colisão " com alguem

        //Chamando o método de morte do inimigo
        //Estou checando com quem eu colidi e pegando o script inimigo dele
        //Depois estou chamando o comportamento (método) morrendo dele
        collision.GetComponent<Inimigo>().Morrendo();

        //Tentando destruir com quem eu colidi
        Destroy(collision.gameObject);

        //Me destruindo
        Destroy(gameObject);
    }

}
