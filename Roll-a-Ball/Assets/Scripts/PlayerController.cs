using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text countText;
	public Text winText;
    public Text timerText;

	public Rigidbody rb;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCountText();
		winText.text = "";
	}

    private void FixedUpdate()
    {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up")) 
		{
			other.gameObject.SetActive(false);
			count++;
			setCountText();
		}
        else if (other.gameObject.CompareTag("Bonus Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 5;
            setCountText();
        }
	}

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 16 && winText.text == "")
        {
            winText.text = "You Win!";
            timerText.color = Color.blue;
        }
    }
}