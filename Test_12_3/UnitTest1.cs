using CarsLibrary;
using _12_3;
namespace Test_12_3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Arrange & Act
            MyTree<Car> tree = new MyTree<Car>(10);

            // Assert
            Assert.AreEqual(10, tree.Count);
            Assert.IsNotNull(tree.Root);
        }

        [TestMethod]
        public void TestAddPoint()
        {
            // Arrange
            MyTree<Car> tree = new MyTree<Car>(1);
            Car car = new Car();
            car.RandomInit();

            // Act
            tree.AddPoint(car);

            // Assert
            Assert.AreEqual(2, tree.Count);
            if (tree.Root.Left != null)
            {
                Assert.AreEqual(car, tree.Root.Left.Data);
            }
            if (tree.Root.Right != null)
            {
                Assert.AreEqual(car, tree.Root.Right.Data);
            }
        }

        [TestMethod]
        public void TestTransformToSearchTree()
        {
            // Arrange
            MyTree<Car> tree = new MyTree<Car>(10);

            // Act
            tree.TransformToSearchTree();

            // Assert
            Assert.AreEqual(10, tree.Count);
        }

        [TestMethod]
        public void TestNumberOfLeaves()
        {
            // Arrange
            MyTree<Car> tree = new MyTree<Car>(10);

            // Act
            int numberOfLeaves = tree.NumberOfLeaves();

            // Assert
            Assert.IsTrue(numberOfLeaves > 0);
        }

        [TestMethod]
        public void TestClone()
        {
            // Arrange
            MyTree<Car> tree = new MyTree<Car>(10);

            // Act
            MyTree<Car> clonedTree = tree.Clone();

            // Assert
            Assert.AreEqual(tree.Count, clonedTree.Count);
            Assert.IsNotNull(clonedTree.Root);
        }

        [TestMethod]
        public void TestClear()
        {
            // Arrange
            MyTree<Car> tree = new MyTree<Car>(10);

            // Act
            tree.Clear();

            // Assert
            Assert.AreEqual(0, tree.Count);
            Assert.IsNull(tree.Root);
        }

        [TestMethod]
        public void TestRemoveRoot()
        {
            // Arrange
            MyTree<Car> tree = new MyTree<Car>(1);

            // Act
            bool removed = tree.Remove(tree.Root.Data);

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(0, tree.Count);
            Assert.IsNull(tree.Root);
        }

        [TestMethod]
        public void TestRemoveLeaf()
        {
            // Arrange
            MyTree<Car> tree = new MyTree<Car>(1);
            Car car1 = new Car();
            car1.RandomInit();
            Car car2 = new Car();
            car2.RandomInit();
            tree.AddPoint(car1);
            tree.AddPoint(car2);
            tree.TransformToSearchTree();

            // Act
            bool removed = tree.Remove(car2);

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(2, tree.Count);
            Assert.IsNotNull(tree.Root);
        }

        [TestMethod]
        public void TestRemoveNodeWithOneChild()
        {
            // Arrange
            MyTree<Car> tree = new MyTree<Car>(1);
            Car car1 = new Car();
            car1.RandomInit();
            Car car2 = new Car();
            car2.RandomInit();
            Car car3 = new Car();
            car3.RandomInit();
            tree.AddPoint(car1);
            tree.AddPoint(car2);
            tree.AddPoint(car3);
            tree.TransformToSearchTree();

            // Act
            bool removed = tree.Remove(car2);

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(3, tree.Count);
        }

        [TestMethod]
        public void TestRemoveNodeWithTwoChildren()
        {
            // Arrange
            MyTree<Car> tree = new MyTree<Car>(1);
            Car car1 = new Car();
            car1.RandomInit();
            Car car2 = new Car();
            car2.RandomInit();
            Car car3 = new Car();
            car3.RandomInit();
            Car car4 = new Car();
            car4.RandomInit();
            Car car5 = new Car();
            car5.RandomInit();
            tree.AddPoint(car1);
            tree.AddPoint(car2);
            tree.AddPoint(car3);
            tree.AddPoint(car4);
            tree.AddPoint(car5);

            // Act
            bool removed = tree.Remove(car3);

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(5, tree.Count);
        }



        [TestMethod]
        public void TestRemoveNonExisting()
        {
            // Arrange
            MyTree<Car> tree = new MyTree<Car>(10);
            Car car = new Car();
            car.RandomInit();

            // Act
            bool removed = tree.Remove(car);

            // Assert
            Assert.IsFalse(removed);
            Assert.AreEqual(10, tree.Count);
        }


        [TestMethod]
        public void TestNumberOfLeavesInBranches()
        {
            // Arrange
            MyTree<Car> tree = new MyTree<Car>(10);
            int leavesCount = 0;

            // Act
            tree.NumberOfLeavesInBranches(tree.Root, ref leavesCount);

            // Assert
            Assert.IsTrue(leavesCount > 0);
        }

        [TestMethod]
        public void TestShowTree()
        {
            // Arrange
            MyTree<Car> tree = new MyTree<Car>(10);

            // Act & Assert
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                tree.ShowTree();
                var result = sw.ToString();
                Assert.IsFalse(string.IsNullOrEmpty(result));
            }
        }
        [TestMethod]
        public void TestPointDefaultConstructor()
        {
            // Arrange & Act
            Point<int> point = new Point<int>();

            // Assert
            Assert.AreEqual(0, point.Data);
            Assert.IsNull(point.Left);
            Assert.IsNull(point.Right);
        }

        [TestMethod]
        public void TestPointParameterizedConstructor()
        {
            // Arrange
            int expectedData = 5;

            // Act
            Point<int> point = new Point<int>(expectedData);

            // Assert
            Assert.AreEqual(expectedData, point.Data);
            Assert.IsNull(point.Left);
            Assert.IsNull(point.Right);
        }

        [TestMethod]
        public void TestPointToString()
        {
            // Arrange
            int data = 5;
            Point<int> point = new Point<int>(data);

            // Act
            string result = point.ToString();

            // Assert
            Assert.AreEqual(data.ToString(), result);
        }

        [TestMethod]
        public void TestPointCompareTo_SameData()
        {
            // Arrange
            int data = 5;
            Point<int> point1 = new Point<int>(data);
            Point<int> point2 = new Point<int>(data);

            // Act
            int result = point1.CompareTo(point2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestPointCompareTo_LessThan()
        {
            // Arrange
            Point<int> point1 = new Point<int>(3);
            Point<int> point2 = new Point<int>(5);

            // Act
            int result = point1.CompareTo(point2);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestPointCompareTo_GreaterThan()
        {
            // Arrange
            Point<int> point1 = new Point<int>(7);
            Point<int> point2 = new Point<int>(5);

            // Act
            int result = point1.CompareTo(point2);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestPointProperties()
        {
            // Arrange
            Point<int> leftChild = new Point<int>(2);
            Point<int> rightChild = new Point<int>(3);
            Point<int> parent = new Point<int>(1);

            // Act
            parent.Left = leftChild;
            parent.Right = rightChild;

            // Assert
            Assert.AreEqual(leftChild, parent.Left);
            Assert.AreEqual(rightChild, parent.Right);
        }
    }
}