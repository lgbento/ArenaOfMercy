using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	private float speed = 300;
	private float jumpForce = 350;
	private Rigidbody2D rb2dPlayer;
	private float h;

	private bool lookRight = true;
	public bool LookRight
	{
		get { return lookRight; }
		//set { lookRight = value; }
	}

	[SerializeField]
	private BoxCollider2D attackCollider;
	private bool attack = false;


	[SerializeField]
	private Transform onGround;
	private bool isGround;
	[SerializeField]
	private LayerMask layerGround;

	private Animator anim;
	private SpriteRenderer sprite;

	private bool blink = false;
	public bool Blink
	{
		get { return blink; }
	}

	private void Start()
	{
		this.rb2dPlayer = this.GetComponent<Rigidbody2D>();
		this.anim = GetComponent<Animator>();
		this.sprite = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		h = Input.GetAxisRaw("Horizontal");

		isGround = Physics2D.OverlapCircle(onGround.position, 0.1f, layerGround); ;

		if (h > 0 && !lookRight)
		{
			Flip();
		}
		if (h < 0 && lookRight)
		{
			Flip();
		}

		if (Input.GetKeyDown(KeyCode.Space) && isGround)
		{
			rb2dPlayer.AddForce(new Vector2(0, jumpForce));
		}

		if (Input.GetMouseButtonDown(0) && isGround)
		{
			anim.SetTrigger("attack");
		}

		anim.SetFloat("run", Mathf.Abs(h));
		anim.SetBool("isGround", isGround);
		anim.SetFloat("jump", rb2dPlayer.velocity.y);
	}

	private void FixedUpdate()
	{
		if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
		{
			rb2dPlayer.velocity =
				new Vector2(h * speed * Time.fixedDeltaTime,
								rb2dPlayer.velocity.y);
		}
		else
		{
			rb2dPlayer.velocity = Vector2.zero;
		}
	}

	void Flip()
	{
		lookRight = !lookRight;
		transform.localScale = new Vector2(
			transform.localScale.x * -1, transform.localScale.y);
	}

	public void activateCollide()
	{
		attack = !attack;
		attackCollider.gameObject.SetActive(attack);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			Destroy(other.gameObject);
		}
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			StartCoroutine(DamageBlink());
		}
	}

	IEnumerator DamageBlink()
	{
		blink = true;
		for(int i = 0; i < 5; i++)
		{
			sprite.color = new Color(1,1,1,0);
			yield return new WaitForSeconds(0.2f);
			sprite.color = new Color(1, 1, 1, 1);
			yield return new WaitForSeconds(0.2f);
		}
		blink = false;
	}
}
