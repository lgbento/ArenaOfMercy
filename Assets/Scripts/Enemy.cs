using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private float speed;

	private Player player;
    
    void Start()
    {
		player = FindObjectOfType<Player>();
    }

    
    void Update()
    {
		if (player.transform.position.x > transform.position.x && 
			player.LookRight)
		{
			transform.position = 
				Vector2.MoveTowards(transform.position, 
				player.transform.position, 
				speed * Time.deltaTime); ;
		}

		if(player.transform.position.x < transform.position.x &&
			!player.LookRight)
		{
			transform.position = Vector2.MoveTowards(transform.position,
				player.transform.position,
				speed*Time.deltaTime);
		}

		transform.Rotate(0,0,1, Space.Self);

    }
}
