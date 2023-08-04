using System;
using System.Collections.Generic;

namespace TestPrograms
{
    class Program
    {

        static void Main(string[] args)
        {

            int[] nums1 = { 3, 1, 2, 4 };
            int k1 = 2;
            Console.WriteLine(FindKthLargest(nums1, k1));
            int[] nums = { 0, 0, 1, 1, 1, 1, 2, 3, 3 };
            int result = RemoveDuplicates(nums);
            int length = MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            int case1 = FirstMissingPositive(new int[] { 1, 2, 0 });

            int case2 = FirstMissingPositive(new int[] { 3, 4, -1, 1 });

            int case3 = FirstMissingPositive(new int[] { 7, 8, 9, 11, 12 });
            IList<IList<int>> getsum1 = ThreeSumFunc(new int[] { -2, 0, 0, 2, 2 });
 //           NextPermutation(new int[] {3,2,1});
            GetLongestLength(new int[] {4,7,1,2,8,10,3 });
            Merge(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3);
            int[] ar1 = { 1, 2 };
            int[] ar2 = { 3, 4,5 };
            double med = FindMedianSortedArrays(ar1, ar2);
            int[] artwosum = { 3, 2, 4 };
            int[] getsum = TwoSum(artwosum, 6);
            Console.ReadLine();
        }
        //NumericToRoman
        public static string NumericToRoman(int no)
        {
            int[] numeric = {1,4,5,9,10,40,50,90,100,400,500,900,1000 };
            string[] romainno = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "DM", "M" };
            string getroman = "";
            for(int i=numeric.Length-1;i>=0;i--)
            {
                while(no>=numeric[i])
                {
                    no -= numeric[i];
                    getroman += romainno[i];
                }
            }
            return getroman;
        }
        // Roman To Integer
       public static int RomanToNumeric(string getroman)
        {
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>
            {
                {'I' ,1 },
                {'V' ,5 },
                {'X',10 },
                {'L',50 },
                {'C',100 },
                {'D',500 },
                {'M',1000 }
            };
            int totalvalu = 0;
            for(int i=0;i<getroman.Length;i++)
            {
                int currentvalue = keyValuePairs[getroman[i]];
                
                if (i + 1 < getroman.Length && keyValuePairs[getroman[i+1]]>currentvalue)
                {
                    totalvalu -= currentvalue;
                }
                else
                {
                    totalvalu += currentvalue;
                }
            }
            return totalvalu;
        }

         // Roman To Integer
       public static int RomanToNumeric(string getroman)
        {
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>
            {
                {'I' ,1 },
                {'V' ,5 },
                {'X',10 },
                {'L',50 },
                {'C',100 },
                {'D',500 },
                {'M',1000 }
            };
            int totalvalu = 0;
            for(int i=0;i<getroman.Length;i++)
            {
                int currentvalue = keyValuePairs[getroman[i]];
                
                if (i + 1 < getroman.Length && keyValuePairs[getroman[i+1]]>currentvalue)
                {
                    totalvalu -= currentvalue;
                }
                else
                {
                    totalvalu += currentvalue;
                }
            }
            return totalvalu;
        }public static int FindKthLargest(int[] nums, int k)
        {
            // Quickselect to find the kth largest element
            int left = 0;
            int right = nums.Length - 1;

            while (true)
            {
                int pivotIndex = Partition(nums, left, right);
                int kthLargestIndex = nums.Length - k;

                if (pivotIndex == kthLargestIndex)
                {
                    return nums[pivotIndex];
                }
                else if (pivotIndex < kthLargestIndex)
                {
                    left = pivotIndex + 1;
                }
                else
                {
                    right = pivotIndex - 1;
                }
            }
        }

        private static int Partition(int[] nums, int left, int right)
        {
            // Choosing the rightmost element as the pivot
            int pivot = nums[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (nums[j] <= pivot)
                {
                    swap(nums, i, j);
                    i++;
                }
            }

            swap(nums, i, right);
            return i;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 2)
                return nums.Length;

            int slow = 1;
            for (int fast = 2; fast < nums.Length; fast++)
            {
                if (nums[fast] != nums[slow - 1])
                {
                    slow++;
                    nums[slow] = nums[fast];
                }
            }

