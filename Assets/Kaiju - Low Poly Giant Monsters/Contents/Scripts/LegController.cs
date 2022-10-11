//The main script that controls when legs will update to ensure that legs are updated evenly.




using System.Collections.Generic;
using UnityEngine;


namespace DistantLands
{
    public class LegController : MonoBehaviour
    {


        public Leg[] legs;
        [HideInInspector]
        public List<Leg> legUpdateImportance;



        // Start is called before the first frame update
        void Start()
        {

            legUpdateImportance.AddRange(legs);

        }

        // Update is called once per frame
        void Update()
        {

            List<Leg> usedLegs = new List<Leg>();

            foreach (Leg i in legUpdateImportance)
            {

                i.UpdateLeg();

                if (!i.grounded)
                    usedLegs.Add(i);

            }

            foreach (Leg i in usedLegs)
                legUpdateImportance.Remove(i);


        }

        private void LateUpdate()
        {

            foreach (Leg i in legs)
            {

                if (!legUpdateImportance.Contains(i))
                    legUpdateImportance.Add(i);


            }
        }

    }
}