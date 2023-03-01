namespace DocumentForm.Fields
{
    public class FormFieldCompute : FormField, IComputeField
    {
        public char LeftOperator { get; set; } // left operator for the addition
        public char RightOperator { get; set; } // right operator for the addition
        public FormFieldCompute(char label, char leftOperator, char rightOperator)
        : base(label)
        {
            LeftOperator = leftOperator;
            RightOperator = rightOperator;
        }

        public override double GetEvaluation(IDictionary<char, FormField> fields)
        {
            return fields[LeftOperator].GetEvaluation(fields) + fields[RightOperator].GetEvaluation(fields);
        }
    }
}