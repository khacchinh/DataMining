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
        private String test;
        private String path = "";
        private int K = 10;
        private static List<Class> class_Items = new List<Class>();
        private List<List<String>> all_data = null;
        private List<List<String>> all_data_without_class = null;
        private List<Distance> distance;
        private String class_result;
        List<String> trainData = new List<string>();
        List<String> testData = new List<string>();
        List<String> testDataTrueClass = new List<string>();
        List<String> testDataPredictClass = new List<string>();



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
            all_data_without_class = all_data;
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
            txtTest.Text = all_data[1][1];
            calculateAccuracy();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            distance = new List<Distance>();
            class_result = "";
            test = "";
            K = 0;
            lblResult.Text = "Class of test is: ";
            lblTest.Text = "";
            if (txtTest.Text.Equals(""))
                MessageBox.Show("Test NULL");
            else if (txtK.Text.Equals(""))
                MessageBox.Show("K NULL");
            else
            {
                test = txtTest.Text;
                K = Int32.Parse(txtK.Text);
                caculateDistance(all_data, distance);
                //caculatorDistance(all_data, distance);
                getResultMining(all_data, distance);
            }

        }

        private void calculateAccuracy()
        {
            

            // get data to train and test array
            for (int i = 0; i < all_data[1].Count; i++)
            {
                if (i <= (all_data[1].Count * 0.7)-1)
                {
                    trainData.Add(all_data[1][i]);
                    ListViewItem item = new ListViewItem(trainData.Last());
                    //listView2.Items.Add(item);
                }
                else
                {
                    testData.Add(all_data[1][i]);
                    ListViewItem item = new ListViewItem(testData.Last());
                    //listView2.Items.Add(item);
                }
            }

            // lấy class thật vào array
            for (int i = 0; i < all_data[1].Count; i++)
            {
                string[] temp = testData[1].Split(',');
                testDataTrueClass.Add(temp[temp.Length-1]);
                ListViewItem item = new ListViewItem(testDataTrueClass.Last());
                listView2.Items.Add(item);
            }

            // mỗi dòng trong test
            for (int i = 0; i < testData.Count; i++)
            {
                // viết cho tui hàm getClassOfInstance();
                //testDataPredictClass[i] = getClassOfInstance(trainData,testData[i]);
                //if (testDataPredictClass[i] == testDataTrueClass[i])
                
                    
            }
            

        }

        private void caculateDistance(List<List<String>> list_String, List<Distance> distance)
        {
            String[] arr_data = null, arr_test = test.Split(',');

            int temp_i;
            double temp_d;
            ////// thêm điều kiện ko có file, dữ liệu sai....
            for (int i = 0; i < list_String[1].Count; i++)
            {
                Distance dis_obj = new Distance();
                double dis = 0.0;
                arr_data = list_String[1][i].Split(',');
                for (int j = 0; j < arr_data.Length - 1; j++)
                {
                    if (Int32.TryParse(arr_data[j], out temp_i))
                        dis += Math.Pow(Int32.Parse(arr_test[j]) - temp_i, 2);
                    else if (Double.TryParse(arr_data[j], out temp_d))
                        dis += Math.Pow(Double.Parse(arr_test[j]) - temp_d, 2);
                    else if (!arr_test[j].Equals(arr_data[j]))
                        dis++;
                }
                dis_obj.Dis = dis;
                dis_obj.Index = i;
                distance.Add(dis_obj);
            }
            sortDistance(distance);
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

        private void getResultMining(List<List<String>> list_String, List<Distance> distance)
        {
            //đếm số lượng từng class trong khoảng k
            for (int i = 0; i < K; i++)
            {
                String[] str = list_String[1][distance[i].Index].Split(',');
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
                        String[] str = list_String[1][distance[j].Index].Split(',');
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
            lblResult.Text = "Class of test is: " + class_result;
            lblTest.Text = "Test: " + txtTest.Text;
            for (int i = 0; i < class_Items.Count; i++)
                class_Items[i].Counter = 0;
        }

    }
}
