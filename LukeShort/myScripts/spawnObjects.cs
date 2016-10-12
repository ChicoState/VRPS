using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnObjects : MonoBehaviour {
	public Transform[] SpawnPoints;
	float timeToSpawn = 1.0f;

	public GameObject myC3po;
	public GameObject myDino;
	public GameObject myHorse;
	public GameObject myMonkey;
	public List<GameObject> myListOfGameObjects = new List<GameObject> ();

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Started");
		//add all the GameObjects to List
		myListOfGameObjects.Add (myC3po);
		myListOfGameObjects.Add (myDino);
		myListOfGameObjects.Add (myHorse);
		myListOfGameObjects.Add (myMonkey);

		//shuffle the list up!
		shuffleMyList(myListOfGameObjects);
		Debug.Log ("called shuffle.");
		Invoke ("SpawnMyObjects",timeToSpawn); 
	}
	
	// Update is called once per frame
	void Update ()
	{}

	void SpawnMyObjects()
	{
		//int spawnIndex = Random.Range (0, SpawnPoints.Length);
		for(int i=0; i<SpawnPoints.Length; i++)
		{
			Instantiate (myListOfGameObjects[i], SpawnPoints [i].position, SpawnPoints [i].rotation);
		}

		/*
		Instantiate(mySphere, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);

		if (spawnIndex == 3)
		{
			spawnIndex = 0;
		}
		else
		{
			++spawnIndex;
		}
		Instantiate (mySphere, SpawnPoints [spawnIndex].position, SpawnPoints [spawnIndex].rotation);*/
	}

	public static void shuffleMyList(List<GameObject> myList)
	{
		for(int i=0; i<myList.Count; i++)
		{
			int randNum = Random.Range(0, myList.Count-1);

			GameObject tempObject = myList[i];
			myList[i] = myList[randNum];
			myList[randNum] = tempObject;
		}
	}
}
