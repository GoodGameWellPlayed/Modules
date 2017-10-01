using UnityEngine;

public class CameraEventSender : MonoBehaviour, IEventSender<CameraMoveEventArguments>
{
    [SerializeField] private Camera _camera;

    private CameraMoveEventArguments _cameraPosition;
    private CameraRectArguments _currentCameraRect;

    private void Update()
    {
        if (_cameraPosition == null)
        {
            _cameraPosition = new CameraMoveEventArguments();
        }

        CameraRectArguments newCameraRect = CameraRectArguments.CreateRectArguments(_camera);

        if (_currentCameraRect.Equals(newCameraRect))
        {
            return;
        }
        _currentCameraRect = newCameraRect;

        float zPositionOffset = -_currentCameraRect.Position.z;
        Vector3 topLeft = _camera.ScreenToWorldPoint(
            new Vector3(0, _currentCameraRect.PixelHeight, zPositionOffset));
        Vector3 bottomRight = _camera.ScreenToWorldPoint(
            new Vector3(_currentCameraRect.PixelWidth, 0, zPositionOffset));

        Vector3 size = new Vector3(bottomRight.x - topLeft.x, topLeft.y - bottomRight.y, 0);

        _cameraPosition.CameraScreenRect = new Rect(topLeft.x, topLeft.y, size.x, size.y);
        TypeEventManager.Instance.Notify(_cameraPosition, this);
    }
}

public struct CameraRectArguments
{
    public Vector3 Position { get; set; }
    public int PixelWidth { get; set; }
    public int PixelHeight { get; set; }

    public static CameraRectArguments CreateRectArguments(Camera camera)
    {
        return new CameraRectArguments()
        {
            Position = camera.transform.position,
            PixelWidth = camera.pixelWidth,
            PixelHeight = camera.pixelHeight
        };
    }

    public override bool Equals(object obj)
    {
        CameraRectArguments other = (CameraRectArguments)obj;
        return other.Position == Position && other.PixelWidth == PixelWidth &&
            other.PixelHeight == PixelHeight;
    }
}

