using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{

    public float velocidade = 1.0f;
    public SpriteRenderer spriteRenderer;

    private bool mudou = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Velocidade = variação de posição / variação de tempo
        //variação de posição = velocidade * variação de tempo
        float variacaoDeTempo = Time.deltaTime;
        Vector3 vetorVelocidade = new Vector3(velocidade, 0f, 0f);
        Vector3 variacaoPosicao = vetorVelocidade * variacaoDeTempo;
        
        if (Input.GetKey(KeyCode.Space)) {
            transform.position += variacaoPosicao;
        }

		/*if (mudou)
		{

			spriteRenderer.color = Color.red;
		}
		else
		{
			spriteRenderer.color = Color.white;
		}
*/


	}

}
