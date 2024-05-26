using CarsLibrary;
using _12_1;
namespace Test_12_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class MyListTests
        {
            [TestMethod]
            public void TestAddToBegin()
            {
                // Arrange
                MyList<Car> list = new MyList<Car>();
                Car car1 = new Car();
                car1.RandomInit();
                Car car2 = new Car();
                car2.RandomInit();

                // Act
                list.AddToBegin(car1);
                list.AddToBegin(car2);

                // Assert
                Assert.AreEqual(2, list.Count);
                Assert.AreEqual(car2, list.GetBeg().Data);
            }

            [TestMethod]
            public void TestAddToEnd()
            {
                // Arrange
                MyList<Car> list = new MyList<Car>();
                Car car1 = new Car();
                car1.RandomInit();
                Car car2 = new Car();
                car2.RandomInit();

                // Act
                list.AddToEnd(car1);
                list.AddToEnd(car2);

                // Assert
                Assert.AreEqual(2, list.Count);
                Assert.AreEqual(car1, list.GetBeg().Data);
                Assert.AreEqual(car2, list.GetBeg().Next.Data);
            }

            [TestMethod]
            public void TestRemoveItem()
            {
                // Arrange
                MyList<Car> list = new MyList<Car>();
                Car car1 = new Car();
                car1.RandomInit();
                Car car2 = new Car();
                car2.RandomInit();
                list.AddToEnd(car1);
                list.AddToEnd(car2);

                // Act
                bool removed = list.RemoveItem(car1);

                // Assert
                Assert.IsTrue(removed);
                Assert.AreEqual(1, list.Count);
                Assert.AreEqual(car2, list.GetBeg().Data);
            }

            [TestMethod]
            public void TestRemoveItem_SingleElement()
            {
                // Arrange
                MyList<Car> list = new MyList<Car>();
                Car car1 = new Car();
                car1.RandomInit();
                list.AddToEnd(car1);

                // Act
                bool removed = list.RemoveItem(car1);

                // Assert
                Assert.IsTrue(removed);
                Assert.AreEqual(0, list.Count);
                Assert.IsNull(list.GetBeg());
            }

            [TestMethod]
            public void TestRemoveItem_LastElement()
            {
                // Arrange
                MyList<Car> list = new MyList<Car>();
                Car car1 = new Car();
                car1.RandomInit();
                Car car2 = new Car();
                car2.RandomInit();
                list.AddToEnd(car1);
                list.AddToEnd(car2);

                // Act
                bool removed = list.RemoveItem(car2);

                // Assert
                Assert.IsTrue(removed);
                Assert.AreEqual(1, list.Count);
                Assert.AreEqual(car1, list.GetBeg().Data);
                Assert.IsNull(list.GetBeg().Next);
            }

            [TestMethod]
            public void TestRemoveItem_MiddleElement()
            {
                // Arrange
                MyList<Car> list = new MyList<Car>();
                Car car1 = new Car();
                car1.RandomInit();
                Car car2 = new Car();
                car2.RandomInit();
                Car car3 = new Car();
                car3.RandomInit();
                list.AddToEnd(car1);
                list.AddToEnd(car2);
                list.AddToEnd(car3);

                // Act
                bool removed = list.RemoveItem(car2);

                // Assert
                Assert.IsTrue(removed);
                Assert.AreEqual(2, list.Count);
                Assert.AreEqual(car1, list.GetBeg().Data);
                Assert.AreEqual(car3, list.GetBeg().Next.Data);
            }

            [TestMethod]
            public void TestRemoveItem_NotFound()
            {
                // Arrange
                MyList<Car> list = new MyList<Car>();
                Car car1 = new Car();
                car1.RandomInit();
                Car car2 = new Car();
                car2.RandomInit();
                Car car3 = new Car();
                car3.RandomInit();
                list.AddToEnd(car1);
                list.AddToEnd(car2);

                // Act
                bool removed = list.RemoveItem(car3);

                // Assert
                Assert.IsFalse(removed);
                Assert.AreEqual(2, list.Count);
            }

            [TestMethod]
            public void TestClear()
            {
                // Arrange
                MyList<Car> list = new MyList<Car>();
                Car car = new Car();
                car.RandomInit();
                list.AddToEnd(car);

                // Act
                list.Clear();

                // Assert
                Assert.AreEqual(0, list.Count);
                Assert.IsNull(list.GetBeg());
            }

            [TestMethod]
            public void TestClone()
            {
                // Arrange
                MyList<Car> list = new MyList<Car>();
                Car car1 = new Car();
                car1.RandomInit();
                Car car2 = new Car();
                car2.RandomInit();
                list.AddToEnd(car1);
                list.AddToEnd(car2);

                // Act
                MyList<Car> clonedList = list.Clone();

                // Assert
                Assert.AreEqual(list.Count, clonedList.Count);
                Assert.AreNotSame(list.GetBeg().Data, clonedList.GetBeg().Data); // Ensure deep copy
                Assert.AreEqual(list.GetBeg().Data, clonedList.GetBeg().Data);   // Ensure data equality
                Assert.AreNotSame(list.GetBeg().Next.Data, clonedList.GetBeg().Next.Data); // Ensure deep copy for next item
                Assert.AreEqual(list.GetBeg().Next.Data, clonedList.GetBeg().Next.Data);   // Ensure data equality for next item
            }

            [TestMethod]
            public void TestClone_EmptyList()
            {
                // Arrange
                MyList<Car> list = new MyList<Car>();

                // Act
                MyList<Car> clonedList = list.Clone();

                // Assert
                Assert.AreEqual(list.Count, clonedList.Count);
                Assert.IsNull(clonedList.GetBeg());
            }

            [TestMethod]
            public void TestFindItem()
            {
                // Arrange
                MyList<Car> list = new MyList<Car>();
                Car car1 = new Car();
                car1.RandomInit();
                Car car2 = new Car();
                car2.RandomInit();
                list.AddToEnd(car1);
                list.AddToEnd(car2);

                // Act
                var foundItem = list.FindItem(car1);

                // Assert
                Assert.IsNotNull(foundItem);
                Assert.AreEqual(car1, foundItem.Data);
            }

            [TestMethod]
            public void TestFindItem_NotFound()
            {
                // Arrange
                MyList<Car> list = new MyList<Car>();
                Car car1 = new Car();
                car1.RandomInit();
                Car car2 = new Car();
                car2.RandomInit();
                Car car3 = new Car();
                car3.RandomInit();
                list.AddToEnd(car1);
                list.AddToEnd(car2);

                // Act
                var foundItem = list.FindItem(car3);

                // Assert
                Assert.IsNull(foundItem);
            }

            [TestMethod]
            public void TestConstructorWithSize()
            {
                // Arrange
                int size = 5;

                // Act
                MyList<Car> list = new MyList<Car>(size);

                // Assert
                Assert.AreEqual(size, list.Count);
            }

            [TestMethod]
            public void TestConstructorWithCollection()
            {
                // Arrange
                Car[] cars = new Car[3];
                for (int i = 0; i < cars.Length; i++)
                {
                    cars[i] = new Car();
                    cars[i].RandomInit();
                }

                // Act
                MyList<Car> list = new MyList<Car>(cars);

                // Assert
                Assert.AreEqual(cars.Length, list.Count);
                for (int i = 0; i < cars.Length; i++)
                {
                    Assert.AreEqual(cars[i], list.GetBeg().Data); // Assumes list.AddToEnd appends to end, maintaining order
                    list.RemoveItem(cars[i]); // Remove to check the next item
                }
            }
            [TestMethod]
            public void TestConstructorWithData()
            {
                // Arrange
                int expected = 10;

                // Act
                Point<int> point = new Point<int>(expected);

                // Assert
                Assert.AreEqual(expected, point.Data);
                Assert.IsNull(point.Next);
                Assert.IsNull(point.Prev);
            }

            [TestMethod]
            public void TestConstructorWithoutData()
            {
                // Arrange & Act
                Point<int> point = new Point<int>();

                // Assert
                Assert.AreEqual(default(int), point.Data);
                Assert.IsNull(point.Next);
                Assert.IsNull(point.Prev);
            }

            [TestMethod]
            public void TestToStringWithData()
            {
                // Arrange
                string expected = "Test";

                // Act
                Point<string> point = new Point<string>(expected);

                // Assert
                Assert.AreEqual(expected, point.ToString());
            }

            [TestMethod]
            public void TestToStringWithoutData()
            {
                // Arrange & Act
                Point<int> point = new Point<int>();

                // Assert
                Assert.AreEqual("0", point.ToString());
            }

            [TestMethod]
            public void TestGetHashCodeWithData()
            {
                // Arrange
                int expected = 10;

                // Act
                Point<int> point = new Point<int>(expected);

                // Assert
                Assert.AreEqual(expected.GetHashCode(), point.GetHashCode());
            }

            [TestMethod]
            public void TestGetHashCodeWithoutData()
            {
                // Arrange & Act
                Point<int> point = new Point<int>();

                // Assert
                Assert.AreEqual(default(int).GetHashCode(), point.GetHashCode());
            }
        }
    }
}