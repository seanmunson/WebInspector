using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Xml;
using System.Windows.Forms;
using Microsoft.Win32;
using HtmlAgilityPack;
using System.Data.SqlClient;


namespace WindowsFormsApplication2
{
    
    /// <summary>
    /// Described the type of relationship between two elements
    /// </summary>
    public enum RelationShipType
    {
        RelationInclude, RelationLink, Relationhref, RealtionURL, RelationCOM, RelationOther, RelationNone
    }
    // this is the connection coloration method.
    /// <summary>
    /// Described the general type for an element (usually by the type of 'open/edit' we want.
    /// </summary>
    public enum ElementType
    {
       Unknown, TextFile, ImageFile, BinaryFile, URL, COMobject, DotNetObject 
    }
    public class ElementRelationship
    {
       public ProgramElement Dependent;
       public ProgramElement Supporter;
       public RelationShipType Relation;
       
        
    }

    // This is a single way to pull data out of a text or XML file.
    /// <summary>
    /// Top-level abstract Parse Class
    /// </summary>
    public abstract class ParseFeature
    {
        public RelationShipType Type;
        public string Name;
        public abstract string[] parse(ProgramElement obj);

        public ParseFeature(RelationShipType t, string n)
        {
            Type = t;
            Name = n;
        }
    }
    
    // This is a ParseFeature that extracts REGEX matches
    // ^using (.+);+                                : CS Code reference 
    // "<!--.+#include.+[virtual]=\"(.+)\".+-->"    :asp File Include

    /// <summary>
    /// Returns the Matchstrings given a regex string
    /// </summary>
    public class RegexParser:ParseFeature
    {
        private string RegexString;
        public RegexParser(string matchstring, RelationShipType Type, string Name):base(Type,Name)
        {
            this.RegexString=matchstring;
        }

        public override string[] parse(ProgramElement obj)
        {
            Stack<string> S = new Stack<string>();
            FileElement el ;
            if ((el = obj as FileElement)==null ?  true : false)
            throw new Exception("Parser Type Miscast");

            foreach (Match m in Regex.Matches(el.contents, RegexString))
            {
                
                    S.Push(m.Groups[1].Value);
                
               
            }
            return S.ToArray();
        }
    }
    public class XformParser : ParseFeature
    {
        private string Matchstring;
        private string Changestring;
        public XformParser(string matchString, string changeToString, RelationShipType Type, string Name)
            : base(Type, Name)
        {
            this.Matchstring = matchString;
            this.Changestring = changeToString;
        }

        public override string[] parse(ProgramElement obj)
        {
            Stack<string> S = new Stack<string>();
            FileElement el;
            if ((el = obj as FileElement) == null ? true : false)
                throw new Exception("Parser Type Miscast");
            else
            {
                el.contents = el.contents.Replace(this.Matchstring, this.Changestring);
            }
            
            return S.ToArray();
        }
    }
    public class HTMLFormParser:ParseFeature
    {

        public HTMLFormParser(RelationShipType Type, string Name)
            : base(Type, Name)
        {
           
        }

        public override string[] parse(ProgramElement obj)
        {
            Stack<string> S = new Stack<string>();
            FileElement el;
            if ((el = obj as FileElement) == null ? true : false)
                throw new Exception("Parser Type Miscast");
            else
            {
                HtmlAgilityPack.HtmlDocument C = new HtmlAgilityPack.HtmlDocument();
                C.LoadHtml(el.contents);
                el.contents = C.ToString();
            }
            
            return S.ToArray();
        }
    }
    #region
    // This Extracts a given tag / property from an XML document. 
    // If Propertyname is null, then it returns the whole tag. 
    // like <tag p1="a" p2="b"> returns "tag p1=/"a/" p2=/"b/""
    /*
   public class XMLParser : ParseFeature
   {
       string XsltTagIdentifier;
       string PropertyName;

       public XMLParser(string TagIdentifier, RelationShipType Type, string Name, string PropertyKey="" )
           : base(Type, Name)
       {
           XsltTagIdentifier = TagIdentifier;
           PropertyName = PropertyKey;
       }
        public override string[] parse(ProgramElement obj)
        {
            //FileElement El;
            //if ((El = obj as FileElement) == null) throw new Exception("Parser Type Miscast - Document is not Texty");
            //XmlDocument XD = new XmlDocument();
            //try
            //{
            //    XD.LoadXml(El.contents);
            //}
            //catch (Exception e)
            //{
            //    throw new Exception("Parser Type Miscast - document is not XML type");
            //}
            //XmlNodeList Xn =  XD.GetElementsByTagName(XsltTagIdentifier);
            //foreach(XmlNode x in Xn)
            //{
            //    if (this.PropertyName.Length > 0)
            //    {
            //        if (x.HasAttribute(PropertyName))
            //        {
            //        }
            //    }
            //}
            return new string[1]();
        }
    }

            */
    #endregion
    // This is the root object giving in and out links
    public abstract class ProgramElement
    {
        public readonly static char[] forbiddenchars=">\"\'<;?!%*".ToCharArray();

