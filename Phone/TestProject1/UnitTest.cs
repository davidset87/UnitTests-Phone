using ClassLibrary;

namespace TestProjectPhone
{
    [TestClass]
    public class TestJednostkowy1
    {
        // Test konstruktora z poprawnymi danymi
        [TestMethod]
        public void Test_Konstruktor_Dane_Poprawne()
        {
            // Arrange
            var wlasciciel = "Molenda";
            var numerTelefonu = "123456789";

            // Act
            var telefon = new Phone(wlasciciel, numerTelefonu);

            // Assert
            Assert.AreEqual(wlasciciel, telefon.Owner);
            Assert.AreEqual(numerTelefonu, telefon.PhoneNumber);
        }

        // Test konstruktora z nieprawidłowym właścicielem (pusty ciąg znaków)
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Konstruktor_Owner_Null_Or_Empty()
        {
            // Arrange
            var wlasciciel = "";
            var numerTelefonu = "123456789";

            // Act
            new Phone(wlasciciel, numerTelefonu);
        }

        // Test konstruktora z nieprawidłowym numerem telefonu
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Konstruktor_NumerTelefonu_Nieprawidlowy()
        {
            // Arrange
            var wlasciciel = "Molenda";
            var numerTelefonu = "123";

            // Act
            new Phone(wlasciciel, numerTelefonu);
        }

        // Test dodawania kontaktu
        [TestMethod]
        public void Test_DodajKontakt_Poprawny()
        {
            // Arrange
            var telefon = new Phone("Molenda", "123456789");
            var nazwaKontaktu = "Jan";
            var numerKontaktu = "987654321";

            // Act
            var wynik = telefon.AddContact(nazwaKontaktu, numerKontaktu);

            // Assert
            Assert.IsTrue(wynik);
            Assert.AreEqual(1, telefon.Count);
        }

        // Test dodawania kontaktu przy pełnej książce telefonicznej
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_DodajKontakt_KsiazkaTelefoniczna_Pelna()
        {
            // Arrange
            var telefon = new Phone("Molenda", "123456789");

            for (int i = 0; i < 100; i++)
            {
                telefon.AddContact($"Kontakt{i}", "111111111");
            }

            // Act
            telefon.AddContact("Overflow", "222222222");
        }

        // Test dzwonienia do istniejącego kontaktu
        [TestMethod]
        public void Test_Zadzwon_DoIstniejacegoKontaktu()
        {
            // Arrange
            var telefon = new Phone("Molenda", "123456789");
            telefon.AddContact("Jan", "987654321");

            // Act
            var wynik = telefon.Call("Jan");

            // Assert
            Assert.AreEqual("Dzwonię do 987654321 (Jan) ...", wynik);
        }

        // Test dzwonienia do nieistniejącego kontaktu
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_Zadzwon_DoNieistniejacegoKontaktu()
        {
            // Arrange
            var telefon = new Phone("Molenda", "123456789");

            // Act: Próba dzwonienia
            telefon.Call("Nieistniejący");
        }
    }
}