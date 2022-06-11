using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraAnchor : MonoBehaviour
{
	public enum AnchorType
	{
		BottomLeft,
		BottomCenter,
		BottomRight,
		MiddleLeft,
		MiddleCenter,
		MiddleRight,
		TopLeft,
		TopCenter,
		TopRight,
	};

	public AnchorType anchorType;
	public Vector3 anchorOffset;
	IEnumerator updateAnchorRoutine;

	private void Start()
	{
		updateAnchorRoutine = UpdateAnchorAsync();
		StartCoroutine(updateAnchorRoutine);
	}

	IEnumerator UpdateAnchorAsync()
	{
		uint cameraWaitCycles = 0;

		while (ViewportHandler.Instance == null)
		{
			++cameraWaitCycles;
			yield return new WaitForEndOfFrame();
		}

		if (cameraWaitCycles > 0)
		{
			print(string.Format("CameraAnchor found ViewportHandler instance after waiting {0} frame(s). You might want to check that ViewportHandler has an earlie execution order.", cameraWaitCycles));
		}

		UpdateAnchor();
		updateAnchorRoutine = null;
	}

	private void UpdateAnchor()
	{
		switch (anchorType)
		{
			case AnchorType.BottomLeft:
				SetAnchor(ViewportHandler.Instance.BottomLeft);
				break;
			case AnchorType.BottomCenter:
				SetAnchor(ViewportHandler.Instance.BottomCenter);
				break;
			case AnchorType.BottomRight:
				SetAnchor(ViewportHandler.Instance.BottomRight);
				break;
			case AnchorType.MiddleLeft:
				SetAnchor(ViewportHandler.Instance.MiddleLeft);
				break;
			case AnchorType.MiddleCenter:
				SetAnchor(ViewportHandler.Instance.MiddleCenter);
				break;
			case AnchorType.MiddleRight:
				SetAnchor(ViewportHandler.Instance.MiddleRight);
				break;
			case AnchorType.TopLeft:
				SetAnchor(ViewportHandler.Instance.TopLeft);
				break;
			case AnchorType.TopCenter:
				SetAnchor(ViewportHandler.Instance.TopCenter);
				break;
			case AnchorType.TopRight:
				SetAnchor(ViewportHandler.Instance.TopRight);
				break;
		}
	}

	private void SetAnchor(Vector3 anchor)
	{
		Vector3 newPos = anchor + anchorOffset;
		if (!transform.position.Equals(newPos))
		{
			transform.position = newPos;
		}
	}

#if UNITY_EDITOR
	private void Update()
	{
		if (updateAnchorRoutine == null)
		{
			updateAnchorRoutine = UpdateAnchorAsync();
			StartCoroutine(updateAnchorRoutine);
		}
	}
#endif
}