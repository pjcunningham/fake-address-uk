fake-address-uk
===============

Generates randomized UK addresses using real UK data (Towns, Counties, Post Codes etc). 

```C#

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
```

How to use
---------

```C#

	var addresses = FakeAddressGenerator.Generate(1000000);
	foreach (var address in addresses) {
		// do something with address
	}
```
