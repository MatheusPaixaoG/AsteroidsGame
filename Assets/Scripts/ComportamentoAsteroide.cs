using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoAsteroide : MonoBehaviour
{
  public Rigidbody2D meuRigidBody;
  public float velocidadeMaxima = 1.0f;

  // Start is called before the first frame update
  void Start()
  {
    Vector2 direcao = Random.insideUnitCircle;
    direcao *= velocidadeMaxima;
    meuRigidBody.velocity = direcao;
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnTriggerEnter2D(Collider2D other)
  {
    Destroy(gameObject);
    Destroy(other.gameObject);
  }
}
