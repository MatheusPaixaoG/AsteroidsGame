using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoJogador : MonoBehaviour
{
  public Rigidbody2D meuRigidBody;
  public float aceleracao = 1.0f;
  public float velocidadeAngular = 180.0f;
  public float velocidadeMaxima = 4.0f;
  public Rigidbody2D prefabProjetil;
  public float velocidadeProjetil = 10.0f;

  public float duracaoProjetilEmSegundos = 4.0f;

  // Start is called before the first frame update
  void Start()
  {

  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Rigidbody2D projetil = Instantiate(prefabProjetil, meuRigidBody.position, Quaternion.identity);
      projetil.velocity = transform.up * velocidadeProjetil;
      Destroy(projetil.gameObject, duracaoProjetilEmSegundos);
    }
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (Input.GetKey(KeyCode.UpArrow))
    {
      Vector3 direcao = transform.up * aceleracao;
      meuRigidBody.AddForce(direcao, ForceMode2D.Force);
    }

    if (Input.GetKey(KeyCode.LeftArrow))
    {
      meuRigidBody.rotation += velocidadeAngular * Time.deltaTime;
    }

    if (Input.GetKey(KeyCode.RightArrow))
    {
      meuRigidBody.rotation -= velocidadeAngular * Time.deltaTime;
    }

    if (meuRigidBody.velocity.magnitude > velocidadeMaxima)
    {
      meuRigidBody.velocity = Vector2.ClampMagnitude(meuRigidBody.velocity, velocidadeMaxima);
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    Destroy(gameObject);
  }
}