        public IResolver Resolver; // Connects to the parent context.
        public LinkedList<ParseFeature> Parsers;
        //public LinkedList<ElementRelationship> Depends;
        //public LinkedList<ElementRelationship> Supports;
        public Dictionary<string, ElementRelationship> Supports, Depends;

        public ElementType ElementType;

        public virtual void ParseDepends()
        {
            
            foreach (ParseFeature p in Parsers)
            {
                // Apply all configured parsers and then resolve the references.
                string[] S = p.parse(this);
                foreach (string s in S)
                {
                    if (s.IndexOfAny(forbiddenchars) > -1)
                    {
                        Console.Out.WriteLine("forbidden char");
                    }
                    else
                    {
                        ElementRelationship R = Resolver.ResolveReference(this.name, s, p.Type);
                        //this.Depends.AddLast(R);
                        if (!this.Depends.ContainsKey(s))
                        {
                            this.Depends.Add(s, R);
                            if (R.Supporter!=null)
                            {
                                R.Supporter.AddSupported(R);
                            }
                        }
                    }
                }
            }
        }
        
         /// <summary>
         /// This is used by the supported file to inform the supporting file that it is, in fact, dependednt on it. 
         /// </summary>
         /// <param name="R">a descriptor of the </param>
        public virtual void AddSupported(ElementRelationship R)
        {
            
            if (!this.Supports.ContainsKey(R.Dependent.name))
            {
                this.Supports.Add(R.Dependent.name, R);
            }
        }

        public virtual void UltimatelyDependent(HashSet<ProgramElement> Predecessors)
        {
            // assume that this item is not a dependent of itself.
            if (this.Depends.Count >0)
            {
                foreach( ElementRelationship r in this.Depends.Values)
                {
                    if (!Predecessors.Contains(r.Supporter))
                    {
                        Predecessors.Add(r.Supporter);
                        r.Supporter.UltimatelyDependent(Predecessors);
                    }
                }
            }
        }
        public string name;
        public string description;
        public bool isPresent;
        public ProgramElement()
        {
            Depends = new Dictionary<string, ElementRelationship>();
            Supports = new Dictionary<string, ElementRelationship>();
            name = "";
            description = "";
            isPresent = false;
            ElementType = ElementType.Unknown;
        }
    }
    // This is a virtual Object - Off-site URLs, Services, 
    public class RumpElement:ProgramElement
    {
        public RumpElement(string CompleteFilename)
        {
            name= CompleteFilename;
            
        }
        public override void ParseDepends()
        {
            // do nothing 
        }
    }
    public class RemoteElement : ProgramElement
    {
        public RemoteElement(string CompleteFilename)
        {
            name = CompleteFilename;
        }
        public override void ParseDepends()
        {
            // do nothing 
        }
    }
    public class SQLElement : ProgramElement
    {
        public string Name = "";
        public string ServerName = "";
        public string Database = "";
        public string Text="";
        public SQLElement(string name, string servername, string database, string text)
        {
            Name = name;
        }
        public override void ParseDepends()
        {
            // do nothing 
        }
    }
    public class COMElement : ProgramElement
    {
        public string ClassID;
        public string CurVer;
        public string Name; 
        public COMElement(string ClassId)
        {
            ClassID = ClassId;

        }
        public override void ParseDepends()
        {
         // Look up  //HKEY_LOCAL_MACHINE/SOFTWARE/Classes/{ClassID}
            Name= Registry.GetValue("HKEY_LOCAL_MACHINE/SOFTWARE/Classes", ClassID, "") as string ;
            if (Name.Length > 0)
            {
                string s = Registry.GetValue(String.Format("HKEY_LOCAL_MACHINE/SOFTWARE/Classes/{0}", ClassID), "", "NOITEM") as string;
            }
        }
    }

