//Allows an series of objects to all follow each other in a snake-like fashion.




using System.Collections.Generic;
using UnityEngine;


namespace DistantLands
{
    public class Worm : MonoBehaviour
    {

        [System.Serializable]
        public class Segment
        {

            public Transform transform;
            public float offset;
            public Transform nextSegment;


        }
        [HideInInspector]
        public List<Segment> segments;

        public Transform[] tail;


        [Tooltip("Which axis is the world up")]
        public Vector3 up;



        Vector3 oldTravelVector;




        // Start is called before the first frame update
        void Start()
        {



            int j = 0;

            foreach (Transform i in tail)
            {

                if (i != tail[0])
                {
                    Segment k = new Segment();

                    k.transform = i;
                    k.nextSegment = tail[j];

                    segments.Add(k);
                    j++;



                }
                else
                {
                    Segment k = new Segment();

                    k.transform = i;

                    segments.Add(k);



                }
            }

            foreach (Segment i in segments)
            {

                if (i.nextSegment)
                    i.offset = Vector3.Distance(i.transform.position, i.nextSegment.position);


            }


            oldTravelVector = segments[0].transform.position;


        }

        // Update is called once per frame
        void Update()
        {

            Vector3 travelVector = segments[0].transform.position - oldTravelVector;





            foreach (Segment i in segments)
            {


                if (i.nextSegment)
                {

                    float travelAmount = Vector3.Distance(i.transform.position, i.nextSegment.position) - i.offset;


                    i.transform.LookAt(i.nextSegment, up);

                    i.transform.position += i.transform.forward * travelAmount;




                }
            }


            oldTravelVector = travelVector;


        }
    }
}