using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
namespace ImageFilters
{
    class SortHelper
    {

        public static byte Kth_element(Byte[] Array , int K)
        {


            //int pivot(int[] arr, int l, int r)
            //{
            //    Random random = new Random();

            //    int range = (r - l) + 1;
            //    int pivotIndex = l + (random.Next() % range);
            //    int pivotElement = arr[pivotIndex];

            //    while (l < r)
            //    {
            //        while (arr[l] < pivotElement)
            //            l++;

            //        while (arr[r] > pivotElement)
            //            r--;

            //        if (arr[l] == arr[r])
            //            l++;
            //        else if (l < r)
            //        {
            //            int tmp = arr[l];
            //            arr[l] = arr[r];
            //            arr[r] = tmp;
            //        }

            //    }
            //    return r;

            //}

            //int quickSelect(int[] arr, int l, int r, int k)
            //{

            //    if (l == r)
            //        return arr[l];

            //    int pivotIndex = pivot(arr, l, r);
            //    int length = (pivotIndex - l + 1);

            //    if (length == k)
            //        return arr[pivotIndex];
            //    else if (k < length)
            //        return quickSelect(arr, l, (pivotIndex - 1), k);
            //    else
            //        return quickSelect(arr, (pivotIndex + 1), r, (k - length));
            //}

          




            int T = K - 1;
            for (int i = 0; i < T; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < Array.Length; j++)
                {
                    if (Array[j] < Array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Byte temp = Array[i];
                Array[i] = Array[minIndex];
                Array[minIndex] = temp;
            }

            int N = Array.Length - 1;
            for (int i = N; i > N - T; i--)
            {
                int maxIndex = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (Array[j] > Array[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                Byte temp = Array[i];
                Array[i] = Array[maxIndex];
                Array[maxIndex] = temp;
            }

            int sum = 0;
            for (int i = T; i <= N - T; i++)
            {
                sum += Array[i];
            }
            byte average = (byte)(sum / (N - 2 * T));
            return average;
        }


        public static byte[] CountingSort(Byte[] Array)
        {
            //TODO: Implement the Counting Sort alogrithm on the input array



            var maxVal = Array[0];
            for (int i = 1; i < Array.Length; i++)
                if (Array[i] > maxVal)
                    maxVal = Array[i];

            //not required in this type of code
            var minVal = Array[0];
            for (int i = 1; i < Array.Length; i++)
                if (Array[i] < minVal)
                    minVal = Array[i];


            var size = Array.Length;

            var occurrences = new int[maxVal + 1];
            for (int i = 0; i < maxVal + 1; i++)
            {
                occurrences[i] = 0;
            }
            for (int i = 0; i < size; i++)
            {
                occurrences[Array[i]]++;
            }
            for (int i = 0, j = 0; i <= maxVal; i++)
            {
                while (occurrences[i] > 0)
                {
                    Array[j] = (byte)i;
                    j++;
                    occurrences[i]--;
                }
            }

            return Array;

            //// Remove the next line
            //throw new NotImplementedException();
        }





        static void swap(Byte[] arr, int i, int j)
        {
            Byte temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;


        }

        static int partition(Byte[] arr, int low, int high)
        {



            int pivot = arr[high];

            int i = (low - 1);


            for (int j = low; j <= high - 1; j++)
            {


                if (arr[j] < pivot)
                {

                    i++;

                    swap(arr, i, j);
                }
            }
            swap(arr, i + 1, high);
            return (i + 1);
        }


        static byte[] quickSort(Byte[] arr, int low, int high)
        {


            if (low < high)
            {
                int pi = partition(arr, low, high);
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
            return arr;
        }


        public static byte[] QuickSort(Byte[] Array)
        {
            int n = Array.Length;

            int size = Array.Length;
            Byte temp = Array[0];
            Byte temp2 = Array[n - 1];
            if (size % 2 == 0)
            {
                if (Array[0] > Array[n - 1])
                {
                    Array[0] = Array[n - 1];
                    Array[n - 1] = temp;
                }
            }
            else
            {
                int median = (size / n);
                if (Array[0] > Array[n - 1])
                {
                    Array[0] = Array[n - 1];
                    Array[n - 1] = temp;
                }
                else if (Array[median + 1] > Array[n - 1])
                {
                    Array[median + 1] = Array[n - 1];
                    Array[n - 1] = temp2;
                }
                else if (Array[median + 1] < Array[0])
                {
                    Array[median + 1] = Array[0];
                    Array[0] = temp2;
                }

            }
            quickSort(Array, 0, n - 1);
            return Array;
        }
    }
}