    // This is a known non-interpretable object (a DLL, EXE or )
    public class BinElement : ProgramElement
    {
        public BinElement(string CompleteFilename)
        {
            name= CompleteFilename;
        }
        public override void ParseDepends()
        {
            // do nothing 
        }
    }
    
   // This is a text-based component, ASP, XML C or VB
    public class FileElement:ProgramElement
    {
        public string contents="";
        public FileElement(string CompleteFilename)
        {
            this.name = CompleteFilename;
        }
        public override void ParseDepends()
        {
            if (this.Parsers == null) return;   // At construction time, parsers are added. 
            if (this.Parsers.Count == 0) return; // if no parsers added, we can't parse.
            if (contents.Length==0)
            {
                contents = File.ReadAllText(this.name,Encoding.ASCII);            
            }
            base.ParseDepends();
        }
        
    }

    public static class FileTyper
    {
        /* This is the Factory class for the ProgramElement Classes. 
         * 
         * Using the Extensions, it determines which items are text and which are binary.
         * It then adds the right Parsers to the right elements.
         * 
         * 
         * 
         */
        private static string[] texttypes = { ".asp", ".css", ".cs", ".js", ".html",    ".inc", ".txt",".htm", ".asa",     ".vb", 
                                              ".c" , ".aspx", ".xml", ".jscript",       ".xsl",  ".ini", ".htaccess",".asax",".bat",
                                              ".mustache", ".xsd",".csproj",".vdproj",  "dtproj",".cfg",".discomap",".wsdl",".xss",
                                              ".xsc", ".vssscc",".cgi",".ascx",".sln",  ".map",".vbs",".svc",".sql",".config",
                                              ".datasource",".pl",".pm",".lbi",".lck",  ".settings",".database",".dtproj",".user",".dtsx",
                                              ".dtsconfig",".refresh",".tmpl",".htc",".asc",".vspscc",".dbp",".nuspec",".mno",".php",
                                              ".master",".json",".opml",".rb",".transform",".psd1",".psm1",".ps1","" };
        private static string[] bintypes = { ".dll", ".ocx", ".pdf", ".bin", ".gif", ".bmp", ".jpg", ".jpeg", ".png", ".ico", ".exe", ".svg", ".ttf", ".woff", ".scc", ".swf", ".pdb", ".psd1", ".lnk", ".resx", ".suo", ".suo", ".fla", ".swf", ".snk", ".otf", ".mmp", ".tif", ".db", ".eot", ".gz", ".psd", ".doc", ".eps", ".csv", ".pptx", ".nupkg",".cache" };
        private static string[] XMLtypes = {".csproj",".xml",".xls",".xlst"};
        private static int[] textcount = new int[texttypes.Length];
        private static int[] bincount = new int[bintypes.Length];
        private static HashSet<string> ExtraTypes = new HashSet<string>();
        
        public static void AddUnreportedType(string ext)
        {
            ExtraTypes.Add(ext);    

        }
        public static bool iscode(string ext)
        {
            for (int i = 0; i < texttypes.Length; i++)
            {
                if (ext.Equals(texttypes[i]))
                {
                    textcount[i]++;
                    return true;
                }
            }
            return false;
        }
        public static bool isText(string ext)
        {

            for (int i = 0; i < texttypes.Length; i++)
            {
                if (ext.Equals(texttypes[i])) 
                {
                    textcount[i]++;
                    return true;
                    
                }
            }
            return false;
        }
        
