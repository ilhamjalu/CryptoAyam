using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowPassword : MonoBehaviour
{
    [SerializeField] List<Sprite> showPasswordAssets;
    [SerializeField] Button showPasswordButton;

    // Start is called before the first frame update
    void Start()
    {
        showPasswordButton = gameObject.GetComponent<Button>();

        showPasswordButton.onClick.AddListener( ()=>MakePasswordVisible(showPasswordButton.GetComponentInParent<TMP_InputField>()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakePasswordVisible(TMP_InputField pass)
    {
        Debug.Log("TEST222 " + pass.name);

        Image temp = showPasswordButton.GetComponent<Image>();

        if (temp.sprite == showPasswordAssets[0])
        {
            temp.sprite = showPasswordAssets[1];
            pass.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            temp.sprite = showPasswordAssets[0];
            pass.contentType = TMP_InputField.ContentType.Password;

        }

        pass.ForceLabelUpdate();
    }
}
