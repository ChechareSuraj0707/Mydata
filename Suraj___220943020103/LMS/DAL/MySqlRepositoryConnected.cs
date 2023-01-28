namespace DAL;
using BOL;
using System.Data;
using MySql.Data.MySqlClient; 


public static class MySqlRepository{

     public static string conString=@"server=localhost;port=3306;user=root;password=root;database=transflower"; 
   
   
   
      public static bool LoginCheck (string email,string password)
      {
        Console.WriteLine(email);
        Console.WriteLine(password);
         
         bool status=false;
       
        string query="select * from employees where email=@email and password=@password";
        
        MySqlConnection con=new MySqlConnection(conString);
      
        

        try{
            
            con.Open();
            MySqlCommand cmd=new MySqlCommand();
            cmd.Connection=con;
            cmd.CommandText=query;
            cmd.Parameters.AddWithValue("@email",email);
            cmd.Parameters.AddWithValue("@password",password);
            
        
    
            MySqlDataReader reader=cmd.ExecuteReader();
           
            if (reader.Read())
            {
                string name=reader["firstName"].ToString();
               
                status=true;

            }
            else{
                Console.WriteLine("false");
            }
        
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
         
      }
      finally{
      con.Close();
      }
     
   
     return status;
   
      }
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
    public static List<Product> GetAll(){
        List<Product> products=new List<Product>();
        //database connectivity Code
        string query="SELECT * FROM products";
        //Connected data Access
        IDbConnection con=new MySqlConnection();
        con.ConnectionString=conString;
        IDbCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        try{
            con.Open();
            IDataReader reader=cmd.ExecuteReader();
            while(reader.Read()){
                string id=reader["productCode"].ToString();
                string title=reader["productName"].ToString();
                string description=reader["productDescription"].ToString();
                int stockAvailable=int.Parse(reader["quantityInStock"].ToString());
                double unitPrice=double.Parse(reader["buyPrice"].ToString());
                string category=reader["productLine"].ToString();
                Product product=new Product{
                    ProductId=id,
                    Title=title,
                    Description=description,
                    UnitPrice=unitPrice,
                    Category=category,
                    StockAvailable=stockAvailable,
                    ImageUrl="/images/nano.jpg"
                };
                products.Add(product);
            }

        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally{
            con.Close();
        }
        return products;
    }
}
