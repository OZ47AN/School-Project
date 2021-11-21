using UnityEngine;
using System.Collections;

namespace Pathfinding
{
	
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class NewEnemyMovement : VersionedMonoBehaviour
	{
		private Transform playerPos;
		private AIPath aipath;

		IAstarAI ai;

        private void Start()
        {
			playerPos = GameObject.FindGameObjectWithTag("Player").transform;
			aipath = gameObject.GetComponent<AIPath>();
		}

        void OnEnable()
		{
			ai = GetComponent<IAstarAI>();
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable()
		{
			if (ai != null) ai.onSearchPath -= Update;
		}

		void Update()
		{
			if (playerPos != null && ai != null) ai.destination = playerPos.position;
		}
	}
}