            return slow + 1;
        }
        public static int MaxSubArray(int[] nums)
        {
            List<int> lis = new List<int>(nums);
            int start = 0;
            int starting = 0;
            int end = 0;
            int maxendingsum = 0;
            int maxstartingsum = 0;
            int length = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                maxendingsum += nums[i];
                if (maxstartingsum < maxendingsum)
                {
                    maxstartingsum = maxendingsum;
                    starting = start + 1;
                    end = i;

                }
                if (maxendingsum < 0)
                {
                    maxendingsum = 0;
                    start = i;
                }


            }
            return maxstartingsum;



        }
        public static int FirstMissingPositive(int[] nums)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                while (nums[i] > 0 && nums[i] <= nums.Length &&
                 nums[nums[i] - 1] != nums[i])
                {
                    swap(nums, i, nums[i] - 1);
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }
            return 0;

        }
        //public void swapmis(int[] nums, int i, int j)
        //{
        //    int temp = nums[i];
        //    nums[i] = nums[j];
        //    nums[j] = temp;

        //}
        public static void FindIndex(int[] nums)
        {

        }
        public static IList<IList<int>> ThreeSumFunc(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> lis = new List<IList<int>>();
           
            for(int i=0;i<nums.Length-2;i++)
            {
                int start = i;
                int left = i + 1;
                int right = nums.Length - 1;
                while(left < right)
                {
                    List<int> lisdu = new List<int>();
                    int sum = nums[start] + nums[left] + nums[right];
                    int oldleft = 0;
                    if(sum==0)
                    {
                        oldleft = left;
                        lisdu.Add(nums[start]);
                        lisdu.Add(nums[left]);
                        lisdu.Add(nums[right]);                      
                        
                        if(!lis.Contains(lisdu))
                        lis.Add(lisdu);                        
                        left++;
                        right--;                                             
                    }
                    else if(sum<0)
                    {
                        oldleft = left;
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                    while (left < nums.Length - 1 && nums[oldleft] == nums[left])
                        left++;
                }
                while (i < nums.Length-1 && nums[i] == nums[i + 1])
                    i++;

            }        
            return lis;
        }
        public static int FindRightIndex(int[] nums,int target)
        {
            int index = -1;
            int start = 0;
            int end = nums.Length - 1;
            while(start<=end)
            {
                int middleindex = start + (end - start) / 2;
                if(nums[middleindex]<=target)
                {
                    start = middleindex + 1;
                    if(nums[middleindex]==target)
                    {
                        index = middleindex;
                    }

                }
                else
                {
                    end = middleindex - 1; 
                }
            }

            return index;

        }
        public static int FindLeftIndex(int[] nums,int target)
        {
            int index = -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int middleindex = start + (end - start) / 2;
                if (nums[middleindex] >= target)
                {
                    end = middleindex - 1;
                    if (nums[middleindex] == target)
                    {
                        index = middleindex;
                    }
                }
                else
                {
                    start = middleindex + 1;
                }
            }
            return index;
        }
        public static void BinarySearch(int []nums,int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            while(start<=end)
            {
                int middle = start + (end - start) / 2;
                if(nums[middle]==target)
                {
                    Console.WriteLine(middle);
                }
                else if(nums[middle]<target)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }                        
            }
        }

        public static void NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;
            int j = nums.Length - 1;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i > 0)
            {
                while (j > 0 && nums[i] > nums[j])
                {
                    j--;
                }
                swap(nums, i, j);
            }

           
            reverse(nums, i + 1, j);


        }
        public static void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;

        }
        public static void reverse(int[] nums, int i, int j)
        {

            while (i < j)
            {
                swap(nums, i, j);
                i++;
                j--;
            }
        }
        public static void GetLongestLength(int []num)
        {
            List<int> ar = new List<int>(num);
            int no = 0;
            int lengt = 0;
            int count = 0;
            List<int> store = new List<int>();
            for(int i=0;i<num.Length;i++)
            {
                if(!ar.Contains(num[i]-1))
                {
                    no = num[i];
                    count = num[i];
                    while(ar.Contains(no))
                    {
                        
                        no++;
                    }
                    if(lengt<no-num[i])
                    {
                        
                        lengt = no - num[i];                                          
                    }
                }
            }

            List<int> indexesOfLongestSeq = new List<int>();
            for (int i = 0; i < lengt; i++)
            {
                indexesOfLongestSeq.Add(count + i);
            }
            Console.WriteLine(lengt);

        }
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int k = m + n - 1;
            m = m - 1;
            n = n - 1;
            while(m>=0 && n>=0)
            {
                if(nums1[m]>nums2[n])
                {
                    nums1[k] = nums1[m];
                    m--;
                }
                else
                {
                    nums1[k] = nums2[n];
                    n--;
                }
                k--;
            }
            while(n>=0)
            {
                nums1[k] = nums2[n];
                n--;
                k--;
            }


        }
            public static int[] TwoSum(int[] nums, int target)
        {
           // Array.Sort(nums);
            for(int i=0;i<nums.Length-1;i++)
            {
                int start = 0;
                int left = i+1;
                int right = nums.Length - 1;

                while(start<right)
                {
                    int sum = nums[i] + nums[right];
                    if(sum==target)
                    {                       
                        return new int[] { i, right};
                    }
                    else if(sum<target)
                    {
                        start++;
                    }
                    else
                    {
                        right--;
                    }

                }
                while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                    i++;

            }
            return new int[] { 1, 2 };
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int n = nums1.Length  + nums2.Length;
            int[] kmedianarray = new int[n];

            int i = 0, j = 0, k = 0;
            while(i<nums1.Length && j<nums2.Length)
            {
                if(nums1[i]<nums2[j])
                {
                    kmedianarray[k] = nums1[i];
                    k++;
                    i++;
                }
                else
                {
                    kmedianarray[k] = nums2[j];
                    k++;
                    j++;
                }
            }
            while(i<nums1.Length)
            {
                kmedianarray[k] = nums1[i];
                k++;
                i++;
            }
            while (j < nums2.Length)
            {
                kmedianarray[k] = nums2[j];
                k++;
                j++;
            }
            int middle = kmedianarray.Length / 2;
            double med = 0;
            if (middle%2==0)
            {
                 med = (kmedianarray[middle] + kmedianarray[middle - 1]) / 2;
                Console.WriteLine(kmedianarray[Convert.ToInt32(med)]);

            }
            else
            {
                med = kmedianarray[middle];
                Console.WriteLine(kmedianarray[middle]);
            }
            return med;
        }
    }
}

 static void FindDuplicates(int[] arr)
        {
            List<int> se = new List<int>();
           // bool k = se.Add(1);
            HashSet<int> set = new HashSet<int>();
            HashSet<int> duplicates = new HashSet<int>();
            
            foreach (int element in arr)
            {              

                if (!set.Add(element))
                {
                    // If the element already exists in the set, it's a duplicate.
                    // Add it to the duplicates set if it's not already there.
                    if (!duplicates.Contains(element))
                    {
                        duplicates.Add(element);
                        Console.WriteLine(element);
                    }
                }
            }
        }

public static void Movezerostoleft()
        {
            int[] ar = { 1, 2, 4, 0, 9, 23, 0, 7, 6 };
            int count = ar.Length - 1; // Start from the end of the array

            for (int i = ar.Length - 1; i >= 0; i--)
            {
                if (ar[i] != 0)
                {
                    ar[count] = ar[i];
                    count--;
                }
            }

            while (count >= 0)
            {
                ar[count] = 0;
                count--;
            }
        
        }

public static int FindMaxOccuringintegerOnes(int[] nums)
        {
            int getinteger = 0;
            int count = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    getinteger = nums[i];
                }
                if(nums[i]==getinteger)
                {

                    count++;
                }
                else {
                    count--;
}
            }
            return getinteger;
        }


public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int Store = 0, maxcount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    Store++;
                }
                else
                {
                    Store = 0;
                }
                maxcount = Math.Max(maxcount, Store);

            }           
            return maxcount;
        }

