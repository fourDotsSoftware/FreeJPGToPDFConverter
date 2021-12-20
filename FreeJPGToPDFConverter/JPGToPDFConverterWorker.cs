using System;
using System.Collections.Generic;

using System.Text;

using System.Diagnostics;

namespace FreeJPGToPDFConverter
{
    class JPGToPDFConverterWorker
    {
        public static Process pr = null;

        public static void ConvertJPGToPDF(List<string> lstImages, string outputFile,
            int documentSize, int orientation, int margin, int alignment)
        {
            string tmpfn = System.IO.Path.GetTempFileName();
            string tmpdir=tmpfn+".dir";

            if (!System.IO.Directory.Exists(tmpdir))
            {
                System.IO.Directory.CreateDirectory(tmpdir);
            }

            for (int k = 0; k < lstImages.Count; k++)
            {
                System.IO.File.Copy(lstImages[k], System.IO.Path.Combine(tmpdir, System.IO.Path.GetFileName(lstImages[k])));
            }

            pr = new Process();
            pr.StartInfo.CreateNoWindow = true;
            pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pr.StartInfo.FileName = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "PDFUtilitiesNew.exe");
            pr.StartInfo.Arguments = "/jpgtopdf "+
                "\"" + tmpdir + "\" \"" + outputFile + "\" \"" + documentSize + "\" \"" + orientation + "\" \"" + margin
                + "\" \"" + alignment + "\"";

            for (int k = 0; k < lstImages.Count; k++)
            {
                pr.StartInfo.Arguments += " \"" + System.IO.Path.GetFileName(lstImages[k]) + "\"";
            }

            pr.Start();
            pr.WaitForExit();

            while (!pr.HasExited)
            {
                System.Windows.Forms.Application.DoEvents();
            }

            string[] filez = System.IO.Directory.GetFiles(tmpdir);

            for (int k = 0; k < filez.Length; k++)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(filez[k]);
                fi.Attributes = System.IO.FileAttributes.Normal;
                fi.Delete();
            }

            System.IO.FileInfo fi2 = new System.IO.FileInfo(tmpfn);
            fi2.Attributes = System.IO.FileAttributes.Normal;
            fi2.Delete();

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(tmpdir);
            di.Attributes = System.IO.FileAttributes.Normal;
            di.Delete();
        }
    }
}
