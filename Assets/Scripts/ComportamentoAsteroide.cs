using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoAsteroide : MonoBehaviour
{
  public static System.Action EventoAsteroideDestruido = null;
  public EfeitoAsteroideDestruido prefabEfeitos;
  public Rigidbody2D meuRigidBody;
  public ComportamentoAsteroide prefabAsteroideMenor;
  public float velocidadeMaxima = 2.0f;
  public int quantidadeFragmentos = 3;

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
    for (int i = 0; i < quantidadeFragmentos; i++)
    {
      Instantiate(prefabAsteroideMenor, meuRigidBody.position, Quaternion.identity);
    }

    if (EventoAsteroideDestruido != null)
    {
      EventoAsteroideDestruido();
    }

    Instantiate(prefabEfeitos, meuRigidBody.position, Quaternion.identity);

    Destroy(gameObject);
    Destroy(other.gameObject);
  }
}
