using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurcovaraboTA
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();

            //Form2 PF = new Form2();
            //
            //if (PF.ShowDialog() == DialogResult.Cancel)
            //    Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {


        }
        public string qwe;

        public void metod(string qwe)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gnom9\source\repos\CurcovaraboTA\CurcovaraboTA\Database.mdf;Integrated Security=True";

            SqlConnection myConnection = new SqlConnection(connectionString);

            myConnection.Open();

            string query = qwe;

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[8]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
                //"Select Sum(Price * quantity)FROM Products";
            }

            reader.Close();

            myConnection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string qwe = "SELECT * FROM Products ORDER BY id";
            metod(qwe);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gnom9\source\repos\CurcovaraboTA\CurcovaraboTA\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Products] (Id, NameShop,Adress,Code,NameProducts,quantity,Price)" +
                "VALUES (@Id, @NameShop,@Adress,@Code,@NameProducts,@quantity,@Price)", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox6.Text);
                command.Parameters.AddWithValue("NameShop", textBox5.Text);
                command.Parameters.AddWithValue("Adress", textBox4.Text);
                command.Parameters.AddWithValue("Code", textBox3.Text);
                command.Parameters.AddWithValue("NameProducts", textBox2.Text);
                command.Parameters.AddWithValue("quantity", textBox1.Text);
                command.Parameters.AddWithValue("Price", textBox14.Text);

                await sqlConnection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void инструкцияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            SqlDataReader sqlReader = null;

            qwe = "SELECT * FROM[Products]";

            SqlCommand command = new SqlCommand(qwe, sqlConnection);
            try
            {
                metod(qwe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gnom9\source\repos\CurcovaraboTA\CurcovaraboTA\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
                !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) &&
                !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) &&
                !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text) &&
                !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text) &&
                !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Products] SET [NameShop]=@NameShop" +
                    ",[Adress]= @Adress,[Code]=@Code,[NameProducts]=@NameProducts,[quantity]=@quantity" +
                    ",[Price]=@Price WHERE [Id]= @Id", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox12.Text);
                command.Parameters.AddWithValue("NameShop", textBox15.Text);
                command.Parameters.AddWithValue("Adress", textBox11.Text);
                command.Parameters.AddWithValue("Code", textBox10.Text);
                command.Parameters.AddWithValue("NameProducts", textBox9.Text);
                command.Parameters.AddWithValue("quantity", textBox8.Text);
                command.Parameters.AddWithValue("Price", textBox7.Text);

                await sqlConnection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text))
            {
                MessageBox.Show("Заполните Id");
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
        private async void button7_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gnom9\source\repos\CurcovaraboTA\CurcovaraboTA\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);
            if (!string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Products] SET [NameShop]=@NameShop WHERE [Id]= @Id", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox12.Text);
                command.Parameters.AddWithValue("NameShop", textBox15.Text);

                await sqlConnection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text))
            {
                MessageBox.Show("Заполните Id");
            }
            else
            {
                MessageBox.Show("Вы забыли добавить название магазина");
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gnom9\source\repos\CurcovaraboTA\CurcovaraboTA\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);
            if (!string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Products] SET [Adress] = @Adress WHERE [Id]= @Id", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox12.Text);
                command.Parameters.AddWithValue("Adress", textBox11.Text);

                await sqlConnection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text))
            {
                MessageBox.Show("Заполните Id");
            }
            else
            {
                MessageBox.Show("Вы забыли добавить адресс");
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gnom9\source\repos\CurcovaraboTA\CurcovaraboTA\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);
            if (!string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Products] SET [Code]=@Code WHERE [Id]= @Id", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox12.Text);
                command.Parameters.AddWithValue("Code", textBox10.Text);

                await sqlConnection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text))
            {
                MessageBox.Show("Заполните Id");
            }
            else
            {
                MessageBox.Show("Вы забыли добавить артикул продукта");
            }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gnom9\source\repos\CurcovaraboTA\CurcovaraboTA\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);
            if (!string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Products] SET [NameProducts]=@NameProducts WHERE [Id]= @Id", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox12.Text);
                command.Parameters.AddWithValue("NameProducts", textBox9.Text);

                await sqlConnection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text))
            {
                MessageBox.Show("Заполните Id");
            }
            else
            {
                MessageBox.Show("Вы забыли добавить название продукта");
            }

        }
        private async void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gnom9\source\repos\CurcovaraboTA\CurcovaraboTA\Database.mdf;Integrated Security=True";

                sqlConnection = new SqlConnection(connectionString);
                if (!string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                    !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
                {
                    SqlCommand command = new SqlCommand("UPDATE [Products] SET [quantity]=@quantity WHERE [Id]= @Id", sqlConnection);

                    command.Parameters.AddWithValue("Id", textBox12.Text);
                    command.Parameters.AddWithValue("quantity", textBox8.Text);

                    await sqlConnection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
                else if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text))
                {
                    MessageBox.Show("Заполните Id");
                }
                else
                {
                    MessageBox.Show("Вы забыли добавить количество продукта");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный формат ввода", ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gnom9\source\repos\CurcovaraboTA\CurcovaraboTA\Database.mdf;Integrated Security=True";

                sqlConnection = new SqlConnection(connectionString);
                if (!string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                    !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    SqlCommand command = new SqlCommand("UPDATE [Products] SET [Price]=@Price WHERE [Id]= @Id", sqlConnection);

                    command.Parameters.AddWithValue("Id", textBox12.Text);
                    command.Parameters.AddWithValue("Price", textBox7.Text);

                    await sqlConnection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
                else if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text))
                {
                    MessageBox.Show("Заполните Id");
                }
                else
                {
                    MessageBox.Show("Вы забыли добавить цену");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный формат ввода", ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gnom9\source\repos\CurcovaraboTA\CurcovaraboTA\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            if (!string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Products] WHERE [Id]=@Id", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox13.Text);
                await sqlConnection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                MessageBox.Show("Заполните Цену!");
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox12.Clear();
            textBox15.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox7.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
            textBox14.Clear();
            textBox6.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox13.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        public void metod2(string qwe)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gnom9\source\repos\CurcovaraboTA\CurcovaraboTA\Database.mdf;Integrated Security=True";

            SqlConnection myConnection1 = new SqlConnection(connectionString);
            myConnection1.Open();

            string query = qwe;

            SqlCommand command1 = new SqlCommand(query, myConnection1);

            SqlDataReader reader1 = command1.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader1.Read())
            {
                
                    data.Add(new string[4]);

                    data[data.Count - 1][0] = reader1[0].ToString();
                    data[data.Count - 1][1] = reader1[1].ToString();
                    data[data.Count - 1][2] = reader1[2].ToString();
                    data[data.Count - 1][3] = reader1[3].ToString();

                    //"Select Sum(Price * quantity)FROM Products";
                
            }

            reader1.Close();

            myConnection1.Close();

            foreach (string[] s in data)
                dataGridView2.Rows.Add(s);
        }
    


        private async void button13_Click(object sender, EventArgs e)
        {
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gnom9\source\repos\CurcovaraboTA\CurcovaraboTA\Database.mdf;Integrated Security=True";
            //
            //sqlConnection = new SqlConnection(connectionString);
            dataGridView2.Rows.Clear();
            string qwe = "SELECT Id,NameShop,quantity,NameProducts FROM Products ORDER BY Id";
            metod2(qwe);

            //await sqlConnection.OpenAsync();
            

        }
    }
}

            
