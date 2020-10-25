using System;

namespace sortArray
{
    class Program
    {
        static void Main(string[] args)
        {

            //int[] iInput = new int[9] { 5,3,4,7,2,8,6,9,1 };
            //亂數產生
            int[] iInput = new int[10];
            for (int i = 0; i < iInput.Length; i++)
            {
                Random rnd = new Random();
                iInput[i] = rnd.Next(1, 100);
            }
            //SelectSort selectSort = new SelectSort(iInput);
            //BubbleSort bubbleSort = new BubbleSort(iInput);
            choseSort(iInput, (int)sortLevel.MergeSort);


        }
        public static void Sorting( int[] iInput)
        {
            for (int i = 0; i < iInput.Length; i++)
            {
                //暫存第i個位置的值
                int temp = iInput[i];
                //最小值搜尋
                int minAdr = minAdress(iInput, i);
                //排序交換
                iInput[i] = iInput[minAdr];
                iInput[minAdr] = temp;
            }
        }
        public static void showArray(String strName,int[] iInput)
        {
            Console.WriteLine(strName);
            foreach (int item in iInput)
            {
                Console.Write(String.Format("{0} ",item ));
            }
        }
        //搜尋 num陣列從第iStart個位置到結束的最小值位置
        public static int minAdress(int[] num, int iStart)
        {
            int min = int.MaxValue;
            int minAdr = iStart;
            for (int i = iStart; i < num.Length; i++)
            {
                if (min > num[i])
                {
                    min = num[i];
                    minAdr = i;
                }
            }
            return minAdr;
        }
        public static commandSkin choseSort(int[] nums,int iChose)
        {
            Console.WriteLine((sortLevel)iChose);
            commandSkin cmdSort;
            switch (iChose)
            { 
                case (int)sortLevel.InsertionSort:
                    return cmdSort = new InsertionSort(nums);
                case (int)sortLevel.BubbleSort:
                    return cmdSort = new BubbleSort(nums);
                case (int)sortLevel.MergeSort:
                    return cmdSort = new MergeSort(nums);
                case (int)sortLevel.QuickSort:
                    return cmdSort = new QuickSort(nums);
                case (int)sortLevel.SelectSort:
                    return cmdSort = new SelectSort(nums);
                default:
                    return null;


            }
            return null;
        }

    }
    enum sortLevel
    {
        SelectSort,
        BubbleSort,
        InsertionSort,
        MergeSort,
        QuickSort
    }
 


}
