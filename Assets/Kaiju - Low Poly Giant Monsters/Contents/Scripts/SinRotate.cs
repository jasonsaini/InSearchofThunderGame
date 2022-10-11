//Simple script that rotates an object by a sine wave.




using UnityEngine;


namespace DistantLands
{
    public class SinRotate : MonoBehaviour
    {

        public Vector3 depth;
        public float offset = 0;
        public float width = 10;
        private Vector3 originalRot;


        // Start is called before the first frame update
        void Start()
        {

            originalRot = transform.localEulerAngles;

        }

        // Update is called once per frame
        void Update()
        {

            float sinPos = Mathf.Sin((Time.time - offset) / width * 30);



            transform.localEulerAngles = originalRot + (depth * sinPos);


        }
    }
}