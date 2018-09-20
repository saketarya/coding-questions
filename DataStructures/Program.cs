using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            TestBST();

            ///////// Least coin combination for a number N with goven denominations coins
            int[] coins = new int[] { 4, 6, 7 };
            int numCoins = Arithmatics.StartGetLeastCoinsForANumber(coins, -17);
            numCoins = Arithmatics.StartGetLeastCoinsForANumber(coins, 4);

            //Find Longest pelindrome - O(n^2)
            string rawString = "abfdracecarabaortitabcdef";
            Console.WriteLine(StringMan.FindLongestPelindromeON2(rawString));

            //Find Longest pelindrome - O(n)            
            Console.WriteLine(StringMan.FindLongestPelindromeON(rawString));

            rawString = "abcdcaacden";
            Console.WriteLine(StringMan.FindLongestPelindromeON(rawString));



            ////////// Make BST Out of an array.
            int[] arr = new int[] { 16,4,1,5,21,10,17,};
            Node<int> root = BSTBroker.PrepareBSTFromArray(arr);

            arr = new int[] { 16, 4, 1, 5, 4, 21, 10, 17, };
            root = BSTBroker.PrepareBSTFromArray(arr);


        }

        static void Main1(string[] args)
        {
            string rawString = "abfdracecarabaortitabcdef";
            Console.WriteLine(StringMan.FindLongestPelindromeON2(rawString));

            TestBST();
        }

        private static void TestBST()
        {
            // create new BST (new, insert)
            /*              15
             *        6             18
             *    3       7      17     20   
             *  2   4       13
             *             9
             * */
            BST<int> bst = new BST<int>(new int[] { 2, 3, 4, 6, 7, 9, 13, 15, 17, 18, 20 });

            bst.PrintInOrder();
            // search - for Root, leaf, 

            // find minima

            // find Maxima

            // Print InOrder
            // Print PreOrder
            // Print PostOrder

            // Find successor - root, maximum , N.Parent.Left = NULL, N.Parent.Right = NULL

            // Find predecessor - root , minimum, N.Parent.Left = NULL, N.Parent.Right = NULL

            

        }
    }

    class Program101
    {
        static void Main02(string[] args)
        {
            ReviseStrinRecursions.PrintPalindromes("ababc");
            ReviseStrinRecursions.PrintPalindromes("cdababanp");
            ReviseStrinRecursions.StartPrintParenthesisCombo(3);
            Console.WriteLine(112 << 5);
            ReviseStrinRecursions.StartPhoneCharComibation_Rcrsv(new byte[] { 2,3,5,2 });

            ReviseStrinRecursions.StartPermutation("a");
            ReviseStrinRecursions.StartPermutation("ab");
            ReviseStrinRecursions.StartPermutation("ac");

            ReviseStrinRecursions.StartCombinations("a");
            ReviseStrinRecursions.StartCombinations("ab");
            ReviseStrinRecursions.StartCombinations("abc");

            uint u = 5;
            char[] charr = new char[u];

            charr[u - 2] = (char)97;

            MainNEW(args);

            int[] arr = new int[] { 3,2,5,6};
            int[] brr = new int[4];
            brr = arr;
            Console.WriteLine(brr[3]);
            TestLinkedListOps();

        }

        private static void TestLinkedListOps()
        {
            int z = StringToInt("-4484");
            z = StringToInt("284");
            z = StringToInt("0");

            MyGenLinkedList<int> intList = new MyGenLinkedList<int>(5);
            intList.PrintList(); //5

            //intList.DeleteLast(); // 5
            //intList.PrintList();

            //Console.WriteLine("Nth to last: N= 1, val={0}", (intList.FindNthToLast(1)).ToString());

            //intList.InsertFirst(5); //2,5
            //intList.PrintList();

            intList.InsertFirst(2); //2,5
            intList.PrintList();

            intList.InsertLast(9); //2,5,9
            intList.PrintList();

            intList.InsertAfter(5, 7); //2,5,7,9
            intList.PrintList();

            intList.InsertAfter(5, 17); //2,5,7,9
            intList.PrintList();

            intList.InsertAfter(5, 4); //2,5,7,9
            intList.PrintList();

            intList.InsertAfter(4, 12); //2,5,7,9
            intList.PrintList();

            intList.InsertLast(19); //2,5,9
            intList.PrintList();

            //reverse

            intList.ReverseList();
            intList.PrintList();

            // nth to last
            //Console.WriteLine("Nth to last: N= 0, val={0}", (intList.FindNthToLast(0)).ToString());
            Console.WriteLine("Nth to last: N= 7, val={0}", (intList.FindNthToLast(7)).ToString());
            //Console.WriteLine("Nth to last: N= 9, val={0}", (intList.FindNthToLast(9)).ToString());
            Console.WriteLine("Nth to last: N= 3, val={0}", (intList.FindNthToLast(3)).ToString());
            Console.WriteLine("Nth to last: N= 1, val={0}", (intList.FindNthToLast(1)).ToString());

            intList.CheckAndBreakCycle();
            intList.CreateCycle(4);
            intList.CheckAndBreakCycle();

            //delete nth
            //intList.DeleteNth(3);
            intList.DeleteNthUpdated(4);
            intList.PrintList();

            intList.DeleteFirst(); //5,7,9
            intList.PrintList();

            intList.DeleteWithValue(7); //5,9
            intList.PrintList();

            intList.DeleteLast(); // 5
            intList.PrintList();

            //intList.DeleteLast(); // 5
            //intList.PrintList();
        }

        static void Main01(string[] args)
        {
            MainNEW(args);
            BitArray bitArr = new BitArray(int.MaxValue);

            CallTryCatch();
             //[67108864]

        //    Car[] cars = new Car[2];
        //    cars[0] = new Car("Nissan");
        //    cars[1] = new Car("Toyota");

        //    Swap(cars[0], cars[1]);
            // no change in array.


            BST binaryTree = new BST();
            //binaryTree.CreateTree(4);
            //int[] arr = new int[] { 2, 5, 1, 3, 7, 6, 9 };

            binaryTree.CreateTree(9);
            int[] arr = new int[] { 4, 14, 2, 5, 10, 1, 3, 7, 12, 6, 8, 11, 13 };

            foreach (int x in arr)
            {
                binaryTree.InsertNode(x);
            }

            binaryTree.PrintInorder();

            Console.WriteLine(binaryTree.Add('a', 'b'));
            Console.WriteLine("Now print PreOrder Ittv....");
            Console.WriteLine();
            binaryTree.PrintTree_PreOrder_Ittv(binaryTree.Root);

            binaryTree.PrintTree_InOrder_Ittv(binaryTree.Root);


            Console.WriteLine("Now print PostOrder Ittv....");
            Console.WriteLine();
            binaryTree.PrintTree_PostOrder_Ittv(binaryTree.Root);


            int i = 5;
            Console.WriteLine(i = i << 5);
            Console.WriteLine(i = i << 5);

            bool ss = CheckHasUniqueCharsUsingBitwise("abcdefghij");

            
            IntBuffer buff = new IntBuffer(4);
            Producer p = new Producer(buff);
            Consumer c = new Consumer(buff);

            Thread producer = new Thread(new ThreadStart(p.Run));
            Thread consumer = new Thread(new ThreadStart(c.Run));
            producer.Start();
            consumer.Start();
        }

        private static void CallTryCatch()
        {
            try
            {
                throw new ArgumentException("test arg ex");
            }
            catch (ArgumentException ex)
            {
                throw new Exception("Arg ex", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Swap(Car car1, Car car2)
        {
            Car temp = car1;
            car1 = car2;
            car2 = temp;
        }

        private static bool CheckHasUniqueCharsUsingBitwise(string input)
        {
            int checker = 0;
            int val = 0;
            foreach (char c in input)
            {
                val = c - 'a';
                if ((checker & (1 << val)) > 0 )
                {
                    return false;
                }
                checker = 1 << val;
            }
            return true;
        }

        private static void FindDupWithoutExtraBuffer(string str)
        {
            int all = 0;
            int dup = 0;
            str = str.ToUpper();

            int bitPosition = 0;
            
            foreach (char c in str)
            {
                bitPosition = c - 'A';                
                if ((all & (1 << bitPosition)) > 0)
                {
                    dup = dup | (1 << bitPosition);
                }

                all = all | (1 << bitPosition); 
            }

            // now every bit 1 in dup represents the char which is a duplicate
            // use it as a lookup
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                bitPosition = c - 'A';
                if((dup & (1 << bitPosition)) == 0)
                {
                    sb.Append(c);
                }
            }

            Console.WriteLine(sb.ToString());

        }

        static void MainNEW(string[] args)
        {
            IntBuffer buff = new IntBuffer(8);
            Producer p = new Producer(buff);
            Consumer c = new Consumer(buff);

            Thread producer = new Thread(new ThreadStart(p.Run));
            Thread consumer = new Thread(new ThreadStart(c.Run));
            producer.Start();
            consumer.Start();



            
            string aaa = "aa";
            string bbb = "bb";
            Console.WriteLine("aa={0}, bb={1}", aaa, bbb);
            Permutation.SwapUs<string>(ref aaa, ref bbb);
            Console.WriteLine("aa={0}, bb={1}", aaa, bbb);

            int[] arr = new int[] { 2, 3 };
            Console.WriteLine("arr[0]={0}, arr[1]={1}", arr[0], arr[1]);
            Permutation.SwapUs<int>(ref arr[0], ref arr[1]);
            Console.WriteLine("arr[0]={0}, arr[1]={1}", arr[0], arr[1]);


            // find first non repeating char
            string ss = "IKiNAKAP";
            Console.WriteLine("first distinct char is = '{0}'", FindFirstNonRepeatingChar2(ss));
            ////

            // In place string update.
            ss = "Battle of Vowels: Indiana Jones";
            Console.WriteLine(RemoveSelectedChars(ss, "aeiou"));

            // In place string reversal
            ss = "This is a test string.";
            Console.WriteLine(InPlaceStringReversal(ss));

            // Int to String
            ss = IntToString(284);
            ss = IntToString(-4484);
            ss = IntToString(0);
            ss = IntToString(+23);
            ss = IntToString(+0);
            
            // string to int
            int z = StringToInt("-4484");
            z = StringToInt("284");            
            z = StringToInt("0");

            FindDupWithoutExtraBuffer("HELLO");

            // Permutation n!
            Permutation permutation = new Permutation();
            string inStr = "ABCD";

           // permutation.setper(inStr.ToCharArray());
            permutation.SetPermutation(inStr);

            permutation.SetCombi(inStr);

            

            // phone number combinations
            Console.WriteLine("phone number combinations");
            Console.WriteLine("------------------------------");
            //Console.WriteLine(PhoneNumberChars.GetChar(0, 0));
            //Console.WriteLine(PhoneNumberChars.GetChar(1, 0));
            //Console.WriteLine(PhoneNumberChars.GetChar(0, 1));
            //Console.WriteLine(PhoneNumberChars.GetChar(1, 1));
            //Console.WriteLine(PhoneNumberChars.GetChar(2, 3));
            //Console.WriteLine(PhoneNumberChars.GetChar(9, 1));
            //Console.WriteLine(PhoneNumberChars.GetChar(9, 0));

            permutation.SetPhoneCharConfig(new byte[] { 7,4,2,3});

            
            
            
            string[] xxx = new string[2];
            string[] yyy = new string[3];
            yyy[2] = "hello";
            xxx = yyy;
            Console.WriteLine(xxx[2]);
            ///
            string aa = "barista";
            string bb = "far";
            char[] final = aa.ToCharArray();
            if (bb.Length <= aa.Length)
            {
                Array.Copy(bb.ToCharArray(), 0, final, 0, bb.Length);
            }
            Console.WriteLine(final);
            //
            //int[,] arr = new int[2, 3]; // [col, row]
            //arr[1, 2] = 20;

            Collections();
            string x = null;
            Console.WriteLine("reverse of empty = {0}", ReverseMe(string.Empty));
            Console.WriteLine("reverse of null = {0}", ReverseMe(x));
            x = "seetaphal";
            Console.WriteLine("reverse of x = {0}", ReverseMe(x));

            x = "this is seetaphal";
            Console.WriteLine("reverse of x = {0}", ReverseMe(x));
            Console.Read();
            
            MySingleLLNode head = MySingleLinkedList.CreateList(2);

            MySingleLinkedList.AddLast(head, 5);
            head = MySingleLinkedList.AddFirst(head, 1);
            head = MySingleLinkedList.AddAscOrder(head, 3);
            head = MySingleLinkedList.AddAscOrder(head, 7);
            head = MySingleLinkedList.AddAscOrder(head, 1);
            head = MySingleLinkedList.AddAscOrder(head, 6);
            head = MySingleLinkedList.AddAscOrder(head, 4);
            
            MySingleLinkedList.PrintList(head);

            MySingleLinkedList.DeleteMe(ref head, 1); //delete First
            MySingleLinkedList.PrintList(head);
            MySingleLinkedList.DeleteMe(ref head, 7); //delete last
            MySingleLinkedList.PrintList(head);
            MySingleLinkedList.DeleteMe(ref head, 59); //delete Non existent
            MySingleLinkedList.PrintList(head);
            MySingleLinkedList.DeleteMe(ref head, 5); //delete 5
            MySingleLinkedList.PrintList(head);
            //MySingleLinkedList.DeleteMe(null, 1); //delete from Null

            MySingleLinkedList.PrintList(head);

            Console.Read();
        }

        public static string ReverseMe(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            return new string(Enumerable.Range(1, input.Length).Select(i => input[input.Length - i]).ToArray());
            //char[] outArr = input.ToCharArray();
            //Array.Reverse(outArr);            
            //return new String(outArr);
        }

        public static void Collections()
        {
            Hashtable ht = new Hashtable();
            ht.Add(1, "one");
            ht.Add(2, "two");
            ht.Add(3, "three");

            foreach (object o in ht.Keys)
            {
                Console.WriteLine(ht[o]);
            }


            Dictionary<int, string> dir = new Dictionary<int, string>();
            dir.Add(1, "one");
            dir.Add(1, "one");

            
        }

        public static char FindFirstNonRepeatingChar(string src)
        {
            
            if(string.IsNullOrWhiteSpace(src))
                throw new ArgumentException("blank input string");
            src = src.ToLower();
            Hashtable ht = new Hashtable();
            int val,k = 0;
            foreach (char c in src)
            {
                k = (int)c;
                val = ht[k] == null ? 0 : ((int)ht[k]) + 1;
                ht[k] = val;
            }

            // Search element with value 0 - IN ORDER OF CHARS IN GIVEN STRING
            //foreach (object o in ht.Keys) - would break the original order of chars
            foreach (char c in src)
            {
                k = (int)c;
                if ((int)ht[k] == 0)
                {
                    return c;
                }
            }

            return '0';
        }

        public static char FindFirstNonRepeatingChar2(string insrc)
        {
            string src = insrc.ToLower();
            if (string.IsNullOrWhiteSpace(src))
                throw new ArgumentException("blank input string");
            
            Object seenOnce = new Object();
            Object seenMore = new Object();
            Hashtable ht = new Hashtable();
            
            foreach (char c in src)
            {
                ht[c] = ht[c] == null ? seenOnce : seenMore;
            }

            // Search element with value 0 - IN ORDER OF CHARS IN GIVEN STRING
            //foreach (object o in ht.Keys) - would break the original order of chars
            for(int i=0; i < src.Length; i++)
            {
                if (ht[src[i]].Equals(seenOnce))
                {
                    return insrc[i];
                }
            }

            return '0';
        }

        public static string RemoveSelectedChars(string srcString, string removeStr)
        {   
            // Set a look up array (of chars) to false
            bool[] lookup = new bool[128];

            // For all chars in removeStr, set the flag to true
            foreach (char c in removeStr)
            {   
                lookup[c] = true;
                if (c > 64 && c < 91) // capital
                {
                    lookup[c+32] = true;
                }
                else if (c > 96 && c < 122)
                {
                    lookup[c-32] = true;
                }
            }
            
            char[] arr = srcString.ToArray();
            int D = 0;
            // Go thru sourceStr. Copy each chr C (arr[S]) to arr[D] if its flag is false in the look array
            for (int S = 0; S < arr.Length; S++)
            {
                if(!lookup[arr[S]])
                {
                    arr[D] = arr[S];
                    D++;
                }
            }

            if (D == 0)
                return string.Empty;
            else
                return new string(arr).Substring(0, D);

        }

        public static string InPlaceStringReversal(string inStr)
        {
            int len = inStr.Length;
            // reverse the string InPlace
            Reverse(ref inStr, 0, len - 1);

            int start, end = 0;
            // starting from first index (which was actually END), 
            //While end < length of string
            while (end < len)
            {
                //  if(str[end] != " "
                if (inStr[end] != ' ')
                {
                    start = end;
                    //      while end < length and str[end] != " " //Find the index of next " ".
                    //          end++;
                    //      end--; // Go back 1 index. This is start of the current word
                    while (end < len && inStr[end] != ' ')
                    {
                        end++;
                    }
                    end--;

                    // Reverse this substring in the string InPlace.
                    Reverse(ref inStr, start, end);
                }
                end++;
            }
            
            return inStr;
        }

        public static void Reverse(ref string inStr, int start, int end)
        {
            StringBuilder sb = new StringBuilder(inStr);
            
            Reverse(sb, start, end);
            inStr = sb.ToString();
        }

        public static void Reverse(StringBuilder arr, int start, int end)
        {
            char temp;
            //char[] arr = inStr.ToArray();
            //Array.Reverse(arr);
            while (start < end)
            {
                temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }

            //inStr = new string(arr);
        }
        //public static void Reverse(char[] inStr, int start, int end)
        //{
        //    char temp;
        //    char[] arr = inStr.ToArray();
        //    //Array.Reverse(arr);
        //    while (start < end)
        //    {
        //        temp = arr[start];
        //        arr[start] = arr[end];
        //        arr[end] = temp;
        //        start++;
        //        end--;
        //    }

        //    inStr = new string(arr);
        //}

        public static string IntToString(int num)
        {
            bool isNegative = false;
            if (num < 0)
            {
                isNegative = true;
                num *= -1;
            }

            StringBuilder sb = new StringBuilder();
            char tempChar;
            do
            {
                tempChar = (char)(num % 10 + '0');
                sb.Append(tempChar);
                // append char;
                //num = num /10;
                num /= 10;
                // if(num == 0)
                //  break;
            } while (num > 0);

            if (isNegative)
            {
                // we need to put '-' as the first element in array
                // append '-';
                sb.Append('-');
            }
            int len = sb.Length;

            Reverse(sb, 0, len - 1);
            //char temp;
            //for (int start = 0, end=len-1; start < end; start++,end--)
            //{
            //    temp = sb[start];
            //    sb[start] = sb[end];
            //    sb[end] = temp;
            //}

            return sb.ToString();
        }

        public static int StringToInt(string input)
        {
            int i = 0;
            int num = 0;
            bool isNegative = false;
            if (input[0] == '-')
            {
                i++;
                isNegative = true;
            }

            int tempChar;
            for (; i < input.Length; i++)
            {
                // read char at [i]
                tempChar = input[i] - '0';
                
                // multiply the num by 10 and add (char - '0')
                num = num * 10 + tempChar;
            }

            return ( isNegative ? num * -1 : num);

        }
    }
}
