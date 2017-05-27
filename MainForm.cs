using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttributeGrammer {
    public partial class MainForm : Form {



        public MainForm()
        {
            InitializeComponent();
            txtGrammarRules.Text = "*-/*+abcdef";
            this.Height = 200;
        }


        public static bool Isoperator(String s) {
            if (s[0] == '*' || s[0] == '/' || s[0] == '$'
                || s[0] == '%' || s[0] == '+' || s[0] == '-') {
            return true;
        }
        return false;
        }

        

        // Prefix To Infix 
        public static String preToIn(String s) {
        ArrayStack stack = new ArrayStack(20);
        String a, b, test;
        for (int i = 0; i != s.Length; i++) {
            test = "" + s[i];
            if (Isoperator(test)) {
                stack.push(test);
            } else {
                if (!Isoperator(stack.gettop())) {
                    a = stack.pop();
                    b = stack.pop();
                    test = "" + a + b + test + "";
                }
                stack.push(test);
            }
        }
        return stack.pop();
    }



        private void button1_Click(object sender, EventArgs e)
        {
            txtProductionRules.Text = preToIn(txtGrammarRules.Text);
            this.Height = 380;
            
        }
        static String s;
        static int temp = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            listAtoms.Items.Clear();
            temp = 0;
            s =txtProductionRules.Text;

          //  List<String> pluses = new List<String>();
            List<String> Result = new List<String>();

             getResult(Result);
           
            //catch
            //{
            //    MessageBox.Show("Incorrect ");
            //}
            foreach (var item in Result)
            {
                listAtoms.Items.Add(item);
            }
            this.Height = 600;




        }
         void getResult(List<String> Result)
        {

            // Perform Multiplication and Divition
            for (int i = 1; i < s.Length; i++)
            {
                // perform multiplication First : 

                if (s[i] == '*')
                {
                    if (Isoperator(  s[i-1].ToString()) || Isoperator(s[i+1].ToString())){
                        MessageBox.Show(" Incorrect input"); listAtoms.Items.Clear();

                        return;
                    }
                    
                    Result.Add("MUL  " + s[i - 1] + " " + s[i + 1] + "  ==> " + temp);
                    s = s.Replace(s[i - 1] + "*" + s[i + 1], Convert.ToString(temp++));
                    i = 0;
                    
                }
                else if (s[i] == '/')
                {
                    if (Isoperator(  s[i-1].ToString()) || Isoperator(s[i+1].ToString())){
                        MessageBox.Show(" Incorrect input");
                        return;
                    }
                    Result.Add("Div  " + s[i - 1] + " " + s[i + 1] + "  ==> " + temp);
                    s = s.Replace(s[i - 1] + "/" + s[i + 1],  Convert.ToString(temp));
                    i = 0;
                    temp++;
                }

            }
            // PrintRes();
            // Perform Addition
            for (int i = 1; i < s.Length; i++)
            {

                // perform multiplication First : 
                if (s[i] == '+')
                {
                    if (Isoperator(  s[i-1].ToString()) || Isoperator(s[i+1].ToString())){
                        MessageBox.Show(" Incorrect input"); listAtoms.Items.Clear();

                        
                        return;
                    }

                    Result.Add("ADD  " + s[i - 1] + " " + s[i + 1] + "  ==> " + temp);
                    s = s.Replace(s[i - 1] + "+" + s[i + 1],  Convert.ToString(temp));
                    i = 0;
                    temp++;
                }
                else if (s[i] == '-')
                {
                    if (Isoperator(  s[i-1].ToString()) || Isoperator(s[i+1].ToString())){
                        MessageBox.Show(" Incorrect input"); listAtoms.Items.Clear();

                        return;
                    }

                    Result.Add("Sub  " + s[i - 1] + " " + s[i + 1] + "  ==> " + temp);
                    s = s.Replace(s[i - 1] + "-" + s[i + 1],  Convert.ToString(temp));
                    i = 0;
                    temp++;
                }
            }
            
        }
       





    }
}
