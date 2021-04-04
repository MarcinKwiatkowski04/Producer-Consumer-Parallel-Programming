using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProducentKonsumentWPF
{
    /// <summary>
    /// Interaction logic for WieluProd1Kons.xaml
    /// </summary>
    public partial class WieluProd1Kons : Window
    {
        static string connectionString = "Data Source=LAPTOP-564H2LL3;Initial Catalog=PK;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public static Label prodlabel1;
        public static int storageSize;


        public WieluProd1Kons()
        {
            InitializeComponent();
            UruchomWątki();

        }


        Random rand = new Random();
        static BlockingCollection<int> Buffer = new BlockingCollection<int>();
        public int BufferSize = storageSize;
        static int BufferEmptyPlaces = storageSize;


        int produkt = 0;
        public void Produce(BlockingCollection<int> buffer, int nrProd)
        {

            
            int index = 0;
            bool canProduce = false;
            while (true)
            {
                if (connection.State != ConnectionState.Open) connection.Open();

                if (BufferEmptyPlaces == 0 || BufferEmptyPlaces == storageSize)
                {

                    canProduce = false;
                    while (!canProduce)
                    {

                        Thread.Sleep(10);
                        if (BufferEmptyPlaces > 0)
                        {
                            canProduce = true;
                        }
                    }
                }

                Dispatcher.Invoke(new Action(() =>
                {
                    producerListbox.Items.Add("Producent " + nrProd + " wyprodukował produkt nr " + produkt);
                    producerListbox.SelectedIndex = producerListbox.Items.Count - 1;
                    producerListbox.ScrollIntoView(producerListbox.SelectedItem);
                }));
                Thread.Sleep(rand.Next(1000));

                Dispatcher.Invoke(new Action(() =>
                {
                    string queryAddItem = "INSERT INTO Magazyn (Produkt) VALUES ( " + produkt + ")";
                    SqlCommand cmdAddItem = new SqlCommand(queryAddItem, connection);
                    cmdAddItem.ExecuteScalar();
                }));


                Dispatcher.Invoke(new Action(() =>
                {
                    string queryGetItem = "SELECT Produkt FROM Magazyn where Produkt = " + produkt;
                    SqlCommand cmdGetItem = new SqlCommand(queryGetItem, connection);
                    produkt = Int32.Parse(cmdGetItem.ExecuteScalar().ToString());
                    warehouseListbox.Items.Add(produkt);
                }));


                Thread.Sleep(10);
                buffer.Add(produkt);
                BufferEmptyPlaces--;
                produkt++;
                index++;

                connection.Close();
            }

        }

        public void Consume(BlockingCollection<int> buffer)
        {


            int index = 0;
            while (true)
            {
                // connection.Open();

                foreach (var i in buffer.GetConsumingEnumerable())
                {

                    Dispatcher.Invoke(new Action(() =>
                    {
                        consumerListbox.Items.Add("Konsumuję produkt nr " + i);
                        consumerListbox.SelectedIndex = consumerListbox.Items.Count - 1;
                        consumerListbox.ScrollIntoView(consumerListbox.SelectedItem);
                        warehouseListbox.Items.Remove(i);
                    }));

                    Dispatcher.Invoke(new Action(() =>
                    {
                        string queryRemoveItem = "DELETE FROM Magazyn WHERE Produkt = " + i;
                        SqlCommand cmdRemoveItem = new SqlCommand(queryRemoveItem, connection);
                        cmdRemoveItem.ExecuteScalar();
                    }));

                    Thread.Sleep(rand.Next(2000));

                    Thread.Sleep(20);
                    index++;
                    BufferEmptyPlaces++;
                }

                // connection.Close();
            }

        }
        public Task UruchomWątki()
        {
            connection.Open();

            string queryRemoveItems = "DELETE FROM Magazyn";
            SqlCommand cmdRemoveItems = new SqlCommand(queryRemoveItems, connection);
            cmdRemoveItems.ExecuteScalar();

            string queryGetStorageSize = "SELECT StorageSize FROM Parameters";
            SqlCommand cmdGetStorageSize = new SqlCommand(queryGetStorageSize, connection);
            storageSize = Int32.Parse(cmdGetStorageSize.ExecuteScalar().ToString());


            connection.Close();
            BufferSize = storageSize;
            BufferEmptyPlaces = storageSize;

            var producerTask = Task.Run(() => Produce(Buffer, 1));
            var producerTask1 = Task.Run(() => Produce(Buffer, 2));
            var producerTask2 = Task.Run(() => Produce(Buffer, 3));
            var consumeTask = Task.Run(() => Consume(Buffer));



            return null;
        }
    }
}
