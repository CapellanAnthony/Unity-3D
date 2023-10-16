using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
	public GameObject winTextObject;
	public GameObject LostTextObject;
	//public GameObject BallObject;

    private int count;
    private Rigidbody rb;
    private AudioSource audio;
    private float movementX;
    private float movementY;
	
	public float tiempoInicial = 60.0f; // Tiempo inicial en segundos
    private float tiempoRestante;

    public TMP_Text textoTiempo; // Referencia al texto donde se mostrará el tiempo

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        count = 0;

        tiempoRestante = tiempoInicial; //nuevo

        SetCountText ();
        winTextObject.SetActive(false);
		LostTextObject.SetActive(false);
        StartCoroutine(sceneLoader());
    }
	//Nuevo
	void Update()
    {
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0.0f)
        {
            // Aquí puedes agregar acciones para cuando el tiempo se agote
            // Por ejemplo, reiniciar el nivel o mostrar un mensaje de "Has perdido"
            Debug.Log("Tiempo agotado. ¡Has perdido!");
			LostTextObject.SetActive(true);
            tiempoRestante = 0.0f; // Asegurarse de que el tiempo no sea negativo
        }

        ActualizarTextoTiempo();
    }
	//nuevo
	void ActualizarTextoTiempo()
    {
        int segundos = Mathf.CeilToInt(tiempoRestante);
        textoTiempo.text = "Tiempo: " + segundos.ToString();
    }

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate() {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            audio.Play();
            count++;
            SetCountText();
        }
    }

     void SetCountText()
	{
		countText.text = "Puntos: " + count.ToString();

		if (count >= 12) 
		{
            winTextObject.SetActive(true);
		}
	}

    IEnumerator sceneLoader()
    {
        Debug.Log("Waiting for Player score to be >=12 ");
        yield return new WaitUntil(() => count >= 12 || tiempoRestante <= 0.0f);
        Debug.Log("Player score is >=12. Loading next Level");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
