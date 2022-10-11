//Simulates velocity calculations by remembering where a transform was in the last frame.




using UnityEngine;


namespace DistantLands
{
    public class GetVelocityFromTransform : MonoBehaviour
    {

        public Vector3 velocity;
        private Vector3 lastPos;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            velocity = transform.position - lastPos;

            lastPos = transform.position;


        }
    }
}