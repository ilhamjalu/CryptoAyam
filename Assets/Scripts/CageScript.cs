using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CageScript : EarningScript, IDropHandler
{
    [SerializeField] public List<BaseChicken> chickens;
    [SerializeField] bool isStart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateWaitTimeUI(gameObject.name);
    }

    void AddChickentoList(BaseChicken chicken)
    {
        chickens.Add(chicken);
        LayingEgg();
    }

    void LayingEgg()
    {
        if (IsCouple(false, false))
        {
            EarningTime(gameObject.name);
        }
    }

    bool IsCouple(bool male, bool female)
    {
        for (int i = 0; i < chickens.Count; i++) 
        {
            if (chickens[i].name == "male")
            {
                male = true;
            }
            else if (chickens[i].name == "female")
            {
                female = true;
            }
        }

        if(male && female)
        {
            return true;
        }

        return false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.TryGetComponent<BaseChicken>(out var temp))
        {
            temp.transform.parent.gameObject.SetActive(false);

            AddChickentoList(temp);
            temp.chickenStartPosition = transform.position;
            temp.transform.SetParent(gameObject.transform);
        }
    }
}
