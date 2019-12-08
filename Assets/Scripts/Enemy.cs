using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private float speed;

    private Rigidbody2D rb2dEnemy;
    private Animator anim;
    private Player player;
    private bool run = true;
    
    void Start()
    {
		player = FindObjectOfType<Player>();
        this.rb2dEnemy = this.GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        float h = 1F;
		/*if (player.transform.position.x > transform.position.x && 
			player.LookRight)
		{
			transform.position = 
				Vector2.MoveTowards(transform.position, 
				player.transform.position, 
				speed * Time.deltaTime);
                
        }

		if(player.transform.position.x < transform.position.x &&
			!player.LookRight)
		{*/
			transform.position = Vector2.MoveTowards(transform.position,
				player.transform.position,
				speed*Time.deltaTime);
                anim.SetFloat("run", Mathf.Abs(h));
       // }

        
        //transform.Rotate(0,0,1, Space.Self);

    }
}
