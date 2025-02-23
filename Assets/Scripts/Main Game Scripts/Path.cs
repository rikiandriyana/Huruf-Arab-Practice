using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Path {
    public List<Vector2> points;

    public Path(Vector2 centre) {
        points = new List<Vector2> {
            centre + Vector2.left,
            centre + Vector2.left * 0.35f,
            centre + Vector2.right * 0.35f,
            centre + Vector2.right
        };
        Debug.Log($"Path created with {points.Count} points"); // Debugging
    }

    public Vector2 this[int i] => points[i];
    public int NumPoints => points.Count;
    public int NumSegments => (points.Count - 4) / 3 + 1;

    public void AddSegment(Vector2 anchorPos) {
        Vector2 lastAnchor = points[points.Count - 1];
        Vector2 control1 = lastAnchor + (anchorPos - lastAnchor) * 0.3f;
        Vector2 control2 = anchorPos - (anchorPos - lastAnchor) * 0.3f;

        points.Add(control1);
        points.Add(control2);
        points.Add(anchorPos);
        Debug.Log($"Added segment at {anchorPos}, total points: {points.Count}");
    }

    public Vector2[] GetPointsInSegment(int i) =>
        new Vector2[] { points[i * 3], points[i * 3 + 1], points[i * 3 + 2], points[i * 3 + 3] };

    public void MovePoint(int i, Vector2 pos) {
        Vector2 delta = pos - points[i];
        points[i] = pos;

        if (i % 3 == 0 && i > 0 && i < points.Count - 1) {
            points[i - 1] += delta;
            points[i + 1] += delta;
        }
    }
}

