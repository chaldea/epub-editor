using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chaldea.Epub.Service
{
    public class NativeService
    {
        public Task<string[]> ShowFileDialog()
        {
            var tcs = new TaskCompletionSource<string[]>();
            var th = new Thread(() =>
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tcs.SetResult(openFileDialog.FileNames);
                    
                }
                else
                {
                    tcs.SetResult(new string[] { });
                }
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            th.Join();
            return tcs.Task;
        }
    }
}