public static int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;
            //  Array.Sort(nums);
           // Perform cyclic sort
            for (int i = 0; i < n; i++)
            {
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    Swap(nums, i, nums[i] - 1);
                }
            }

            // Find the first missing positive integer
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            // All positive integers from 1 to n are present
            return n + 1;
        }
 public static int KSumWithoutRecurrsion(int[] nums, int k)
        {
            List<int> subsequenceSums = new List<int>() { 0 }; // Include the empty subsequence sum
            foreach (int num in nums)
            {
                List<int> newSums = new List<int>(subsequenceSums); // Copy the current subsequence sums

                foreach (int sum in subsequenceSums)
                {
                    int newSum = sum + num;
                    newSums.Add(newSum);
                }

                subsequenceSums = newSums;
            }
          //  subsequenceSums.RemoveAt(0);
            subsequenceSums.Sort();
            subsequenceSums.Reverse();

            return k <= subsequenceSums.Count ? subsequenceSums[k - 1] : 0;
        }

 public static int FindKthLargest(int[] nums, int k)
        {
            // Quickselect to find the kth largest element
            int left = 0;
            int right = nums.Length - 1;

            while (true)
            {
                int pivotIndex = Partition(nums, left, right);
                int kthLargestIndex = nums.Length - k;

                if (pivotIndex == kthLargestIndex)
                {
                    return nums[pivotIndex];
                }
                else if (pivotIndex < kthLargestIndex)
                {
                    left = pivotIndex + 1;
                }
                else
                {
                    right = pivotIndex - 1;
                }
            }
        }

        private static int Partition(int[] nums, int left, int right)
        {
            // Choosing the rightmost element as the pivot
            int pivot = nums[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (nums[j] <= pivot)
                {
                    swap(nums, i, j);
                    i++;
                }
            }

            swap(nums, i, right);
            return i;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 2)
                return nums.Length;

            int slow = 1;
            for (int fast = 2; fast < nums.Length; fast++)
            {
                if (nums[fast] != nums[slow - 1])
                {
                    slow++;
                    nums[slow] = nums[fast];
                }
            }

            return slow + 1;
        }
        public static int MaxSubArray(int[] nums)
        {
            List<int> lis = new List<int>(nums);
            int start = 0;
            int starting = 0;
            int end = 0;
            int maxendingsum = 0;
            int maxstartingsum = 0;
            int length = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                maxendingsum += nums[i];
                if (maxstartingsum < maxendingsum)
                {
                    maxstartingsum = maxendingsum;
                    starting = start + 1;
                    end = i;

                }
                if (maxendingsum < 0)
                {
                    maxendingsum = 0;
                    start = i;
                }


            }
            return maxstartingsum;



        }
        public static int FirstMissingPositive(int[] nums)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                while (nums[i] > 0 && nums[i] <= nums.Length &&
                 nums[nums[i] - 1] != nums[i])
                {
                    swap(nums, i, nums[i] - 1);
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }
            return 0;

        }
        //public void swapmis(int[] nums, int i, int j)
        //{
        //    int temp = nums[i];
        //    nums[i] = nums[j];
        //    nums[j] = temp;

        //}
        public static void FindIndex(int[] nums)
        {

        }
        public static IList<IList<int>> ThreeSumFunc(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> lis = new List<IList<int>>();
           
            for(int i=0;i<nums.Length-2;i++)
            {
                int start = i;
                int left = i + 1;
                int right = nums.Length - 1;
                while(left < right)
                {
                    List<int> lisdu = new List<int>();
                    int sum = nums[start] + nums[left] + nums[right];
                    int oldleft = 0;
                    if(sum==0)
                    {
                        oldleft = left;
                        lisdu.Add(nums[start]);
                        lisdu.Add(nums[left]);
                        lisdu.Add(nums[right]);                      
                        
                        if(!lis.Contains(lisdu))
                        lis.Add(lisdu);                        
                        left++;
                        right--;                                             
                    }
                    else if(sum<0)
                    {
                        oldleft = left;
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                    while (left < nums.Length - 1 && nums[oldleft] == nums[left])
                        left++;
                }
                while (i < nums.Length-1 && nums[i] == nums[i + 1])
                    i++;

            }        
            return lis;
        }
        public static int FindRightIndex(int[] nums,int target)
        {
            int index = -1;
            int start = 0;
            int end = nums.Length - 1;
            while(start<=end)
            {
                int middleindex = start + (end - start) / 2;
                if(nums[middleindex]<=target)
                {
                    start = middleindex + 1;
                    if(nums[middleindex]==target)
                    {
                        index = middleindex;
                    }

                }
                else
                {
                    end = middleindex - 1; 
                }
            }

            return index;

        }
        public static int FindLeftIndex(int[] nums,int target)
        {
            int index = -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int middleindex = start + (end - start) / 2;
                if (nums[middleindex] >= target)
                {
                    end = middleindex - 1;
                    if (nums[middleindex] == target)
                    {
                        index = middleindex;
                    }
                }
                else
                {
                    start = middleindex + 1;
                }
            }
            return index;
        }
        public static void BinarySearch(int []nums,int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            while(start<=end)
            {
                int middle = start + (end - start) / 2;
                if(nums[middle]==target)
                {
                    Console.WriteLine(middle);
                }
                else if(nums[middle]<target)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }                        
            }
        }

        public static void NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;
            int j = nums.Length - 1;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i > 0)
            {
                while (j > 0 && nums[i] > nums[j])
                {
                    j--;
                }
                swap(nums, i, j);
            }

           
            reverse(nums, i + 1, j);


        }
        public static void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;

        }
        public static void reverse(int[] nums, int i, int j)
        {

            while (i < j)
            {
                swap(nums, i, j);
                i++;
                j--;
            }
        }
        public static void GetLongestLength(int []num)
        {
            List<int> ar = new List<int>(num);
            int no = 0;
            int lengt = 0;
            int count = 0;
            List<int> store = new List<int>();
            for(int i=0;i<num.Length;i++)
            {
                if(!ar.Contains(num[i]-1))
                {
                    no = num[i];
                    count = num[i];
                    while(ar.Contains(no))
                    {
                        
                        no++;
                    }
                    if(lengt<no-num[i])
                    {
                        
                        lengt = no - num[i];                                          
                    }
                }
            }

            List<int> indexesOfLongestSeq = new List<int>();
            for (int i = 0; i < lengt; i++)
            {
                indexesOfLongestSeq.Add(count + i);
            }
            Console.WriteLine(lengt);

        }
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int k = m + n - 1;
            m = m - 1;
            n = n - 1;
            while(m>=0 && n>=0)
            {
                if(nums1[m]>nums2[n])
                {
                    nums1[k] = nums1[m];
                    m--;
                }
                else
                {
                    nums1[k] = nums2[n];
                    n--;
                }
                k--;
            }
            while(n>=0)
            {
                nums1[k] = nums2[n];
                n--;
                k--;
            }


        }
            public static int[] TwoSum(int[] nums, int target)
        {
           // Array.Sort(nums);
            for(int i=0;i<nums.Length-1;i++)
            {
                int start = 0;
                int left = i+1;
                int right = nums.Length - 1;

                while(start<right)
                {
                    int sum = nums[i] + nums[right];
                    if(sum==target)
                    {                       
                        return new int[] { i, right};
                    }
                    else if(sum<target)
                    {
                        start++;
                    }
                    else
                    {
                        right--;
                    }

                }
                while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                    i++;

            }
            return new int[] { 1, 2 };
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int n = nums1.Length  + nums2.Length;
            int[] kmedianarray = new int[n];

            int i = 0, j = 0, k = 0;
            while(i<nums1.Length && j<nums2.Length)
            {
                if(nums1[i]<nums2[j])
                {
                    kmedianarray[k] = nums1[i];
                    k++;
                    i++;
                }
                else
                {
                    kmedianarray[k] = nums2[j];
                    k++;
                    j++;
                }
            }
            while(i<nums1.Length)
            {
                kmedianarray[k] = nums1[i];
                k++;
                i++;
            }
            while (j < nums2.Length)
            {
                kmedianarray[k] = nums2[j];
                k++;
                j++;
            }
            int middle = kmedianarray.Length / 2;
            double med = 0;
            if (middle%2==0)
            {
                 med = (kmedianarray[middle] + kmedianarray[middle - 1]) / 2;
                Console.WriteLine(kmedianarray[Convert.ToInt32(med)]);

            }
            else
            {
                med = kmedianarray[middle];
                Console.WriteLine(kmedianarray[middle]);
            }
            return med;
        }
    }


