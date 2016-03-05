using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1
{
    public partial class Form1 : Form
    {
        public double saveNum;
        public bool prov;
        public string oper;
        public double save;
        public double memNum;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {//функция нажатия на цифру
            Button btn_clicked = (Button)sender;
            if(btn_clicked.Text == ",")
            {
                if (!windowView.Text.Contains(","))
                {
                    this.windowView.Text += btn_clicked.Text;
                }
                return;
            }
            if ((this.windowView.Text == "0" ) || prov)
            {
                prov = false;
                this.windowView.Text = btn_clicked.Text;
            }
            else
            {
                this.windowView.Text += btn_clicked.Text;
            }
             
        }

        private void operation_Click(object sender, EventArgs e)
        {//функция нажатия на операцию(сложение, делить и т.д.)
            
            if (saveNum != 0)
            {
                this.result_Click(sender, e);// когда не нажимая равно нажимаем след операцию
            }
            

            saveNum = double.Parse(this.windowView.Text);
            prov = true;
            Button op_click = (Button)sender;
            oper = ((Button)sender).Text;//отправка операции
            Console.WriteLine(saveNum);
            
        }

        private void result_Click(object sender, EventArgs e)
        {// функция результата(равно)

            double resultOperation = 0;

            if (oper == "+")
            {
                resultOperation = saveNum + double.Parse(this.windowView.Text);
                
            }
            else if (oper == "-")
            {
                resultOperation = saveNum - double.Parse(this.windowView.Text);
            }
            else if (oper == "x")
            {
                resultOperation = saveNum * double.Parse(this.windowView.Text);
            }
            else if (oper == "/")
            {
                resultOperation = saveNum / double.Parse(this.windowView.Text);
            }
            else if (oper == "1/x")
            {
                resultOperation = 1 / double.Parse(this.windowView.Text);
            }
            else if (oper == "Sqrt")
            {
                resultOperation = Math.Sqrt(double.Parse(this.windowView.Text));
            }
            else if (oper == "sin(x)")
            {
                resultOperation = Math.Sin(double.Parse(this.windowView.Text) * Math.PI / 180);
            }
            else if (oper == "cos(x)")
            {
                resultOperation = Math.Cos(double.Parse(this.windowView.Text) * Math.PI / 180);
            }
            else if (oper == "ln")
            {
                resultOperation = Math.Log(double.Parse(this.windowView.Text));
            }
            
            save = resultOperation;
            this.windowView.Text = resultOperation.ToString();
            prov = true;
            saveNum = 0;
            
        }

        private void clear_Click(object sender, EventArgs e)
        {
            saveNum = 0;
            save = 0;
            prov = false;
            oper = "";
            this.windowView.Text = "0";
        }


        private void operationMinPlus_Click(object sender, EventArgs e)
        {
            double num = double.Parse(this.windowView.Text);
            num *= -1;
            this.windowView.Text = num.ToString();
        }

        private void buttonMemory_Click(object sender, EventArgs e)
        {
            Button mem = (Button)sender;
            if( mem.Text == "MS")
            {
                memNum = double.Parse(this.windowView.Text);
            }
            else if ( mem.Text == "MR" )
            {
              this.windowView.Text = memNum.ToString();
            }
            else if ( mem.Text == "M+" )
            {
                memNum += double.Parse(this.windowView.Text);
            }
            else if ( mem.Text == "MC")
            {
                memNum = 0;
            }
        }

        private void BackOp(object sender, EventArgs e)
        {
            if (windowView.Text.Length != 0 && this.windowView.Text != "0")
            {
                this.windowView.Text = windowView.Text.Substring(0, windowView.Text.Length - 1);
            }
            else
            {
                this.windowView.Text = "0";
            }
            
        }
    }
}



//Для нажатия на равно несколько раз доработать
    //if (save != 0)// когда равно несколько раз нажимаешь
    //{

//    Console.WriteLine("double=");
//    double saveResultOperation = 0;
//    if (oper == "+")
//    {
//        saveResultOperation = double.Parse(this.windowView.Text) + save;// то что на экране + сохраненное число

//    }
//    else if (oper == "-")
//    {
//        saveResultOperation = double.Parse(this.windowView.Text) - save;
//    }
//    else if (oper == "x")
//    {
//        saveResultOperation = double.Parse(this.windowView.Text) * save;
//    }
//    else if (oper == "/")
//    {
//        saveResultOperation = double.Parse(this.windowView.Text) / save;
//    }
//    else if (oper == "1/x")
//    {
//        saveResultOperation = 1 / save;
//    }
//    else if (oper == "Sqrt")
//    {
//        saveResultOperation = Math.Sqrt(save);
//    }

//    this.windowView.Text = saveResultOperation.ToString();
//    prov = true;
//    return;
//}