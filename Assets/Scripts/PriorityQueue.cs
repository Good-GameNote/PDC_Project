using System;
using System.Collections;
using System.Collections.Generic;

public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> heap = new List<T>();

    public int Count => heap.Count;

    public bool Enqueue(T item)
    {
        if (heap.Contains(item))
            return false;

        heap.Add(item);
        int i = heap.Count - 1;
        while (i > 0)
        {
            int parentIndex = (i - 1) / 2;
            if (heap[i].CompareTo(heap[parentIndex]) >= 0)
                break;
            Swap(i, parentIndex);
            i = parentIndex;
        }
        return true;
    }
   
    public bool Remove(T item)
    {
        int index = heap.IndexOf(item);
        if (index == -1)
            return false;

        int lastIndex = heap.Count - 1;
        if (index != lastIndex)
        {
            heap[index] = heap[lastIndex];
            heap.RemoveAt(lastIndex);

            // 위로 이동
            int parentIndex = (index - 1) / 2;
            if (index > 0 && heap[index].CompareTo(heap[parentIndex]) < 0)
            {
                while (index > 0)
                {
                    parentIndex = (index - 1) / 2;
                    if (heap[index].CompareTo(heap[parentIndex]) >= 0)
                        break;
                    Swap(index, parentIndex);
                    index = parentIndex;
                }
            }
            // 아래로 이동
            else
            {
                while (true)
                {
                    int leftChildIndex = 2 * index + 1;
                    int rightChildIndex = 2 * index + 2;
                    int smallestIndex = index;

                    if (leftChildIndex < heap.Count && heap[leftChildIndex].CompareTo(heap[smallestIndex]) < 0)
                        smallestIndex = leftChildIndex;

                    if (rightChildIndex < heap.Count && heap[rightChildIndex].CompareTo(heap[smallestIndex]) < 0)
                        smallestIndex = rightChildIndex;

                    if (smallestIndex == index)
                        break;

                    Swap(index, smallestIndex);
                    index = smallestIndex;
                }
            }
        }
        else
        {
            heap.RemoveAt(lastIndex);
        }

        return true;
    }
    //public T Dequeue()
    //{
    //    if (heap.Count == 0)
    //        throw new InvalidOperationException("The queue is empty.");

    //    T root = heap[0];
    //    heap[0] = heap[heap.Count - 1];
    //    heap.RemoveAt(heap.Count - 1);

    //    int i = 0;
    //    while (true)
    //    {
    //        int leftChildIndex = 2 * i + 1;
    //        int rightChildIndex = 2 * i + 2;
    //        int smallestIndex = i;

    //        if (leftChildIndex < heap.Count && heap[leftChildIndex].CompareTo(heap[smallestIndex]) < 0)
    //            smallestIndex = leftChildIndex;

    //        if (rightChildIndex < heap.Count && heap[rightChildIndex].CompareTo(heap[smallestIndex]) < 0)
    //            smallestIndex = rightChildIndex;

    //        if (smallestIndex == i)
    //            break;

    //        Swap(i, smallestIndex);
    //        i = smallestIndex;
    //    }

    //    return root;
    //}
    private void Swap(int i, int j)
    {
        T temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }

    //public bool TryPeek(out T result)
    //{
    //    if (heap.Count > 0)
    //    {
    //        result = heap[0];
    //        return true;
    //    }
    //    else
    //    {
    //        result = default(T);
    //        return false;
    //    }
    //}

    public void Circuit(Action<T> action)
    {
        foreach (var item in heap)
        {
            action(item);
        }
    }

}