        public static bool isBin(string ext)
        {

            for (int i = 0; i < bintypes.Length; i++)
            {
                if (ext.Equals(bintypes[i]))
                {
                    bincount[i]++;
                    return true;
                    
                }
            }
            return false;
        }
        // Task Factory Method
        public static ProgramElement CreateElement(string CompleteFilename)
        {
            string e = Path.GetExtension(CompleteFilename).ToLower();
            if (e.Length == 0)
            {
                //Console.Out.WriteLine(CompleteFilename);
                FileElement R = new FileElement(CompleteFilename);
                AddParsers(R, e);
                R.ElementType = ElementType.TextFile;
                return R;

            }
            if (isText(e))
            {
                FileElement R = new FileElement(CompleteFilename);
                AddParsers(R, e);
                R.ElementType = ElementType.TextFile;
                return R;
            }
            if(isBin(e))
            {
                BinElement R = new BinElement(CompleteFilename);
                R.ElementType = ElementType.BinaryFile;
                return R;
                
            }
            Console.Out.Write("Unknown Type file : " + CompleteFilename);
            ExtraTypes.Add(e);
            return new RumpElement(CompleteFilename);
        }
        public static void AddParsers(ProgramElement El, string Ext )
        {
            if (El.Parsers == null)
            {
                El.Parsers = new LinkedList<ParseFeature>();
            }
            switch (Ext.ToLower())
            {
                case ".css":
                    // url\('*([0-9a-z_\.\/:-]*)'*\);
                    El.Parsers.AddFirst(new XformParser("\n", "\r\n", RelationShipType.RelationNone, "Standardise CRLF"));
                    El.Parsers.AddLast(new RegexParser("url\\('*([0-9a-z_\\.\\/:-]*)'*\\);", RelationShipType.RelationOther,"Css Url Reference"));
                    break;
                    
                case ".cs":
                    El.Parsers.AddLast(new RegexParser("using[\\s](.+);", RelationShipType.RelationCOM,"C# Includes"));
                    break;
                case ".vbs":
                    El.Parsers.AddLast(new RegexParser("call include([\"'](.*)[\"'])", RelationShipType.RelationCOM, "VBScript Includes"));
                    El.Parsers.AddLast(new RegexParser("CreateObject([\"'](.*)[\"'])", RelationShipType.RelationCOM, "VBScript COM Object"));
                    break;
                case ".asp"  :
                    // <!--.*#include.*[virtual*].*="(.+)".*-->
                    El.Parsers.AddLast(new RegexParser("<!--.*#include.*[virtual*].*=\"(.+)\".*-->", RelationShipType.RelationInclude,"ASP Includes"));
                    //
                    El.Parsers.AddLast(new RegexParser("(?i)Server.CreateObject(?-i)\\(\\\"(\\w+.\\w+)\\\"\\)",RelationShipType.RelationCOM,"Server.create object(multiple Languages)"));
                   // El.Parsers.AddLast(new RegexParser("<link.+rel=\\\"stylesheet\\\".+href=\\\"(.*)\\\">", RelationShipType.RelationLink, "Link Tag, Stylesheet property(HTML)"));
                    // 
                    break;
                case ".inc":
                    El.Parsers.AddLast(new RegexParser("<!--.*#include.*[virtual*].*=\"(.+)\".*-->", RelationShipType.RelationInclude,"ASP Includes"));
                    El.Parsers.AddLast(new RegexParser("(?i)Server.CreateObject(?-i)\\(\\\"(\\w+.\\w+)\\\"\\)",RelationShipType.RelationCOM,"Server.create object(multiple Languages)"));
                    break;
                case ".js":
                    El.Parsers.AddLast(new RegexParser("(?i)ActiveXObject(?-i)\\(\\\"(\\w+.\\w+)\\\"\\)",RelationShipType.RelationCOM,"new ActiveXObject Javascript"));
                    break;
                case ".htm" :
                    El.Parsers.AddLast(new RegexParser("<link.+href=[\"'](.*)[\"']>", RelationShipType.RelationOther, "Link Tag"));
                    El.Parsers.AddLast(new RegexParser("<script.+src=[\"'](.*)[\"']>", RelationShipType.RelationOther, "Link Tag"));
                    break;
                case ".html" :
                    El.Parsers.AddFirst(new XformParser("\n", "\r\n", RelationShipType.RelationNone, "Standardise CRLF"));
                    El.Parsers.AddLast(new RegexParser("<link.+href=[\"'](.*)[\"']>", RelationShipType.RelationOther, "Link Tag"));
                    El.Parsers.AddLast(new RegexParser("<script.+src=[\"'](.*)[\"']>", RelationShipType.RelationOther, "Source Tag"));
                    El.Parsers.AddLast(new RegexParser("<source.+src=[\"'](.*)[\"']>", RelationShipType.RelationNone, "Audio Tag"));
                    break;
                case ".txt":
                    break;
                case ".mustache":
                    break;
                case ".php":
                    El.Parsers.AddFirst(new XformParser("\n", "\r\n", RelationShipType.RelationNone, "Standardise CRLF"));
                    El.Parsers.AddLast(new RegexParser("require_once*\\s*\\([\\S]*\\s*\\.\\s*'(.*)'\\);",RelationShipType.RelationInclude,"PHP Require Once"));
                    El.Parsers.AddLast(new RegexParser("require*\\s*\\([\\S]*\\s*\\.\\s*'(.*)'\\);", RelationShipType.RelationInclude, "PHP Require "));
                    El.Parsers.AddLast(new RegexParser("include '(.*)';",RelationShipType.RelationInclude,"PHP include"));
             

                    break;
                    // 
            }   


        }
    }

