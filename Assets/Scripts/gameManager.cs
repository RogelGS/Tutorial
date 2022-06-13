using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public Renderer background;
    public GameObject col;
    public float velocity = 2;

    public GameObject rock;
    public GameObject miniRock;
    public GameObject menu;
    public GameObject menuGameOver;

    public List<GameObject> colList;
    public List<GameObject> obsList;

    public bool start = false;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // Creación del mapa
        for (int i = 0; i < 21; i++)
        {
            colList.Add(Instantiate(col, new Vector2(-10 + i, -3), Quaternion.identity));
        }

        // Crear obstaculo
        obsList.Add(Instantiate(rock, new Vector2(18, -2), Quaternion.identity));
        obsList.Add(Instantiate(miniRock, new Vector2(14, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start == true && gameOver == false)
        {
            menu.SetActive(false);

            // Movimiento del fondo
            background.material.mainTextureOffset = background.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;

            // Movimiento del mapa
            for (int i = 0; i < colList.Count; i++)
            {
                if (colList[i].transform.position.x <= -10)
                {
                    colList[i].transform.position = new Vector3(10, -3, 0);
                }

                colList[i].transform.position = colList[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocity;
            }

            // Movimiento de obstaculos
            for (int i = 0; i < obsList.Count; i++)
            {
                if (obsList[i].transform.position.x <= -10)
                {
                    float random = Random.Range(11, 18);
                    obsList[i].transform.position = new Vector3(random, -2, 0);
                }

                obsList[i].transform.position = obsList[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocity;
            }
        }
    }
}
