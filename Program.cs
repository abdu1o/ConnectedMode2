using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedMode2
{
    internal class Program
    {
        private static string conn = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        static void Main(string[] args)
        {

            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = null;

                    while (true)
                    {
                        Console.WriteLine("[1] - New product\n" +
                            "[2] - New supplier\n" +
                            "[3] - New type\n" +
                            "[4] - Update product\n" +
                            "[5] - Update supplier\n" +
                            "[6] - Update type\n" +
                            "[7] - Delete product\n" +
                            "[8] - Delete supplier\n" +
                            "[9] - Delete type\n");

                        int choice;
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                command = new SqlCommand("INSERT INTO Product (name, type_id, supplier_id, count) VALUES (@Name, @TypeID, @SupplierID, @Count)", connection);
                                Console.Write("Enter the product name: ");
                                string name = Console.ReadLine();
                                command.Parameters.AddWithValue("@Name", $"{name}");

                                Console.Write("Enter the type id: ");
                                int type = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.AddWithValue("@TypeID", $"{type}");

                                Console.Write("Enter the supplier id: ");
                                int supplier = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.AddWithValue("@SupplierID", $"{supplier}");

                                Console.Write("Enter the supplier id: ");
                                int count = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.AddWithValue("@Count", $"{count}");
                                break;

                            case 2:
                                command = new SqlCommand("INSERT INTO Supplier (name) VALUES (@Name)", connection);
                                Console.Write("Enter the product name: ");
                                string spname = Console.ReadLine();
                                command.Parameters.AddWithValue("@Name", $"{spname}");

                                break;

                            case 3:
                                command = new SqlCommand("INSERT INTO Type (name) VALUES (@Name)", connection);
                                Console.Write("Enter the product name: ");
                                string typename = Console.ReadLine();
                                command.Parameters.AddWithValue("@Name", $"{typename}");

                                break;

                            case 4:
                                command = new SqlCommand("UPDATE Product SET name = @Name, type_id = @TypeID, supplier_id = @SupplierID, count = @Count WHERE id = @ID", connection);
                                Console.Write("Enter the product id: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.AddWithValue("@ID", $"{id}");

                                Console.Write("Enter new product name: ");
                                name = Console.ReadLine();
                                command.Parameters.AddWithValue("@Name", $"{name}");

                                Console.Write("Enter new type id: ");
                                type = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.AddWithValue("@TypeID", $"{type}");

                                Console.Write("Enter new supplier id: ");
                                supplier = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.AddWithValue("@SupplierID", $"{supplier}");

                                Console.Write("Enter new count: ");
                                count = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.AddWithValue("@Count", $"{count}");
                                break;

                            case 5:
                                command = new SqlCommand("UPDATE Supplier SET name = @Name WHERE id = @ID", connection);
                                Console.Write("Enter the supplier id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.AddWithValue("@ID", $"{id}");

                                Console.Write("Enter new supplier name: ");
                                name = Console.ReadLine();
                                command.Parameters.AddWithValue("@Name", $"{name}");
                                break;

                            case 6:
                                command = new SqlCommand("UPDATE Type SET name = @Name WHERE id = @ID", connection);
                                Console.Write("Enter the supplier id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.AddWithValue("@ID", $"{id}");

                                Console.Write("Enter new supplier name: ");
                                name = Console.ReadLine();
                                command.Parameters.AddWithValue("@Name", $"{name}");
                                break;

                            case 7:
                                command = new SqlCommand("DELETE FROM Product WHERE id = @ID", connection);
                                Console.Write("Enter the supplier id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.AddWithValue("@ID", $"{id}");
                                break;

                            case 8:
                                command = new SqlCommand("DELETE FROM Supplier WHERE id = @ID", connection);
                                Console.Write("Enter the supplier id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.AddWithValue("@ID", $"{id}");
                                break;

                            case 9:
                                command = new SqlCommand("DELETE FROM Type WHERE id = @ID", connection);
                                Console.Write("Enter the supplier id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.AddWithValue("@ID", $"{id}");
                                break;
                        }
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
