namespace DocumentForm.Fields
{
    public class FormFieldInput : FormField
    {
        public FormFieldInput(char label, double value)
        : base(label, value)
        { }

        public override double GetEvaluation(IDictionary<char, FormField> fields)
        {
            return Value;
        }
    }
}