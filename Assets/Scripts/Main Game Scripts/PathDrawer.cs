using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

[ExecuteInEditMode]
public class PathDrawer : MonoBehaviour
{
    public Path path;
    private LineRenderer myLineRenderer;
    public int MyCurrentNumber;

    private void OnEnable() {
        EnsureLineRenderer();
        if (path == null) {
            CreatePath();
        }
    }

    private void EnsureLineRenderer() {
        if (this.GetComponent<EdgeCollider2D>() == null) {
            this.gameObject.AddComponent<EdgeCollider2D>();
        }

        if (myLineRenderer == null) {
            myLineRenderer = gameObject.GetComponent<LineRenderer>();
            if (myLineRenderer == null) {
                myLineRenderer = gameObject.AddComponent<LineRenderer>();
            }
            myLineRenderer.widthMultiplier = 0.2f;
            myLineRenderer.useWorldSpace = true;
            myLineRenderer.positionCount = 0;
        }
    }

    public void CreatePath() {
        path = new Path(transform.position);
        DrawPath(path.points);
    }

    public void DrawPath(List<Vector2> points) {
        EnsureLineRenderer();

        myLineRenderer.positionCount = points.Count;
        for (int i = 0; i < points.Count; i++) {
            myLineRenderer.SetPosition(i, new Vector3(points[i].x, points[i].y, 0));
        }

        // Perbaikan pengaturan EdgeCollider2D
        if (this.GetComponent<EdgeCollider2D>() != null) {
            Vector2[] colliderPoints = new Vector2[points.Count];
            for (int i = 0; i < points.Count; i++) {
                colliderPoints[i] = new Vector2(points[i].x - 90f, points[i].y - 90f);
            }
            this.GetComponent<EdgeCollider2D>().points = colliderPoints;
        }
    }
}
