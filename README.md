- 👋 Hi, I’m @asadgul12
- 👀 I’m interested in ...
- 🌱 I’m currently learning ...
- 💞️ I’m looking to collaborate on ...
- 📫 How to reach me ...

<!---
asadgul12/asadgul12 is a ✨ special ✨ repository because its `RE static void FindDuplicates(int[] arr)
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
    }ADME.md` (this file) appears on your GitHub profile.
You can click the Preview link to take a look at your changes.
--->
