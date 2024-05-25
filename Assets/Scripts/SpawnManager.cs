using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CagePosition
{
    public RectTransform cagePosition;
    public bool isFull;
}

public class SpawnManager : MonoBehaviour
{
    [Header("Chicken")]
    public GameObject[] chicken;
    public Transform chickenParent;

    [Header("Cage")]
    public GameObject cage;
    public List<CagePosition> cagePositions = new List<CagePosition>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCage()
    {
        for(int i = 0; i < cagePositions.Count; i++)
        {
            if (!cagePositions[i].isFull)
            {
                GameObject spawnObj = Instantiate(cage, cagePositions[i].cagePosition.position, Quaternion.identity);
                spawnObj.transform.SetParent(cagePositions[i].cagePosition);
                spawnObj.transform.localScale = Vector3.one;
                spawnObj.name += i;

                cagePositions[i].isFull = true;
                return;
            }
        }
    }

    public void SpawnChicken(int index)
    {
        chickenParent.gameObject.SetActive(true);

        GameObject spawnObj = Instantiate(chicken[index], Vector3.zero, Quaternion.identity);
        spawnObj.transform.SetParent(chickenParent);
        spawnObj.transform.localScale = Vector3.one;
    }
}
