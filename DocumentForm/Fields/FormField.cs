namespace DocumentForm.Fields
{
    public abstract class FormField
    {
        public char Label { get; private set; }
        public double Value { get; protected set; }

        public FormField(char label)
        {
            Label = label;
        }
        public FormField(char label, double value)
        : this(label)
        {
            Value = value;
        }
        public abstract double GetEvaluation(IDictionary<char, FormField> fields);
    }
}