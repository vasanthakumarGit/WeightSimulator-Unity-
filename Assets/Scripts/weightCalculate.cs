using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WeightSystem
{
    // This script calculates the total weight on two weighing plates and adjusts the color of the balance feedback according to that.
    public class WeightCalculator : MonoBehaviour
    {
        [SerializeField]
        private GameObject leftIndicator;
        [SerializeField]
        private GameObject rightIndicator;
        private float weight;

        // This method calculates the total weight on the weight plate by adding the mass value from the Rigidbody component.
        void OnTriggerEnter(Collider coll)
        {
            if (coll.GetComponent<Rigidbody>())
            {
                weight += coll.GetComponent<Rigidbody>().mass;
                PlayerPrefs.SetFloat(gameObject.name, weight);
                WeightFeedback();
            }
        }

        // When an object is removed from the weighing plate, its weight is subtracted from the total weight.
        void OnTriggerExit(Collider coll)
        {
            if (coll.GetComponent<Rigidbody>())
            {
                weight -= coll.GetComponent<Rigidbody>().mass;
                // This script is attached to two objects (weighing plates). To calculate weight on both sides,
                // weight value is mapped to the respective weighing plate using PlayerPrefs.
                PlayerPrefs.SetFloat(gameObject.name, weight);
                WeightFeedback();
            }
        }

        // This method turns the color of the balance feedback to Green when the weights on both weighing plates are equal.
        // It turns the color orange on the side which is lighter.
        void WeightFeedback()
        {
            Image image1 = leftIndicator.GetComponent<Image>();
            Image image2 = rightIndicator.GetComponent<Image>();

            // Getting the weight values of both plates.
            float savedWeightPlate1 = PlayerPrefs.GetFloat("WeightPlate1", 0f) * 10;
            int WeightPlate1 = (int)savedWeightPlate1;

            float savedWeightPlate2 = PlayerPrefs.GetFloat("WeightPlate2", 0f) * 10;
            int WeightPlate2 = (int)savedWeightPlate2; // Converted float to int to compare if both the weights are equal by rounding them

            if (WeightPlate1 == WeightPlate2)
            {
                image1.color = Color.green;
                image2.color = Color.green;
            }
            else if (savedWeightPlate1 > savedWeightPlate2)
            {
                image2.color = new Color(1.0f, 0.5f, 0.0f);
                leftIndicator.SetActive(false);
            }
            else if (savedWeightPlate1 < savedWeightPlate2)
            {
                image1.color = new Color(1.0f, 0.5f, 0.0f);
                rightIndicator.SetActive(false);
            }
        }
    }
}
