using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DSRBackupUtility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Method taken from:
        // https://stackoverflow.com/questions/876473/is-there-a-way-to-check-if-a-file-is-in-use
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                /*
                 * The file is unavailable because it:
                 *  - is still being written to
                 *  - is being processed by another thread
                 *  - does not exist
                 */
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            // The file is not locked.
            return false;
        }
    }
}
