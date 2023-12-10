using Mirror;
using UnityEngine;

namespace QuickStart
{
    public class PlayerController : NetworkBehaviour
    {
        private const float RotationSpeed = 110.0f;
        private const float MovementSpeed = 4.0f;

        public override void OnStartLocalPlayer()
        {
            SetCameraPosition();
        }

        private void SetCameraPosition()
        {
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.localPosition = Vector3.zero;
        }

        private void Update()
        {
            if (!IsControlledByLocalPlayer()) return;

            ProcessInput();
        }

        private bool IsControlledByLocalPlayer()
        {
            return isLocalPlayer;
        }

        private void ProcessInput()
        {
            RotatePlayer();
            MovePlayer();
        }

        private void RotatePlayer()
        {
            float rotation = Input.GetAxis("Horizontal") * Time.deltaTime * RotationSpeed;
            transform.Rotate(0, rotation, 0);
        }

        private void MovePlayer()
        {
            float movement = Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed;
            transform.Translate(0, 0, movement);
        }
    }
}