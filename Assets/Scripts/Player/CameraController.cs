using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour{

    public float sensitivity;
    
    private GameObject _character;

    private void Start()
    {
        _character = transform.parent.gameObject;
    }

    public void Update () {
        Vector2 mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * sensitivity;
        transform.localRotation *= Quaternion.AngleAxis(-mouseMovement.y, Vector3.right);
        _character.transform.localRotation *= Quaternion.AngleAxis(mouseMovement.x, _character.transform.up);

        //Weapon weapon = _character.GetComponentInChildren<Weapon>();
        //weapon.transform.localRotation *= Quaternion.AngleAxis(-mouseMovement.y, Vector3.right);
    }
}
