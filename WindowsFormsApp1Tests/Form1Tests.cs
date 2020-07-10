using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;


namespace WindowsFormsApp1.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void SprawdzCzyRowneTest()
        {
            Walidator walidator = new Walidator();

            bool wynikMetody = walidator.SprawdzCzyRowne("test", "test");
            
            Assert.AreEqual(wynikMetody, true);
        }
        
        [TestMethod()]
        public void DajZakonczenieTest()
        {
            Zakonczenia zakonczenia = new Zakonczenia();

            string wynik = zakonczenia.DajZakonczenie(2);
            
            Assert.AreEqual(wynik, "Częśc języka polskiego zakończona");
        }
    }
}