using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Orders orders = new Orders();
            FoodDeliver foodDeliver = new FoodDeliver(orders);
            AppService appService = new AppService();
            foodDeliver.foodprepare += appService.EmailService;
            foodDeliver.foodprepare += appService.SmsService;
            foodDeliver.preparefood(new Orders() { Name = "xyz" });
            IList<IList<int>> lis = FourSum(new int[] { 2, 2, 2, 2, 2 },0);
            stringsorting("Hello World");
            string inputString = "Hello, how are you?";
            int vowelCount, wordCount, characterCount;

            CountVowelsWordsAndCharacters(inputString, out vowelCount, out wordCount, out characterCount);

            Console.WriteLine("Number of vowels: " + vowelCount);
            Console.WriteLine("Number of words: " + wordCount);
            Console.WriteLine("Number of characters: " + characterCount);
            printcharactercount("The quick brown fox jumps over the lazy dog");
            FirstNonRepeatedString(new string[] { "hello", "world", "hello", "world", "goodbye" });
            countnoofwords("The quick brown");
            EvenLengthWord("The quick brown fox jumps over the lazy dog");
            WellFormed("{}");
            bool getanagrams = CheckStringAnag("care", "race");
            string s = ReverseWords("the sky is blue");
            FindDuplicates(new int[] { 1, 2, 3, 4, 5, 2, 6, 7, 3, 8, 9, 5 });
            FindDuplicate(new int[] { 3, 1, 3, 4, 2 });
            CheckWhileloop(new int[] {1,2,3,4,5, });
            Movezerostoleft();
            FindMaxOccuringintegerOnes(new int[] { 1, 2, 1, 0, 4, 5, 4, 6, 4, 5, 4, 9, 4 });
            FindMaxConsecutiveOnes(new int[] { 1, 1, 0, 1, 1, 1 }) ;

            int[] nums1 = { 3, 4, -1, 1 };
            int missing = FirstMissingPositive(nums1);
            Console.WriteLine(missing);
            int[] nums = { 2, 4, -2 };
            int k = 5;
            int kSum = KSumWithoutRecurrsion(nums, k);
            Console.WriteLine(kSum);
            Console.WriteLine("Hello World!");
        }
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            IList <IList<int>> Lis = new List<IList<int>>();
            for(int i=0;i<nums.Length-3;i++)
            {
                for(int j=i+1;j<nums.Length-2;j++)
                {
                    int left = j;
                    int middle = j + 1;
                    int right = nums.Length - 1;
                  //  int start = j;
                    while(middle < right)
                    {
                        int oldmiddle = 0;
                        int sum = nums[i] + nums[j] + nums[middle] + nums[right];
                        if (sum == target)
                        {
                            oldmiddle = middle;
                            List<int> lisc = new List<int>();
                            lisc.Add(nums[i]);
                            lisc.Add(nums[j]);
                            lisc.Add(nums[middle]);
                            lisc.Add(nums[right]);
                            Lis.Add(lisc);

                            middle++;
                            right--;
                        }
                        else if(sum<target)
                        {
                            middle++;
                        }
                        else
                        {
                            right--;
                        }
                        while (middle < nums.Length - 1 && nums[oldmiddle] == nums[middle])
                            middle++;

                        while (j < nums.Length - 1 && nums[j] == nums[j + 1])
                            j++;

                        while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                            i++;
                    }
                }
              
            }
            return Lis;

        }
        public static void stringsorting(string ar)
        {
            char[] sa = ar.ToCharArray();
            Array.Sort(sa);
            char[] charArray = ar.ToCharArray();

            // Use bubble sort to sort the character array in descending order
            for (int i = 0; i < charArray.Length - 1; i++)
            {
                for (int j = 0; j < charArray.Length-i - 1; j++)
                {
                    if (charArray[j] > charArray[j + 1])
                    {
                   //    Swap characters if the current character is smaller than the next character
                        char temp = charArray[j];
                        charArray[j] = charArray[j + 1];
                        charArray[j + 1] = temp;
                    }
                }
            }
            foreach (var item in charArray)
            {

                Console.Write(item);
            }

        }
        public static bool IsLetter(char c)
        {
            // Custom function to check if a character is a letter (uppercase or lowercase)
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }

        public static void CountVowelsWordsAndCharacters(string input, out int vowelCount, out int wordCount, out int characterCount)
        {
            vowelCount = 0;
            wordCount = 0;
            characterCount = 0;

            // Convert the input string to lowercase for case-insensitive vowel count
            string lowerInput = input.ToLower();

            // Define the set of vowels
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            bool insideWord = false;

            foreach (char c in input)
            {
                // Increment character count
                characterCount++;

                // Check if the character is a letter and not a whitespace
                if (IsLetter(c))
                {
                    // Increment word count if entering a new word
                    if (!insideWord)
                    {
                        wordCount++;
                        insideWord = true;
                    }
                }
                else
                {
                    insideWord = false;
                }

                // Check if the lowercase character is a vowel
                if (Array.IndexOf(vowels, char.ToLower(c)) != -1)
                {
                    vowelCount++;
                }
            }
        }
        public static void printcharactercount(string s)
        {
            string[] spl = s.Split(' ');
            foreach(var items in spl)
            {
                int lengthchar = items.Length;
                Console.WriteLine("Word " + items + "    Length is " + lengthchar);
            }

        }
        public static void FirstNonRepeatedString(string []s)
        {
            Dictionary<string, int> storekey = new Dictionary<string, int>();
            foreach(string items in s)
            {
                if(storekey.ContainsKey(items))
                {
                    storekey[items]++;
                }
                else
                {
                    storekey[items] = 1;
                }
            }

            foreach(var item in s)
            {
                if(storekey[item]==1)
                {
                    Console.WriteLine(item);
                }
            }

        }
        public static void countnoofwords(string s1)
        {
            int count = 0;
            if(s1[0]!=' ')
            {
                count++;
            }
            for(int i=0;i<s1.Length-1;i++)
            {
                if(s1[i]!=' ' && s1[i+1]!=' ' )
                {
                    count++;
                }
            }
            Console.WriteLine(count);
       
        }
        public static bool CheckStringAnag(string str1,string str2)
        {
            char[] arr = str1.ToCharArray();
            char[] arr2 = str2.ToCharArray();
            Array.Sort(arr);
            Array.Sort(arr2);
            for(int i=0;i<arr.Length;i++)
            {
                if(arr[i]!=arr2[i])
                {
                    return false;
                }

            }
            return true;           
        }
        public static bool WellFormed(string s)
        {

            int parnetesiscount = 0;
            int squareparen = 0;
            int curly = 0;
            foreach (var items in s)
            {
                if (items == '(')
                {
                    parnetesiscount++;
                }
                else if (items == ')')
                {
                    parnetesiscount--;
                }
                else if (items == '{')
                {
                    curly++;
                }
                else if (items == '}')
                {
                    curly--;
                }
                else if (items == '[')
                {
                    squareparen++;
                }
                else if (items == ']')
                {
                    squareparen--;
                }
                if (parnetesiscount < 0 || squareparen<0 || curly<0)
                {
                    return false;
                }


            }

            return (parnetesiscount == 0 && squareparen == 0 && curly == 0);
        }
        public static void EvenLengthWord(string s)
        {
            
            string[] spl = s.Split(' ');
            foreach(var items in spl)
            {
                if(items.Length%2==0)
                {
                    Console.WriteLine(items);
                }
            }
        }
        public static string ReverseWords(string s)
        {
            string[] spli = s.Trim().Split(" ");
            string storewords = "";
            for(int i=spli.Length-1;i>=0;i--)
            {
                storewords += spli[i];

                if (i!=0)
                {
                    storewords +=" ";
                }
   
            }
            return storewords.Trim();
            //Console.WriteLine(storewords);

        }
        static void FindDuplicates(int[] arr)
        {
            List<int> se = new List<int>();
           // bool k = se.Add(1);
            HashSet<int> set = new HashSet<int>();
            HashSet<int> duplicates = new HashSet<int>();
            
            foreach (int element in arr)
            {              

                if (!set.Add(element))
                {
                    // If the element already exists in the set, it's a duplicate.
                    // Add it to the duplicates set if it's not already there.
                    if (!duplicates.Contains(element))
                    {
                        duplicates.Add(element);
                        Console.WriteLine(element);
                    }
                }
            }
        }
        public static void CheckWhileloop(int []nums)
        {
            int a = nums[0];
            while (true)
            {
                a = nums[a];
                Console.WriteLine(a);
            }
               

        }
        public static int FindDuplicate(int[] nums)
        {
            // Step 1: Find the intersection point of the two runners (tortoise and hare)
            int tortoise = nums[0];
            int hare = nums[0];

            // The "tortoise" moves one step at a time
            // The "hare" moves two steps at a time
            while (true)
            {
                tortoise = nums[tortoise];
                hare = nums[nums[hare]];

                // If there is a cycle, the two pointers will meet
                if (tortoise == hare)
                {
                    break;
                }
            }

            // Step 2: Find the entrance to the cycle
            int ptr1 = nums[0];
            int ptr2 = tortoise;

            // Move both pointers one step at a time until they meet at the entrance of the cycle
            while (ptr1 != ptr2)
            {
                ptr1 = nums[ptr1];
                ptr2 = nums[ptr2];
            }

            // The entrance to the cycle is the repeated element
            return ptr1;
        }
        public static void Movezerostoleft()
        {
            int[] ar = { 1, 2, 4, 0, 9, 23, 0, 7, 6 };
            int count = ar.Length - 1; // Start from the end of the array

            for (int i = ar.Length - 1; i >= 0; i--)
            {
                if (ar[i] != 0)
                {
                    ar[count] = ar[i];
                    count--;
                }
            }

            while (count >= 0)
            {
                ar[count] = 0;
                count--;
            }

            //int[] ar = {1,2,4,0,9,23,0,7,6 };
            //int count = 0;
            //for(int i=0;i<ar.Length;i++)
            //{
            //    if(ar[i]!=0)
            //    {
            //        ar[count++] = ar[i];
            //    }
            //}

            //while(count<ar.Length)
            //{
            //    ar[count++] = 0;
            //}

        
        
        }

        public static int FindMaxOccuringintegerOnes(int[] nums)
        {
            int getinteger = 0;
            int count = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    getinteger = nums[i];
                }
                if(nums[i]==getinteger)
                {

                    count++;
                }
                else {
                    count--;
}
            }
            return getinteger;
        }
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int Store = 0, maxcount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    Store++;
                }
                else
                {
                    Store = 0;
                }
                maxcount = Math.Max(maxcount, Store);

            }
            //if(maxcount< Store)
            //{
            //    maxcount = Store;
            //}
            return maxcount;
        }

        public static int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;
            //  Array.Sort(nums);
           // Perform cyclic sort
            for (int i = 0; i < n; i++)
            {
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    Swap(nums, i, nums[i] - 1);
                }
            }

            // Find the first missing positive integer
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            // All positive integers from 1 to n are present
            return n + 1;
        }
        private static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        public static int KSum(int[] nums, int k)
        {
            List<int> subsequenceSums = new List<int>();
            GenerateSubsequenceSums(nums, 0, 0, subsequenceSums, 0);

            subsequenceSums.Sort();
            subsequenceSums.Reverse();

            return k <= subsequenceSums.Count ? subsequenceSums[k - 1] : 0;
        }
        public static int KSumWithoutRecurrsion(int[] nums, int k)
        {
            List<int> subsequenceSums = new List<int>() { 0 }; // Include the empty subsequence sum
            foreach (int num in nums)
            {
                List<int> newSums = new List<int>(subsequenceSums); // Copy the current subsequence sums

                foreach (int sum in subsequenceSums)
                {
                    int newSum = sum + num;
                    newSums.Add(newSum);
                }

                subsequenceSums = newSums;
            }
          //  subsequenceSums.RemoveAt(0);
            subsequenceSums.Sort();
            subsequenceSums.Reverse();

            return k <= subsequenceSums.Count ? subsequenceSums[k - 1] : 0;
        }
        private static void GenerateSubsequenceSums(int[] nums, int index, int currentSum, List<int> subsequenceSums,int count)
        {
            
            if (index==nums.Length)
            {
                subsequenceSums.Add(currentSum);
                int count1 = count;
                Console.WriteLine(count1);
                return;
            }
            
            // Include the current element in the subsequence
              GenerateSubsequenceSums(nums, index + 1, currentSum + nums[index], subsequenceSums,1);
            // Exclude the current element from the subsequence
            GenerateSubsequenceSums(nums, index + 1, currentSum, subsequenceSums, 2);
        }


    }
}

 static void FindDuplicates(int[] arr)
        {
            List<int> se = new List<int>();
           // bool k = se.Add(1);
            HashSet<int> set = new HashSet<int>();
            HashSet<int> duplicates = new HashSet<int>();
            
            foreach (int element in arr)
            {              

                if (!set.Add(element))
                {
                    // If the element already exists in the set, it's a duplicate.
                    // Add it to the duplicates set if it's not already there.
                    if (!duplicates.Contains(element))
                    {
                        duplicates.Add(element);
                        Console.WriteLine(element);
                    }
                }
            }
        }

