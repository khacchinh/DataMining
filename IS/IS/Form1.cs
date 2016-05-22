using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS
{
    public partial class Form1 : Form
    {
        //private String test;
        private String path = "";
        private int K = 10;
        private static List<Class> class_Items = new List<Class>();
        private List<List<String>> all_data = null;
        private List<Distance> distance;
        private String class_result;
        private List<String> trainData = new List<string>();
        private List<String> testData = new List<string>();
        private List<String> testDataTrueClass = new List<string>();
        private List<String> testDataPredictClass = new List<string>();



        public Form1()
        {
            InitializeComponent();
        }

        internal static void addClass(Class class_item){
            class_Items.Add(class_item);
        }
        
        private void opneFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOpenFile.Text = openFileDialog1.FileName;
                path = txtOpenFile.Text;
                readFile();
            }
        }

        private void readFile()
        {
            int ins = 0;
            //class_Items = new List<Class>();
            all_data = ReadFile.readDataFromFile(path, ref ins);
            lblIns.Text = "Instance: " + ins.ToString();
            showClasses();
            addDataToListView();
        }

        private void showClasses()
        {
            String str = "Classes: ";
            for (int i = 0; i < class_Items.Count; i++)
                str += class_Items[i].Class_Item + " ";
            lblClass.Text = str;
        }

        private void addDataToListView()
        {
            lvData.Items.Clear();
            lvData.View = View.Details;
            lvData.GridLines = true;
            lvData.FullRowSelect = true;
            for (int i = 0; i < all_data[0].Count; i++) //header
            {
                lvData.Columns.Add(all_data[0][i], 67);
            }

            String[] arr_line = null;
            for (int i = 0; i < all_data[1].Count; i++) //data
            {
                arr_line = all_data[1][i].Split(',');
                ListViewItem item = new ListViewItem(arr_line);
                lvData.Items.Add(item);
            }
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            distance = new List<Distance>();
            class_result = "";
            //test = "";
            K = 0;
            lblResult.Text = "Class of test is: ";
            lblTest.Text = "";
            K = Int32.Parse(txtK.Text);

            testDataPredictClass.Clear();
            testDataTrueClass.Clear();
            distance.Clear();
            trainData.Clear();
            testData.Clear();
            listView2.Clear();

            splitArray(all_data[1], trainData, testData);
            calculateAccuracy();

        }

        private void splitArray(List<String> input, List<String> trainData, List<String> testData)
        {            
            Random ran = new Random();

            int trainCount;
            trainCount = (int) (input.Count() * 0.3) - 1;
            int testCount = input.Count()-trainCount;
           
            List<String> tempi = new List<string>(input);

            for (int i = 0; i < trainCount; i++)
            {
                int a = ran.Next(0, tempi.Count());
                trainData.Add(tempi[a]);
                tempi.RemoveAt(a);
            }

            testData.AddRange(tempi);
        }

        private void calculateAccuracy()
        {
            distance = new List<Distance>();

            // lấy class thật vào array
            for (int i = 0; i < testData.Count; i++)
            {
                string[] temp = testData[i].Split(',');
                testDataTrueClass.Add(temp[temp.Length-1]);
            }

            // predict class
            for (int i = 0; i < testData.Count; i++)
            {
                testDataPredictClass.Add(caculateDistance(trainData, distance, testData[i]));
                class_result = null;
            }

            //show
            listView2.Items.Clear();
            listView2.View = View.Details;
            listView2.GridLines = true;
            listView2.FullRowSelect = true;

            listView2.Columns.Add("Predict class", 67);
            listView2.Columns.Add("True class", 67);
            listView2.Columns.Add("==", 67);

            List<String> a = new List<string>();
            int count = 0;
            for (int i = 0; i < testDataPredictClass.Count; i++)
            {
                if (testDataPredictClass[i].ToString() == testDataTrueClass[i].ToString())
                    count++;

                a.Add(testDataPredictClass[i].ToString());
                a.Add(testDataTrueClass[i].ToString());
                a.Add(count.ToString());
                ListViewItem item = new ListViewItem(a.ToArray());
                listView2.Items.Add(item);
                a.Clear();
            }
            float acc = ((float)count / (float)testDataPredictClass.Count);
            lblAcc.Text = "Accuracy: " + acc.ToString() + "   /  " + count.ToString() + "  /  " + testDataPredictClass.Count.ToString();

            
        }
        
        private void calculateMinFucDis(List<String> trainData, List<Distance> distance,String testString)
        {
            String[] arr_data = null, arr_test = testString.Split(',');

            int temp_i;
            double temp_d;
            for (int i = 0; i < trainData.Count; i++)
            {
                Distance dis_obj = new Distance();
                double dis = 0.0;
                arr_data = trainData[i].Split(',');
                for (int j = 0; j < arr_data.Length - 1; j++)
                {
                    if (Int32.TryParse(arr_data[j], out temp_i))
                        dis  += Math.Pow(Int32.Parse(arr_test[j]) - temp_i, 2);
                    else if (Double.TryParse(arr_data[j], out temp_d))
                        dis += Math.Pow(Double.Parse(arr_test[j]) - temp_d, 2);
                    else if (!arr_test[j].Equals(arr_data[j]))
                        dis++;
                    //dis = Math.Sqrt(dis);
                }
                dis_obj.Dis = dis;
                dis_obj.Index = i;
                distance.Add(dis_obj);
                
            }
        }

        private String caculateDistance(List<String> trainData, List<Distance> distance, String testString)
        {
            calculateMinFucDis(trainData, distance ,testString);
            sortDistance(distance);
            return getResultMining(trainData, distance);
        }

        private void sortDistance(List<Distance> distance)
        {
            for (int i = 0; i < distance.Count; i++)
            {
                for (int j = distance.Count - 1; j > i; j--)
                {
                    if (distance[i].Dis > distance[j].Dis)
                    {
                        Distance temp_obj = distance[i];
                
                        distance[i] = distance[j];
                        distance[j] = temp_obj;
                    }
                }
            }
        }

        private String getResultMining(List<String> list_String, List<Distance> distance)
        {
            //đếm số lượng từng class trong khoảng k
            for (int i = 0; i < K; i++)
            {
                String[] str = list_String[distance[i].Index].Split(',');
                for (int j = 0; j < class_Items.Count; j++)
                {
                    if (class_Items[j].Class_Item.Equals(str[str.Length - 1]))
                        class_Items[j].Counter++;
                }
            }

            ////dựa vào số lượng từng class => kết quả
            String str_index = "";
            int local_sum = class_Items[0].Counter;
            int index = 0;
            for (int i = 1; i < class_Items.Count; i++)
            {
                if (local_sum < class_Items[i].Counter)
                {
                    local_sum = class_Items[i].Counter;
                    index = i;
                }
            }
            class_result = class_Items[index].Class_Item;

            //TH =
            for (int i = 0; i < class_Items.Count; i++)/////count-1
            {
                for (int j = 0; j < class_Items.Count; j++)///// j=1
                {
                    if (class_Items[i].Counter == class_Items[j].Counter && i != j && class_Items[i].Counter >= local_sum)///?????????
                        str_index += i.ToString() + ",";
                }
            }

            if (!str_index.Equals(""))
            {
                String[] str_test = str_index.Split(',');
                double total = 0.0;
                index = 0;
                for (int i = 0; i < str_test.Length - 1; i++)
                {
                    double temp = 0.0;
                    for (int j = 0; j < K; j++)
                    {
                        String[] str = list_String[distance[j].Index].Split(',');
                        if (class_Items[Int32.Parse(str_test[i])].Class_Item.Equals(str[str.Length - 1]))
                        {
                            temp += distance[j].Dis;
                        }
                    }
                    if (total == 0.0) total = temp;
                    if (total > temp)
                    {
                        total = temp;
                        index = Int32.Parse(str_test[i]);
                    }
                }
                class_result = class_Items[index].Class_Item;   
            }
            distance.Clear();
            //return class_Items[index].Class_Item;
            return class_result;
        }

        private void getResultToForm()
        {
            lblResult.Text = "Class of test is: " + class_result;
            lblTest.Text = "Test: " + txtTest.Text;
            for (int i = 0; i < class_Items.Count; i++)
                class_Items[i].Counter = 0;
        }

        private void btn_Test1_Click(object sender, EventArgs e)
        {
            splitArray(all_data[1], trainData, testData);
            distance = new List<Distance>();
            class_result = "";
            //test = "";
            K = 0;
            lblResult.Text = "Class of test is: ";
            lblTest.Text = "";
            if (txtTest.Text.Equals(""))
                MessageBox.Show("Test NULL");
            else if (txtK.Text.Equals(""))
                MessageBox.Show("K NULL");
            else
            {
                //test = txtTest.Text;
                K = Int32.Parse(txtK.Text);
                caculateDistance(trainData, distance, txtTest.Text);
                //getResultMining(trainData, distance);
                getResultToForm();
            }
        }

    }
}
