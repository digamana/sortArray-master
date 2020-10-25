using System;
using System.Collections.Generic;
using System.Text;

namespace sortArray
{
    public class commandSkin
    {
        protected string sortName_ = String.Empty;
        protected int[] nums;
        public void showArray(String strName, int[] iInput)
        {
            Console.WriteLine(strName);
            foreach (int item in iInput)
            {
                Console.Write(String.Format("{0} ", item));
            }
            Console.WriteLine();
        }
        public void showSorting(string sortName,int[] nums)
        { 
        
        }

        /// <summary>
        /// 交換位置 (Num1 與Num2位置的內容調換)
        /// </summary>
        /// <param name="iInput"></param>交換的陣列
        /// <param name="Num1"></param>第Num1個位置
        /// <param name="Num2"></param>第Num2個位置
        public void changeAdr(int[] iInput, int Num1,int Num2)
        {
            int temp = iInput[Num1];
            //排序交換
            iInput[Num1] = iInput[Num2];
            iInput[Num2] = temp;
        }

    }


    class SelectSort: commandSkin
    {
        private string sortName_ = "選擇排序法";
       

        public SelectSort(int[] num)
        {
            nums = num;
            showArray("排序前", nums);
            Sorting(nums);
            showArray("排序後", nums);
        }
        public  string strName 
        {
            get { return sortName_; }
            set { sortName_=value; } 
        }

        /// <summary>
        /// 執行排序中
        /// </summary>
        /// <param name="iInput"></param>
        void Sorting(int[] iInput)
        {
            for (int i = 0; i < iInput.Length; i++)
            {
                //搜尋從i到最後的最小值所在位置
                int minAdr = minAdress(iInput, i);
                changeAdr(iInput,i,minAdr);
            }
        }

        /// <summary>
        /// 搜尋 num陣列從第iStart個位置到結束的最小值位置
        /// </summary>
        /// <param name="num"></param> 要排徐的陣列
        /// <param name="iStart"></param> 從第iStart個位置開始搜尋
        /// <returns></returns>
        int minAdress(int[] num, int iStart)
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

    }

    class BubbleSort: commandSkin
    {
        private string sortName_ = "氣泡排序法";
        private int[] nums;
        public string strName
        {
            get { return sortName_; }
            set { sortName_ = value; }
        }

        public BubbleSort(int[] num)
        {
            nums = num;
            showArray("排序前", nums);
            Sorting(nums);
            showArray("排序後", nums);
        }
        void Sorting(int[] iInput)
        {
            foreach (int time in iInput)
            {
                for (int i = iInput.Length - 2; i >= 0; i--)
                {
                    //搜尋從i到最後的最小值所在位置
                    if (iInput[i] > iInput[i + 1])
                    {
                        changeAdr(iInput, i, i + 1);
                        i++;
                    }
                }
            }
 
        }
    }

    class InsertionSort : commandSkin
    {
        private string sortName_ = "插入排序法";
        public InsertionSort(int[] num)
        {
            nums = num;
            showArray("排序前", nums);
            moveArray(nums, 2, 5);
            Sorting(nums);
            showArray("排序後", nums);
        }
        void Sorting(int[] iInput)
        {
            int iLast = iInput[iInput.Length-1];
            int iSorted = 1;

            //for (int i = iInput.Length-1; i> iSorted; i--)
            //{
            //    iInput[i] = iInput[i - 1];
            //}
            //iInput[0] = iLast;
            //Console.WriteLine(findInsertAdr(iInput, iInput.Length,10));
            for (int i = 1; i < iInput.Length; i++)
            {
                if (iInput[i] < iInput[i - 1])
                {
                    for (int j = i-1; j >= 0; j--)
                    {
                        if (iInput[j] > iInput[i] && iInput[j + 1] <= iInput[i])
                        { 
                        
                        }
                    }



                }



            }
            int findInsertAdr(int[] iInput,int iEnd,int iInsert)
            {
                int adr;
                for (int i = 0; i < iEnd-1; i++)
                {
                    if (iInput[i] > iInsert && iInput[i + 1] <= iInsert)
                    {
                        return i;
                    }
                }
                return 0;
            }
        }

        /// <summary>
        /// 陣列向右位移1個單位
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="iStart"></param>
        /// <param name="iEnd"></param>
        void moveArray(int[] nums, int iStart, int iEnd)
        {
            if (iStart > iEnd && (iStart> nums.Length || iEnd > nums.Length)) return;
            int temp = nums[iEnd];           
            for (int i = iEnd; i > iStart; i--)
            {
                nums[i] = nums[i - 1];
            }
            nums[iStart] = temp;


        }

    }
    class MergeSort : commandSkin
    {
        private string sortName_ = "合併排序法";
        public MergeSort(int[] num)
        {
            nums = num;
            showArray("排序前", nums);
            Sorting(nums,0,nums.Length-1);
            showArray("排序後", nums);
        }
        void Sorting(int[] iInput, int iLow, int iHigh)
        {
            if (iLow < iHigh)
            {
                int iMid = (iLow+iHigh) / 2;
                Sorting(iInput,iLow,iMid);
                Sorting(iInput,iMid+1,iHigh);
                iMerge(iInput,iLow,iMid,iHigh);
            }
        }
        void iMerge(int[] iInput, int iLow, int iMId,int iHigh)
        {
            int[] arrTemp = new int[iHigh- iLow +1];
            int i = iLow;
            int j = iMId + 1;
            int k = 0;

            while (i <= iMId && j <= iHigh)
            {
                if (iInput[i] <= iInput[j])
                {
                    arrTemp[k++] = iInput[i++];
                }
                else
                {
                    arrTemp[k++] = iInput[j++];
                }
                
            }
            while (i <= iMId) arrTemp[k++] = iInput[i++];
            while (j <= iHigh) arrTemp[k++] = iInput[j++];

            for (i = iLow, k = 0; i <= iHigh; i++)
            {
                iInput[i] = arrTemp[k++];
            }
        }
    }
    class QuickSort : commandSkin
    {
        private string sortName_ = "快速排序法";
        public QuickSort(int[] num)
        {
            nums = num;
            showArray("排序前", nums);
            Sorting(nums,0,nums.Length-1);
            showArray("排序後", nums);
        }
        void Sorting(int[] iInput,int iLow,int iHigh)
        {
            int iMid;
            if (iLow < iHigh)
            {
                iMid = iPartition(iInput, iLow, iHigh);
                Sorting(iInput,iLow,    iMid-1);
                Sorting(iInput, iMid + 1,iHigh) ;
            }
        }
        /// <summary>
        /// 掃描
        /// </summary>
        /// <param name="iInput"></param>
        /// <param name="iLow"></param>
        /// <param name="iHigh"></param>
        /// <returns></returns>
        int iPartition(int[] iInput, int iLow, int iHigh)
        {
            int i = iLow;
            int j = iHigh;
            int iPivot = iInput[i];
            while (i < j)
            {
                //從右邊開始掃描
                while (i < j && iPivot < iInput[j]) j--;
                if (i < j)
                {
                    changeAdr(iInput,i,j);
                    i++;
                }
                //向左掃描
                while (i < j && iPivot > iInput[i]) i++;
                if (i < j)
                {
                    changeAdr(iInput, i, j);
                    j--;
                }              
            }
            return i;
        }
    }
}
