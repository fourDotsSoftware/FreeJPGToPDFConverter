using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FreeJPGToPDFConverter
{ 
    class ArgsHelper
    {        
        public static bool ExamineArgs(string[] args)
        {
            if (args.Length == 0) return true;
                        
            Module.args = args;

            try
            {
                if (args[0].ToLower().Trim().StartsWith("-tempfile:"))
                {                                       
                    string tempfile = GetParameter(args[0]);

                    //MessageBox.Show(tempfile);

                    using (StreamReader sr = new StreamReader(tempfile, Encoding.Unicode))
                    {
                        string scont = sr.ReadToEnd();

                        //args = scont.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        args = SplitArguments(scont);
                        Module.args = args;

                        // MessageBox.Show(scont);
                    }

                    Module.IsFromWindowsExplorer = true;
                }
                else if (args.Length>0 && (Module.args.Length==1 && (System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0]))))
                {

                }
                else
                {
                    Module.IsCommandLine = true;

                    //System.Windows.Forms.MessageBox.Show("0");

                    frmMain f=new frmMain();

                    string password = "";

                    frmMain.Instance.dt.Rows.Clear();

                    for (int k = 0; k < Module.args.Length; k++)
                    {
                        if (System.IO.File.Exists(Module.args[k]))
                        {
                            frmMain.Instance.AddFile(Module.args[k],password);

                            password = "";
                        }
                        else if (System.IO.Directory.Exists(Module.args[k]))
                        {
                            frmMain.Instance.SilentAdd = true;

                            frmMain.Instance.AddFolder(Module.args[k],password);

                            password = "";
                        }
                        else if (Module.args[k].ToLower().Trim() == "-keepcreationdate"
    || Module.args[k].ToLower().Trim() == "/keepcreationdate")
                        {
                            //frmMain.Instance.retainTimestampToolStripMenuItem.Checked = true;

                            Properties.Settings.Default.KeepCreationDate = true;

                            password = "";
                        }
                        else if (Module.args[k].ToLower().Trim() == "-keeplastmoddate"
                            || Module.args[k].ToLower().Trim() == "/keeplastmoddate")
                        {
                            //frmMain.Instance.retainTimestampToolStripMenuItem.Checked = true;

                            Properties.Settings.Default.KeepLastModificationDate = true;

                            password = "";
                        }

                        else if (Module.args[k].ToLower().StartsWith("/outputfile:") ||
    Module.args[k].ToLower().StartsWith("-outputfile:"))
                        {
                            string outfile = GetParameter(Module.args[k]);

                            //3RecentFilesHelper.AddRecentOutputFile(outfile);

                            //3frmMain.Instance.cmbOutputDir.SelectedIndex = 0;

                            //Module.OutputFilepath = outfile;

                            frmMain.Instance.OutputFilepath = outfile;

                            password = "";
                        }
                        else if (Module.args[k].ToLower().StartsWith("/documentsize:") ||
        Module.args[k].ToLower().StartsWith("-documentsize:"))
                        {
                            string ds = GetParameter(Module.args[k]);

                            int ids = int.Parse(ds);

                            frmMain.Instance.ucJPGToPDFConverter1.cmbDocumentSize.SelectedIndex = ids;
                        }
                        else if (Module.args[k].ToLower().StartsWith("/orientation:") ||
    Module.args[k].ToLower().StartsWith("-orientation:"))
                        {
                            string ds = GetParameter(Module.args[k]);

                            int ids = int.Parse(ds);

                            frmMain.Instance.ucJPGToPDFConverter1.cmbOrientation.SelectedIndex = ids;
                        }
                        else if (Module.args[k].ToLower().StartsWith("/margin:") ||
    Module.args[k].ToLower().StartsWith("-margin:"))
                        {
                            string ds = GetParameter(Module.args[k]);

                            int ids = int.Parse(ds);

                            frmMain.Instance.ucJPGToPDFConverter1.cmbMargin.SelectedIndex = ids;
                        }
                        else if (Module.args[k].ToLower().StartsWith("/imagealignment:") ||
    Module.args[k].ToLower().StartsWith("-imagealignment:"))
                        {
                            string ds = GetParameter(Module.args[k]);

                            int ids = int.Parse(ds);

                            frmMain.Instance.ucJPGToPDFConverter1.cmbImageAlignment.SelectedIndex = ids;
                        }                                                
                    }                                      
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not parse Arguments !", ex.ToString());
                return false;
            }

            return true;
        }

        private static string RemoveQuotes(string str)
        {
            if ((str.StartsWith("\"") && str.EndsWith("\"")) ||
                    (str.StartsWith("'") && str.EndsWith("'")))
            {
                if (str.Length > 2)
                {
                    str = str.Substring(1, str.Length - 2);
                }
                else
                {
                    str = "";
                }
            }

            return str;
        }

        private static string GetParameter(string arg)
        {
            int spos = arg.IndexOf(":");
            if (spos == arg.Length - 1) return "";
            else
            {
                string str=arg.Substring(spos + 1);

                if ((str.StartsWith("\"") && str.EndsWith("\"")) ||
                    (str.StartsWith("'") && str.EndsWith("'")))
                {
                    if (str.Length > 2)
                    {
                        str = str.Substring(1, str.Length - 2);
                    }
                    else
                    {
                        str = "";
                    }
                }

                return str;
            }
        }

        public static string[] SplitArguments(string commandLine)
        {
            char[] parmChars = commandLine.ToCharArray();
            bool inSingleQuote = false;
            bool inDoubleQuote = false;
            for (int index = 0; index < parmChars.Length; index++)
            {
                if (parmChars[index] == '"' && !inSingleQuote)
                {
                    inDoubleQuote = !inDoubleQuote;
                    parmChars[index] = '\n';
                }
                if (parmChars[index] == '\'' && !inDoubleQuote)
                {
                    inSingleQuote = !inSingleQuote;
                    parmChars[index] = '\n';
                }
                if (!inSingleQuote && !inDoubleQuote && parmChars[index] == ' ')
                    parmChars[index] = '\n';
            }
            return (new string(parmChars)).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static void ShowCommandUsage()
        {
            string msg = GetCommandUsage();

            Module.ShowMessage(msg);

            Environment.Exit(0);
        }
        public static string GetCommandUsage()
        {
            string msg = "Convert JPG and other type of Images to PDF document.\n\n" +
            "FreeJPGToPDFConverter.exe [file|directory]\n" +
            "[/cmd]\n" +
            "[/keeptimestamp]\n"+                                    
            "[/outputfile:OUTPUT_FILEPATH]\n"+        
            "[/documentsize:DOCUMENT_SIZE_VALUE]\n"+
            "[/orientation:ORIENTATION_VALUE]\n" +
            "[/margin:MARGIN_VALUE]\n" +
            "[/imagealignment:IMAGE_ALIGNMENT_VALUE]\n" +            
            "[/?]\n\n\n" +
            "cmd : use the command line\n" +
            "file : one or more Microsoft Word documents to be processed.\n" +
            "directory : one or more directories containing files to be processed.\n" +                                                           
            "outputfile  : (optional) the combined Word document output filepath.\n"+
            "keepcreationdate : (optional) keep file creation date.\n" +
            "keeplastmoddate : (optional) keep file last modification date.\n" +
            "documentsize : Document Size\n" +
            "DOCUMENT_SIZE_VALUE: 0=Original Size,1=A4,2=US Letter\n"+
            "orientation : Document Orientation\n"+
            "ORIENTATION_VALUE: 0=Portrait,1=Landscape,2=Auto\n"+
            "MARGIN_VALUE : 0=Small Margin,1=Big Margin,2=No Margin\n"+
            "imagealigment : Image Alignemtn\n"+
            "IMAGE_ALIGNMENT_VALUE : 0=Middle Center,1=Top Center,2=Bottom Center,3=Middle Left,4=Top Left,5=Bottom Left,6=Middle Right,7=Top Right,8=Bottom Right\n"+
            "/? : show help\n\n\n" +
            "Example :\n" +
            "FreeJPGToPDFConverter.exe \"c:\\images\\images1.jpg\" \"c:\\images\\images2.jpg\" \"c:\\images\\images3.jpg\"" +
            " /outputfile:\"c:\\documents\\images.pdf\" /documentsize:0 /orientation:0 /margin:1";

            return msg;            
        }

        public static bool IsFromFolderWatcher
        {
            get
            {                
                // new
                if (Module.args.Length > 0 && Module.args[0].ToLower().Trim() == "/cmdfw")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsFromWindowsExplorer
        {
            get
            {
                if (Module.IsFromWindowsExplorer) return true;

                // new
                if (Module.args.Length > 0 && (Module.args[0].ToLower().Trim().Contains("-tempfile:")
                    || (Module.args.Length==1 && (System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0])))))
                {
                    Module.IsFromWindowsExplorer = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsFromCommandLine
        {
            get
            {
                if (Module.args == null || Module.args.Length == 0)
                {
                    return false;
                }

                if (ArgsHelper.IsFromWindowsExplorer)
                {
                    Module.IsCommandLine = false;
                    return false;
                }
                else if (Module.args.Length > 0 && (Module.args.Length == 1 && (System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0]))))
                {
                    Module.IsCommandLine = false;
                    return false;
                }
                else
                {
                    Module.IsCommandLine = true;
                    return true;
                }
            }
        }

        /*
        public static bool IsFromWindowsExplorer()
        {
            if (Module.args == null || Module.args.Length == 0)
            {
                return false;
            }

            for (int k = 0; k < Module.args.Length; k++)
            {
                if (Module.args[k] == "-visual")
                {
                    Module.IsFromWindowsExplorer = true;
                    return true;
                }
            }

            Module.IsFromWindowsExplorer = false;
            return false;
        }
        */

        public static void ExecuteCommandLine()
        {
            string err = "";
            bool finished = false;

            try
            {
                /*
                if (Module.CmdLogFile != string.Empty)
                {
                    try
                    {
                        Module.CmdLogFileWriter = new StreamWriter(Module.CmdLogFile, true);
                        Module.CmdLogFileWriter.AutoFlush = true;
                        Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] Started compressing PDF files !");
                    }
                    catch (Exception exl)
                    {
                        Module.ShowMessage("Error could not start log writer !");
                        ShowCommandUsage();
                        Environment.Exit(0);
                        return;
                    }
                }                

                if (Module.CmdImportListFile != string.Empty)
                {
                    frmMain.Instance.ImportList(Module.CmdImportListFile);

                    err += frmMain.Instance.SilentAddErr;

                }
                */

                if (Module.args[0].ToLower() == "/h" ||
                        Module.args[0].ToLower() == "-h" ||
                        Module.args[0].ToLower() == "-?" ||
                        Module.args[0].ToLower() == "/?")
                {
                    ShowCommandUsage();
                    Environment.Exit(1);
                    return;
                }

                if (frmMain.Instance.dt.Rows.Count == 0)
                {
                    Module.ShowMessage("Please specify at least one Image to Convert to PDF !");
                    ShowCommandUsage();
                    Environment.Exit(0);
                    return;
                }

                if (frmMain.Instance.OutputFilepath == string.Empty)
                {
                    Module.ShowMessage("Please specify PDF output file !");
                    ShowCommandUsage();
                    Environment.Exit(0);
                    return;
                }
                
                frmMain.Instance.tsbMergeDocuments_Click(null,null);
                
            }
            finally
            {
                
            }
            Environment.Exit(0);
        }

        
                
                
    }

    public class ReadListsResult
    {
        public bool Success = true;
        public string err = "";
    }
}
