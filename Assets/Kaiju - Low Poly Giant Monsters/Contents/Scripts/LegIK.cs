//Simple IK script for moving legs and arms of creatures.




using UnityEngine;


namespace DistantLands
{

	[ExecuteInEditMode]
	public class LegIK : MonoBehaviour
	{

		
		public Transform upperArm;
		public Transform forearm;
		public Transform hand;
		public Transform elbow;
		public Transform target;
		[Space(20)]
		public Vector3 uppperArm_OffsetRotation;
		public Vector3 forearm_OffsetRotation;
		public Vector3 hand_OffsetRotation;
		[Space(20)]
		public bool handMatchesTargetRotation = true;

		float angle;
		float upperArmLength;
		float foreArmLength;
		float totalLength;
		float targetDistance;
		float adjacent;



		// Update is called once per frame
		void LateUpdate()
		{
			if (upperArm != null && forearm != null && hand != null && elbow != null && target != null)
			{
				upperArm.LookAt(target, elbow.position - upperArm.position);
				upperArm.Rotate(uppperArm_OffsetRotation);

				Vector3 cross = Vector3.Cross(elbow.position - upperArm.position, forearm.position - upperArm.position);



				upperArmLength = Vector3.Distance(upperArm.position, forearm.position);
				foreArmLength = Vector3.Distance(forearm.position, hand.position);
				totalLength = upperArmLength + foreArmLength;
				targetDistance = Vector3.Distance(upperArm.position, target.position);
				targetDistance = Mathf.Min(targetDistance, totalLength - totalLength * 0.001f);

				adjacent = ((upperArmLength * upperArmLength) - (foreArmLength * foreArmLength) + (targetDistance * targetDistance)) / (2 * targetDistance);

				angle = Mathf.Acos(adjacent / upperArmLength) * Mathf.Rad2Deg;

				upperArm.RotateAround(upperArm.position, cross, -angle);

				forearm.LookAt(target, cross);
				forearm.Rotate(forearm_OffsetRotation);

				if (handMatchesTargetRotation)
				{
					hand.rotation = target.rotation;
					hand.Rotate(hand_OffsetRotation);
				}


			}

		}
	}
}