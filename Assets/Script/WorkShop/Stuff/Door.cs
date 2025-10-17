using System.Collections;
using TMPro;
using UnityEngine;

public class Door : Stuff, IInteractable
{
    public Door() {
        Name = "Door";
    }
    // ���������Ѻ�к���һ�еٶ١�Դ�����������
    private bool isOpen = false;

    // ��˹����˹觷���е٨�����͹�
    public Vector3 openOffset = new Vector3(0, 0, 2f);

    // ��������㹡������͹��е�
    public float slideSpeed = 2f;
    public Transform door;

    public bool isInteractable { get => isLock; set => isLock = value; }

    public void Interact(Player player)
    {
        // ��ش Coroutine ��ҡ�͹����� Coroutine ����
        StopAllCoroutines();

        // ��һ�е��Դ���� ���Դ��е�
        if (isOpen)
        {
            StartCoroutine(SlideDoor(door.position - openOffset));
        }
        // ��һ�еٻԴ���� ����Դ��е�
        else
        {
            StartCoroutine(SlideDoor(door.position + openOffset));
        }

        // ��ѺʶҹТͧ��е�
        isOpen = !isOpen;
    }

    private IEnumerator SlideDoor(Vector3 targetPosition)
    {
        Vector3 startPosition = door.position;
        float timeElapsed = 0;

        // �ٻ���зӧҹ�������� ��Һ��ҷ���е��ѧ����͹����֧���˹��������
        while (timeElapsed < 1)
        {
            // �ӹǳ���˹�����ͧ��е�Ẻ�������
            timeElapsed += Time.deltaTime * slideSpeed;
            door.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed);
            yield return null; // �ͨ����Ҩж֧����Ѵ�
        }

        // ��Ǩ�ͺ��������һ�е���������˹��ش���·��١��ͧ
        door.position = targetPosition;
    }

}
