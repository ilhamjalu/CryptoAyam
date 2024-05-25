using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseChicken : MonoBehaviour
{
    public string chickenName;
    public Image chickenObj;
    public Vector3 chickenStartPosition = Vector3.zero;
    public float speed;

    public float moveSpeed = 100f;
    public float changeDirectionTime = 1f;

    public RectTransform rectTransform;
    private Vector2 direction;
    private float timer;

    public void MoveChicken()
    {

    }

    public void ChangeDirection()
    {
        float angle = Random.Range(0f, 360f);
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    void KeepInBounds()
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        RectTransform canvasRect = rectTransform.root.GetComponent<RectTransform>();

        for (int i = 0; i < corners.Length; i++)
        {
            Vector3 screenPoint = RectTransformUtility.WorldToScreenPoint(null, corners[i]);
            if (screenPoint.x < 0 || screenPoint.x > Screen.width || screenPoint.y < 0 || screenPoint.y > Screen.height)
            {
                direction = -direction;
                break;
            }
        }
    }

    public void ChickenMovement()
    {
        //chicken.transform.position = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0) * speed;

        //RectTransform rectTransform = GetComponent<RectTransform>();

        //rectTransform.position = Vector2.MoveTowards(rectTransform.position, new Vector3(Random.Range(-6, 6), Random.Range(-10, 10)), speed * Time.deltaTime);

        //chicken.transform.Translate(new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0) * speed * Time.deltaTime);

        rectTransform.anchoredPosition += direction * moveSpeed * Time.deltaTime;

        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            ChangeDirection();
            timer = 0f;
        }

        //KeepInBounds();
    }
}
