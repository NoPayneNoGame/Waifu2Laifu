using UnityEngine;
using System.Collections;

public class SquareCamera : MonoBehaviour {
  public enum CameraView {
    Back,
    Left,
    Right, 
    Front
  }

  [SerializeField]
  private CameraView cameraView = CameraView.Back;

  [SerializeField]
  private float rectHeight = 0.5f;

  private Camera cam;

  private float cachedWidth = 0.0f;
  private float cachedHeight = 0.0f;


  private void Start()
  {
    cam = GetComponent<Camera>();

    this.RefreshScreenSize();
    float ratio = this.GetRatio();
    float rectWidth = rectHeight * ratio;

    float halfHeight = rectHeight / 2;
    float halfWidth = rectWidth / 2;

    Rect newRect = new Rect(0, 0, rectWidth, rectHeight);

    if(cameraView == CameraView.Back) {
      newRect.x = 0.5f - halfWidth;
      newRect.y = 0.5f + halfHeight;
    } else if (cameraView == CameraView.Left) {
      newRect.x = 0.5f + halfWidth;
      newRect.y = 0.5f - halfHeight;
    } else if (cameraView == CameraView.Right) {
      newRect.x = 0.5f - rectWidth - halfWidth;
      newRect.y = 0.5f - halfHeight;
    } else if (cameraView == CameraView.Front) {
      newRect.x = 0.5f - halfWidth;
      newRect.y = 0.5f - rectHeight - halfHeight;
    }

    cam.rect = newRect;
  }

  void RefreshScreenSize() {
    this.cachedHeight = Screen.height;
    this.cachedWidth = Screen.width;
  }

  float GetRatio () {
    if(this.cachedHeight < this.cachedWidth) {
      return this.cachedHeight / this.cachedWidth;
    } else {
      return this.cachedWidth / this.cachedHeight;
    }
  }
}