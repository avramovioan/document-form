using DocumentForm.Fields;
using DocumentForm.Helpers;

namespace DocumentForm.Forms
{
    public class Form : IForm
    {
        private IDictionary<char, FormField> fields;

        public Form()
        {
            fields = new Dictionary<char, FormField>();
        }

        public void AddField(FormField formField)
        {
            fields.Add(formField.Label, formField);
        }

        public void AddField(FormFieldCompute formFieldCompute)
        {
            fields.Add(formFieldCompute.Label, formFieldCompute);
            //Circular dependency is evaluated at creation time for prevention
            DependencyEvaluator.EvaluateDependecies(formFieldCompute, new List<char>(), fields);
        }

        public double GetFieldValue(char fieldLabel)
        {
            return fields[fieldLabel].GetEvaluation(fields);
        }
    }
}