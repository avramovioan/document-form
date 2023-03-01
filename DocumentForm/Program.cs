using DocumentForm.Fields;
using DocumentForm.Forms;

static void TestForm1()
{
    //example 1
    //   A -- B
    //     \
    //      C
    //   D -- E
    //     \
    //      F
    Form form1 = new Form();

    form1.AddField(new FormFieldCompute('A', 'B', 'C'));
    form1.AddField(new FormFieldCompute('D', 'E', 'F'));
    form1.AddField(new FormFieldInput('B', 7));
    form1.AddField(new FormFieldInput('C', 12));
    form1.AddField(new FormFieldInput('E', 17));
    form1.AddField(new FormFieldInput('F', 22));

    System.Console.WriteLine($"A: {form1.GetFieldValue('A')}");
    System.Console.WriteLine($"D: {form1.GetFieldValue('D')}");
}

static void TestForm2()
{
    //example 2
    //   A -- B
    //     \
    //      C -- D
    //        \   
    //          E
    Form form2 = new Form();

    form2.AddField(new FormFieldCompute('A', 'B', 'C'));
    form2.AddField(new FormFieldCompute('C', 'D', 'E'));
    form2.AddField(new FormFieldInput('B', 7));
    form2.AddField(new FormFieldInput('D', 12));
    form2.AddField(new FormFieldInput('E', 17));

    System.Console.WriteLine($"A: {form2.GetFieldValue('A')}");
    System.Console.WriteLine($"C: {form2.GetFieldValue('C')}");
}

static void TestForm3()
{
    //example 3
    // Will throw exception for circular dependency
    // A -> C -> A
    //   A -- B
    //   /\
    //   \/
    //   C -- D       
    //          
    Form form3 = new Form();

    form3.AddField(new FormFieldCompute('A', 'B', 'C'));
    form3.AddField(new FormFieldCompute('C', 'A', 'D'));
    form3.AddField(new FormFieldInput('B', 7));
    form3.AddField(new FormFieldInput('D', 12));

    System.Console.WriteLine($"A: {form3.GetFieldValue('A')}");
    System.Console.WriteLine($"C: {form3.GetFieldValue('C')}");
}

static void TestForm4()
{
    //example 4
    // Will throw exception for circular dependency
    // A -> C -> E -> F -> H -> A
    //
    //    A -- B
    //    | \
    //    |  C -- D
    //    |    \   
    //     \     E -- G
    //      \     \  /
    //       \      F 
    //        \   /
    //          H -- I  
    Form form4 = new Form();

    form4.AddField(new FormFieldCompute('A', 'B', 'C'));
    form4.AddField(new FormFieldCompute('C', 'D', 'E'));
    form4.AddField(new FormFieldCompute('E', 'F', 'G'));
    form4.AddField(new FormFieldCompute('F', 'G', 'H'));
    form4.AddField(new FormFieldCompute('H', 'A', 'I'));
    form4.AddField(new FormFieldInput('B', 7));
    form4.AddField(new FormFieldInput('D', 12));
    form4.AddField(new FormFieldInput('G', 17));
    form4.AddField(new FormFieldInput('I', 22));

    System.Console.WriteLine($"A: {form4.GetFieldValue('A')}");
    System.Console.WriteLine($"C: {form4.GetFieldValue('C')}");
    System.Console.WriteLine($"E: {form4.GetFieldValue('E')}");
    System.Console.WriteLine($"F: {form4.GetFieldValue('F')}");
    System.Console.WriteLine($"H: {form4.GetFieldValue('H')}");

}

static void TestForm5()
{
    //example 5
    //    B -- A
    //    |   /
    //    |  C -- D
    //    |    \   
    //     \     E -- G
    //      \     \  /
    //       \      F 
    //        \   /
    //          H -- I  
    Form form4 = new Form();

    form4.AddField(new FormFieldCompute('A', 'B', 'C'));
    form4.AddField(new FormFieldCompute('C', 'D', 'E'));
    form4.AddField(new FormFieldCompute('E', 'F', 'G'));
    form4.AddField(new FormFieldCompute('F', 'G', 'H'));
    form4.AddField(new FormFieldCompute('H', 'B', 'I'));
    form4.AddField(new FormFieldInput('B', 7));
    form4.AddField(new FormFieldInput('D', 12));
    form4.AddField(new FormFieldInput('G', 17));
    form4.AddField(new FormFieldInput('I', 22));


    System.Console.WriteLine($"A: {form4.GetFieldValue('A')}");
    System.Console.WriteLine($"C: {form4.GetFieldValue('C')}");
    System.Console.WriteLine($"E: {form4.GetFieldValue('E')}");
    System.Console.WriteLine($"F: {form4.GetFieldValue('F')}");
    System.Console.WriteLine($"H: {form4.GetFieldValue('H')}");
}


TestForm4();