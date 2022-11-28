using UnityEngine;

namespace Com.SciFiShooter.DarkLynxDEV
{
    public class PlayerLocomotion : MonoBehaviour
    {

        [Header("Player Movement - General Fields")]
        [SerializeField] private Camera fpsCamera;

        private Vector3 moveDirection;
        private float playerSpeed;
        private Rigidbody rb;

        [Header("Player - Ground Check")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;

        [Header("Player Movement - Walking")]
        [SerializeField] private float walkSpeed;
        private float baseFOV;

        [Header("Player Movement - Running")]
        [SerializeField] private float runSpeed;
        [SerializeField]private float sprintFOVModifier;

        private bool sprint;
        private bool isSprinting;

        [Header("Player Movement - Jumping")]
        [SerializeField] private float jumpForce;

        void Start()
        {
            Camera.main.enabled = false;

            baseFOV = fpsCamera.fieldOfView;
            playerSpeed = walkSpeed;

            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        void LateUpdate() {
            //Adjust FOV if player is Sprinting
            if(isSprinting) {
                fpsCamera.fieldOfView = Mathf.Lerp(fpsCamera.fieldOfView, baseFOV * sprintFOVModifier, Time.deltaTime * 8f);
            } else {
                fpsCamera.fieldOfView = Mathf.Lerp(fpsCamera.fieldOfView, baseFOV, Time.deltaTime * 8f);
            }
        }

        public void HandleMovement(Vector2 input) {
            moveDirection = Vector3.zero;
            moveDirection.x = input.x;
            moveDirection.z = input.y;
            moveDirection.Normalize();

            Vector3 targetVelocity = transform.TransformDirection(moveDirection) * playerSpeed * Time.deltaTime;
            targetVelocity.y = rb.velocity.y;
            rb.velocity = targetVelocity;

            //Player Movement - Sprinting
            isSprinting = sprint && moveDirection.z > 0f && isGrounded();

            if (isSprinting) {
                playerSpeed = runSpeed;
            } else {
                playerSpeed = walkSpeed;
            }
        }

        public void Jump() {
            if(isGrounded()) {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }  
        }

        public void Sprint() {
            sprint = !sprint; 
        }

        private bool isGrounded() {
            return Physics.Raycast(groundCheck.position, Vector3.down, 0.1f, groundLayer);
        }
    }
}
