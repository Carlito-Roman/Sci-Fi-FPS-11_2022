using UnityEngine;
using UnityEngine.InputSystem;

namespace Com.SciFiShooter.DarkLynxDEV
{
    public class InputManager : MonoBehaviour
    {

        [SerializeField] private PlayerInputs playerInputs;
        [SerializeField] private PlayerInputs.OnFootActions onFoot;

        [Header("Script Reference Variable Fields")]
        [SerializeField] private PlayerLocomotion locomotion;
        [SerializeField] private PlayerLook look;

        void Awake()
        {
            playerInputs = new PlayerInputs();
            onFoot = playerInputs.OnFoot;

            locomotion = GetComponent<PlayerLocomotion>();
            look = GetComponent<PlayerLook>();
        }

        void FixedUpdate()
        {
            locomotion.HandleMovement(onFoot.Movement.ReadValue<Vector2>());
        }

        private void Update()
        {
            onFoot.Jump.performed += ctx => locomotion.Jump();

            onFoot.Sprint.performed += ctx => locomotion.Sprint();
            onFoot.Sprint.canceled += ctx => locomotion.Sprint();
        }

        void LateUpdate()
        {
            look.HandleLook(onFoot.Look.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            onFoot.Enable();
        }

        private void OnDisable()
        {
            onFoot.Disable();
        }
    }
}
