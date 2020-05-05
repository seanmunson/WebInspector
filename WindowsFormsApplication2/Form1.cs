using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
 
namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public MachineContext M ;
        public Stack<string> History = new Stack<string>();
        public Form1()
        {
            InitializeComponent();
        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

       
        private void Load_From_Root(string s)
        {
            this.Cursor = Cursors.WaitCursor;
          
            if (M == null)
            {
                FileSystemLoad(s);
                FileSystemMesh();
            }
            RefreshList();
         
            this.Cursor = Cursors.Default;
        }
        private void FileSystemLoad(string RootFolder)
        {
            this.lstFiles.Items.Clear();
            M = new MachineContext();
            M.RootFolderName = RootFolder;
            this.Text = "Reading " + RootFolder;
            this.Cursor = Cursors.WaitCursor;
            M.ReadRoot();

            this.Text = "Reading complete " + RootFolder;
            this.Cursor = Cursors.Default;
            
        }
        private void FileSystemMesh()
        {
            this.Text = "Interlacing ...";
            this.Cursor = Cursors.WaitCursor;
            M.BuildReferenceWeb();
            this.Cursor = Cursors.Default;
            this.Text = "Interlacing complete.";
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml("food");
        }
       
        private void RefreshList()
        {
            lstFiles.Items.Clear();
            foreach (string s in M.Elements.Keys)
            {
                if (!lstFiles.Items.Contains(s))
                lstFiles.Items.Add(s);
            }
            lstMissing.Items.Clear();
            lstObjects.Items.Clear();

            foreach (string s in M.Elements.Keys)
            {
                if (!lstFiles.Items.Contains(s))
                {
                    ProgramElement E = M.Elements[s];

                    if (E.ElementType!= ElementType.COMobject)
                    {
                        lstMissing.Items.Add(s);
                    }
                    else
                    {
                        lstObjects.Items.Add(s);
                        System.Console.Out.WriteLine(s);
                    }
                }
            }
        }

        private void lstObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            
        }

        private void MnuClick(object sender, EventArgs e)
        {
            ToolStripMenuItem o = sender as  ToolStripMenuItem;

            switch (o.Text)
            {
                case "Load From Root":
                    {
                        string s = "";
                        DialogResult d;

                        d = InputBox("Location of web root", "Location", ref s);
                        if (d == DialogResult.OK)
                        {
                            if (!Directory.Exists(s))
                            {
                                MessageBox.Show("Directory '" + s + "' doesn't exist.");
                                d = DialogResult.Cancel;
                            }
                            else
                            {
                                Load_From_Root(s);
                            }
                        }
                        break;
                    }
            }
        }


        private void lst_DoubleClick(object sender, EventArgs e)
        {
            ListBox LB = sender as ListBox;
            ProgramElement E = M.Elements[LB.SelectedItem as string];
            try
            {
                FileElement F = E as FileElement;
                cmdFindTextinFiles.Text = F.contents;
                this.Width = 1280;
            }
            catch (Exception xe)
            {

            }
        }
        private void FillWithDescendents(ListBox L, ProgramElement R, int cnt)
        {
            String pad = "";
            pad = pad.PadLeft(cnt * 2 ,' ');
            foreach (ElementRelationship Dp in R.Depends.Values)
            {
                if (Dp.Supporter!=null)
                {
                if (!L.Items.Contains(Dp.Supporter.name))
                {
                    L.Items.Add(pad +Dp.Supporter.name);
                    
                }
                if (Dp.Supporter.Depends.Count > 0)
                {
                    FillWithDescendents(L, Dp.Supporter, cnt+1);
                }
            }
            }
            

        }
        private void NavigateToFile(string Filename, bool isForward)
        {
            if (Filename==null) return;
            txtAddressBar.Text = Filename;
            Filename = Filename.Trim();
            if (!M.Elements.ContainsKey(Filename))
            {
                MessageBox.Show("not found : " + Filename);
                return;
            }
            ProgramElement E = M.Elements[Filename];
            lstDepends.Items.Clear();
            lstSupports.Items.Clear();

            foreach (ElementRelationship Dp in E.Depends.Values)
            {
                if (Dp.Supporter!=null) lstDepends.Items.Add(Dp.Supporter.name);
            }
            //FillWithDescendents(lstSupports, E,1);
           
            foreach (ElementRelationship Sp in E.Supports.Values)
            {
                lstSupports.Items.Add(Sp.Dependent.name);
            }
            
            lstFiles.SelectedItem=Filename;
            if (isForward) History.Push(Filename);
            try
            {
                FileElement F = E as FileElement;
                cmdFindTextinFiles.Text = F.contents;

                if (this.Width<1280)           this.Width = 1280;
            }
            catch (Exception xe)
            {
                if (this.Width <800) this.Width = 800;
            }

        }
        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox LB = sender as ListBox;
            NavigateToFile(LB.SelectedItem as string, true);
            if (txtSearchText.Text.Length > 0)
            {
                FindTextInShownFile(txtSearchText.Text);
            }
        }
        private void FindTextInShownFile(string txt, int start=0)
        {
             int i = cmdFindTextinFiles.Text.IndexOf(txt, cmdFindTextinFiles.SelectionStart + cmdFindTextinFiles.SelectionLength);
            if (i<=0)
            {
                MessageBox.Show("No More Found");
            }
            else
            {
                cmdFindTextinFiles.SelectionStart = i;
                cmdFindTextinFiles.SelectionLength = txtTextToFind.Text.Length;
                cmdFindTextinFiles.ScrollToCaret();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Width = 800;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void lstDepends_DoubleClick(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            NavigateToFile(lb.SelectedItem as string, true);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (History.Count > 0)
                NavigateToFile(History.Pop(), false);
        }

        private void lstSupports_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            NavigateToFile(lb.SelectedItem as string, true);
        }

        private void btnFindText_Click(object sender, EventArgs e)
        {
           FindTextInShownFile(txtTextToFind.Text);
        }

        private void lblSortOb_Click(object sender, EventArgs e)
        {
            if (lblSortOb.Text == "⇩")
            {
                lstObjects.Sorted = false;
                lblSortOb.Text = "☐";
            }
            else
            {
                lstObjects.Sorted = true;
                lblSortOb.Text = "⇩";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "⇩")
            {
                lstFiles.Sorted = false;
                label1.Text = "☐";
            }
            else
            {
                lstFiles.Sorted = true;
                label1.Text = "⇩";
            }
        }


        private void cmdFindText_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (txtSearchText.Text.Length>0)
            {
            lstFiles.Items.Clear();
            ProgramElement E;
            string S;
            
            
            foreach (KeyValuePair<string,ProgramElement> KVP in M.Elements)
            {
                S = KVP.Key;
                E = KVP.Value;
                if (E.ElementType == ElementType.TextFile)
                {
                    FileElement F = E as FileElement;
                    if (F.contents.Length > 0)
                    {
                        if (F.contents.ToUpper().Contains(txtSearchText.Text.ToUpper()))
                        {
                            lstFiles.Items.Add(S);
                            i++;
                        }
                    }
                }
                
            }
            if (i == 0)
            {
                MessageBox.Show("No Files were found with text string (" + txtSearchText.Text + ")");
            }
            else
            {
                MessageBox.Show(String.Format("{0:d} were found with text string ('{1}')",i, txtSearchText.Text ));
            }
           }
        }

        private void lstDepends_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox LB = sender as ListBox;

            NavigateToFile(LB.Text, true);

        }

        private void cmdSleuth_Click(object sender, EventArgs e)
        {
            if (txtSleuthFileNameList.Text.Length == 0 || !txtSleuthFileNameList.Text.Contains(','))
            {
                MessageBox.Show("Need more than two filenames, seperated by a comma (,) to sleuth their common dependencies.");
                return;
            }
            string[] Filenames = txtSleuthFileNameList.Text.Split(',');
            if (Filenames.Length < 2)
            {
                MessageBox.Show("Need more than two filenames, seperated by a comma (,) to sleuth their common dependencies.");
                return;
            }
            if (M==null)
            {
                MessageBox.Show("System not Loaded");
                return;
            }
            if (M.Elements==null)
            {
                MessageBox.Show("System not Loaded. Please load the system");
                return;
            }
            Dictionary<string,HashSet<ProgramElement>> D = new Dictionary<string,HashSet<ProgramElement>>(); // List of dependencies of all items listen under txtSleuthFileNameList.Text
            List<ProgramElement> X = new List<ProgramElement>(); // List of all depended files listed - to control maximal flow
            

            foreach (string s in Filenames)
            {
                string t = M.RootFolderName + s;
                t = t.ToLower();
                if (!M.Elements.ContainsKey(t))
                {
                    MessageBox.Show(String.Format("File name '{0}' not found in Systembase", t));
                   
                }
                else
                {
                    HashSet<ProgramElement> H = new HashSet<ProgramElement>();
                    if (M.Elements.ContainsKey(t))
                    {
                        ProgramElement E = M.Elements[t];

                        E.UltimatelyDependent(H);   // this gets the list of all files that could be deemed dependent to E

                        foreach (ProgramElement L in H)
                        {
                            if (!X.Contains(L))
                            {
                                X.Add(L);
                            }
                        }
                    }
                    D.Add(t,H);
                }
            }

            int[] ConcurrenceCount = new int[X.Count];
           
            // look at each hashset, and check each element of x. 
            lstDepends.Items.Clear();
            lstDepends.Sorted = true;
            for (int i = 0; i < X.Count; i++)
            {
                foreach (HashSet<ProgramElement> d in D.Values)
                {
                    if (d.Contains(X[i]))
                    {
                        ConcurrenceCount[i]++;
                    }
                }
                lstDepends.Items.Add(String.Format("{0}\t[ {1} ]", X[i].name, ConcurrenceCount[i]));
                if (ConcurrenceCount[i] == Filenames.Length)
                {
                    MessageBox.Show( String.Format("{0} appears in {1} items.",X[i],ConcurrenceCount[i]));

                }
            }

            
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string retval = "";
            foreach( string s in lstFiles.Items)
            {
                retval += (s + "\r\n");
            }
            Clipboard.SetText (retval);

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lstObjects_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control )
            {
                ListBox L = sender as ListBox;
                
                switch (e.KeyCode)
                {
                    case Keys.C:

                        string tmp = "";
                    
                        foreach (string s in L.Items)   
                            tmp = tmp  + (s as string) + "\r\n";
                       
                        Clipboard.SetText(tmp);
                        break;
                    case Keys.X:
                        
                        string tmp2 = "";
                        
                        foreach (string s in L.Items)
                            tmp2 = tmp2 + "\"" + (s as string) + "\",";

                        Clipboard.SetText(tmp2);
                        break;
                    case Keys.S:
                        L.Sorted = !L.Sorted;
                        break;
                   
                }
            }
        }

        private void lstObjects_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ListBox LB = sender as ListBox;
            if (M.Elements.ContainsKey(LB.SelectedItem as string))
            {
                lstDepends.Items.Clear();
                lstSupports.Items.Clear();
                ProgramElement E = M.Elements[LB.SelectedItem as string];
                int Di=0;
                foreach (string D in E.Depends.Keys)
                {
                    lstDepends.Items.Add(D);
                    Di++;
                }
                label4.Text = String.Format("Depends [{0:d}]" ,Di); 
                int Si=0;
                foreach (string S in E.Supports.Keys)
                {
                    lstSupports.Items.Add(S);
                    Si++;
                }
                label5.Text = String.Format("Supports [{0:d}]", Si); 
            }

        }

        private void cmdWordCount_Click(object sender, EventArgs e)
        {
            frmWordSearch W = new frmWordSearch();
             W.M = this.M; 
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdFindTextinFiles.WordWrap = !cmdFindTextinFiles.WordWrap;
            wordWrapToolStripMenuItem.Checked = cmdFindTextinFiles.WordWrap;
        }

        private void cmdFindTextinFiles_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void connectToSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