public static void Movezerostoleft()
        {
            int[] ar = { 1, 2, 4, 0, 9, 23, 0, 7, 6 };
            int count = ar.Length - 1; // Start from the end of the array

            for (int i = ar.Length - 1; i >= 0; i--)
            {
                if (ar[i] != 0)
                {
                    ar[count] = ar[i];
                    count--;
                }
            }

            while (count >= 0)
            {
                ar[count] = 0;
                count--;
            }
        
        }

public static int FindMaxOccuringintegerOnes(int[] nums)
        {
            int getinteger = 0;
            int count = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    getinteger = nums[i];
                }
                if(nums[i]==getinteger)
                {

                    count++;
                }
                else {
                    count--;
}
            }
            return getinteger;
        }


public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int Store = 0, maxcount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    Store++;
                }
                else
                {
                    Store = 0;
                }
                maxcount = Math.Max(maxcount, Store);

            }           
            return maxcount;
        }

public static int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;
            //  Array.Sort(nums);
           // Perform cyclic sort
            for (int i = 0; i < n; i++)
            {
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    Swap(nums, i, nums[i] - 1);
                }
            }

            // Find the first missing positive integer
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            // All positive integers from 1 to n are present
            return n + 1;
        }
 public static int KSumWithoutRecurrsion(int[] nums, int k)
        {
            List<int> subsequenceSums = new List<int>() { 0 }; // Include the empty subsequence sum
            foreach (int num in nums)
            {
                List<int> newSums = new List<int>(subsequenceSums); // Copy the current subsequence sums

                foreach (int sum in subsequenceSums)
                {
                    int newSum = sum + num;
                    newSums.Add(newSum);
                }

                subsequenceSums = newSums;
            }
          //  subsequenceSums.RemoveAt(0);
            subsequenceSums.Sort();
            subsequenceSums.Reverse();

            return k <= subsequenceSums.Count ? subsequenceSums[k - 1] : 0;
        }

 public static int FindKthLargest(int[] nums, int k)
        {
            // Quickselect to find the kth largest element
            int left = 0;
            int right = nums.Length - 1;

            while (true)
            {
                int pivotIndex = Partition(nums, left, right);
                int kthLargestIndex = nums.Length - k;

                if (pivotIndex == kthLargestIndex)
                {
                    return nums[pivotIndex];
                }
                else if (pivotIndex < kthLargestIndex)
                {
                    left = pivotIndex + 1;
                }
                else
                {
                    right = pivotIndex - 1;
                }
            }
        }

        private static int Partition(int[] nums, int left, int right)
        {
            // Choosing the rightmost element as the pivot
            int pivot = nums[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (nums[j] <= pivot)
                {
                    swap(nums, i, j);
                    i++;
                }
            }

            swap(nums, i, right);
            return i;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 2)
                return nums.Length;

            int slow = 1;
            for (int fast = 2; fast < nums.Length; fast++)
            {
                if (nums[fast] != nums[slow - 1])
                {
                    slow++;
                    nums[slow] = nums[fast];
                }
            }

            return slow + 1;
        }
        public static int MaxSubArray(int[] nums)
        {
            List<int> lis = new List<int>(nums);
            int start = 0;
            int starting = 0;
            int end = 0;
            int maxendingsum = 0;
            int maxstartingsum = 0;
            int length = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                maxendingsum += nums[i];
                if (maxstartingsum < maxendingsum)
                {
                    maxstartingsum = maxendingsum;
                    starting = start + 1;
                    end = i;

                }
                if (maxendingsum < 0)
                {
                    maxendingsum = 0;
                    start = i;
                }


            }
            return maxstartingsum;



        }
        public static int FirstMissingPositive(int[] nums)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                while (nums[i] > 0 && nums[i] <= nums.Length &&
                 nums[nums[i] - 1] != nums[i])
                {
                    swap(nums, i, nums[i] - 1);
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }
            return 0;

        }
        //public void swapmis(int[] nums, int i, int j)
        //{
        //    int temp = nums[i];
        //    nums[i] = nums[j];
        //    nums[j] = temp;

        //}
        public static void FindIndex(int[] nums)
        {

        }
        public static IList<IList<int>> ThreeSumFunc(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> lis = new List<IList<int>>();
           
            for(int i=0;i<nums.Length-2;i++)
            {
                int start = i;
                int left = i + 1;
                int right = nums.Length - 1;
                while(left < right)
                {
                    List<int> lisdu = new List<int>();
                    int sum = nums[start] + nums[left] + nums[right];
                    int oldleft = 0;
                    if(sum==0)
                    {
                        oldleft = left;
                        lisdu.Add(nums[start]);
                        lisdu.Add(nums[left]);
                        lisdu.Add(nums[right]);                      
                        
                        if(!lis.Contains(lisdu))
                        lis.Add(lisdu);                        
                        left++;
                        right--;                                             
                    }
                    else if(sum<0)
                    {
                        oldleft = left;
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                    while (left < nums.Length - 1 && nums[oldleft] == nums[left])
                        left++;
                }
                while (i < nums.Length-1 && nums[i] == nums[i + 1])
                    i++;

            }        
            return lis;
        }
        public static int FindRightIndex(int[] nums,int target)
        {
            int index = -1;
            int start = 0;
            int end = nums.Length - 1;
            while(start<=end)
            {
                int middleindex = start + (end - start) / 2;
                if(nums[middleindex]<=target)
                {
                    start = middleindex + 1;
                    if(nums[middleindex]==target)
                    {
                        index = middleindex;
                    }

                }
                else
                {
                    end = middleindex - 1; 
                }
            }

            return index;

        }
        public static int FindLeftIndex(int[] nums,int target)
        {
            int index = -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int middleindex = start + (end - start) / 2;
                if (nums[middleindex] >= target)
                {
                    end = middleindex - 1;
                    if (nums[middleindex] == target)
                    {
                        index = middleindex;
                    }
                }
                else
                {
                    start = middleindex + 1;
                }
            }
            return index;
        }
        public static void BinarySearch(int []nums,int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            while(start<=end)
            {
                int middle = start + (end - start) / 2;
                if(nums[middle]==target)
                {
                    Console.WriteLine(middle);
                }
                else if(nums[middle]<target)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }                        
            }
        }

        public static void NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;
            int j = nums.Length - 1;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i > 0)
            {
                while (j > 0 && nums[i] > nums[j])
                {
                    j--;
                }
                swap(nums, i, j);
            }

           
            reverse(nums, i + 1, j);


        }
        public static void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;

        }
        public static void reverse(int[] nums, int i, int j)
        {

            while (i < j)
            {
                swap(nums, i, j);
                i++;
                j--;
            }
        }
        public static void GetLongestLength(int []num)
        {
            List<int> ar = new List<int>(num);
            int no = 0;
            int lengt = 0;
            int count = 0;
            List<int> store = new List<int>();
            for(int i=0;i<num.Length;i++)
            {
                if(!ar.Contains(num[i]-1))
                {
                    no = num[i];
                    count = num[i];
                    while(ar.Contains(no))
                    {
                        
                        no++;
                    }
                    if(lengt<no-num[i])
                    {
                        
                        lengt = no - num[i];                                          
                    }
                }
            }

            List<int> indexesOfLongestSeq = new List<int>();
            for (int i = 0; i < lengt; i++)
            {
                indexesOfLongestSeq.Add(count + i);
            }
            Console.WriteLine(lengt);

        }
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int k = m + n - 1;
            m = m - 1;
            n = n - 1;
            while(m>=0 && n>=0)
            {
                if(nums1[m]>nums2[n])
                {
                    nums1[k] = nums1[m];
                    m--;
                }
                else
                {
                    nums1[k] = nums2[n];
                    n--;
                }
                k--;
            }
            while(n>=0)
            {
                nums1[k] = nums2[n];
                n--;
                k--;
            }


        }
            public static int[] TwoSum(int[] nums, int target)
        {
           // Array.Sort(nums);
            for(int i=0;i<nums.Length-1;i++)
            {
                int start = 0;
                int left = i+1;
                int right = nums.Length - 1;

                while(start<right)
                {
                    int sum = nums[i] + nums[right];
                    if(sum==target)
                    {                       
                        return new int[] { i, right};
                    }
                    else if(sum<target)
                    {
                        start++;
                    }
                    else
                    {
                        right--;
                    }

                }
                while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                    i++;

            }
            return new int[] { 1, 2 };
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int n = nums1.Length  + nums2.Length;
            int[] kmedianarray = new int[n];

            int i = 0, j = 0, k = 0;
            while(i<nums1.Length && j<nums2.Length)
            {
                if(nums1[i]<nums2[j])
                {
                    kmedianarray[k] = nums1[i];
                    k++;
                    i++;
                }
                else
                {
                    kmedianarray[k] = nums2[j];
                    k++;
                    j++;
                }
            }
            while(i<nums1.Length)
            {
                kmedianarray[k] = nums1[i];
                k++;
                i++;
            }
            while (j < nums2.Length)
            {
                kmedianarray[k] = nums2[j];
                k++;
                j++;
            }
            int middle = kmedianarray.Length / 2;
            double med = 0;
            if (middle%2==0)
            {
                 med = (kmedianarray[middle] + kmedianarray[middle - 1]) / 2;
                Console.WriteLine(kmedianarray[Convert.ToInt32(med)]);

            }
            else
            {
                med = kmedianarray[middle];
                Console.WriteLine(kmedianarray[middle]);
            }
            return med;
        }
    }


