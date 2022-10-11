//Simple navigation script to show off how the procedural animation can be used.




using UnityEngine;


namespace DistantLands
{
    public class Follow : MonoBehaviour
    {

        public Transform target;
        public float speed;
        public float angularSpeed;
        public float stoppingDistance;
        public bool paused;




        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (!paused && target)
                if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position, Vector3.up), angularSpeed * Time.deltaTime);
                }

        }
    }
}