using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace library
{
    public partial class Library : Form
    {
        private string connectionString = @"Server=LAPTOP-HN6USHOM\IMRANSQL; Database=Library; Integrated Security=True";
        private SqlConnection sqlConnection;

        //Command
        private string commandString;
        private SqlCommand sqlCommand;

        public Library()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string commandString = @" INSERT INTO book(book_id, book_name, write_name, quantity, dept)values('" + bookid.Text + "','" + addbook.Text + "','" + addwriter.Text + "','" + quantity.Text + "','" + comboBox1.Text + "')";
             sqlCommand = new SqlCommand(commandString, sqlConnection);

            int a = sqlCommand.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("upload succesfully");
            }

            sqlConnection.Close();
        }
    
        private void Show_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;


                String commandString = @"SELECT *FROM book";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    DataTable dataTable = new DataTable();

                    dataTable.Load(dataReader);
                    dataGridView1.DataSource = dataTable;
                }
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }




        private void add_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string commandString = @" INSERT INTO students(student_id,student_name,Date,dept)values('" + stdId.Text + "','" + stdname.Text + "','" + date.Text + "','" + deptcomboBox2.Text + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            int a = sqlCommand.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("upload succesfully");
            }

            sqlConnection.Close();

        }

        private void studentbtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;


                String commandString = @"SELECT *FROM students";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    DataTable dataTable = new DataTable();

                    dataTable.Load(dataReader);
                    dataGridView2.DataSource = dataTable;
                }
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            string book__id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string book_name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string write_name = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            richTextBox1.Text = book__id;
            richTextBox2.Text = book_name;
            richTextBox3.Text = write_name;
        }

        private void borrowBook_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string commandString = @" INSERT INTO borrow(book_id,student_id,book_name,writer_name,date)values('" + richTextBox1.Text + "','" + richTextBox4.Text + "','" + richTextBox2.Text + "','" + richTextBox3.Text + "','" + dateTimePicker1.Text + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            int a = sqlCommand.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Book Borrowed succesfully ");
            }

            sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;


                String commandString = @"SELECT *FROM borrow";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    DataTable dataTable = new DataTable();

                    dataTable.Load(dataReader);
                    dataBorrow.DataSource = dataTable;
                }
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void return3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string commandString = @"Delete From borrow where student_id='" + richTextBox4.Text + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            int a = sqlCommand.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Book Return succesfully ");
            }

            sqlConnection.Close();
        }



        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

      
    }
}
