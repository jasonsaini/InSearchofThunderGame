//Sets the Y position of a transform based off of several other transforms and a sine wave.




using UnityEngine;

namespace DistantLands
{
    public class BodyEffector : MonoBehaviour
    {


        public Transform[] effectors;

        public float offset;
        public float sinDepth = 0;
        public float sinWidth = 15;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {


            float i = 0;


            foreach (Transform j in effectors)
                i += j.position.y;

            i /= effectors.Length;
            i += offset + (Mathf.Sin(Time.time * 90 / sinWidth) * sinDepth);


            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, i, Time.deltaTime), transform.position.z);





        }
    }
}