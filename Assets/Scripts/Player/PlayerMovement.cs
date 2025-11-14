using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _rb;

        private InputAction moveAction;
        private InputAction jumpAction;
        float moveForce = 30f;
        float maxSpeed = 99999f;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            moveAction = InputSystem.actions.FindAction("Move");
            jumpAction = InputSystem.actions.FindAction("Jump");
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector2 moveValue = moveAction.ReadValue<Vector2>();

            
            //Movement
            Vector3 move = new Vector3(moveValue.x, 0, moveValue.y);
            Vector3 flatVelocity = new Vector3(_rb.linearVelocity.x, 0, _rb.linearVelocity.z);
            if (flatVelocity.magnitude < maxSpeed)
            {
                Debug.Log(move);
                _rb.AddForce(move * moveForce, ForceMode.Acceleration);
            }
            
            //Jump
            if (jumpAction.IsPressed())
            {
                _rb.AddForce(new Vector3(0,10));
            }
        }
    }
}
