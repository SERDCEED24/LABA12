using CarsLibrary;
using _12_2;
namespace Test_12_2
{
    [TestClass]
    public class UnitTest1
    {
        private MyHashTable<Car> CreateHashTableWithCars(int count)
        {
            MyHashTable<Car> hashTable = new MyHashTable<Car>(count);
            for (int i = 0; i < count; i++)
            {
                Car car = new Car();
                car.RandomInit();
                hashTable.AddItem(car);
            }
            return hashTable;
        }

        [TestMethod]
        public void TestAddItem()
        {
            // Arrange
            MyHashTable<Car> hashTable = new MyHashTable<Car>(10);
            Car car = new Car();
            car.RandomInit();

            // Act
            hashTable.AddItem(car);

            // Assert
            Assert.AreEqual(1, hashTable.Count);
            Assert.IsTrue(hashTable.Contains(car));
        }

        [TestMethod]
        public void TestRemoveData()
        {
            // Arrange
            MyHashTable<Car> hashTable = CreateHashTableWithCars(10);
            Car carToRemove = new Car();
            carToRemove.RandomInit();
            hashTable.AddItem(carToRemove);

            // Act
            bool removed = hashTable.RemoveData(carToRemove);

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(10, hashTable.Count); 
            Assert.IsFalse(hashTable.Contains(carToRemove));
        }

        [TestMethod]
        public void TestContains()
        {
            // Arrange
            MyHashTable<Car> hashTable = CreateHashTableWithCars(10);
            Car car = new Car();
            car.RandomInit();
            hashTable.AddItem(car);

            // Act & Assert
            Assert.IsTrue(hashTable.Contains(car));
        }

        [TestMethod]
        public void TestFindItem()
        {
            // Arrange
            MyHashTable<Car> hashTable = new MyHashTable<Car>(10);
            Car car = new Car();
            car.RandomInit();
            hashTable.AddItem(car);

            // Act
            int index = hashTable.FindItem(car);

            // Assert
            Assert.IsTrue(index >= 0);
            Assert.AreEqual(car, hashTable.Table[index]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddItemTableFull()
        {
            // Arrange
            MyHashTable<Car> hashTable = new MyHashTable<Car>(1);
            Car car1 = new Car();
            car1.RandomInit();
            Car car2 = new Car();
            car2.RandomInit();
            hashTable.AddData(car1);

            // Act
            hashTable.AddData(car2); 
        }

        [TestMethod]
        public void TestAddItemWithResize()
        {
            // Arrange
            MyHashTable<Car> hashTable = new MyHashTable<Car>(1, 0.5);
            Car car1 = new Car();
            car1.RandomInit();
            Car car2 = new Car();
            car2.RandomInit();

            // Act
            hashTable.AddItem(car1);
            hashTable.AddItem(car2);

            // Assert
            Assert.AreEqual(2, hashTable.Count);
            Assert.IsTrue(hashTable.Contains(car1));
            Assert.IsTrue(hashTable.Contains(car2));
        }

        [TestMethod]
        public void TestPrint()
        {
            // Arrange
            MyHashTable<Car> hashTable = new MyHashTable<Car>(2);
            Car car1 = new Car();
            car1.RandomInit();
            Car car2 = new Car();
            car2.RandomInit();
            hashTable.AddItem(car1);
            hashTable.AddItem(car2);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                hashTable.Print();
                var result = sw.ToString();

                // Assert
                Assert.IsTrue(result.Contains(car1.ToString()));
                Assert.IsTrue(result.Contains(car2.ToString()));
            }
        }
    }
}