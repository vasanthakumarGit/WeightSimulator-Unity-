using UnityEngine;
using UnityEngine.UI;

namespace ObjectInstantiation
{
    // This script handles the instantiation of a 3D object when a button is clicked.
    public class InstantiateOnButtonClick : MonoBehaviour
    {
        [SerializeField]
        private GameObject objectToInstantiate;

        // Position variables for instantiation, Getting these positions to instantiate the objects right under their corresponding buttons.
        public float xAxisPosition = 0.0f;
        public float yAxisPosition = 0.0f;
        public float zAxisPosition = 0.0f;

        private void Start()
        {
            Button button = GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => OnClick(objectToInstantiate));
            }
        }

        // Called when the button is clicked
        // When the 3D object's button is clicked, the 3D object will be instantiated in a specific position.
        private void OnClick(GameObject objectToInstantiate)
        {
            // Set the spawn position.
            Vector3 spawnPosition = new Vector3(xAxisPosition, yAxisPosition, zAxisPosition);

            // Instantiate object at spawn position with no rotation.
            Instantiate(objectToInstantiate, spawnPosition, Quaternion.identity);
        }
    }
}
