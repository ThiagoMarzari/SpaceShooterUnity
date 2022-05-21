using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroInimigo : MonoBehaviour
{
    [SerializeField] private float velocidade = 7f;
    private Rigidbody2D meuRB;
    [SerializeField] private GameObject meuTiro;

    // Start is called before the first frame update
    void Start()
    {
        //Velocidade controle do tiro do inimigo
        meuRB = GetComponent<Rigidbody2D>();
        meuRB.velocity = Vector2.down * velocidade;

    }

    // Update is called once per frame
    void Update()
    {
        //Destruindo meu tiro
        if (transform.position.y <= -7)
        {
            Destroy(meuTiro);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("player"))
        {                       
            Destroy(gameObject); //Destruindo meu gameObject
            
            other.GetComponent<PlayerController>().PerdeVida();

        }
    }

}
