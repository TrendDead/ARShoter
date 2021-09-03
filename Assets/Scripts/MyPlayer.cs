using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    [SerializeField]
    private int _score = 0;
    [SerializeField]
    private TMP_Text _text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Box box))
        { 
            _score++;
            Destroy(box.gameObject);
            _text.text = _score.ToString();

        }
    }


}
