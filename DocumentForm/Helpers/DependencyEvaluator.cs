using DocumentForm.Fields;

namespace DocumentForm.Helpers
{
    public static class DependencyEvaluator
    {

        public static void EvaluateDependecies(IComputeField computeField,
                                               ICollection<char> dependencyPath,
                                               IDictionary<char, FormField> fields)
        {
            if (fields.ContainsKey(computeField.LeftOperator))
            {
                Evaluate(computeField.LeftOperator, dependencyPath, fields);
            }
            if (fields.ContainsKey(computeField.RightOperator))
            {
                Evaluate(computeField.RightOperator, dependencyPath, fields);
            }
            else
            {
                return;
            }
        }

        private static void Evaluate(char label,
                                     ICollection<char> dependencyPath,
                                     IDictionary<char, FormField> fields)
        {
            if (fields[label] is IComputeField computeField)
            {
                if (dependencyPath.Contains(label))
                {
                    dependencyPath.Add(label);
                    TerminateProcess(dependencyPath);
                }

                dependencyPath.Add(label);
                EvaluateDependecies(computeField, dependencyPath, fields);
            }
        }

        private static void TerminateProcess(ICollection<char> dependencyPath)
        {
            DisplayDepencencyPath(dependencyPath);
            throw new InvalidOperationException("Circular dependency detected.");
        }

        private static void DisplayDepencencyPath(ICollection<char> dependencyPath)
        {
            foreach (char item in dependencyPath)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine();
        }
    }
}