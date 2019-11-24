using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    public GameObject prefabInimigo;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GerarInimigos", 2, 4);
    }

    public void GerarInimigos()
    {

        Vector3 novaPosicao = new Vector3(transform.position.x, transform.position.y, 0);

        Instantiate(prefabInimigo, novaPosicao, transform.rotation);

    }
}
