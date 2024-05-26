using CarsLibrary;
using _12_4;

namespace Test_12_4
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
        [TestMethod]
        public void TestAddMyCollection()
        {
            // Arrange
            MyCollection<Car> collection = new MyCollection<Car>();
            Car car = new Car();
            car.RandomInit();

            // Act
            collection.Add(car);

            // Assert
            Assert.AreEqual(1, collection.Count);
            Assert.IsTrue(collection.Contains(car));
        }

        [TestMethod]
        public void TestClearMyCollection()
        {
            // Arrange
            MyCollection<Car> collection = new MyCollection<Car>(5);

            // Act
            collection.Clear();

            // Assert
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void TestContainsMyCollection()
        {
            // Arrange
            MyCollection<Car> collection = new MyCollection<Car>();
            Car car = new Car();
            car.RandomInit();
            collection.Add(car);

            // Act
            bool contains = collection.Contains(car);

            // Assert
            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void TestCopyToMyCollection()
        {
            // Arrange
            MyCollection<Car> collection = new MyCollection<Car>(5);
            Car[] array = new Car[10];

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => collection.CopyTo(null, 2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => collection.CopyTo(array, -1));
            Assert.ThrowsException<ArgumentException>(() => collection.CopyTo(array, 8));
            collection.CopyTo(array, 2);

            // Assert
            for (int i = 2; i < 7; i++)
            {
                Assert.IsNotNull(array[i]);
            }
        }

        [TestMethod]
        public void TestRemoveMyCollection()
        {
            // Arrange
            MyCollection<Car> collection = new MyCollection<Car>();
            Car car = new Car();
            car.RandomInit();
            collection.Add(car);

            // Act
            bool removed = collection.Remove(car);

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(0, collection.Count);
            Assert.IsFalse(collection.Contains(car));
        }

        [TestMethod]
        public void TestGetEnumeratorMyCollection()
        {
            // Arrange
            MyCollection<Car> collection = new MyCollection<Car>(5);

            // Act
            IEnumerator<Car> enumerator = collection.GetEnumerator();
            int count = 0;
            while (enumerator.MoveNext())
            {
                count++;
            }

            // Assert
            Assert.AreEqual(5, count);
        }

        [TestMethod]
        public void TestICollectionPropertiesMyCollection()
        {
            // Arrange
            MyCollection<Car> collection = new MyCollection<Car>();

            // Act
            bool isReadOnly = collection.IsReadOnly;

            // Assert
            Assert.IsFalse(isReadOnly);
        }

        [TestMethod]
        public void TestConstructorWithLengthMyCollection()
        {
            // Arrange
            int length = 10;
            MyCollection<Car> collection = new MyCollection<Car>(length);

            // Act & Assert
            Assert.AreEqual(length, collection.Count);
        }

        [TestMethod]
        public void TestConstructorWithCollectionMyCollection()
        {
            // Arrange
            MyCollection<Car> originalCollection = new MyCollection<Car>(5);
            MyCollection<Car> newCollection = new MyCollection<Car>(originalCollection);

            // Act & Assert
            Assert.AreEqual(originalCollection.Count, newCollection.Count);
            foreach (var car in originalCollection)
            {
                Assert.IsTrue(newCollection.Contains(car));
            }
        }

        [TestMethod]
        public void TestAddItemMyCollection()
        {
            // Arrange
            MyCollection<Car> collection = new MyCollection<Car>();
            Car car = new Car();
            car.RandomInit();

            // Act
            collection.AddItem(car);

            // Assert
            Assert.AreEqual(1, collection.Count);
            Assert.IsTrue(collection.Contains(car));
        }

        [TestMethod]
        public void TestRemoveDataMyCollection()
        {
            // Arrange
            MyCollection<Car> collection = new MyCollection<Car>();
            Car car = new Car();
            car.RandomInit();
            collection.AddItem(car);

            // Act
            bool removed = collection.RemoveData(car);

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(0, collection.Count);
            Assert.IsFalse(collection.Contains(car));
        }
    }
}