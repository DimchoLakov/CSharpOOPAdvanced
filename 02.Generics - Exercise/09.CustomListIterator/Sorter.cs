using System;

public class Sorter
{
    public static void Sort<T>(CustomList<T> myList) where T : IComparable<T>
    {
        for (int i = 1; i <= myList.Count - 1; ++i)

            for (int j = 0; j < myList.Count - i; ++j)

                if (myList[j].CompareTo(myList[j + 1]) > 0)
                {
                    var temp = myList[j];
                    myList[j] = myList[j + 1];
                    myList[j + 1] = temp;
                }
    }
}