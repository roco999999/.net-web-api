/*
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase 
    {

        
        [HttpPost]
        public Response Add(int id,double x, double y)
        {
            var connectionString = "Host=localhost;Port=5432;Database=dbstuden;Username=postgres;Password=riften06";
            var sql = "INSERT INTO doors (id, x, y) VALUES (@id, @x, @y)";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("x", x);
                    command.Parameters.AddWithValue("y", y);
                    command.ExecuteNonQuery();
                }
            }

            var door = new Door
            {
                Id = id,
                X = x,
                Y = y
            };

            return new Response("Eleman eklendi.", door);
        }
        

        [HttpPost]  // auto-increment
        public Response Add( double x, double y)
        {
            var connectionString = "Host=localhost;Port=5432;Database=dbstuden;Username=postgres;Password=riften06";
            var sql = "INSERT INTO doors (x, y) VALUES (@x, @y) RETURNING id";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("x", x);
                    command.Parameters.AddWithValue("y", y);
                    var id = (int)command.ExecuteScalar();

                    var door = new Door
                    {
                        Id = id,
                        X = x,
                        Y = y
                    };

                    return new Response("Eleman eklendi.", door);
                }
            }
        }

        [HttpDelete("Id")]
        public Response Delete(int id)
        {
            var connectionString = "Host=localhost;Port=5432;Database=dbstuden;Username=postgres;Password=riften06";
            var sql = "DELETE FROM doors WHERE Id = @id";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();
                }
            }
            return new Response("Eleman silindi.", null);
        }


        [HttpPut("Id")]
        public Response Update(int id, double? x = null, double? y = null)
        {
            var connectionString = "Host=localhost;Port=5432;Database=dbstuden;Username=postgres;Password=riften06";
            var sql = "UPDATE doors SET ";

            if (x.HasValue)
            {
                sql += "X = @x, ";
            }

            if (y.HasValue)
            {
                sql += "Y = @y, ";
            }

            // Remove the trailing comma and space
            sql = sql.TrimEnd(',', ' ');

            sql += " WHERE Id = @id";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("id", id);

                    if (x.HasValue)
                    {
                        command.Parameters.AddWithValue("x", x.Value);
                    }

                    if (y.HasValue)
                    {
                        command.Parameters.AddWithValue("y", y.Value);
                    }
                    

                    command.ExecuteNonQuery();
                }
            }
            return new Response("Eleman güncellendi.", null);
        }

        [HttpGet("Id")]
        public Response Read(int id)
        {
            var connectionString = "Host=localhost;Port=5432;Database=dbstuden;Username=postgres;Password=riften06";
            var sql = "SELECT * FROM doors WHERE Id = @id";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var door = new Door
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                X = Convert.ToDouble(reader["X"]),
                                Y = Convert.ToDouble(reader["Y"])
                            };

                            return new Response("Veri bulundu.", door);
                        }
                    }
                }
            }

            return new Response("Veri bulunamadı.", null);
        }



        [HttpGet]
        public List<Door> GetAll()
        {
            var connectionString = "Host=localhost;Port=5432;Database=dbstuden;Username=postgres;Password=riften06";
            var sql = "SELECT * FROM doors";

            var doors = new List<Door>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = Convert.ToInt32(reader["Id"]);
                            var x = Convert.ToDouble(reader["X"]);
                            var y = Convert.ToDouble(reader["Y"]);

                            var door = new Door
                            {
                                Id = id,
                                X = x,
                                Y = y
                            };

                            doors.Add(door);
                        }
                    }
                }
            }

            return doors;
        }

    }
}
*/