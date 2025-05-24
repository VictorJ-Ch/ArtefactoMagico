using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour
{
    public Transform posA, posB, posC, posD;
    public float speed = 2f;

    public GameObject enemigosZoneA, enemigosZoneB, player, ui;

    public Camera cam;
    public Camera blackOne;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.enabled = true;
        blackOne.enabled = false;

        enemigosZoneA.SetActive(false);
        enemigosZoneB.SetActive(false);
        player.SetActive(false);
        ui.SetActive(false);

        StartCoroutine(MoveCameraSequence());
    }

    IEnumerator MoveCameraSequence()
    {
        yield return MoveToPosition(posA.position, posB.position);
        blackOne.enabled = true;
        cam.enabled = false;
        transform.position = posC.position;
        yield return new WaitForSeconds(3f);
        blackOne.enabled = false;
        cam.enabled = true;
        yield return MoveToPosition(posC.position, posD.position);

        enemigosZoneA.SetActive(true);
        enemigosZoneB.SetActive(true);
        player.SetActive(true);
        ui.SetActive(true);
        cam.enabled = false;
    }

    IEnumerator MoveToPosition(Vector3 start, Vector3 end)
    {
        float elapsedTime = 0f;
        float journeyTime = Vector3.Distance(start, end) / speed;

        while (elapsedTime < journeyTime)
        {
            transform.position = Vector3.Lerp(start, end, elapsedTime / journeyTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = end;
    }
}
