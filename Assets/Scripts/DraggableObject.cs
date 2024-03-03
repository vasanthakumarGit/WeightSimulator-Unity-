using UnityEngine;

// Namespace declaration
namespace InteractiveObjects
{
    // This script makes an object draggable by the mouse.
    public class DraggableObject : MonoBehaviour
    {
        private Vector3 initialOffset;//offset between object's position and mouse position.
        private float objectScreenDepth; // depth of the object relation to camera.
        private bool gravityEnabled = false;
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            if (rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
                rb.useGravity = false; // Disable gravity initially,so it wont fall down right after it is instantiated.
            }
        }

        // Called when the mouse is pressed down on the object
        private void OnMouseDown()
        {
            objectScreenDepth = Camera.main.WorldToScreenPoint(transform.position).z;
            initialOffset = transform.position - GetMousePositionInWorld();

            // Enable gravity in first click of the object
            if (!gravityEnabled)
            {
                rb.useGravity = true;
                gravityEnabled = true;
            }
        }

        // Calculate the mouse position in the world
        private Vector3 GetMousePositionInWorld()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = objectScreenDepth;
            return Camera.main.ScreenToWorldPoint(mousePosition);
        }

        //mouse the object on mouse drag
        private void OnMouseDrag()
        {
            transform.position = GetMousePositionInWorld() + initialOffset;
        }
    }
}
