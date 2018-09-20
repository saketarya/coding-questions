using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDataStructures
{
    [TestClass]
    public class TreeUtilsTests
    {
        public static TreeNode<int> tree = null;

        [TestInitialize]
        public void Init()
        {
            tree = new TreeNode<int>(314);
            tree.Left = new TreeNode<int>(6) {
                Left = new TreeNode<int>(271) { Left = new TreeNode<int>(28), Right = new TreeNode<int>(0) },
                Right = new TreeNode<int>(561) { Right = new TreeNode<int>(3) { Left = new TreeNode<int>(17) } }
            };

            tree.Right = new TreeNode<int>(6) {
                Left = new TreeNode<int>(2) {
                    Right = new TreeNode<int>(1)
                    {
                        Left = new TreeNode<int>(401) { Right = new TreeNode<int>(641)},
                        Right = new TreeNode<int>(268)
                    }
                },
                Right = new TreeNode<int>(271) {
                    Right = new TreeNode<int>(28)
                }
            };
        }
        [TestCleanup]
        public void Cleanup()
        {
            CleanupRecursive(tree);
        }
        
        private void CleanupRecursive(TreeNode<int> n)
        {
            if (n == null)
                return;

            CleanupRecursive(n.Left);
            CleanupRecursive(n.Right);
            n = null;
        }

        [TestMethod]
        public void TestRootToLeafAllPathForSum()
        {
            BinaryTreeUtils utils = new BinaryTreeUtils();
            var results = utils.PrintAllRootToLeafPathWithGivenSum(tree, 619);
            Assert.IsTrue(results.Count == 2);
            Assert.IsTrue(string.Join(",", results[0]).Equals("314,6,271,28"));
            Assert.IsTrue(string.Join(",", results[1]).Equals("314,6,271,28"));

            results = utils.PrintAllRootToLeafPathWithGivenSum(tree, 591);
            Assert.IsTrue(results.Count == 2);
            Assert.IsTrue(string.Join(",", results[0]).Equals("314,6,271,0"));
            Assert.IsTrue(string.Join(",", results[1]).Equals("314,6,2,1,268"));
        }

        [TestMethod]
        public void TesTBitwiseShift()
        {
            var a = 0xff;
            var b = 0xffff;
            int i = -2;
            int j = 2;
            j = ~j + 1;
            Assert.IsTrue(j == -2);
            Assert.IsTrue(~(-2)+1 == 1);
            i = (i >> 1) & 0xff;
            Assert.IsTrue(i == 1);
        }

        [TestMethod]
        public void TestTwosComplement()
        {
            Assert.IsTrue(~13 + 1 == -13);
            Assert.IsTrue(~(-2) + 1 == 2);

            int i = 37;
            Assert.IsTrue(~(~i+1)+1 == i);
        }

    }
}