    /// <summary>
    /// This class Reads the configuration file, creates parser objects and then 
    /// </summary>
    public class ConfigurationEngine
    {

    }


    public interface IResolver
    {
         ElementRelationship ResolveReference(string CompleteFileName, string ReferenceFileName, RelationShipType Type);
    }
    
    public class MachineContext:IResolver 
    {
        private Queue<string> FileNamesToParse = new Queue<string>();

        public Dictionary<string, ProgramElement> Elements;
        private Dictionary<string, ProgramElement> tmpElements; // this is used for adding 'new' items after the initial generation.
        public MachineContext()
        {
            Elements = new Dictionary<string, ProgramElement>();
        }
        public void ReadRoot()
        {
            LoadFolder(RootFolderName, FileNamesToParse);

            while (FileNamesToParse.Count > 0)
            {
                string filename = FileNamesToParse.Dequeue();
                Elements.Add(filename, FileTyper.CreateElement(filename));
            }
            return; 

        }
        public void LoadFolder(string foldername, Queue<string> list)
        {
            if (!Directory.Exists(foldername))
            {
                MessageBox.Show(foldername + " not found");
                return;
            }
            foldername = foldername.ToLower();
            string[] F = Directory.GetFiles(foldername);
            foreach( string  f in F)
                if (!list.Contains(f.ToLower())) { list.Enqueue(f.ToLower()); }

            string[] D = Directory.GetDirectories(foldername);
            foreach (string d in D)
            {
                LoadFolder(d, list);
            }
        }
        public void BuildReferenceWeb()
        {
            tmpElements = new Dictionary<string, ProgramElement>();
            foreach (ProgramElement E in Elements.Values)
            {
                
                E.Resolver = this;
                E.ParseDepends();
            }
            foreach (string s in tmpElements.Keys)
            {
                Elements.Add(s, tmpElements[s]);
                
            }
            
        }
        public string RootFolderName;

