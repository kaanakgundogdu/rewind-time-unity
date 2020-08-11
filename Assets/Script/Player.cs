using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    private float _speed = 5f;
    private float _horizontalInput;
    private float _verticalInput;
    private float _jumpForce = 5f;
    [SerializeField] private bool _isOnGround = false;
    private Vector3 _position;
    private Vector3 _inputVector;
    private Rigidbody _myRigidBody;
    

    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody>();
        
    }

	void Update()
	{
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");


        _inputVector = new Vector3( _horizontalInput *_speed , _myRigidBody.velocity.y , _verticalInput *_speed );

        transform.LookAt( transform.position + new Vector3 (_inputVector.x, 0, _inputVector.z) );


        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround  )
        {
            _myRigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;
        }
    }

	private void FixedUpdate()
	{

        _myRigidBody.velocity = _inputVector;
	}

	private void OnCollisionEnter (Collision collision)
	{
		if( collision.gameObject.tag == ("Ground"))
		{
            _isOnGround = true;
		}
	}


}