using UnityEngine;
using UnityEngine.AI;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

/* Note: animations are called via the controller for both the character and capsule using animator null checks
 */

namespace StarterAssets
{
	[RequireComponent(typeof(CharacterController))]
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
	[RequireComponent(typeof(PlayerInput))]
#endif
	public class ThirdPersonAdaptado : MonoBehaviour
	{
		[Header("Player")]
		[Tooltip("Move speed of the character in m/s")]
		public float MoveSpeed = 2.0f;
		[Tooltip("Sprint speed of the character in m/s")]
		public float SprintSpeed = 5.335f;
		[Tooltip("How fast the character turns to face movement direction")]
		[Range(0.0f, 0.3f)]
		public float RotationSmoothTime = 0.12f;
		[Tooltip("Acceleration and deceleration")]
		public float SpeedChangeRate = 10.0f;

		
		public float rotationSpeed = 0.0f;


		// player
		private float _speed;
		private float _animationBlend;
		
		private float _rotationVelocity;
		private float _verticalVelocity;
		private float _terminalVelocity = 53.0f;



		// animation IDs
		private int _animIDSpeed;
		private int _animIDGrounded;

		private int _animIDMotionSpeed;

		private Animator _animator;

		private GameObject _mainCamera;

		private const float _threshold = 0.01f;

		private bool _hasAnimator;


		PlayerController playerController;


		NavMeshAgent navMeshAgent;

		private void Awake()
		{
			// get a reference to our main camera
			if (_mainCamera == null)
			{
				_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
			}
			navMeshAgent = GetComponent<NavMeshAgent>();

			navMeshAgent.updateRotation = false;
		}

		private void Start()
		{
			_hasAnimator = TryGetComponent(out _animator);
			playerController = GetComponent<PlayerController>();
			AssignAnimationIDs();

			_animator.SetBool(_animIDGrounded, true);
		}

		private void Update()
		{
				
			Move();
			RotateTowards(playerController.posDestino);
		}


		private void AssignAnimationIDs()
		{
			_animIDSpeed = Animator.StringToHash("Speed");
			_animIDGrounded = Animator.StringToHash("Grounded");
			_animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
		}

		

		

		private void Move()
		{
			
		
			// update animator if using character
			if (_hasAnimator)
			{
				//_animator.SetFloat(_animIDSpeed, _animationBlend);
				_animator.SetFloat(_animIDSpeed, navMeshAgent.desiredVelocity.magnitude);
				_animator.SetFloat(_animIDMotionSpeed, navMeshAgent.desiredVelocity.magnitude);
			}

		
		}

		private void RotateTowards(Transform target)
		{
			Vector3 direction = (target.position - transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
			
		}


		
	}
}