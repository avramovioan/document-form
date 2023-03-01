using DocumentForm.Fields;

namespace DocumentForm.Forms
{
    public interface IForm
    {
        void AddField(FormField formField);
        double GetFieldValue(char fieldLabel);
    }
}