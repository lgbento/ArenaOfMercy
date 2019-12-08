using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

	[SerializeField]
	private Transform camera;
    [SerializeField]
    private Transform cameraLimitLeft;
    [SerializeField]
    private Transform cameraLimitRight;


    void Start()
    {
        
    }

    void Update()
    {
      /*
        camera.position = new Vector3(transform.position.x,
        camera.position.y,
        camera.position.z);
        
     */

    }
}