        /// <summary>
        /// Combines relative paths. 
        /// </summary>
        /// <param name="CompleteFileName">File From which the reference is being made.</param>
        /// <param name="Stem">The Reference (absolute or relative)</param>
        /// <param name="ContextRoot"></param>
        /// <returns></returns>
        private string PathAdder(string CompleteFileName, string Stem, string ContextRoot="")
        {
            string retval="";

            string fileCurrentDirectory = CompleteFileName.Remove(CompleteFileName.Length - Path.GetFileName(CompleteFileName).Length);
            // rule 1 : 
            // CFN  : C:\wwwroot\inetpub\website1\forums\startrek\Posting.asp
            // Stem : ~happy.asp
            // CR   : C:\wwwroot\inetpub\happy.asp
            if (Stem.IndexOf("~") == 0)
            {

            }
            // rule 2:
            // CFN  : C:\wwwroot\inetpub\website1\forums\startrek\Posting.asp
            // Stem : \happy.asp
            // CR   : C:\wwwroot\inetpub\happy.asp

            // rule 3:
            // CFN  : C:\wwwroot\inetpub\website1\forums\startrek\Posting.asp
            // Stem : ../../Angry/happy.asp
            // CR   : C:\wwwroot\inetpub\Angry\happy.asp

            // rule 3:
            // CFN  : C:\wwwroot\inetpub\website1\forums\startrek\Posting.asp
            // Stem : ./happy.asp
            // CR   : C:\wwwroot\inetpub\website1\forums\startrek\happy.asp



            return retval;

        }
        /// <summary>
        /// Constructs the relationobject and guarantees that the component objects exist in the hash table. 
        /// </summary>
        /// <param name="CompleteFileName">Name of the Dependent Element (calling or including or Linking out to... )</param>
        /// <param name="ReferenceFileName">Name of the Required Element (called, created, loaded, or instantiated)</param>
        /// <param name="Type">The type of reference</param>
        /// <returns>Elementrelationship with object pointers to elements</returns>
        /// Note : Elements can include Absolute filenames (which must be unique) or ClassIDs (similarly unique) or URLS (similarly unique)
        /// While building the list of elements, Put new Elements into tmpElements to avoid issues with Iterator Disruption
        ElementRelationship IResolver.ResolveReference(string CompleteFileName, string ReferenceFileName, RelationShipType Type )
        {
            CompleteFileName = CompleteFileName.ToLower();
            ReferenceFileName = ReferenceFileName.ToLower();
            ElementRelationship retval = new ElementRelationship();
            retval.Dependent = this.Elements[CompleteFileName];
            retval.Relation = Type;

            if (Type == RelationShipType.RelationCOM)
            {
                if (BasicResolve(retval,ReferenceFileName))
                    System.Console.Out.WriteLine("Unknown COM supporter: " + ReferenceFileName);
                retval.Supporter.ElementType=ElementType.COMobject;

                return retval;
            } // End COM relation

            if (Type == RelationShipType.RelationLink)
            { // Must handle Http:// , or relative files (my.css, my.html, /subdir/subsubdir/my.html, ~/Food/my.aspx. 
                if (ReferenceFileName.IndexOf("://") >= 0)
                {
                    // it's an HTTP tag. 
                    if(this.Elements.ContainsKey(ReferenceFileName))
                    {
                        retval.Supporter=Elements[ReferenceFileName];
                        return retval;
                    }else if (this.tmpElements.ContainsKey(ReferenceFileName))
                    {
                         retval.Supporter=tmpElements[ReferenceFileName];
                         return retval;
                    }
                    else 
                    {

                    }
                    
                }
            }
            if (Type == RelationShipType.RelationInclude )
            {

                // have to make sure that paths are appropriately combined. 
                // Given c:\p1\p2\p3\p4\source.txt and ..\..\inc\foo\myfile.txt give :

                if (ReferenceFileName.Contains("/")) ReferenceFileName = ReferenceFileName.Replace("/", "\\");
                string b = CompleteFileName.Remove(CompleteFileName.Length - Path.GetFileName(CompleteFileName).Length);
                string c = Path.GetFullPath(RootFolderName + ReferenceFileName).ToLower(); 
                string a = Path.GetFullPath(b + ReferenceFileName).ToLower();

                if (this.Elements.ContainsKey(a))
                {
                    retval.Supporter = this.Elements[a];
                    return retval;
                }
                else if (this.Elements.ContainsKey(c))
                {
                        retval.Supporter = this.Elements[c];
                        return retval;
                }
                else if (this.tmpElements.ContainsKey(a))
                {
                        retval.Supporter = this.tmpElements[a];
                        return retval;
                }
                System.Console.Out.WriteLine("Unknown File supporter: " + a);
                ProgramElement R = new RumpElement(a);
                R.ElementType = ElementType.BinaryFile;
                tmpElements.Add(a, R);
                retval.Supporter = R;
                return retval;
            }

            return retval;

            
        }

        /// <summary>
        /// Performs the basic check for the value in the existing hash tables, so we don't do it for every single type of element
        /// </summary>
        /// <param name="relObj">Existing relation object</param>
        /// <param name="a">Name of the resource</param>
        /// <returns>Returns whether the item was created or successfully added.</returns>
        private bool BasicResolve(ElementRelationship relObj, string a)
        {
            bool retval=false;
            if (this.Elements.ContainsKey(a))
                {
                    relObj.Supporter = this.Elements[a];
                }
                else if (tmpElements.ContainsKey(a))
                {
                    relObj.Supporter = tmpElements[a];
                }
            else
            {
                System.Console.Out.WriteLine("Unknown supporter: " + a);
                ProgramElement R = new RumpElement(a);
                tmpElements.Add(a, R);
                relObj.Supporter = R;
                retval=true;
            }
            return retval;
        }


    }


}

