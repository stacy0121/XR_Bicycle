using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List_sort : MonoBehaviour
{


    public GameObject Fif_ran_num_obj; // ������ ������Ʈ
    private RandomNumberDisplay randomnumber_sci;



    private void Start()
    {
        randomnumber_sci = Fif_ran_num_obj.GetComponent<RandomNumberDisplay>();
    }

    public void sort_list()
    {
        randomnumber_sci.numbers.Sort();
    }

}
