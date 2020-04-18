using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Mistox;

namespace Renesas_unassembler {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            openFileDialog1.ShowDialog();
        }

        public static string[] converted;
        public static List<byte> bytes;

        public static void WorkerThread() {
            Parallel.For(0, bytes.Count, index => {
                if (index % 2 == 0) {
                    byte cur1 = bytes[(index)];
                    byte cur2 = bytes[(index) + 1];
                    Thread.Sleep(0);
                    string bitecode = Convert.ToString(cur1, 2).PadLeft(8, '0') +
                        Convert.ToString(cur2, 2).PadLeft(8, '0');

                    string A = bitecode.Substring(0, 4);
                    string B = bitecode.Substring(4, 4);
                    string C = bitecode.Substring(8, 4);
                    string D = bitecode.Substring(12, 4);
                    converted[index/2] = Unassembly.Unassemble(A, B, C, D);
                }
            });
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {
            OpenFileDialog self = (OpenFileDialog)sender;
            string path = self.FileName;
            bytes = File.ReadAllBytes(path).ToList();
            converted = new string[bytes.Count/2];
            Thread x = new Thread(new ThreadStart(WorkerThread));
            x.Start();
            x.Join();
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Desktop\Out.asm", string.Join("\n", converted));
            Application.ExitThread();
        }
    }
}