using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace FakeAddressUK {


    public sealed class FakeAddressGenerator {

        private static readonly List<string> _Addresses;
        private static readonly List<string> _Buildings;
        private static readonly List<string> _Numbers;
        private static readonly List<string> _Streets;
        private static readonly List<string> _Suburbs;
        private static readonly List<string> _Towns;
        private static readonly List<string> _Counties;
        private static readonly List<string> _PostCodes;
        private static readonly int _AddressesCount;
        private static readonly int _BuildingsCount;
        private static readonly int _NumbersCount;
        private static readonly int _StreetsCount;
        private static readonly int _SuburbsCount;
        private static readonly int _TownsCount;
        private static readonly int _CountiesCount;
        private static readonly int _PostCodesCount;
        private static readonly Random _Random = new Random();

        private static List<string> GetListFromResource(Assembly assembly, string name) {
            var result = new List<string>();
            using (var reader = new StreamReader(assembly.GetManifestResourceStream(string.Format("FakeAddressUK.Resources.{0}", name)))) {
            
                string s = String.Empty;
                while ((s = reader.ReadLine()) != null) {
                    result.Add(s);
                }
                return result;
            }
        }

        static FakeAddressGenerator() {
            var assembly = Assembly.GetExecutingAssembly();
            _Addresses = GetListFromResource(assembly, "Addresses.txt");
            _AddressesCount = _Addresses.Count();
            
            _Buildings = GetListFromResource(assembly, "Buildings.txt");
            _BuildingsCount = _Buildings.Count();
            
            _Numbers = GetListFromResource(assembly, "Numbers.txt");
            _NumbersCount = _Numbers.Count();
            
            _Streets = GetListFromResource(assembly, "Streets.txt");
            _StreetsCount = _Streets.Count();
            
            _Suburbs = GetListFromResource(assembly, "Suburbs.txt");
            _SuburbsCount = _Suburbs.Count();
            
            _Towns = GetListFromResource(assembly, "Towns.txt");
            _TownsCount = _Towns.Count();
            
            _Counties = GetListFromResource(assembly, "Counties.txt");
            _CountiesCount = _Counties.Count();
            
            _PostCodes = GetListFromResource(assembly, "PostCodes.txt");
            _PostCodesCount = _PostCodes.Count();
        }

        public static IEnumerable<FakeAddress> Generate(int total) {
          
            var count = 0;
            while (count < total) {               
                count++;
                yield return new FakeAddress {
                    Address = _Addresses[_Random.Next(_AddressesCount)], 
                    BuildingName = _Buildings[_Random.Next(_BuildingsCount)],
                    Number = _Numbers[_Random.Next(_NumbersCount)],
                    Street = _Streets[_Random.Next(_StreetsCount)],
                    Suburb = _Suburbs[_Random.Next(_SuburbsCount)],
                    Town = _Towns[_Random.Next(_TownsCount)],
                    County = _Counties[_Random.Next(_CountiesCount)],
                    PostCode = _PostCodes[_Random.Next(_PostCodesCount)],
                };
            }
        }

    }


    public class FakeAddress {

        public string Address { get; set; }
        public string BuildingName { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }
}
