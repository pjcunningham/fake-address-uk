using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakeAddressUK.Tests {
    [TestClass]
    public class FakeAddressTests {

        [TestMethod]
        public void GenerateZeroAddresses() {

            var addresses = FakeAddressGenerator.Generate(0);
            Assert.AreEqual(addresses.Count(), 0);

        }

        [TestMethod]
        public void GenerateNegativeAddresses() {

            var addresses = FakeAddressGenerator.Generate(-1);
            Assert.AreEqual(addresses.Count(), 0);

        }

        [TestMethod]
        public void GenerateOneAddresses() {

            var addresses = FakeAddressGenerator.Generate(1);
            Assert.AreEqual(addresses.Count(), 1);

        }

        [TestMethod]
        public void GenerateTwentyAddresses() {

            var addresses = FakeAddressGenerator.Generate(20);
            Assert.AreEqual(addresses.Count(), 20);

        }

        [TestMethod]
        public void GenerateOneThousandAddresses() {

            var addresses = FakeAddressGenerator.Generate(1000);
            Assert.AreEqual(addresses.Count(), 1000);

        }

        [TestMethod]
        public void IterateOneThousandAddresses() {

            var addresses = FakeAddressGenerator.Generate(1000);
            foreach (var address in addresses) {
                Assert.AreEqual(typeof(FakeAddress), address.GetType());
            }

        }

        [TestMethod]
        public void IterateOneMillionAddresses() {

            var addresses = FakeAddressGenerator.Generate(1000000);
            foreach (var address in addresses) {
                Assert.AreEqual(typeof(FakeAddress), address.GetType());
            }

        }

        [TestMethod]
        public void IterateProjectionAddresses() {

            var addresses = FakeAddressGenerator.Generate(1000000).Select(q => new {PostCode = q.PostCode});
            foreach (var address in addresses) {
                Assert.IsNotNull(address.PostCode);
            }

        }

    }
}
