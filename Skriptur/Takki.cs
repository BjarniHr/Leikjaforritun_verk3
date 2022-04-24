using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Takki : MonoBehaviour
{
    // þegar takki er í senunni þá unlockea ég músina
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // Start is called before the first frame update
    // og ef það er ýtt á takkann þá byrja ég leikinn
    public void Byrja()
    {
        SceneManager.LoadScene("SampleScene");
        ProjectileScript.count = 0;
        Debug.Log("Takki Ýttur á");
    }
}
