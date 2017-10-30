using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour{

    public float sensitivity;
    public float minY, maxY;

    private Vector2 mouseLook;
    
    private GameObject _character;

    private void Start()
    {
        _character = transform.parent.gameObject;
    }

    public void Update () {
        Vector2 mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * sensitivity;
        mouseLook += mouseMovement;
        mouseLook.y = Mathf.Clamp(mouseLook.y, minY, maxY);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        _character.transform.localRotation *= Quaternion.AngleAxis(mouseMovement.x, _character.transform.up);
    }
}
