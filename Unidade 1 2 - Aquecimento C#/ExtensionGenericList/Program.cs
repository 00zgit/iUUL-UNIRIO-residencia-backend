using Q4;

List<string> strlist = new() { "string 1", "string 2", "string 1", "string 3", "string 2"};

List<int> intlist = new() { 3, 1, 2, 4, 5, 3, 1, 2, 4, 5 };

strlist = ExtensionGenericList.RemoveRepetido(strlist);
intlist = ExtensionGenericList.RemoveRepetido(intlist);

strlist.ForEach(e => Console.WriteLine($"{e} "));
intlist.ForEach(e => Console.WriteLine($"{e} "));