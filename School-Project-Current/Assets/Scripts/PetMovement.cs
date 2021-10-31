using UnityEngine;
using System.Collections;

namespace Pathfinding
{
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class PetMovement : VersionedMonoBehaviour
	{
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		private Transform enemyTarget;
		public AIPath aipath;

		bool enemyGotHit;
		float waitForNextHit;

		IAstarAI ai;

		void OnEnable()
		{
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable()
		{
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update()
		{
			FindClosestEnemy();
            if (enemyTarget != null)
            {
				if ((gameObject.transform.position - enemyTarget.position).sqrMagnitude < 25 && enemyGotHit == false)
				{
					aipath.endReachedDistance = 0;
					aipath.maxSpeed = 11;
					aipath.slowdownDistance = 2;
					if (enemyTarget != null && ai != null) ai.destination = enemyTarget.position;
					if ((gameObject.transform.position - enemyTarget.position).sqrMagnitude < 1)
					{
						enemyGotHit = true;
					}
				}
				else if (enemyGotHit == false)
				{
					aipath.endReachedDistance = 3;
					aipath.maxSpeed = 8;
					aipath.slowdownDistance = 6;
					if (target != null && ai != null) ai.destination = target.position;
				}
			}
			
            if (enemyGotHit)
            {
				aipath.endReachedDistance = 3;
				aipath.maxSpeed = 11;
				aipath.slowdownDistance = 6;
				if (target != null && ai != null) ai.destination = target.position;
				waitForNextHit += Time.deltaTime;
				if (waitForNextHit > 3)
				{
					enemyGotHit = false;
					waitForNextHit = 0;
				}
            }
		}

		public void FindClosestEnemy()
		{
			GameObject[] gos;
			gos = GameObject.FindGameObjectsWithTag("GhostEnemy");
			GameObject closest = null;
			float distance = Mathf.Infinity;
			Vector3 position = transform.position;
			foreach (GameObject go in gos)
			{
				Vector3 diff = go.transform.position - position;
				float curDistance = diff.sqrMagnitude;
				if (curDistance < distance)
				{
					closest = go;
					distance = curDistance;
					enemyTarget = closest.transform;
				}
			}
			//Debug.Log(closest);
		}
	}
}
