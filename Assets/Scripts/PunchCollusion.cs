using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PunchCollusion : MonoBehaviour
{
    private int BlockCount;
    public TextMeshProUGUI DestroyedCountText;
    public PlayerController Sus;

    // Start is called before the first frame update
    void Start()
    {
        BlockCount = 0;
        SetDestroyedCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDestroyedCountText()
    {
        DestroyedCountText.text = "Blocks Destoryed: " + BlockCount.ToString() + "/15";
        if (BlockCount >= 15)
        {
            Sus.IsAllBlocksGone = true;
            Sus.SetCountText();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Breakable"))
        {
            other.gameObject.SetActive(false);
            BlockCount = BlockCount + 1;

            SetDestroyedCountText();
        }
    }
}