using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Orders orders = new Orders();
            FoodDeliver foodDeliver = new FoodDeliver(orders);
            AppService appService = new AppService();
            foodDeliver.foodprepare += appService.EmailService;
            foodDeliver.foodprepare += appService.SmsService;
            foodDeliver.preparefood(new Orders() { Name = "xyz" });
            IList<IList<int>> lis = FourSum(new int[] { 2, 2, 2, 2, 2 },0);
            stringsorting("Hello World");
            string inputString = "Hello, how are you?";
            int vowelCount, wordCount, characterCount;

            CountVowelsWordsAndCharacters(inputString, out vowelCount, out wordCount, out characterCount);

            Console.WriteLine("Number of vowels: " + vowelCount);
            Console.WriteLine("Number of words: " + wordCount);
            Console.WriteLine("Number of characters: " + characterCount);
            printcharactercount("The quick brown fox jumps over the lazy dog");
            FirstNonRepeatedString(new string[] { "hello", "world", "hello", "world", "goodbye" });
            countnoofwords("The quick brown");
            EvenLengthWord("The quick brown fox jumps over the lazy dog");
            WellFormed("{}");
            bool getanagrams = CheckStringAnag("care", "race");
            string s = ReverseWords("the sky is blue");
            FindDuplicates(new int[] { 1, 2, 3, 4, 5, 2, 6, 7, 3, 8, 9, 5 });
            FindDuplicate(new int[] { 3, 1, 3, 4, 2 });
            CheckWhileloop(new int[] {1,2,3,4,5, });
            Movezerostoleft();
            FindMaxOccuringintegerOnes(new int[] { 1, 2, 1, 0, 4, 5, 4, 6, 4, 5, 4, 9, 4 });
            FindMaxConsecutiveOnes(new int[] { 1, 1, 0, 1, 1, 1 }) ;

            int[] nums1 = { 3, 4, -1, 1 };
            int missing = FirstMissingPositive(nums1);
            Console.WriteLine(missing);
            int[] nums = { 2, 4, -2 };
            int k = 5;
            int kSum = KSumWithoutRecurrsion(nums, k);
            Console.WriteLine(kSum);
            Console.WriteLine("Hello World!");
        }
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            IList <IList<int>> Lis = new List<IList<int>>();
            for(int i=0;i<nums.Length-3;i++)
            {
                for(int j=i+1;j<nums.Length-2;j++)
                {
                    int left = j;
                    int middle = j + 1;
                    int right = nums.Length - 1;
                  //  int start = j;
                    while(middle < right)
                    {
                        int oldmiddle = 0;
                        int sum = nums[i] + nums[j] + nums[middle] + nums[right];
                        if (sum == target)
                        {
                            oldmiddle = middle;
                            List<int> lisc = new List<int>();
                            lisc.Add(nums[i]);
                            lisc.Add(nums[j]);
                            lisc.Add(nums[middle]);
                            lisc.Add(nums[right]);
                            Lis.Add(lisc);

                            middle++;
                            right--;
                        }
                        else if(sum<target)
                        {
                            middle++;
                        }
                        else
                        {
                            right--;
                        }
                        while (middle < nums.Length - 1 && nums[oldmiddle] == nums[middle])
                            middle++;

                        while (j < nums.Length - 1 && nums[j] == nums[j + 1])
                            j++;

                        while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                            i++;
                    }
                }
              
            }
            return Lis;

        }
        public static void stringsorting(string ar)
        {
            char[] sa = ar.ToCharArray();
            Array.Sort(sa);
            char[] charArray = ar.ToCharArray();

            // Use bubble sort to sort the character array in descending order
            for (int i = 0; i < charArray.Length - 1; i++)
            {
                for (int j = 0; j < charArray.Length-i - 1; j++)
                {
                    if (charArray[j] > charArray[j + 1])
                    {
                   //    Swap characters if the current character is smaller than the next character
                        char temp = charArray[j];
                        charArray[j] = charArray[j + 1];
                        charArray[j + 1] = temp;
                    }
                }
            }
            foreach (var item in charArray)
            {

                Console.Write(item);
            }

        }
        public static bool IsLetter(char c)
        {
            // Custom function to check if a character is a letter (uppercase or lowercase)
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }

        public static void CountVowelsWordsAndCharacters(string input, out int vowelCount, out int wordCount, out int characterCount)
        {
            vowelCount = 0;
            wordCount = 0;
            characterCount = 0;

            // Convert the input string to lowercase for case-insensitive vowel count
            string lowerInput = input.ToLower();

            // Define the set of vowels
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            bool insideWord = false;

            foreach (char c in input)
            {
                // Increment character count
                characterCount++;

                // Check if the character is a letter and not a whitespace
                if (IsLetter(c))
                {
                    // Increment word count if entering a new word
                    if (!insideWord)
                    {
                        wordCount++;
                        insideWord = true;
                    }
                }
                else
                {
                    insideWord = false;
                }

                // Check if the lowercase character is a vowel
                if (Array.IndexOf(vowels, char.ToLower(c)) != -1)
                {
                    vowelCount++;
                }
            }
        }
        public static void printcharactercount(string s)
        {
            string[] spl = s.Split(' ');
            foreach(var items in spl)
            {
                int lengthchar = items.Length;
                Console.WriteLine("Word " + items + "    Length is " + lengthchar);
            }

        }
        public static void FirstNonRepeatedString(string []s)
        {
            Dictionary<string, int> storekey = new Dictionary<string, int>();
            foreach(string items in s)
            {
                if(storekey.ContainsKey(items))
                {
                    storekey[items]++;
                }
                else
                {
                    storekey[items] = 1;
                }
            }

            foreach(var item in s)
            {
                if(storekey[item]==1)
                {
                    Console.WriteLine(item);
                }
            }

        }
        public static void countnoofwords(string s1)
        {
            int count = 0;
            if(s1[0]!=' ')
            {
                count++;
            }
            for(int i=0;i<s1.Length-1;i++)
            {
                if(s1[i]!=' ' && s1[i+1]!=' ' )
                {
                    count++;
                }
            }
            Console.WriteLine(count);
       
        }
        public static bool CheckStringAnag(string str1,string str2)
        {
            char[] arr = str1.ToCharArray();
            char[] arr2 = str2.ToCharArray();
            Array.Sort(arr);
            Array.Sort(arr2);
            for(int i=0;i<arr.Length;i++)
            {
                if(arr[i]!=arr2[i])
                {
                    return false;
                }

            }
            return true;           
        }
        public static bool WellFormed(string s)
        {

            int parnetesiscount = 0;
            int squareparen = 0;
            int curly = 0;
            foreach (var items in s)
            {
                if (items == '(')
                {
                    parnetesiscount++;
                }
                else if (items == ')')
                {
                    parnetesiscount--;
                }
                else if (items == '{')
                {
                    curly++;
                }
                else if (items == '}')
                {
                    curly--;
                }
                else if (items == '[')
                {
                    squareparen++;
                }
                else if (items == ']')
                {
                    squareparen--;
                }
                if (parnetesiscount < 0 || squareparen<0 || curly<0)
                {
                    return false;
                }


            }

            return (parnetesiscount == 0 && squareparen == 0 && curly == 0);
        }
        public static void EvenLengthWord(string s)
        {
            
            string[] spl = s.Split(' ');
            foreach(var items in spl)
            {
                if(items.Length%2==0)
                {
                    Console.WriteLine(items);
                }
            }
        }
        public static string ReverseWords(string s)
        {
            string[] spli = s.Trim().Split(" ");
            string storewords = "";
            for(int i=spli.Length-1;i>=0;i--)
            {
                storewords += spli[i];

                if (i!=0)
                {
                    storewords +=" ";
                }
   
            }
            return storewords.Trim();
            //Console.WriteLine(storewords);

        }
        static void FindDuplicates(int[] arr)
        {
            List<int> se = new List<int>();
           // bool k = se.Add(1);
            HashSet<int> set = new HashSet<int>();
            HashSet<int> duplicates = new HashSet<int>();
            
            foreach (int element in arr)
            {              

                if (!set.Add(element))
                {
                    // If the element already exists in the set, it's a duplicate.
                    // Add it to the duplicates set if it's not already there.
                    if (!duplicates.Contains(element))
                    {
                        duplicates.Add(element);
                        Console.WriteLine(element);
                    }
                }
            }
        }
        public static void CheckWhileloop(int []nums)
        {
            int a = nums[0];
            while (true)
            {
                a = nums[a];
                Console.WriteLine(a);
            }
               

        }
        public static int FindDuplicate(int[] nums)
        {
            // Step 1: Find the intersection point of the two runners (tortoise and hare)
            int tortoise = nums[0];
            int hare = nums[0];

            // The "tortoise" moves one step at a time
            // The "hare" moves two steps at a time
            while (true)
            {
                tortoise = nums[tortoise];
                hare = nums[nums[hare]];

                // If there is a cycle, the two pointers will meet
                if (tortoise == hare)
                {
                    break;
                }
            }

            // Step 2: Find the entrance to the cycle
            int ptr1 = nums[0];
            int ptr2 = tortoise;

            // Move both pointers one step at a time until they meet at the entrance of the cycle
            while (ptr1 != ptr2)
            {
                ptr1 = nums[ptr1];
                ptr2 = nums[ptr2];
            }

            // The entrance to the cycle is the repeated element
            return ptr1;
        }
        public static void Movezerostoleft()
        {
            int[] ar = { 1, 2, 4, 0, 9, 23, 0, 7, 6 };
            int count = ar.Length - 1; // Start from the end of the array

            for (int i = ar.Length - 1; i >= 0; i--)
            {
                if (ar[i] != 0)
                {
                    ar[count] = ar[i];
                    count--;
                }
            }

            while (count >= 0)
            {
                ar[count] = 0;
                count--;
            }

            //int[] ar = {1,2,4,0,9,23,0,7,6 };
            //int count = 0;
            //for(int i=0;i<ar.Length;i++)
            //{
            //    if(ar[i]!=0)
            //    {
            //        ar[count++] = ar[i];
            //    }
            //}

            //while(count<ar.Length)
            //{
            //    ar[count++] = 0;
            //}

        
        
        }

        public static int FindMaxOccuringintegerOnes(int[] nums)
        {
            int getinteger = 0;
            int count = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    getinteger = nums[i];
                }
                if(nums[i]==getinteger)
                {

                    count++;
                }
                else {
                    count--;
}
            }
            return getinteger;
        }
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int Store = 0, maxcount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    Store++;
                }
                else
                {
                    Store = 0;
                }
                maxcount = Math.Max(maxcount, Store);

            }
            //if(maxcount< Store)
            //{
            //    maxcount = Store;
            //}
            return maxcount;
        }

        public static int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;
            //  Array.Sort(nums);
           // Perform cyclic sort
            for (int i = 0; i < n; i++)
            {
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    Swap(nums, i, nums[i] - 1);
                }
            }

            // Find the first missing positive integer
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            // All positive integers from 1 to n are present
            return n + 1;
        }
        private static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        public static int KSum(int[] nums, int k)
        {
            List<int> subsequenceSums = new List<int>();
            GenerateSubsequenceSums(nums, 0, 0, subsequenceSums, 0);

            subsequenceSums.Sort();
            subsequenceSums.Reverse();

            return k <= subsequenceSums.Count ? subsequenceSums[k - 1] : 0;
        }
        public static int KSumWithoutRecurrsion(int[] nums, int k)
        {
            List<int> subsequenceSums = new List<int>() { 0 }; // Include the empty subsequence sum
            foreach (int num in nums)
            {
                List<int> newSums = new List<int>(subsequenceSums); // Copy the current subsequence sums

                foreach (int sum in subsequenceSums)
                {
                    int newSum = sum + num;
                    newSums.Add(newSum);
                }

                subsequenceSums = newSums;
            }
          //  subsequenceSums.RemoveAt(0);
            subsequenceSums.Sort();
            subsequenceSums.Reverse();

            return k <= subsequenceSums.Count ? subsequenceSums[k - 1] : 0;
        }
        private static void GenerateSubsequenceSums(int[] nums, int index, int currentSum, List<int> subsequenceSums,int count)
        {
            
            if (index==nums.Length)
            {
                subsequenceSums.Add(currentSum);
                int count1 = count;
                Console.WriteLine(count1);
                return;
            }
            
            // Include the current element in the subsequence
              GenerateSubsequenceSums(nums, index + 1, currentSum + nums[index], subsequenceSums,1);
            // Exclude the current element from the subsequence
            GenerateSubsequenceSums(nums, index + 1, currentSum, subsequenceSums, 2);
        }


    }
}
